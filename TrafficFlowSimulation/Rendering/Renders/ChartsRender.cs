using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Сonstants;

namespace TrafficFlowSimulation.Rendering.Renders
{
	public abstract class ChartsRender
	{
        public virtual string ChartText => "Chart";
		protected virtual string ChartName => "Chart";
		protected virtual string ChartAreaName => "ChartArea";

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

			Chart.Text = ChartText;
			var chartArea = CreateChartArea();
			Chart.ChartAreas.Add(chartArea);

			Chart.Legends.Add(CreateLegend(LegendStyle.Column));

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

		public virtual void Update(List<double> p1 = null!, List<double> p2 = null!, List<double> p3 = null!)
		{
			foreach (var series in Chart.Series.Where(series => series.Name.Contains(ChartName)))
			{
				var i = Convert.ToInt32(series.Name.Replace(ChartName, ""));
				Chart.Series[i].Points.AddXY(p1[i], p2[i]);
			}
		}

		public virtual void ShowLegend(LegendDisplayOptions option)
		{
			switch (option)
            {
				case LegendDisplayOptions.Full:
					Chart.Legends.Clear();
					Chart.Legends.Add(CreateLegend(LegendStyle.Table));
					break;
				case LegendDisplayOptions.Partially:
					Chart.Legends.Clear();
					Chart.Legends.Add(CreateLegend(LegendStyle.Column));
					break;
				case LegendDisplayOptions.None:
					Chart.Legends.Clear();
					break;
            }
		}

		protected abstract ChartArea CreateChartArea();

		protected abstract Legend CreateLegend(LegendStyle legendStyle);

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
