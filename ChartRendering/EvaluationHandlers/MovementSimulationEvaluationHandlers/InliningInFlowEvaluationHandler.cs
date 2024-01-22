using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Constants;
using ChartRendering.Events;
using ChartRendering.Models;
using EvaluationKernel;
using EvaluationKernel.Equations;
using EvaluationKernel.Models;

namespace ChartRendering.EvaluationHandlers.MovementSimulationEvaluationHandlers;

public class InliningInFlowEvaluationHandler : EvaluationHandler
{
	protected override void Evaluate(object parameters)
	{
		var p = (Parameters) parameters;
		var modelParameters = p.ModelParameters;
		var modeSettings = (InliningInFlowModeSettingsModel) p.ModeSettings;

		var r = new RungeKuttaMethod(modelParameters, new Equation(modelParameters));
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

		StartExecution();
		while (true)
		{
			lock (LockObject)
			{
				if (IsPaused)
				{
					Thread.Sleep(1000);
					continue;
				}
			}

			for (var i = 0; i < n; i++)
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

			var isInliningAvailable = IsInliningAvailable(modelParameters, n, x, y, out var index);
			if (flag && isInliningAvailable)
			{
				modelParameters = ExtendModelParameters(modelParameters, modeSettings, index, x, y);
				n = modelParameters.n;

				xp = xp.Take(index).Concat(new[] {0.0}).Concat(xp.Skip(index)).ToArray();
				yp = yp.Take(index).Concat(new[] {0.0}).Concat(yp.Skip(index)).ToArray();
				x = x.Take(index).Concat(new[] {0.0}).Concat(x.Skip(index)).ToArray();
				y = y.Take(index).Concat(new[] {0.0}).Concat(y.Skip(index)).ToArray();

				var time = r.T;
				r = new RungeKuttaMethod(modelParameters, new Equation(modelParameters));
				r.T = time;
				flag = false;

				p.ChartEventHandler.Invoke(
					new List<ChartEventActions>
					{
						ChartEventActions.AddChartSeries
					},
					new AddChartEventHandlerArgs(modelParameters, index));

				p.ChartEventHandler.Invoke(
					new List<ChartEventActions>
					{
						ChartEventActions.UpdateCharts
					},
					new ChartEventHandlerArgs(new CoordinatesArgs
					{
						T = t,
						X = x.ToList(),
						Y = y.ToList()
					}));
			}

			if (t - tp > 0.1)
			{
				tp = t;

				p.ChartEventHandler.Invoke(
					new List<ChartEventActions>
					{
						ChartEventActions.UpdateCharts
					},
					new ChartEventHandlerArgs(new CoordinatesArgs
					{
						T = t,
						X = x.ToList(),
						Y = y.ToList()
					}));
			}
		}
	}

	private ModelParameters ExtendModelParameters(ModelParameters modelParameters, InliningInFlowModeSettingsModel modeSettings, int index, IEnumerable<double> lambda, IEnumerable<double> Vn)
	{
		modelParameters.n++;
		modelParameters.a.Insert(index, modeSettings.a);
		modelParameters.q.Insert(index, modeSettings.q);
		modelParameters.lSafe.Insert(index, modeSettings.l_safe);
		modelParameters.lCar.Insert(index, modeSettings.l_car);
		modelParameters.Vmax.Insert(index, modeSettings.Vmax);
		modelParameters.k.Insert(index, modeSettings.k);

		modelParameters.lambda = lambda.ToList();
		modelParameters.Vn = Vn.ToList();
		modelParameters.lambda.Insert(index, 0);
		modelParameters.Vn.Insert(index, 0);

		return modelParameters;
	}

	private bool IsInliningAvailable(ModelParameters modelParameters, int n, IReadOnlyList<double> x, IReadOnlyList<double> v, out int inline)
	{
		for (var i = 0; i < n; i++)
		{
			if (x[i] > 0)
				continue;
			inline = i;

			var s = modelParameters.k[i] * (x[i] + Equation.S(modelParameters, i, v[i]) + modelParameters.tau * v[i]);

			if (s + x[i] < 0)
				return true;
			return false;
		}

		inline = n;
		return true;
	}
}