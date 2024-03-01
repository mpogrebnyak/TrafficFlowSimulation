using System.ComponentModel;
using ChartRendering.Constants;
using ChartRendering.Helpers;

namespace ChartRendering.Properties;

internal class ModesSettings
{
	[DefaultValue("StartAndStopMovement")]
	public DrivingMode CurrentDrivingMode { get; set; }

	[DefaultValue("StartAndStopMovement, TrafficThroughOneTrafficLight, InliningInFlow, SpeedLimitChanging, RoadHole, ThroughTheDriver, TrafficThroughOneTrafficLightThroughTheDriver")]
	public DrivingMode[] AvailableDrivingModes { get; set; }

	[DefaultValue("InliningDistanceEstimation")]
	public ParametersSelectionMode CurrentParametersSelectionMode { get; set; }

	[DefaultValue("InliningDistanceEstimation, AccelerationCoefficientEstimation, DecelerationCoefficientEstimation")]
	public ParametersSelectionMode[] AvailableParametersSelectionModes { get; set; }
}