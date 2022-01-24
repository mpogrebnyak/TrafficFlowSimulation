namespace Localization
{
    public static class LocalizationSettings
    {
        public static string[] AvailableLocales = {Locales.ru, Locales.en};

        public static readonly string DefaultLocale = Locales.ru;
		
        public static string CurrentLocale = Locales.ru;
    }
}