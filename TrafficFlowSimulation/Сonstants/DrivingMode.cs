using Localization.Localization;
using TrafficFlowSimulation.Properties.TranslationResources;

namespace TrafficFlowSimulation.Сonstants;

public enum DrivingMode
{
	[LocalizedDescription("SingleLaneTraffic", typeof(EnumResources))]
	StartAndStopMovement = 1,

	[LocalizedDescription("TrafficThroughOneTrafficLight", typeof(EnumResources))]
	TrafficThroughOneTrafficLight = 2,

	[LocalizedDescription("InliningInFlow", typeof(EnumResources))]
	InliningInFlow = 3,

	[LocalizedDescription("SingleLaneTraffic3", typeof(EnumResources))]
	SingleLaneTraffic3 = 4,
}