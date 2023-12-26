using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Helpers;
using ChartRendering.Models;
using ChartRendering.Properties;
using EvaluationKernel.Models;
using Localization;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.SpeedLimitChanging;

public class SpeedLimitChangingDistanceChartRender : DistanceChartRender
{
	public SpeedLimitChangingDistanceChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		foreach (var series in Chart.Series.Where(x => x.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));
			Chart.Series[i].Points.AddXY(0, modelParameters.lambda[i]);

			UpdateLegend(i, true, modelParameters.lambda[i]);
		}
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
		foreach (var series in Chart.Series.Where(series => series.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));
			Chart.Series[i].Points.AddXY(coordinates.T, coordinates.X[i]);

			UpdateLegend(i, true, coordinates.X[i]);
		}
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var segment = GetSegmentList((SpeedLimitChangingModeSettingsModel)modeSettings);

		var model = new ChartAreaCreationModel
		{
			Name = ChartAreaName,
			AxisX = new Axis
			{
				Minimum = 0,
				Maximum = 60,
				Title = LocalizationHelper.Get<ChartRenderingResources>().TimeAxisTitleText,
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = segment.Last() + 100,
				Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceAxisTitleText,
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

	private List<double> GetSegmentList(SpeedLimitChangingModeSettingsModel settings)
	{
		var segmentSpeeds = new SortedDictionary<int, SegmentModel>();
		settings.MapTo(segmentSpeeds);

		return settings.GetSegmentList(segmentSpeeds);
	}
}