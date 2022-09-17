using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;

namespace TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders;

public class InliningDistanceSelectionChartRender : ChartsRender
{
	protected override string _seriesName => "InliningDistanceChangingSeries";

	protected override string _chartAreaName => "InliningDistanceChangingChartArea";

	public InliningDistanceSelectionChartRender(Chart chart) : base(chart)
	{
		FullClearChart();
	}

	public override void RenderChart(ModelParameters modelParameters)
	{
		FullClearChart();

		var chartArea = CreateChartArea(modelParameters);
		_chart.ChartAreas.Add(chartArea);

		_chart.Series.Add(new Series
		{
			Name = _seriesName,
			ChartType = _seriesChartType,
			ChartArea = chartArea.Name,
			BorderWidth = 2,
		});

		var environmentSeries = CreateEnvironment(modelParameters);
		foreach (var series in environmentSeries)
		{
			_chart.Series.Add(series);
		}
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters)
	{
		return new ChartArea()
		{
			Name = _chartAreaName,
			AxisX = new Axis
			{
				Minimum = 0,
				Maximum = 100,
			},
			AxisY = new Axis
			{
				Minimum = -modelParameters.Vmax[1],
				Maximum = modelParameters.Vmax[1],
				Interval = modelParameters.Vmax[1] / 2,
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
		if(p1.Count != p2.Count)
			return;

		var count = p1.Count;
		for (var i = 0; i < count; i++)
		{
			_chart.Series[_seriesName].Points.AddXY(p1[i], p2[i]);
		}
	}

	public override void SetChartAreaAxisTitle(bool isHidden = false)
	{
		throw new System.NotImplementedException();
	}
}