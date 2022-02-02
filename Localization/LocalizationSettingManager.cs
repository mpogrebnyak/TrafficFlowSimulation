using System.Threading;

namespace Localization
{
	public static class LocalizationSettingManager
	{
		public static string GetCurrentLocale()
		{
			var currentLocale = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

			return currentLocale;
		}
	}
}
