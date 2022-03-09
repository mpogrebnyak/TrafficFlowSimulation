using Localization.Localization;
using TrafficFlowSimulation.Properties.TranslationResources;

namespace TrafficFlowSimulation.Сonstants;

public enum DrivingMode
{
	[LocalizedDescription("SingleLaneTraffic", typeof(EnumResources))]
	SingleLaneTraffic = 1,

	[LocalizedDescription("SingleLaneTraffic2", typeof(EnumResources))]
	SingleLaneTraffic2 = 2,

	[LocalizedDescription("SingleLaneTraffic3", typeof(EnumResources))]
	SingleLaneTraffic3 = 3,
}