using System.ComponentModel;
using EvaluationKernel.Constants;

namespace EvaluationKernel.Properties;

internal class ModesSettings
{
	[DefaultValue("StartAndStopMovement")]
	public DrivingMode CurrentDrivingMode { get; set; }

	[DefaultValue("StartAndStopMovement, TrafficThroughOneTrafficLight, InliningInFlow, SpeedLimitChanging, RoadHole, ThroughTheDriver")]
	public DrivingMode[] AvailableDrivingModes { get; set; }

	[DefaultValue("InliningDistanceEstimation")]
	public ParametersSelectionMode CurrentParametersSelectionMode { get; set; }

	[DefaultValue("InliningDistanceEstimation, AccelerationCoefficientEstimation, DecelerationCoefficientEstimation")]
	public ParametersSelectionMode[] AvailableParametersSelectionModes { get; set; }
}