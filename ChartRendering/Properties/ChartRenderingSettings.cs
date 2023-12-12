using System.ComponentModel;
using ChartRendering.Constants.Modes;
using TrafficFlowSimulation.Constants.Modes;

namespace ChartRendering.Properties;

public class ChartRenderingSettings
{
	public DrivingMode CurrentDrivingMode { get; set; }

	[DefaultValue("StartAndStopMovement, TrafficThroughOneTrafficLight, InliningInFlow, SpeedLimitChanging")]
	public DrivingMode[] AvailableDrivingModes { get; set; }

	public ParametersSelectionMode CurrentParametersSelectionMode { get; set; }

	[DefaultValue("InliningDistanceEstimation, AccelerationCoefficientEstimation, DecelerationCoefficientEstimation")]
	public ParametersSelectionMode[] AvailableParametersSelectionModes { get; set; }

	[DefaultValue("ColorCars")]
	public string PaintedCarsFolder { get; set; }

	[DefaultValue(@"\Images")]
	public string ImageFolderName { get; set; }

	[DefaultValue("false")]
	public bool IsTrafficCapacityAvailable { get; set; }
}