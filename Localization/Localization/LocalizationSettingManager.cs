using System.Globalization;

namespace Localization.Localization
{
	public static class LocalizationSettingManager
	{
		public static string GetCurrentLocale()
		{
			var currentLocale = CultureInfo.DefaultThreadCurrentCulture.TwoLetterISOLanguageName;

			return currentLocale;
		}
	}
}
