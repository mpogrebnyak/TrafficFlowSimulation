using EvaluationKernel.Models;
using System.Windows.Forms.DataVisualization.Charting;

namespace TrafficFlowSimulation.Commands.Rendering
{
    public class DistanceChartRender : ChartsRender
    {
        protected override string ChartName => "Distance";
        public DistanceChartRender(ModelParameters modelParameters, Chart chart) : base(modelParameters, chart)
        {
        }

        protected override ChartArea CreateChartArea()
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
                    Maximum = ModelParameters.L + 100
                }
            };
        }
        protected override Legend CreateLegend()
        {
            return new Legend
            {
            };
        }
    }
}
