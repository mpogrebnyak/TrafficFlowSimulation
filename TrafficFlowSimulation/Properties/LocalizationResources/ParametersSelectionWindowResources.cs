using Localization.Localization;

namespace TrafficFlowSimulation.Properties.LocalizationResources;

public class ParametersSelectionWindowResources
{
	[Translation(Locales.ru, "Процент снижения скорости")]
	[Translation(Locales.en, "Percentage of speed reduction")]
	public string SpeedReductionTitle { get; set; }

	[Translation(Locales.ru, "Авария")]
	[Translation(Locales.en, "Crash")]
	public string CrashTitle { get; set; }
}