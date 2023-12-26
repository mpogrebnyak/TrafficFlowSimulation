using System;
using System.Collections.Generic;
using System.Linq;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Constants;
using ChartRendering.Events;
using ChartRendering.Models;
using EvaluationKernel;
using EvaluationKernel.Equations.SpecializedEquations;
using EvaluationKernel.Models;

namespace ChartRendering.EvaluationHandlers.ParametersSelectionEvaluationHandlers;

public class AccelerationCoefficientEstimationSelectionEvaluationHandler : EvaluationHandler
{
	protected override void Evaluate(object parameters)
	{
		var p = (Parameters) parameters;
		var modelParameters = p.ModelParameters;

		if (modelParameters.n != 1)
			return;

		var settings = (AccelerationCoefficientEstimationSettingsModel) p.ModeSettings;

		var cm = new List<CoefficientEstimationCoordinatesModel>();

		double? maxAValue = null;
		double? minAValue = null;

		var step = 0.001;
		for (var a = 0.1; a <= settings.MaxA; a += step)
		{
			var previousCoordinatesModel = cm.LastOrDefault();

			var mp = (ModelParameters)modelParameters.Clone();
			mp.a = new List<double> {a};

			var coordinatesModel = EvaluateInternal(mp, settings);
			cm.Add(coordinatesModel);

			if (previousCoordinatesModel != null && previousCoordinatesModel.Color != coordinatesModel.Color)
			{
				maxAValue = minAValue.HasValue && !maxAValue.HasValue
					? coordinatesModel.X
					: null;
				minAValue ??= coordinatesModel.X;
			}
		}

		//AccelerationCoefficientEstimationSelectionEvaluationHelper.GenerateCharts(modelParameters, cm, em); 

		p.ChartEventHandler.Invoke(
			new List<ChartEventActions>
			{
				ChartEventActions.UpdateCharts,
				ChartEventActions.UpdateChartEnvironments
			},
			new ChartEventHandlerArgs(new CoefficientEstimationCoordinatesArgs
				{
					X = cm.Select(x => x.X).ToList(),
					Y = cm.Select(x => x.Y).ToList(),
					Color = cm.Select(x => x.Color).ToList(),
				},
				new AccelerationCoefficientEnvironmentArgs
				{
					MaxAValue = maxAValue,
					MinAValue = minAValue
				}));
	}

	private CoefficientEstimationCoordinatesModel EvaluateInternal(ModelParameters modelParameters, AccelerationCoefficientEstimationSettingsModel modeSettings)
	{
		var r = new RungeKuttaMethod(modelParameters, new SingleCarAccelerationEquation(modelParameters));
		var n = modelParameters.n;

		var xp = new double[n];
		var yp = new double[n];
		var t = r.T.Last();
		var x = new double[n];
		var y = new double[n];
		for (var i = 0; i < n; i++)
		{
			x[i] = r.X(i).Last();
			y[i] = r.Y(i).Last();
		}

		// погрешность, необходимая для вычисления
		var eps = 0.5;
		while (y[0] <= Math.Floor(modelParameters.Vmax[0]) + eps)
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
			t = r.T.Last();
		}

		return new CoefficientEstimationCoordinatesModel
		{
			X = modelParameters.a[0],
			Y = t,
			Color = t >= modeSettings.MinTime && t <= modeSettings.MaxTime
				? CustomColors.Green.Name
				: CustomColors.BrightRed.Name
		};
	}

	private class CoefficientEstimationCoordinatesModel
	{
		public double X { get; set; }

		public double Y { get; set; }

		public string Color { get; set; }
	}
}