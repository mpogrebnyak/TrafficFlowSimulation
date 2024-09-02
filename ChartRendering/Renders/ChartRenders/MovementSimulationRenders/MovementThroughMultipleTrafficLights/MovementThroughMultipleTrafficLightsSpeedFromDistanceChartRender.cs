using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using EvaluationKernel.Models;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.MovementThroughMultipleTrafficLights;

public class MovementThroughMultipleTrafficLightsSpeedFromDistanceChartRender : SpeedFromDistanceChartRender
{
	public MovementThroughMultipleTrafficLightsSpeedFromDistanceChartRender(Chart chart) : base(chart)
	{
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{ 
		var chartArea = base.CreateChartArea(modelParameters, modeSettings);

		var settings = (MovementThroughMultipleTrafficLightsModeSettingsModel)modeSettings;
		var trafficLightsParameters = settings.MapTo();

		chartArea.AxisX.Minimum = -30;
		chartArea.AxisX.Maximum = trafficLightsParameters.TrafficLightsPosition.Last() + 100;
		chartArea.AxisX.Interval = (trafficLightsParameters.TrafficLightsPosition.Last() + 100) / 5.0;

		return chartArea;
	}
}