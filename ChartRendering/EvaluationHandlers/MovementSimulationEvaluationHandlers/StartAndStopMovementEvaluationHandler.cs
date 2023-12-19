using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ChartRendering.Constants;
using ChartRendering.Events;
using ChartRendering.Models;
using EvaluationKernel;
using EvaluationKernel.Equations;

namespace ChartRendering.EvaluationHandlers.MovementSimulationEvaluationHandlers;

public class StartAndStopMovementEvaluationHandler : EvaluationHandler
{
	protected override void Evaluate(object parameters)
	{
		var p = (Parameters) parameters;
		var modelParameters = p.ModelParameters;

		var r = new RungeKuttaMethod(modelParameters, new MainEquation(modelParameters));
		var n = modelParameters.n;

		var xp = new double[n];
		var yp = new double[n];
		var t = r.T.Last();
		var tp = t;
		var x = new double[n];
		var y = new double[n];
		for (var i = 0; i < n; i++)
		{
			x[i] = r.X(i).Last();
			y[i] = r.Y(i).Last();
		}

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

			for (var i = 0; i < n; i++)
			{
				xp[i] = x[i];
				yp[i] = y[i];
			}

			r.Solve();
			t = r.T.Last();
			for (var i = 0; i < n; i++)
			{
				x[i] = r.X(i).Last();
				y[i] = r.Y(i).Last();
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
}