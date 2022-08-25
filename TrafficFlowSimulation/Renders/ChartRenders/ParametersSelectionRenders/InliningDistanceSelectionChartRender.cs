using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;

namespace TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders;

public class InliningDistanceSelectionChartRender : ChartsRender
{
	public InliningDistanceSelectionChartRender(Chart chart) : base(chart)
	{
		FullClearChart();

		var chartArea = CreateChartArea(null);
		_chart.ChartAreas.Add(chartArea);

		_chart.Series.Add(new Series
		{
			Name = "SeriesName",
			ChartType = _seriesChartType,
			ChartArea = chartArea.Name,
			BorderWidth = 2,
			
		});
		
		var environmentSeries = CreateEnvironment(null);
		foreach (var series in environmentSeries)
		{
			_chart.Series.Add(series);
		}
	}

	public override void RenderChart(ModelParameters modelParameters)
	{
		//base.RenderChart(modelParameters);
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters)
	{
		return new ChartArea()
		{
			Name = "ChartArea",
			AxisX = new Axis
			{
				Minimum = 0,
				Maximum = 50,
			},
			AxisY = new Axis
			{
				Minimum = -10,
				Maximum = 20,

			}
		};
	}

	protected override Legend CreateLegend(LegendStyle legendStyle)
	{
		throw new System.NotImplementedException();
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters)
	{
		var startLineSeries = new Series
		{
			Name = "StartLine",
			ChartType = SeriesChartType.Line,
			ChartArea = _chartAreaName,
			BorderWidth = 2,
			Color = Color.GreenYellow,
			IsVisibleInLegend = false
		};
		startLineSeries.Points.Add(new DataPoint(-100, 0));
		startLineSeries.Points.Add(new DataPoint(100, 0));
		
		return new Series[] { startLineSeries };
	}

	public override void UpdateChart(List<double> p1 = null, List<double> p2 = null, List<double> p3 = null)
	{
		_chart.Series[0].Points.AddXY(p1[0], p2[0]);
	}

	public override void SetChartAreaAxisTitle(bool isHidden = false)
	{
		throw new System.NotImplementedException();
	}
}