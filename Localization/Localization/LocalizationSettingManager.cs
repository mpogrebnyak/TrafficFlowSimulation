using System.Globalization;
using Settings;

namespace Localization.Localization
{
	public static class LocalizationSettingManager
	{
		public static string GetCurrentLocale()
		{
			var availableLocales = SettingsHelper.Get<LocalizationSettings>().AvailableLocales;
			var currentLocale = SettingsHelper.Get<LocalizationSettings>().CurrentLocale;

			if (availableLocales.Contains(currentLocale))
			{
				return currentLocale;
			}

			return SettingsHelper.Get<LocalizationSettings>().DefaultLocale;
		}
	}
}
