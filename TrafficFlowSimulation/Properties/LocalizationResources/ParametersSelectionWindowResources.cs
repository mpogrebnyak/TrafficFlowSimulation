using Localization.Localization;

namespace TrafficFlowSimulation.Properties.LocalizationResources;

public abstract class ParametersSelectionWindowResources
{
	[Translation(Locales.ru, "Процент снижения скорости")]
	[Translation(Locales.en, "Percentage of speed reduction")]
	public string SpeedReductionTitle { get; set; }

	[Translation(Locales.ru, "Процент снижения скорости при k={k}")]
	[Translation(Locales.en, "Percentage of speed reduction k={k}")]
	public abstract string SpeedReductionTitle2(double k);

	[Translation(Locales.ru, "Авария")]
	[Translation(Locales.en, "Crash")]
	public string CrashTitle { get; set; }
}