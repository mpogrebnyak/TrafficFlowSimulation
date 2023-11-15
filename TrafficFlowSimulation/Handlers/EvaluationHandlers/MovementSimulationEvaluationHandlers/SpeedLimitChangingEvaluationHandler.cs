using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using EvaluationKernel;
using EvaluationKernel.Equations;
using EvaluationKernel.Equations.SpecializedEquations;
using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;
using TrafficFlowSimulation.Models.SettingsModels;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.Models;

namespace TrafficFlowSimulation.Handlers.EvaluationHandlers.MovementSimulationEvaluationHandlers;

public class SpeedLimitChangingEvaluationHandler : EvaluationHandler
{
	protected override void Evaluate(object parameters)
	{
		var p = (Parameters) parameters;
		var modelParameters = p.ModelParameters;
		var modeSettings = (SpeedLimitChangingModeSettingsModel) p.ModeSettings;
		var segmentSpeeds = new SortedDictionary<int, SegmentModel>();
		segmentSpeeds.Add(0, new SegmentModel
			{
				SegmentBeginning = modelParameters.lambda.Last(),
				Speed = 16
			}
		);
		
		modeSettings.MapTo(segmentSpeeds);
		
		var r = new RungeKuttaMethod(modelParameters, new EquationWithSpeedLimitChanging(modelParameters, segmentSpeeds));
		var n = modelParameters.n;
		var initialSpeed = new double[n];
		modelParameters.Vmax.CopyTo(initialSpeed);

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

			var isChange = false;
			for (int i = 0; i < n; i++)
			{
				x[i] = r.X(i).Last();
				y[i] = r.Y(i).Last();
				
				if (x[i] >= modeSettings.SegmentBeginning && modelParameters.Vmax[i] != modeSettings.SpeedInSegment)
				{
					modelParameters.Vmax[i] = modeSettings.SpeedInSegment;
					isChange = true;
				}
				if (x[i] >= modeSettings.SegmentEnding && modelParameters.Vmax[i] == modeSettings.SpeedInSegment)
				{
					modelParameters.Vmax[i] = initialSpeed[i];
					isChange = true;
				}
			}

			if (isChange)
			{
				r.Equation = new MainEquation(modelParameters);
			}

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

					/*if (p.ModeSettings.AutoScroll == AutoScroll.Yes)
					{
						var scaleView = carsMovementChart.ChartAreas[0].AxisX.ScaleView;
						scaleView.Scroll(Math.Round(x[p.ModeSettings.ScrollFor]) - 25);
					}*/

					Thread.Sleep(20);
					Application.DoEvents();
				};

				p.Form.Invoke(action);
			}
		}
	}
}