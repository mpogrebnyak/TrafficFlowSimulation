using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Helpers;
using ChartRendering.Models;
using ChartRendering.Properties;
using EvaluationKernel.Models;
using Localization;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.SpeedLimitChanging;

public class SpeedLimitChangingDistanceChartRender : DistanceChartRender
{
	public SpeedLimitChangingDistanceChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		foreach (var series in _chart.Series.Where(x => x.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));
			_chart.Series[i].Points.AddXY(0, modelParameters.lambda[i]);

			UpdateLegend(i, true, modelParameters.lambda[i]);
		}
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
		foreach (var series in _chart.Series.Where(series => series.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));
			_chart.Series[i].Points.AddXY(coordinates.t, coordinates.x[i]);

			UpdateLegend(i, true, coordinates.x[i]);
		}
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var model = new ChartAreaCreationModel
		{
			Name = _chartAreaName,
			AxisX = new Axis
			{
				Minimum = 0,
				Maximum = 60,
				Interval = 10,
				Title = LocalizationHelper.Get<ChartRenderingResources>().TimeAxisTitleText,
				TitleAlignment = StringAlignment.Far
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = modelParameters.L + 100,
				Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceAxisTitleText,
				TitleAlignment = StringAlignment.Far
			}
		};
		var chartArea = ChartAreaRendersHelper.CreateChartArea(model);

		return chartArea;
	}
	
	protected override Series[] CreateEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var settings = (SpeedLimitChangingModeSettingsModel)modeSettings;

/*		var segmentBeginSeries = new Series
		{
			Name = "SegmentBegin",
			ChartType = SeriesChartType.Line,
			ChartArea = _chartAreaName,
			BorderWidth = 2,
			Color = Color.Blue,
			IsVisibleInLegend = false
		};
		segmentBeginSeries.Points.Add(new DataPoint(ChartAreaModel.AxisXMinimum,settings.SegmentBeginning));
		segmentBeginSeries.Points.Add(new DataPoint(ChartAreaModel.AxisXMaximum, settings.SegmentBeginning));

		var segmentEndSeries = new Series
		{
			Name = "SegmentEnd",
			ChartType = SeriesChartType.Line,
			ChartArea = _chartAreaName,
			BorderWidth = 2,
			Color = Color.Blue,
			IsVisibleInLegend = false
		};
		segmentEndSeries.Points.Add(new DataPoint(ChartAreaModel.AxisXMinimum, settings.SegmentEnding));
		segmentEndSeries.Points.Add(new DataPoint(ChartAreaModel.AxisXMaximum, settings.SegmentEnding));

		return new[]
		{
			segmentBeginSeries,
			segmentEndSeries
		};*/
		return new Series[]
		{
			
		} ;
	}
}