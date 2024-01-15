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
				Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceAxisTitleText,
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = RenderingHelper.CalculateMaxSpeed(modelParameters.Vmax),
				Title = LocalizationHelper.Get<ChartRenderingResources>().SpeedAxisTitleText,
			}
		};
		var chartArea = ChartAreaRendersHelper.CreateChartArea(model);

		return chartArea;
	}
}