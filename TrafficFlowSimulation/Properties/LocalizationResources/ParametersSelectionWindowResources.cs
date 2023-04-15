using Localization.Localization;

namespace TrafficFlowSimulation.Properties.LocalizationResources;

public abstract class ParametersSelectionWindowResources
{
	[Translation(Locales.ru, "Процент снижения скорости")]
	[Translation(Locales.en, "Percentage of speed reduction")]
	public string SpeedReductionTitle { get; set; }

	[Translation(Locales.ru, "Процент снижения скорости {k}")]
	[Translation(Locales.en, "Percentage of speed reduction {k}")]
	public abstract string SpeedReductionTitle2(int k);

	[Translation(Locales.ru, "Авария")]
	[Translation(Locales.en, "Crash")]
	public string CrashTitle { get; set; }
}