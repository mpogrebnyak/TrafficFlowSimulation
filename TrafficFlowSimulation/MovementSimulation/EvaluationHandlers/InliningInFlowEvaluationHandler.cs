using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using EvaluationKernel;
using EvaluationKernel.Equations;
using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.Models.ModeSettingsModels;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Renders.MovementThroughOneTrafficLight;

namespace TrafficFlowSimulation.MovementSimulation.EvaluationHandlers;

public class InliningInFlowEvaluationHandler : EvaluationHandler
{
	protected override void Evaluate(object parameters)
	{
		var p = (Parameters) parameters;
		var modelParameters = p.ModelParameters;
		var modeSettings = (MovementThroughOneTrafficLightModeSettings) p.ModeSettings;
		modelParameters.L = 10000;

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

		bool flag = true;
		//bool isGreenLight = true;
		//var circleTime = modeSettings.TrafficLight.GreenSignalTime + modeSettings.TrafficLight.RedSignalTime;
		//bool isCarToStopNotFound = true;
		StartExecution();
		while (true)
		{
			lock (_lockObject)
			{
				if (_isPaused)
				{
					Thread.Sleep(1000);
					continue;
				}
			}

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

			var isInliningAvaliable = IsInliningAvaliable(modelParameters, n, x, y, out var index);
			if (flag && isInliningAvaliable)
			{
				n = n + 1;
				modelParameters = ExtendModelParameters(modelParameters, index, x, y);

				var xpNew = xp.ToList();
				xpNew.Insert(index, 0);
				xp = xpNew.ToArray();

				var ypNew = yp.ToList();
				ypNew.Insert(index, 0);
				yp = ypNew.ToArray();

				var xNew = x.ToList();
				xNew.Insert(index, 0);
				x = xNew.ToArray();

				var yNew = y.ToList();
				yNew.Insert(index, 0);
				y = yNew.ToArray();

				r = new RungeKuttaMethod(modelParameters, new BaseEquation(modelParameters));
				r.T = new[] {tp}.ToList();
				flag = false;
			}
			//isGreenLight = t % circleTime < modeSettings.TrafficLight.GreenSignalTime;

			//if (t - tp > 0.1) 
			if (t - tp > 0.01)
			{
				tp = t;
				MethodInvoker action = delegate
				{
					ServiceLocator.Current.GetInstance<RenderingHandler>().UpdateCharts(t, x, y);
				//	ServiceLocator.Current.GetInstance<RenderingHandler>().UpdateChartEnvironments(
				//		new EnvironmentModel
				//		{
				//			IsGreenLight = isGreenLight,
				//			GreenTime = modeSettings.TrafficLight.GreenSignalTime - t % circleTime,
				//			RedTime = circleTime - t % circleTime
				//		});

					Thread.Sleep(20);
					Application.DoEvents();
				};

				p.Form.Invoke(action);
			}
		}
	}

	private ModelParameters ExtendModelParameters(ModelParameters modelParameters, int index, double[] lambda, double[] Vn)
	{
		var lambdaNew = lambda.ToList();
		lambdaNew.Insert(index, 0);

		var VnNew = Vn.ToList();
		VnNew.Insert(index, 0);

		return new ModelParameters
		{
			n = modelParameters.n + 1,
			a = modelParameters.a.Append(4).ToArray(),
			q = modelParameters.q.Append(3).ToArray(),
			l = modelParameters.l.Append(5).ToArray(),
			Vmax = modelParameters.Vmax.Append(16.7).ToArray(),
			k = modelParameters.k.Append(0.5).ToArray(),
			s = modelParameters.s.Append(20).ToArray(),

			tau = modelParameters.tau,
			eps = modelParameters.eps,
			g = modelParameters.g,
			mu = modelParameters.mu,
			L = modelParameters.L,
			Vmin = modelParameters.Vmin,

			lambda = lambdaNew.ToArray(),
			Vn = VnNew.ToArray(),
		};
	}

	private bool IsInliningAvaliable(ModelParameters modelParameters, int n, double[] x, double[] v, out int inline)
	{
		for (int i = 0; i < n; i++)
		{
			if (x[i] > 0)
				continue;
			inline = i;

			var s = System.Math.Pow(v[i], 2) / (2 * modelParameters.g * modelParameters.mu) + modelParameters.l[i];
			s = s + 5;

			if (s + x[i] < 0)
				return true;
			return false;
		}

		inline = n;
		return true;
	}
}