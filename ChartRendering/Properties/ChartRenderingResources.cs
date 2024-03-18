using Localization.Localization;

// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable InconsistentNaming

namespace ChartRendering.Properties;

public abstract class ChartRenderingResources
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

	[Translation(Locales.ru, "\nПропускная способность: \n")]
	public string TrafficCapacityLabelHead { get; set; }

	[Translation(Locales.ru, "{seconds} c. - {value}")]
	public abstract string TrafficCapacity(int seconds, string value);

	[Translation(Locales.ru, "Процент снижения скорости при k={k}")]
	[Translation(Locales.en, "Percentage of speed reduction at k={k}")]
	public abstract string SpeedReductionTitle(double k);

	[Translation(Locales.ru, "Авария")]
	[Translation(Locales.en, "Crash")]
	public string CrashTitle { get; set; }

	[Translation(Locales.ru, "t")]
	[Translation(Locales.en, "t")]
	public string T { get; set; }

	[Translation(Locales.ru, "x")]
	[Translation(Locales.en, "x")]
	public string X { get; set; }

	[Translation(Locales.ru, "ẋ")]
	[Translation(Locales.en, "ẋ")]
	public string DotX { get; set; }

	[Translation(Locales.ru, "t (c)")]
	[Translation(Locales.en, "t (s)")]
	public string TWithMeasurements { get; set; }

	[Translation(Locales.ru, "x (м)")]
	[Translation(Locales.en, "x (m)")]
	public string XWithMeasurements { get; set; }

	[Translation(Locales.ru, "ẋ (м/с)")]
	[Translation(Locales.en, "ẋ (m/c)")]
	public string DotXWithMeasurements { get; set; }
}