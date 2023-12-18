using System.ComponentModel;
using Modes.Constants;

namespace ChartRendering.Properties;

public class ChartRenderingSettings
{
	[DefaultValue("ColorCars")]
	public string PaintedCarsFolder { get; set; }

	[DefaultValue(@"\Images")]
	public string ImageFolderName { get; set; }

	[DefaultValue("false")]
	public bool IsTrafficCapacityAvailable { get; set; }
}