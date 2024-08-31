using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using EvaluationKernel.Models;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.MovementThroughOneTrafficLight;

public class MovementThroughOneTrafficLightSpeedFromDistanceChartRender : SpeedFromDistanceChartRender
{
	public MovementThroughOneTrafficLightSpeedFromDistanceChartRender(Chart chart) : base(chart)
	{
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{ 
		var chartArea = base.CreateChartArea(modelParameters, modeSettings);

		chartArea.AxisX.Minimum = -30;
		chartArea.AxisX.Maximum = 60;
		chartArea.AxisX.Interval = 90 / 5.0;

		return chartArea;
	}
}