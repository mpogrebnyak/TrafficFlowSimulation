using Localization.Localization;
using TrafficFlowSimulation.Properties.TranslationResources;

namespace TrafficFlowSimulation.Сonstants;

public enum DrivingMode
{
	[LocalizedDescription("SingleLaneTraffic", typeof(EnumResources))]
	StartAndStopMovement = 1,

	[LocalizedDescription("TrafficThroughTrafficLights", typeof(EnumResources))]
	TrafficThroughTrafficLights = 2,

	[LocalizedDescription("SingleLaneTraffic3", typeof(EnumResources))]
	SingleLaneTraffic3 = 3,
}