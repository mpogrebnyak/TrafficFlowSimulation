using System;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Helpers;
using ChartRendering.Properties;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders.SpeedLimitChanging;
using EvaluationKernel.Models;
using Localization;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.RoadHole;

public class RoadHoleDistanceChartRender : SpeedLimitChangingDistanceChartRender
{
	public RoadHoleDistanceChartRender(Chart chart) : base(chart)
	{
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
				Title = LocalizationHelper.Get<ChartRenderingResources>().TimeAxisTitleText,
			},
			AxisY = new Axis
			{
				Minimum = -3,
				Maximum = Math.Ceiling(segments.Last()) + 1,
				Interval = (Math.Ceiling(segments.Last()) + 1 - (-3)) / 5.0,
				Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceAxisTitleText,
			}
		};
		foreach (var segment in segments)
		{
			model.AxisY.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(segment));
		}
		model.AxisX.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(60, LocalizationHelper.Get<ChartRenderingResources>().TWithMeasurements));
		model.AxisY.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(Math.Ceiling(segments.Last()) + 1, LocalizationHelper.Get<ChartRenderingResources>().XWithMeasurements));

		var chartArea = ChartAreaRendersHelper.CreateChartArea(model);

		return chartArea;
	}
}