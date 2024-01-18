using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Constants;
using ChartRendering.Models;
using EvaluationKernel.Models;

namespace ChartRendering.Renders.ChartRenders.ParametersSelectionRenders;

public class InliningDistanceEstimationSelectionChartRender : ChartsRender
{
	protected override string SeriesName => "InliningDistanceEstimationSeries";

	protected override string ChartAreaName => "InliningDistanceEstimationChartArea";

	protected override SeriesChartType SeriesChartType => SeriesChartType.Point;

	private readonly List<Color> _pointColors = CustomColors.GetColorsForInliningDistanceEstimation();

	public InliningDistanceEstimationSelectionChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		FullClearChart();

		var chartArea = CreateChartArea(modelParameters, modeSettings);
		Chart.ChartAreas.Add(chartArea);


		Chart.Series.Where(series => series.Name.Contains(_pointColors.First().Name));
		
		var environmentSeries = CreateEnvironment(modelParameters, modeSettings);
		foreach (var series in environmentSeries)
		{
			Chart.Series.Add(series);
		}
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
	/*	var coordinatesModel = (List<InliningDistanceEstimationCoordinatesModel>) parameters;

		foreach (var cm in coordinatesModel)
		{
			_chart.Series.Single(series => series.Name.Contains(cm.Color))
				.Points
				.AddXY(cm.X, cm.Y);
		}*/
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		return new ChartArea
		{
			Name = ChartAreaName,
			AxisX = new Axis
			{
				Minimum = 0,
				Maximum = 100,
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = modelParameters.Vmax[1],
				Interval = modelParameters.Vmax[1] / 2,
			}
		};
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var startLineSeries = new Series
		{
			Name = "UpperBound",
			ChartType = SeriesChartType.Line,
			ChartArea = ChartAreaName,
			BorderWidth = 2,
			Color = Color.Black,
			IsVisibleInLegend = false
		};
		startLineSeries.Points.Add(new DataPoint(0, 5));
		startLineSeries.Points.Add(new DataPoint(6, 7));

		var endLineSeries = new Series
		{
			Name = "LowerBound",
			ChartType = SeriesChartType.Line,
			ChartArea = ChartAreaName,
			BorderWidth = 2,
			Color = Color.Black,
			IsVisibleInLegend = false
		};
		endLineSeries.Points.Add(new DataPoint(0, 1));
		endLineSeries.Points.Add(new DataPoint(1,1));

		return new[]
		{
			startLineSeries,
			endLineSeries
		};
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