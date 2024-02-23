using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Helpers;
using ChartRendering.Properties;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders.SpeedLimitChanging;
using EvaluationKernel.Models;
using Localization;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.RoadHole;

public class RoadHoleSpeedFromDistanceChartRender : SpeedLimitChangingSpeedFromDistanceChartRender
{
	public RoadHoleSpeedFromDistanceChartRender(Chart chart) : base(chart)
	{
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var model = new ChartAreaCreationModel
		{
			Name = ChartAreaName,
			AxisX = new Axis
			{
				Minimum = -100,
				Maximum = 100,
				Interval = (100 - (-100)) / 5.0,
				Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceAxisTitleText,
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = RenderingHelper.CalculateMaxSpeed(modelParameters.Vmax),
				Interval = RenderingHelper.CalculateMaxSpeed(modelParameters.Vmax) / 5.0,
				Title = LocalizationHelper.Get<ChartRenderingResources>().SpeedAxisTitleText,
			}
		};
		model.AxisX.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(100, LocalizationHelper.Get<ChartRenderingResources>().XWithMeasurements));
		model.AxisY.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(RenderingHelper.CalculateMaxSpeed(modelParameters.Vmax), LocalizationHelper.Get<ChartRenderingResources>().DotXWithMeasurements));

		var chartArea = ChartAreaRendersHelper.CreateChartArea(model);

		return chartArea;
	}
}