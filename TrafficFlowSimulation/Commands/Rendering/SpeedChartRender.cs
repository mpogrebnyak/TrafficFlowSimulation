using EvaluationKernel.Models;
using System.Windows.Forms.DataVisualization.Charting;

namespace TrafficFlowSimulation.Commands.Rendering
{
	public class SpeedChartRender : ChartsRender
	{
		protected override string ChartName => "Speed";
		public SpeedChartRender(ModelParameters modelParameters, Chart chart) : base(modelParameters, chart)
		{
		}

		protected override ChartArea CreateChartArea()
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

		protected override Legend CreateLegend()
		{
			return new Legend
			{
			};
		}
	}
}
