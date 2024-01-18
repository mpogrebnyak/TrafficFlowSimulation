using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Constants;
using ChartRendering.Events;
using ChartRendering.Models;
using EvaluationKernel;
using EvaluationKernel.Equations.SpecializedEquations;

namespace ChartRendering.EvaluationHandlers.MovementSimulationEvaluationHandlers;

public class MovementThroughOneTrafficLightEvaluationHandler : EvaluationHandler
{
	protected override void Evaluate(object parameters)
	{
		var p = (Parameters) parameters;
		var modelParameters = p.ModelParameters;
		var modeSettings = (MovementThroughOneTrafficLightModeSettingsModel)p.ModeSettings;

		var r = new RungeKuttaMethod(modelParameters, new EquationWithStop(modelParameters));
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

		bool isGreenLight = true;
		var circleTime = modeSettings.SingleLightGreenTime + modeSettings.SingleLightRedTime;
		bool isCarToStopNotFound = true;
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

			for (int i = 0; i < n; i++)
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

				if (isGreenLight)
				{
					if (!isCarToStopNotFound)
					{
						r.SetCarNumberToStop(new List<int>());
						isCarToStopNotFound = true;
					}
				}
				else
				{
					if (x[i] < 0 && isCarToStopNotFound)
					{
						r.SetCarNumberToStop(new List<int> {i});
						isCarToStopNotFound = false;
					}
				}
			}

			isGreenLight = t % circleTime < modeSettings.SingleLightGreenTime;

			if (t - tp > 0.1)
			{
				tp = t;

				p.ChartEventHandler.Invoke(
					new List<ChartEventActions>
					{
						ChartEventActions.UpdateCharts,
						ChartEventActions.UpdateChartEnvironments
					},
					new ChartEventHandlerArgs(new CoordinatesArgs
					{
						T = t,
						X = x.ToList(),
						Y = y.ToList()
					},
					new EnvironmentArgs
					{
						IsGreenLight = isGreenLight,
						GreenTime = modeSettings.SingleLightGreenTime - t % circleTime,
						RedTime = circleTime - t % circleTime
					}));
			}
		}
	}
}