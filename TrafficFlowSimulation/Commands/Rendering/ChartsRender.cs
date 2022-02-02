using EvaluationKernel.Models;
using System.Windows.Forms.DataVisualization.Charting;

namespace TrafficFlowSimulation.Commands.Rendering
{
	public abstract class ChartsRender
	{
		protected abstract string ChartName { get; }

		protected ModelParameters ModelParameters;
		protected Chart Chart;
		public ChartsRender(ModelParameters modelParameters, Chart chart)
		{
			ModelParameters = modelParameters;
			Chart = chart;
		}
		public virtual void Render(SeriesChartType chartType)
		{
			var modelParameters = ModelParameters;

			FullClearChart();

			var chartArea = CreateChartArea();
			Chart.ChartAreas.Add(chartArea);

			Chart.Legends.Add(CreateLegend());

			for (int i = 0; i < modelParameters.n; i++)
			{
				Chart.Series.Add(new Series
				{
					Name = ChartName + i,
					ChartType = chartType,
					ChartArea = chartArea.Name,
					BorderWidth = 2
				});
			}

			var environmentSeries = CreateEnvironment();
			foreach (var series in environmentSeries)
			{
				Chart.Series.Add(series);
			}
		}

		protected abstract ChartArea CreateChartArea();

		protected abstract Legend CreateLegend();

		protected virtual Series[] CreateEnvironment()
		{
			return new Series[] { };
		}

		protected void FullClearChart()
		{
			Chart.Series.Clear();
			Chart.ChartAreas.Clear();
			Chart.Legends.Clear();
		}
	}
}
