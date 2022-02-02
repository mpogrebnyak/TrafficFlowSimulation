using Localization;

namespace TrafficFlowSimulation.Resources
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
        public string ChartLegendText { get; set; }
    }
}
