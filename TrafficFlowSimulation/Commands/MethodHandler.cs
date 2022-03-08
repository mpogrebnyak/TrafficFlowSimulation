using EvaluationKernel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TrafficFlowSimulation.Models;

namespace TrafficFlowSimulation.Commands
{
    public class MethodHandler
    {
        private Thread th;
        /// <summary>
        /// Отрисовываем не каждую итерацию, а указанную в Speed
        /// Это увеличивает скорость отрисовки
        /// </summary>
        private int Speed; 
        public MethodHandler()
        {
            th = null;
            Speed = 100;
        }

        public void Execute(ChartsRenderingModel chartsRenderingModel)
        {
            RenderingHelper.RenderCharts(chartsRenderingModel);

            th = new Thread(Method);
            th.Start(chartsRenderingModel);
        }

        public void AbortExecution()
        {
            if (th != null)
                th.Abort();
        }

        private void Method(object parameters)
        {
            var chartsRenderingModel = (ChartsRenderingModel)parameters;
            var speedChart = chartsRenderingModel.SpeedChart;
            var distanceChart = chartsRenderingModel.DistanceChart;
            var modelParameters = chartsRenderingModel.ModelParameters;

            var r = new RungeKuttaMethod(modelParameters);
            var n = modelParameters.n;

            double tp;
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
                tp = t;
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

                if (operationCounter % Speed == 0)
                {
                    MethodInvoker action = delegate
                    {
                        for (int i = 0; i < n; i++)
                        {
                            speedChart.Series[i].Points.AddXY(t, y[i]);
                            distanceChart.Series[i].Points.AddXY(t, x[i]);
                        }

                        speedChart.Update();
                        distanceChart.Update();
                        Application.DoEvents();
                    };

                    speedChart.Invoke(action);
                }

                operationCounter++;
            }
        }
    }
}
