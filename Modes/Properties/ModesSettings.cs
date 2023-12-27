using System.ComponentModel;
using Modes.Constants;

namespace Modes.Properties;

internal class ModesSettings
{
	[DefaultValue("StartAndStopMovement")]
	public DrivingMode CurrentDrivingMode { get; set; }

	[DefaultValue("StartAndStopMovement, TrafficThroughOneTrafficLight, InliningInFlow, SpeedLimitChanging, RoadHole")]
	public DrivingMode[] AvailableDrivingModes { get; set; }

	[DefaultValue("InliningDistanceEstimation")]
	public ParametersSelectionMode CurrentParametersSelectionMode { get; set; }

	[DefaultValue("InliningDistanceEstimation, AccelerationCoefficientEstimation, DecelerationCoefficientEstimation")]
	public ParametersSelectionMode[] AvailableParametersSelectionModes { get; set; }
}