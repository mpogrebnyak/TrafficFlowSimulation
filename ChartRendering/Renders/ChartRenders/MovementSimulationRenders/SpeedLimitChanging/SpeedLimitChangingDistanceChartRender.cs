using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Constants;
using ChartRendering.Helpers;
using ChartRendering.Models;
using ChartRendering.Properties;
using EvaluationKernel.Models;
using Localization;
using Settings;

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
			if (i == 0)
				series.Points.AddXY(0, modelParameters.lambda[i]);

			UpdateLegend(series, true, modelParameters.lambda[i]);
		}
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
		base.UpdateChart(coordinates);

		foreach (var series in Chart.Series.Where(series => series.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));
			series.Points.AddXY(coordinates.T, coordinates.X[i]);

			UpdateLegend(series, true, coordinates.X[i]);
		}
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var segments = RenderingHelper.GetSegmentBeginningList((SpeedLimitChangingModeSettingsModel)modeSettings);

		var model = new ChartAreaCreationModel
		{
			Name = ChartAreaName,
			AxisX = new Axis
			{
				Minimum = 0,
				Maximum = 60,
				Interval = 60 / 5.0,
				Title = LocalizationHelper.Get<ChartRenderingResources>().TimeAxisTitleText
			},
			AxisY = new Axis
			{
				Minimum = modelParameters.lambda[0],
				Maximum = segments.Last() + 100,
				Interval = (segments.Last() + 100 - modelParameters.lambda[0]) / 5.0,
				Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceAxisTitleText
			}
		};
		foreach (var segment in segments)
		{
			model.AxisY.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(segment));
		}
		model.AxisX.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(60, LocalizationHelper.Get<ChartRenderingResources>().TWithMeasurements));
		model.AxisY.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(segments.Last() + 100, LocalizationHelper.Get<ChartRenderingResources>().XWithMeasurements));

		var chartArea = ChartAreaRendersHelper.CreateChartArea(model);

		return chartArea;
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var settings = (SpeedLimitChangingModeSettingsModel)modeSettings;

		var segmentSpeeds = new SortedDictionary<int, SegmentModel>();
		settings.MapTo(segmentSpeeds);

		var maximumTime = SettingsHelper.Get<ChartRenderingSettings>().MaximumTimeForAutomaticIncrease;

		var series = new List<Series>();
		foreach (var segment in segmentSpeeds)
		{
			var segmentSeries = new Series
			{
				Name = "SegmentBegin" + segment.Key,
				ChartType = SeriesChartType.Line,
				ChartArea = ChartAreaName,
				BorderWidth = 2,
				Color = CustomColors.Red,
				IsVisibleInLegend = false,
				BorderDashStyle = ChartDashStyle.Dash
			};
			segmentSeries.Points.Add(new DataPoint(GetChartArea().AxisX.Minimum, segment.Value.SegmentBeginning));

			// необходимо для красивой отрисовки без начала движения
			segmentSeries.Points.Add(new DataPoint(20, segment.Value.SegmentBeginning));
			segmentSeries.Points.Add(new DataPoint(40, segment.Value.SegmentBeginning));

			for (var i = 1; i <= maximumTime; i++)
			{
				segmentSeries.Points.Add(new DataPoint(GetChartArea().AxisX.Maximum * i, segment.Value.SegmentBeginning));
			}
			series.Add(segmentSeries);
		}

		return series.ToArray();
	}
}