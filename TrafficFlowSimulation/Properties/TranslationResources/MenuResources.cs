using Localization.Localization;

namespace TrafficFlowSimulation.Properties.TranslationResources
{
	public class MenuResources
	{
		[Translation(Locales.ru, "Русский")]
		[Translation(Locales.en, "English")]
		public string LanguagesSwitcheButtomTitle { get; set; }

		[Translation(Locales.ru, "Старт")]
		[Translation(Locales.en, "Start")]
		public string StartButtonTitle { get; set; }

		[Translation(Locales.ru, "Стоп")]
		[Translation(Locales.en, "Stop")]
		public string StopButtonTitle { get; set; }

		[Translation(Locales.ru, "Продолжить")]
		[Translation(Locales.en, "Continue")]
		public string ContinueButtonTitle { get; set; }

		[Translation(Locales.ru, "Режим движения:")]
		[Translation(Locales.en, "Driving mode:")]
		public string DrivingModeLabel { get; set; }

		[Translation(Locales.ru, "V: {0} \nS: {1}")]
		[Translation(Locales.en, "V: {0} \nS: {1}")]
		public string CarsMovementChartLegendText { get; set; }

		[Translation(Locales.ru, "Скорости и положения:")]
		[Translation(Locales.en, "Speeds and positions:")]
		public string CarsMovementChartLegendTitleText { get; set; }

		[Translation(Locales.ru, "{0}")]
		[Translation(Locales.en, "{0}")]
		public string SpeedChartLegendText { get; set; }

		[Translation(Locales.ru, "Cкорости:")]
		[Translation(Locales.en, "Speeds:")]
		public string SpeedChartLegendTitleText { get; set; }

		[Translation(Locales.ru, "{0}")]
		[Translation(Locales.en, "{0}")]
		public string DistanceChartLegendText { get; set; }

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
	}
}
