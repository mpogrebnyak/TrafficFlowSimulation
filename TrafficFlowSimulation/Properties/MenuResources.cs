using Localization;
using Localization.Localization;

namespace TrafficFlowSimulation.Properties
{
	public class MenuResources
	{
		[Translation(Locales.ru, "Русский")]
		[Translation(Locales.en, "English")]
		public string LanguagesSwitcheButtomTitle { get; set; }

		[Translation(Locales.ru, "Старт")]
		[Translation(Locales.en, "Start")]
		public string StartButtonTitle { get; set; }

		[Translation(Locales.ru, "Скорость: {0} \nПоложение: {1}")]
		[Translation(Locales.en, "Speed: {0} \nPosition: {1}")]
		public string CarsMovementChartLegendText { get; set; }

		[Translation(Locales.ru, "V: {0}")]
		[Translation(Locales.en, "V: {0}")]
		public string SpeedChartLegendText { get; set; }
		
		[Translation(Locales.ru, "S: {0}")]
		[Translation(Locales.en, "S: {0}")]
		public string DistanceChartLegendText { get; set; }

		[Translation(Locales.ru, "Да")]
		[Translation(Locales.en, "Yes")]
		public string YesTitle { get; set; }

		[Translation(Locales.ru, "Нет")]
		[Translation(Locales.en, "No")]
		public string NoTitle { get; set; }
	}
}
