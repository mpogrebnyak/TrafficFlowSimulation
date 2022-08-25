using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using EvaluationKernel;
using EvaluationKernel.Equations;
using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Renders;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders;

namespace TrafficFlowSimulation.Handlers.EvaluationHandlers.ParametersSelectionEvaluationHandlers;

public class InliningDistanceSelectionEvaluationHandler : EvaluationHandler
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

		int ee = 0;
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

			if (t - tp > 0.1)
			{
				tp = t;
				MethodInvoker action = delegate
				{
					var xx = new List<double>();
					xx.Add(x[0]-x[1]);
					var yy = new List<double>();
					yy.Add(y[0]-y[1]);
					ServiceLocator.Current.GetInstance<ParametersSelectionRenderingHandler>().UpdateChart(0, xx.ToArray(), yy.ToArray());
					//ServiceLocator.Current.GetInstance<<IChartRender>().UpdateCharts(t, x, y);

					/*if (p.ModeSettings.AutoScroll == AutoScroll.Yes)
					{
						var scaleView = carsMovementChart.ChartAreas[0].AxisX.ScaleView;
						scaleView.Scroll(Math.Round(x[p.ModeSettings.ScrollFor]) - 25);
					}*/

					Thread.Sleep(20);
					Application.DoEvents();
				};

				p.Form.Invoke(action);
				
				ee++;
				
				if(y[0] >=modelParameters.Vmax[0]-0.0001 && y[1]>=modelParameters.Vmax[1]-0.0001)
					return;
			}
		}
		
		
		//	chart1.Series[0].Points.AddXY(x[0]-x[1], y[0]-y[1]);
		//tp = t;
		//MethodInvoker action = delegate
		//{
		//	ServiceLocator.Current.GetInstance<RenderingHandler>().UpdateCharts(t, x, y);

		/*if (p.ModeSettings.AutoScroll == AutoScroll.Yes)
		{
			var scaleView = carsMovementChart.ChartAreas[0].AxisX.ScaleView;
			scaleView.Scroll(Math.Round(x[p.ModeSettings.ScrollFor]) - 25);
		}*/

		//	Thread.Sleep(20);
		//	Application.DoEvents();
		//};

		//ParametersEvaluationWindow.Invoke(action);
		//MainWindow.
		//if(MainWindow.ActiveForm != null)
		//	MainWindow.ActiveForm.Invoke(action);
		//p.Charts.CarsMovementChart.Invoke(action);
		//		}

		//		ee++;
				
		//		if(ee>10000)
		//			return;
	}
}