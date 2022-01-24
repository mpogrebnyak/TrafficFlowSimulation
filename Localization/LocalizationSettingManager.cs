using System.Linq;

namespace Localization
{
    public static class LocalizationSettingManager
    {
        public static string GetCurrentLocale()
        {
            var availableLocales = LocalizationSettings.AvailableLocales;
            var currentLocale = LocalizationSettings.CurrentLocale;

            if (availableLocales.Contains(currentLocale))
            {
                return currentLocale;
            }

            return LocalizationSettings.DefaultLocale;
        }

        public static void SetLocale(string currentLocale)
        {
            LocalizationSettings.CurrentLocale = currentLocale;
        }
    }
}
