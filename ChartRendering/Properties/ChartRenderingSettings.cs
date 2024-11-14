using System.ComponentModel;
using ChartRendering.Constants;

namespace ChartRendering.Properties;

public class ChartRenderingSettings
{
	[DefaultValue("ColorCars")]
	public string PaintedCarsFolder { get; set; }

	[DefaultValue("false")]
	public bool IsTrafficCapacityAvailable { get; set; }

	[DefaultValue(10)]
	public int TrafficCapacityRoundsNumber { get; set; }

	[DefaultValue(2)]
	public int MaximumTimeForAutomaticIncrease { get; set; }

	[DefaultValue("BothLane")]
	public ChartViewMode ChartViewMode { get; set; }

	[DefaultValue("false")]
	public bool CalculateMinimumSpeedValue { get; set; }
}