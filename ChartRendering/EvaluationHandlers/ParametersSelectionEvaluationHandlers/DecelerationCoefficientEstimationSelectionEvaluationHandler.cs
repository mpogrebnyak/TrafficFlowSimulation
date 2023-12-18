using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Constants;
using ChartRendering.Models;
using ChartRendering.Renders.ChartRenders.ParametersSelectionRenders;
using EvaluationKernel;
using EvaluationKernel.Equations.SpecializedEquations;
using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;
using Helper = ChartRendering.Helpers.DecelerationCoefficientEstimationSelectionEvaluationHelper;

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

		var cm = new List<DecelerationCoefficientEstimationCoordinatesModel>();
		var em = new DecelerationCoefficientEnvironmentModel();
		var tStop = modelParameters.Vn[0] / (modelParameters.g * modelParameters.mu);
		em.StopTime = tStop;

		var step = 0.02;
		for (var q = step; q <= settings.MaxQ; q += step)
		{
			var mp = (ModelParameters)modelParameters.Clone();
			mp.q = new List<double> {q};

			var coordinatesModel = EvaluateInternal(mp);

			if(coordinatesModel.IsCollapse)
				continue;

			if (coordinatesModel.Y >= tStop && !em.OptimalQ.HasValue)
			{
				em.OptimalQ = coordinatesModel.X;
				em.OptimalTime = coordinatesModel.Y;
				coordinatesModel.Color = CustomColors.Green.Name;
			}

			if (coordinatesModel.Y >= 2 * tStop && !em.DoubleOptimalQ.HasValue)
			{
				em.DoubleOptimalQ = coordinatesModel.X;
				em.DoubleOptimalTime = coordinatesModel.Y;
			}

			if (em.OptimalQ.HasValue)
			{
				cm.Add(coordinatesModel);
			}
		}

		Helper.GenerateCharts(modelParameters, cm, em); 

		MethodInvoker action = delegate
		{
			//ServiceLocator.Current.GetInstance<ParametersSelectionRenderingHandler>().UpdateChart(cm);
		//	ServiceLocator.Current.GetInstance<ParametersSelectionRenderingHandler>().UpdateChartEnvironments(em);
		};
	//	p.Form.Invoke(action);
	}

	private DecelerationCoefficientEstimationCoordinatesModel EvaluateInternal(ModelParameters modelParameters)
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

		while (y[0] >= 0.65)
		{
			if (modelParameters.L - x[0] < 0.001)
			{ 
				return new DecelerationCoefficientEstimationCoordinatesModel
				{
					IsCollapse = true
				};
			}

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

		if (y[0] < 0)
		{ 
			return new DecelerationCoefficientEstimationCoordinatesModel
			{
				IsCollapse = true
			};
		}

		return new DecelerationCoefficientEstimationCoordinatesModel
		{
			X = modelParameters.q[0],
			Y = t,
			Color = CustomColors.Black.Name,
			IsCollapse = false
		};
	}
}