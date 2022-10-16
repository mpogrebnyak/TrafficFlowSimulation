using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders.Models;

namespace TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders;

public class InliningDistanceEstimationSelectionChartRender : ChartsRender
{
	protected override string _seriesName => "InliningDistanceEstimationSeries";

	private string GreenSeriesName => "Green" + _seriesName;

	private string RedSeriesName => "Red" + _seriesName;

	protected override string _chartAreaName => "InliningDistanceEstimationChartArea";

	protected override SeriesChartType _seriesChartType => SeriesChartType.Point;

	public InliningDistanceEstimationSelectionChartRender(Chart chart) : base(chart)
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
			Name = GreenSeriesName,
			ChartType = _seriesChartType,
			ChartArea = chartArea.Name,
			BorderWidth = 1,
			Color = Color.Green,
			MarkerStyle = MarkerStyle.Circle
		});

		_chart.Series.Add(new Series
		{
			Name = RedSeriesName,
			ChartType = _seriesChartType,
			ChartArea = chartArea.Name,
			BorderWidth = 1,
			Color = Color.Red,
			MarkerStyle = MarkerStyle.Circle
		});

		_chart.Series[RedSeriesName].Points.AddXY(-1, -1);
	}

	public override void UpdateChart(object parameters)
	{
		var coordinatesModel = (List<InliningDistanceEstimationCoordinatesModel>) parameters;

		foreach (var cm in coordinatesModel)
		{
			switch (cm.color)
			{
				case PointColor.Green:
				{
					_chart.Series[GreenSeriesName].Points.AddXY(cm.x, cm.y);
					break;
				}
				case PointColor.Red:
				{
					_chart.Series[RedSeriesName].Points.AddXY(cm.x, cm.y);;
					break;
				}
			}
		}
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters)
	{
		return new ChartArea
		{
			Name = _chartAreaName,
			AxisX = new Axis
			{
				Minimum = 0,
				Maximum = 60,
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = modelParameters.Vmax[1],
				Interval = modelParameters.Vmax[1] / 2,
			}
		};
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters)
	{
		return new Series[] { };
	}

	protected override Legend CreateLegend(LegendStyle legendStyle)
	{
		throw new System.NotImplementedException();
	}

	public override void SetChartAreaAxisTitle(bool isHidden = false)
	{
		throw new System.NotImplementedException();
	}
}