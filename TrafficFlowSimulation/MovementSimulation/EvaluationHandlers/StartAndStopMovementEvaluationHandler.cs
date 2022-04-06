using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using EvaluationKernel;
using Microsoft.Practices.ServiceLocation;
using TrafficFlowSimulation.MovementSimulation.EvaluationHandlers;
using TrafficFlowSimulation.Rendering;
using TrafficFlowSimulation.Сonstants;

namespace TrafficFlowSimulation.EvaluationHandlers;

public class StartAndStopMovementEvaluationHandler : EvaluationHandler
{
	protected override void Evaluate(object parameters)
	{
		var p = (Parameters) parameters;
		var carsMovementChart = p.Charts.CarsMovementChart;
		var modelParameters = p.ModelParameters;

		var r = new RungeKuttaMethod(modelParameters);
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

			if (t - tp > 0.1)
			{
				tp = t;
				MethodInvoker action = delegate
				{
					ServiceLocator.Current.GetInstance<RenderingHandler>().UpdateCharts(t, x, y);
					//RenderingHelper.UpdateCharts(p.Charts, t, x, y);

					if (p.ModeSettings.AutoScroll == AutoScroll.Yes)
					{
						var scaleView = carsMovementChart.ChartAreas[0].AxisX.ScaleView;
						scaleView.Scroll(Math.Round(x[p.ModeSettings.ScrollFor]) - 25);
					}

					Thread.Sleep(20);
					Application.DoEvents();
				};
				p.Charts.CarsMovementChart.Invoke(action);
			}
		}
	}
}