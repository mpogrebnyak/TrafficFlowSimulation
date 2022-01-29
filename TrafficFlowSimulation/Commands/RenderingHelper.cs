using EvaluationKernel.Models;
using System.Windows.Forms.DataVisualization.Charting;
using TrafficFlowSimulation.Models;

namespace TrafficFlowSimulation.Commands
{
    public static class RenderingHelper
    {
        public static void RenderCharts(ChartsRenderingModel chartsRenderingModel)
        {
            FullClearChart(chartsRenderingModel.SpeedChart);
            FullClearChart(chartsRenderingModel.DistanceChart);

            var speedchartArea = CreateSpeedChartArea(chartsRenderingModel.ModelParameters);
            var distancechartArea = CreateDistanceChartArea(chartsRenderingModel.ModelParameters);

            var n = chartsRenderingModel.ModelParameters.n;
            Render(chartsRenderingModel.SpeedChart, speedchartArea, n);
            Render(chartsRenderingModel.DistanceChart, distancechartArea, n);
        }

        private static void FullClearChart(Chart chart)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
        }

        private static ChartArea CreateSpeedChartArea(ModelParameters m)
        {
            return new ChartArea
            {
                Name = "speedChartArea",
                AxisX = new Axis
                {
                    Minimum = 0,
                    Maximum = 20,
                },
                AxisY = new Axis
                {
                    Minimum = 0,
                    Maximum = 20
                }
            };
        }

        private static ChartArea CreateDistanceChartArea(ModelParameters m)
        {
            return new ChartArea
            {
                Name = "distancechartArea",
                AxisX = new Axis
                {
                    Minimum = 0,
                    Maximum = 20
                },
                AxisY = new Axis
                {
                    Minimum = 0,
                    Maximum = m.L + 100
                }
            };
        }


        private static void Render(Chart chart, ChartArea chartArea, int n)
        {
            chart.ChartAreas.Add(chartArea);

            for (int i = 0; i < n; i++)
            {
                chart.Series.Add(new Series
                {
                    Name = i.ToString(),
                    ChartType = SeriesChartType.Spline,
                    ChartArea = chartArea.Name,
                    BorderWidth = 2
                });
            }
        }
    }
}