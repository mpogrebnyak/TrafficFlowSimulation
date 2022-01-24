using Localization;

namespace TrafficFlowSimulation.Resources
{
    public class ModuleResources
    {
        [Translation(Locales.ru, "eeeee ee")]
        [Translation(Locales.en, "ttttt")]
        public string InvalidHttpMethod { get; set; }

        [Translation(Locales.ru, "привет")]
        [Translation(Locales.en, "hi")]
        public string eeee { get; set; }
    }
}