using System.Linq;
using System.Threading;
using System.Windows.Forms;
using EvaluationKernel;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Commands.Rendering;
using TrafficFlowSimulation.Models;

namespace TrafficFlowSimulation.Commands
{
	public static class EvaluationHandler
	{
		public class Parameters
		{
			public AllChartsModel Charts;
			public ModelParameters ModelParameters;
		}

		private static Thread? th = null;

		/// <summary>
		/// Отрисовываем не каждую итерацию, а указанную в Speed
		/// Это увеличивает скорость отрисовки
		/// </summary>
		private static int Speed = 100;

		public static void Execute(AllChartsModel charts, ModelParameters modelParameters)
		{
			var parameters = new Parameters
			{
				Charts = charts,
				ModelParameters = modelParameters
			};

			th = new Thread(Method);
			th.Start(parameters);
		}

		private static void Method(object parameters)
		{
			var p = (Parameters) parameters;
			var carsMovementChart = p.Charts.CarsMovementChart;
			var modelParameters = p.ModelParameters;

			var r = new RungeKuttaMethod(modelParameters);
			var n = modelParameters.n;

			var xp = new double[n];
			var yp = new double[n];
			var t = r.T.Last();
			var x = new double[n];
			var y = new double[n];
			for (int i = 0; i < n; i++)
			{
				x[i] = r.X(i).Last();
				y[i] = r.Y(i).Last();
			}

			int operationCounter = 0;
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

				if(operationCounter % Speed == 0)
				{
					MethodInvoker action = delegate
					{

						RenderingHelper.UpdateCharts(t, x, y);


						var ee = carsMovementChart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
						if(x[0] > ee)
						{
							double span = x[0] - ee;
							carsMovementChart.ChartAreas[0].AxisX.ScaleView.Zoom(
								50, 100);
							//carsMovementChart.ChartAreas[0].AxisX.ScaleView.ViewMinimum + span, 
							//carsMovementChart.ChartAreas[0].AxisX.ScaleView.ViewMaximum + span);

						}
						Application.DoEvents();
					};
					p.Charts.CarsMovementChart.Invoke(action);
				}

				operationCounter++;
			}
		}

		public static void AbortExecution()
		{
			if (th != null)
				th.Abort();
		}
	}
}