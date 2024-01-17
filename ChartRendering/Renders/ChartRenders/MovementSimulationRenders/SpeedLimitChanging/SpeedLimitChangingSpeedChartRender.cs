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

public class SpeedLimitChangingSpeedChartRender : SpeedChartRender
{
	public SpeedLimitChangingSpeedChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		foreach (var series in Chart.Series.Where(x => x.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));
			if (i == 0)
				GetSeries(i).Points.AddXY(0, modelParameters.Vn[i]);

			UpdateLegend(i, true, 0);
		}
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
		base.UpdateChart(coordinates);

		foreach (var series in Chart.Series.Where(series => series.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));
			GetSeries(i).Points.AddXY(coordinates.T, coordinates.Y[i]);

			UpdateLegend(i, true, coordinates.Y[i]);
		}
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var segments = RenderingHelper.GetSegmentSpeedList((SpeedLimitChangingModeSettingsModel)modeSettings);

		var model = new ChartAreaCreationModel
		{
			Name = ChartAreaName,
			AxisX = new Axis
			{
				Minimum = 0,
				Maximum = 60,
				Title = LocalizationHelper.Get<ChartRenderingResources>().TimeAxisTitleText
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = RenderingHelper.CalculateMaxSpeed(modelParameters.Vmax),
				Title = LocalizationHelper.Get<ChartRenderingResources>().SpeedAxisTitleText
			}
		};
		foreach (var segment in segments)
		{
			model.AxisY.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(segment));
		}
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
		foreach (var segment in segmentSpeeds.Take(segmentSpeeds.Count - 1).ToList())
		{
			var segmentSeries = new Series
			{
				Name = "SegmentSpeed" + segment.Key,
				ChartType = SeriesChartType.Line,
				ChartArea = ChartAreaName,
				BorderWidth = 2,
				Color = CustomColors.Red,
				IsVisibleInLegend = false,
				BorderDashStyle = ChartDashStyle.Dash
			};
			segmentSeries.Points.Add(new DataPoint(GetChartArea().AxisX.Minimum, segment.Value.Speed));

			// необходимо для красивой отрисовки без начала движения
			segmentSeries.Points.Add(new DataPoint(20, segment.Value.Speed));
			segmentSeries.Points.Add(new DataPoint(40, segment.Value.Speed));

			for (var i = 1; i <= maximumTime; i++)
			{
				segmentSeries.Points.Add(new DataPoint(GetChartArea().AxisX.Maximum * i, segment.Value.Speed));
			}
			series.Add(segmentSeries);
		}

		return series.ToArray();
	}
}