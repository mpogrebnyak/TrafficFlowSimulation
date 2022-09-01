using Localization.Localization;
using TrafficFlowSimulation.Properties.LocalizationResources;

namespace TrafficFlowSimulation.Constants;

public enum DrivingMode
{
	[LocalizedDescription("StartAndStopMovement", typeof(DrivingModeResources))]
	StartAndStopMovement = 1,

	[LocalizedDescription("TrafficThroughOneTrafficLight", typeof(DrivingModeResources))]
	TrafficThroughOneTrafficLight = 2,

	[LocalizedDescription("InliningInFlow", typeof(DrivingModeResources))]
	InliningInFlow = 3,

	[LocalizedDescription("SingleLaneTraffic3", typeof(DrivingModeResources))]
	SingleLaneTraffic3 = 4,
}