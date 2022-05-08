using Localization.Localization;

namespace TrafficFlowSimulation.Properties.TranslationResources;

public class EnumResources
{
	[Translation(Locales.ru, "Движение и остановка")]
	[Translation(Locales.en, "Movement and stopping")]
	public string SingleLaneTraffic { get; set; }

	[Translation(Locales.ru, "Движение через один светофор")]
	[Translation(Locales.en, "Traffic through one traffic light")]
	public string TrafficThroughOneTrafficLight { get; set; }

	[Translation(Locales.ru, "Да")]
	[Translation(Locales.en, "Yes")]
	public string Yes { get; set; }

	[Translation(Locales.ru, "Нет")]
	[Translation(Locales.en, "No")]
	public string No { get; set; }
}