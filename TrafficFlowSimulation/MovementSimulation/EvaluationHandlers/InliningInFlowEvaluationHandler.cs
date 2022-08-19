using System.Linq;
using System.Threading;
using System.Windows.Forms;
using EvaluationKernel;
using EvaluationKernel.Equations;
using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers;

namespace TrafficFlowSimulation.MovementSimulation.EvaluationHandlers;

public class InliningInFlowEvaluationHandler : EvaluationHandler
{
	protected override void Evaluate(object parameters)
	{
		var p = (Parameters) parameters;
		var modelParameters = p.ModelParameters;

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

				var time = r.T;
				r = new RungeKuttaMethod(modelParameters, new BaseEquation(modelParameters));
				r.T = time;
				flag = false;

				MethodInvoker action = delegate
				{
					ServiceLocator.Current.GetInstance<RenderingHandler>().AddSeries(index);
					ServiceLocator.Current.GetInstance<RenderingHandler>().UpdateCharts(t, x, y);
					Application.DoEvents();
				};

				p.Form.Invoke(action);
			}

			if (t - tp > 0.01)
			{
				tp = t;
				MethodInvoker action = delegate
				{
					ServiceLocator.Current.GetInstance<RenderingHandler>().UpdateCharts(t, x, y);

					Thread.Sleep(20);
					Application.DoEvents();
				};

				p.Form.Invoke(action);
			}
		}
	}

	private ModelParameters ExtendModelParameters(ModelParameters modelParameters, int index, double[] lambda, double[] Vn)
	{
		modelParameters.n++;
		modelParameters.a.Insert(index, 4);
		modelParameters.q.Insert(index, 3);
		modelParameters.l.Insert(index, 5);
		modelParameters.Vmax.Insert(index, 16.7);
		modelParameters.k.Insert(index, 0.5);
		modelParameters.s.Insert(index, 20);

		modelParameters.lambda = lambda.ToList();
		modelParameters.Vn = Vn.ToList();
		modelParameters.lambda.Insert(index, 0);
		modelParameters.Vn.Insert(index, 0);

		return modelParameters;
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