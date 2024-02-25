using System;
using System.Collections.Generic;
using System.Linq;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Constants;
using ChartRendering.Events;
using ChartRendering.Helpers;
using ChartRendering.Models;
using Common;
using EvaluationKernel;
using EvaluationKernel.Equations;
using EvaluationKernel.Models;

namespace ChartRendering.EvaluationHandlers.ParametersSelectionEvaluationHandlers;

public class InliningDistanceEstimationSelectionEvaluationHandler : EvaluationHandler
{
	protected override void Evaluate(object parameters)
	{
		var p = (Parameters) parameters;
		var modelParameters = p.ModelParameters;

		if (modelParameters.n != 2)
			return;

		var settings = (InliningDistanceEstimationSettingsModel) p.ModeSettings;
		modelParameters.k = new List<double> {settings.k, settings.k};

		p.ChartEventHandler.Invoke(new List<ChartEventActions> { ChartEventActions.DisplayExecution }, null);

		var fileName = CreateFileName(modelParameters);
		var allCoordinatesModel = TryGetLastValue(settings, fileName, out var initialSpace);

		if (allCoordinatesModel.Any())
		{
			p.ChartEventHandler.Invoke(
				new List<ChartEventActions>
				{
					ChartEventActions.UpdateCharts,
					ChartEventActions.UpdateChartEnvironments,
				},
				new ChartEventHandlerArgs(new CoefficientEstimationCoordinatesArgs
				{
					X = allCoordinatesModel.Select(x => x.X).ToList(),
					Y = allCoordinatesModel.Select(x => x.Y).ToList(),
					Color = allCoordinatesModel.Select(x => x.Color).ToList(),
				}));
		}

		const double step = 0.1;
		for (var space = initialSpace + step; space <= settings.MaximumDistanceBetweenCars; space += step)
		{
			var cm = EvaluateInternal((ModelParameters) modelParameters.Clone(), space, step);
			allCoordinatesModel.AddRange(cm);

			p.ChartEventHandler.Invoke(
				new List<ChartEventActions>
				{
					ChartEventActions.UpdateCharts,
					ChartEventActions.UpdateChartEnvironments,
				},
				new ChartEventHandlerArgs(new CoefficientEstimationCoordinatesArgs
				{
					X = cm.Select(x => x.X).ToList(),
					Y = cm.Select(x => x.Y).ToList(),
					Color = cm.Select(x => x.Color).ToList(),
				}));

			p.ChartEventHandler.Invoke(
				new List<ChartEventActions>
				{
					ChartEventActions.SaveChartPoints
				},
				new ChartEventHandlerWithSavingArgs(
					fileName,
					new SerializerPointsModel
					{
						Name = fileName,
						ModelParameters = modelParameters,
						ModeSettings = settings,
						CoordinatesModel = allCoordinatesModel,
						LastValue = space
					}));

			if (settings.IsSaveChart.Value.Equals(SaveChart.Yes))
			{
				p.ChartEventHandler.Invoke(
					new List<ChartEventActions>
					{
						ChartEventActions.SaveChart
					}, new SaveChartEventHandlerArgs(fileName));
			}
		}

		p.ChartEventHandler.Invoke(new List<ChartEventActions> { ChartEventActions.DisplayExecution }, null);
	}

	protected override void EvaluatePreCalculated(object parameters)
	{
		var p = (Parameters) parameters;
		var modelParameters = p.ModelParameters;
		var preCalculatedParameters = (List<CoefficientEstimationCoordinatesModel>) p.PreCalculatedParameters;

		p.ChartEventHandler.Invoke(
			new List<ChartEventActions>
			{
				ChartEventActions.UpdateCharts,
				ChartEventActions.UpdateChartEnvironments,
			},
			new ChartEventHandlerArgs(new CoefficientEstimationCoordinatesArgs
			{
				X = preCalculatedParameters.Select(x => x.X).ToList(),
				Y = preCalculatedParameters.Select(x => x.Y).ToList(),
				Color = preCalculatedParameters.Select(x => x.Color).ToList(),
			}));
		
		p.ChartEventHandler.Invoke(
			new List<ChartEventActions>
			{
				ChartEventActions.SaveChart
			}, new SaveChartEventHandlerArgs(CreateFileName(modelParameters)));
	}

	private List<CoefficientEstimationCoordinatesModel> EvaluateInternal(ModelParameters modelParameters, double space,
		double step)
	{
		var min = 0;
		var max = Math.Floor(modelParameters.Vmax[1]) + 1;


		var cm = new List<CoefficientEstimationCoordinatesModel>();

		if (space <= modelParameters.lCar[0] + modelParameters.lSafe[1])
		{
			for (var i = max; i >= min; i -= step)
			{
				cm.Add(PrepareCoordinates(i, space, i, -1));
			}

			return cm;
		}

		var topSolution = IsDecelerate(modelParameters, space, max);
		if (topSolution.IsDeceleration == false)
		{
			cm.Add(new CoefficientEstimationCoordinatesModel { X = max, Y = space, Color = CustomColors.Black.Name });
			for (var i = max; i >= min; i -= step)
			{
				cm.Add(PrepareCoordinates(i, space, i, 0));
			}
			cm.Add(new CoefficientEstimationCoordinatesModel { X = max, Y = space, Color = CustomColors.Black.Name });

			return cm;
		}

		cm.Add(PrepareCoordinates(max, space, max, topSolution.Intensity));
		cm.Add(PrepareCoordinates(max, space, min, 0));

		for (var i = max - step; i >= min + step; i -= step)
		{
			if (i < step)
				i = 0;

			var solution = IsDecelerate(modelParameters, space, i);
			cm.Add(PrepareCoordinates(i, space, i, solution.Intensity));

			if (!solution.IsDeceleration)
			{
				cm.Add(new CoefficientEstimationCoordinatesModel { X = cm.Last().X, Y = cm.Last().Y, Color = CustomColors.Black.Name });

				for (var j = i - step; j >= min + step; j -= step)
				{
					cm.Add(PrepareCoordinates(i, space, j, 0));

				}

				return cm;
			}
		}

		if (cm.Any(x => x.Color == CustomColors.Black.Name) == false)
		{
			cm.Add(new CoefficientEstimationCoordinatesModel {X = cm.Last().X, Y = cm.Last().Y, Color = CustomColors.Black.Name});
		}

		return cm;
	}

	private DecelerationEvaluation IsDecelerate(ModelParameters modelParameters, double space, double speed)
	{
		var r = new RungeKuttaMethod(modelParameters, new Equation(modelParameters));
		r.SetInitialConditions(
			new List<double> {modelParameters.Vn[0], speed},
			new List<double> {modelParameters.lambda[0], -space});

		var n = modelParameters.n;

		var xp = new double[n];
		var yp = new double[n];
		var x = new double[n];
		var y = new double[n];
		for (var i = 0; i < n; i++)
		{
			x[i] = r.X(i).Last();
			y[i] = r.Y(i).Last();
		}

		var localMax = speed;
		double localMin = 0;
		double diff = 0;
		var isDeceleration = false;

		while (true)
		{
			for (var i = 0; i < n; i++)
			{
				xp[i] = x[i];
				yp[i] = y[i];
			}

			r.Solve();

			for (var i = 0; i < n; i++)
			{
				x[i] = r.X(i).Last();
				y[i] = r.Y(i).Last();
			}

			if (xp[1] > x[1] || 
				x[0] - x[1] < modelParameters.lCar[0] + modelParameters.lSafe[1] + 1 ||
				double.IsNaN(x[1]) ||
				double.IsNaN(y[1]))
			{
				return new DecelerationEvaluation
				{
					IsDeceleration = true,
					Intensity = -1
				};
			}

			if (y[1] > yp[1] && y[1] - yp[1] > 0.0001)
			{
				if (isDeceleration)
				{
					diff = Math.Max(diff, localMax - localMin);
					if (diff > speed)
						diff = speed;
					isDeceleration = false;
				}

				localMax = y[1];
			}
			else
			{
				localMin = y[1];
				isDeceleration = true;
			}

			const double eps = 0.1;
			if (modelParameters.Vmax[0] - y[0] < eps && modelParameters.Vmax[1] - y[1] < eps)
			{
				return new DecelerationEvaluation
				{
					IsDeceleration = diff > eps,
					Intensity = diff > eps
						? diff
						: 0
				};
			}

		}
	}

	private static CoefficientEstimationCoordinatesModel PrepareCoordinates(double maxSpeed, double x, double y, double intensity)
	{
		var intensityInPercentage = 0.0;
		if (maxSpeed != 0)
		{
			maxSpeed = maxSpeed > 4
				? maxSpeed
				: 4;
			// на сколько процентов скорость снижения отличается от максимальной
			// 100 минус разница между числами в процентах
			intensityInPercentage = intensity <= 0
				? intensity
				: 100 - (int) ((Math.Abs(intensity - maxSpeed)) / maxSpeed * 100);
		}

		return new CoefficientEstimationCoordinatesModel
		{
			X = x,
			Y = y,
			Color = InliningDistanceEstimationSelectionEvaluationRenderingHelper.GetColor(intensityInPercentage),
		};
	}

	private static string CreateFileName(ModelParameters modelParameters)
	{
		var parameters = new Dictionary<string, double>
		{
			{"k", modelParameters.k[1]}
		};

		return CommonFileHelper.CreateFileName("FullFIll", parameters);
	}

	private static List<CoefficientEstimationCoordinatesModel> TryGetLastValue(InliningDistanceEstimationSettingsModel settings, string fileName, out double lastValue)
	{
		if (settings.IsContinueEvaluate.Value.Equals(ContinueEvaluate.No))
		{
			lastValue = 0;
			return new List<CoefficientEstimationCoordinatesModel>();
		}

		var path = CommonFileHelper.CreateFilePath(fileName, null, CommonFileHelper.Extension.Txt);

		try
		{
			var pointsModel = SerializerPointsHelper.DeserializePoints(path);
			lastValue = pointsModel.LastValue;
			return pointsModel.CoordinatesModel;
		}
		catch
		{
			lastValue = 0;
		}

		return new List<CoefficientEstimationCoordinatesModel>();
	}

	private class DecelerationEvaluation
	{
		public bool IsDeceleration { get; set; }

		public double Intensity { get; set; }
	}
}