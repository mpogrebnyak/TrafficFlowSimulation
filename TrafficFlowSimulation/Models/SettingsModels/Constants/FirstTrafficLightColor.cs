using Localization.Localization;

namespace TrafficFlowSimulation.Models.SettingsModels.Constants;

public class FirstTrafficLightColorResources
{
	[Translation(Locales.ru, "Зел.")]
	[Translation(Locales.en, "Green")]
	public string Green { get; set; }

	[Translation(Locales.ru, "Крас.")]
	[Translation(Locales.en, "Red")]
	public string Red { get; set; }
}

public enum FirstTrafficLightColor
{
	[LocalizedDescription("Green", typeof(FirstTrafficLightColorResources))]
	Green = 1,

	[LocalizedDescription("Red", typeof(FirstTrafficLightColorResources))]
	Red = 2
}