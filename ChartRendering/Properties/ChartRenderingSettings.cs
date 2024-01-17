using System.ComponentModel;
namespace ChartRendering.Properties;

public class ChartRenderingSettings
{
	[DefaultValue("ColorCars")]
	public string PaintedCarsFolder { get; set; }

	[DefaultValue("false")]
	public bool IsTrafficCapacityAvailable { get; set; }

	[DefaultValue(10)]
	public int TrafficCapacityTimeInMinutes { get; set; }

	[DefaultValue(2)]
	public int MaximumTimeForAutomaticIncrease { get; set; }
}