using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EvaluationKernel;
using EvaluationKernel.Equations;
using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Models.ParametersSelectionSettingsModels;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders.Models;

namespace TrafficFlowSimulation.Handlers.EvaluationHandlers.ParametersSelectionEvaluationHandlers;

public class InliningDistanceEstimationSelectionEvaluationHandler : EvaluationHandler
{
	protected override void Evaluate(object parameters)
	{
		var p = (Parameters) parameters;
		var modelParameters = p.ModelParameters;
		var settings = (InliningDistanceEstimationSettingsModel) p.ModeSettings;

		if (modelParameters.n != 2)
			return;

		var progressBar = CreateProgressBar(p);

		var cm = new List<InliningDistanceEstimationCoordinatesModel>();

		for (double space = 0; space <= settings.MaximumDistanceBetweenCars; space+=0.1)
		{
			for (double speed = 0; speed <= modelParameters.Vmax[1]; speed+=0.1)
			{
				modelParameters.Vn[1] = speed;
				modelParameters.lambda[1] = -space;

				var isDecelerate = IsDecelerate(modelParameters);

				cm.Add(new InliningDistanceEstimationCoordinatesModel
				{
					x = space,
					y = speed,
					color = isDecelerate ? PointColor.Red : PointColor.Green
				});
			}

			if (progressBar != null)
			{
				void ProgressBarAction()
				{
					progressBar.Value = (int) space;
				}

				p.Form.Invoke((MethodInvoker) ProgressBarAction);
			}
		}

		MethodInvoker action = delegate
		{
			ServiceLocator.Current.GetInstance<ParametersSelectionRenderingHandler>().UpdateChart(cm);
		};

		p.Form.Invoke(action);
	}

	private bool IsDecelerate(ModelParameters modelParameters)
	{
		// Если расстояние меньше расстояния останоки, то заведомо придется тормозить
		var s = System.Math.Pow(modelParameters.Vn[1], 2) / 
				(2 * modelParameters.g * modelParameters.mu) + modelParameters.l[1];
		if (System.Math.Abs(modelParameters.lambda[1]) <= modelParameters.l[0]
				|| s >= modelParameters.lambda[0] - modelParameters.lambda[1])
		{
			return true;
		}

		var r = new RungeKuttaMethod(modelParameters, new BaseEquation(modelParameters));
		var n = modelParameters.n;

		var xp = new double[n];
		var yp = new double[n];
		var t = r.T.Last();
		var tp = t;
		var x = new double[n];
		var y = new double[n];
		for (int i = 0; i < n; i++)
		{
			x[i] = r.X(i).Last();
			y[i] = r.Y(i).Last();
		}

		var eps = 0.00001;
		while (true)
		{
			for (int i = 0; i < n; i++)
			{
				xp[i] = x[i];
				yp[i] = y[i];
			}

			r.Solve();
			t = r.T.Last();
			for (int i = 0; i < n; i++)
			{
				x[i] = r.X(i).Last();
				y[i] = r.Y(i).Last();
			}

			if (t - tp > 0.01)
			{
				tp = t;

				if (yp[1] - y[1] > eps)
				{
					return true;
				}

				if (modelParameters.Vmax[0] - y[0] < eps && modelParameters.Vmax[1] - y[1] < eps)
				{
					return false;
				}
			}
		}
	}

	private ToolStripProgressBar? CreateProgressBar(Parameters p)
	{
		var progressBar = (p.Form.Controls
				.Find(ControlName.ParametersSelectionWindowControlName.ControlMenuStrip, true)
				.Single() as ToolStrip
			)?.Items
			.Find(ControlName.ParametersSelectionWindowControlName.ToolStripProgressBar, true)
			.Single() as ToolStripProgressBar;

		if (progressBar == null)
			return null;

		MethodInvoker action = delegate
		{
			progressBar.Minimum = 0;
			progressBar.Maximum = 60;
			progressBar.Value = 0; 
		};

		p.Form.Invoke(action);

		return progressBar;
	}
}