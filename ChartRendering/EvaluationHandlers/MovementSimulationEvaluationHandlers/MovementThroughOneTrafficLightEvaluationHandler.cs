using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Handlers;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders.Models;
using EvaluationKernel;
using EvaluationKernel.Equations;
using EvaluationKernel.Equations.SpecializedEquations;
using Microsoft.Practices.ServiceLocation;
using TrafficFlowSimulation.Models.ChartRenderModels.SettingsModels;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.MovementThroughOneTrafficLight;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.Models;

namespace TrafficFlowSimulation.Handlers.EvaluationHandlers.MovementSimulationEvaluationHandlers;

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

				if (isGreenLight)
				{
					if (!isCarToStopNotFound)
					{
						r.SetCarNumberToStop(new List<int> { });
						isCarToStopNotFound = true;
					}
				}
				else
				{
					//if (x[i] < modeSettings.TrafficLight.Position && isCarToStopNotFound)
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
				MethodInvoker action = delegate
				{
					ServiceLocator.Current.GetInstance<RenderingHandler>().UpdateCharts(
						new CoordinatesModel
						{
							t = t,
							x = x.ToList(),
							y = y.ToList()
						});
					ServiceLocator.Current.GetInstance<RenderingHandler>().UpdateChartEnvironments(
						new EnvironmentModel
						{
							IsGreenLight = isGreenLight,
							GreenTime = modeSettings.SingleLightGreenTime - t % circleTime,
							RedTime = circleTime - t % circleTime
						});

					Thread.Sleep(20);
					Application.DoEvents();
				};

				p.Form.Invoke(action);
			}
		}
	}
}