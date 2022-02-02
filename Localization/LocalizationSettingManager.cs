using System.Globalization;
using System.Threading;

namespace Localization
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
