using System.Collections.Generic;
using System.Linq;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Constants;
using ChartRendering.Events;
using ChartRendering.Models;
using Common;
using EvaluationKernel;
using EvaluationKernel.Equations.SpecializedEquations;
using EvaluationKernel.Models;

namespace ChartRendering.EvaluationHandlers.ParametersSelectionEvaluationHandlers;

public class DecelerationCoefficientEstimationSelectionEvaluationHandler : EvaluationHandler
{
	protected override void Evaluate(object parameters)
	{
		var p = (Parameters) parameters;
		var modelParameters = p.ModelParameters;

		if (modelParameters.n != 1)
			return;

		var settings = (DecelerationCoefficientEstimationSettingsModel) p.ModeSettings;

		var cm = new List<CoefficientEstimationCoordinatesModel>();
		double? optimalQ = null;

		var step = 0.0001;
		for (var q = 0.0; q <= settings.MaxQ; q += step)
		{
			var mp = (ModelParameters) modelParameters.Clone();
			mp.q = new List<double> {q};

			var coordinatesModel = EvaluateInternal(mp);
			cm.Add(coordinatesModel);

			if (coordinatesModel.Color == CustomColors.BrightRed.Name)
			{
				optimalQ = q;
			}
		}

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
				new DecelerationCoefficientEnvironmentArgs
				{
					OptimalQ = optimalQ,
				}));

		if (settings.IsSaveChart.Value.Equals(SaveChart.Yes))
		{
			p.ChartEventHandler.Invoke(
				new List<ChartEventActions>
				{
					ChartEventActions.SaveChart
				}, new SaveChartEventHandlerArgs(CreateFileName(modelParameters)));
		}
	}

	private CoefficientEstimationCoordinatesModel EvaluateInternal(ModelParameters modelParameters)
	{
		var r = new RungeKuttaMethod(modelParameters, new SingleCarDecelerationEquation(modelParameters));
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

		var tStop = modelParameters.Vn[0] / (modelParameters.g * modelParameters.mu);
		var minSpeed = 0.01;
		while (modelParameters.L > x[0] && t < 2 * tStop && y[0] > minSpeed)
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
			X = modelParameters.q[0],
			Y = y[0],
			Color =  y[0] < minSpeed
				? CustomColors.Green.Name
				: CustomColors.BrightRed.Name
		};
	}

	private static string CreateFileName(ModelParameters modelParameters)
	{
		var parameters = new Dictionary<string, double>
		{
			{"q", modelParameters.q[0]}
		};

		return CommonFileHelper.CreateFileName("Q_Estimation", parameters);
	}
}