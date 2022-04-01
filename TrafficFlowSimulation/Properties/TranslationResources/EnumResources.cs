using Localization.Localization;

namespace TrafficFlowSimulation.Properties.TranslationResources;

public class EnumResources
{
	[Translation(Locales.ru, "Движение и остановка")]
	[Translation(Locales.en, "Movement and stopping")]
	public string SingleLaneTraffic { get; set; }

	[Translation(Locales.ru, "Движение через светофоры")]
	[Translation(Locales.en, "Traffic through traffic lights")]
	public string TrafficThroughTrafficLights { get; set; }

	[Translation(Locales.ru, "Да")]
	[Translation(Locales.en, "Yes")]
	public string Yes { get; set; }

	[Translation(Locales.ru, "Нет")]
	[Translation(Locales.en, "No")]
	public string No { get; set; }
}