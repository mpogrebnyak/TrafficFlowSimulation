using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders.SpeedLimitChanging;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.RoadHole;

public class RoadHoleSpeedFromDistanceChartRender : SpeedLimitChangingSpeedFromDistanceChartRender
{
	public RoadHoleSpeedFromDistanceChartRender(Chart chart) : base(chart)
	{
	}
}