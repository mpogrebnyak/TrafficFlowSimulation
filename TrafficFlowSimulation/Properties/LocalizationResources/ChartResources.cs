using Localization.Localization;

namespace TrafficFlowSimulation.Properties.LocalizationResources;

public class ChartResources
{
	[Translation(Locales.ru, "Скорости и положения:")]
	[Translation(Locales.en, "Speeds and positions:")]
	public string CarsMovementChartLegendTitleText { get; set; }

	[Translation(Locales.ru, "Cкорости:")]
	[Translation(Locales.en, "Speeds:")]
	public string SpeedChartLegendTitleText { get; set; }

	[Translation(Locales.ru, "Положения:")]
	[Translation(Locales.en, "Positions:")]
	public string DistanceChartLegendTitleText { get; set; }

	[Translation(Locales.ru, "Время")]
	[Translation(Locales.en, "Time")]
	public string TimeAxisTitleText { get; set; }

	[Translation(Locales.ru, "Cкорость")]
	[Translation(Locales.en, "Speed")]
	public string SpeedAxisTitleText { get; set; }

	[Translation(Locales.ru, "Расстояние")]
	[Translation(Locales.en, "Distance")]
	public string DistanceAxisTitleText { get; set; }

	[Translation(Locales.ru, "V:")]
	[Translation(Locales.en, "V:")]
	public string SpeedText { get; set; }

	[Translation(Locales.ru, "S:")]
	[Translation(Locales.en, "S:")]
	public string DistanceText { get; set; }
}