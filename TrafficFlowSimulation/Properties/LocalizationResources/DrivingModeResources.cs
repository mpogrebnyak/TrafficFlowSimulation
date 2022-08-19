using Localization.Localization;

namespace TrafficFlowSimulation.Properties.LocalizationResources;

public class DrivingModeResources
{
	[Translation(Locales.ru, "Движение и остановка")]
	[Translation(Locales.en, "Movement and stopping")]
	public string SingleLaneTraffic { get; set; }

	[Translation(Locales.ru, "Движение через один светофор")]
	[Translation(Locales.en, "Traffic through one traffic light")]
	public string TrafficThroughOneTrafficLight { get; set; }

	[Translation(Locales.ru, "Встраивание в поток")]
	[Translation(Locales.en, "Inlining in the flow")]
	public string InliningInFlow { get; set; }
}