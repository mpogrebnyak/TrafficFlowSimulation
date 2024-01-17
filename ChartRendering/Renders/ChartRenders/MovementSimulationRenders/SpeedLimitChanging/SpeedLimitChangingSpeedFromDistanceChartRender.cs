using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Constants;
using ChartRendering.Helpers;
using ChartRendering.Properties;
using EvaluationKernel.Models;
using Localization;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.SpeedLimitChanging;

public class SpeedLimitChangingSpeedFromDistanceChartRender : SpeedFromDistanceChartRender
{
	public SpeedLimitChangingSpeedFromDistanceChartRender(Chart chart) : base(chart)
	{
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var segmentsBeginning = RenderingHelper.GetSegmentBeginningList((SpeedLimitChangingModeSettingsModel)modeSettings);
		var segmentsSpeed = RenderingHelper.GetSegmentSpeedList((SpeedLimitChangingModeSettingsModel)modeSettings);

		var model = new ChartAreaCreationModel
		{
			Name = ChartAreaName,
			AxisX = new Axis
			{
				Minimum = modelParameters.lambda[0],
				Maximum = segmentsBeginning.Last() + 100,
				Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceAxisTitleText,
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = RenderingHelper.CalculateMaxSpeed(modelParameters.Vmax),
				Title = LocalizationHelper.Get<ChartRenderingResources>().SpeedAxisTitleText,
			}
		};
		foreach (var segment in segmentsBeginning)
		{
			model.AxisX.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(segment));
		}
		foreach (var segment in segmentsSpeed)
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

		var series = new List<Series>();
		foreach (var segment in segmentSpeeds.Take(segmentSpeeds.Count - 1).ToList())
		{
			var segmentSpeedSeries = new Series
			{
				Name = "SegmentSpeed" + segment.Key,
				ChartType = SeriesChartType.Line,
				ChartArea = ChartAreaName,
				BorderWidth = 2,
				Color = CustomColors.Red,
				IsVisibleInLegend = false,
				BorderDashStyle = ChartDashStyle.Dash
			};
			segmentSpeedSeries.Points.Add(new DataPoint(GetChartArea().AxisX.Minimum, segment.Value.Speed));

			// необходимо для красивой отрисовки без начала движения
			var chartArea = GetChartArea();
			for (var i = chartArea.AxisX.Minimum; i <= chartArea.AxisX.Maximum; i+= (chartArea.AxisX.Maximum - chartArea.AxisX.Minimum) / 5)
			{
				segmentSpeedSeries.Points.Add(new DataPoint(i, segment.Value.Speed));

			}
			series.Add(segmentSpeedSeries);

			var segmentDistanceSeries = new Series
			{
				Name = "SegmentBegin" + segment.Key,
				ChartType = SeriesChartType.Line,
				ChartArea = ChartAreaName,
				BorderWidth = 2,
				Color = CustomColors.Red,
				IsVisibleInLegend = false,
				BorderDashStyle = ChartDashStyle.Dash
			};
			segmentDistanceSeries.Points.Add(new DataPoint(segment.Value.SegmentBeginning, GetChartArea().AxisY.Minimum));
			segmentDistanceSeries.Points.Add(new DataPoint(segment.Value.SegmentBeginning, GetChartArea().AxisY.Maximum));

			series.Add(segmentDistanceSeries);
		}

		return series.ToArray();
	}
}