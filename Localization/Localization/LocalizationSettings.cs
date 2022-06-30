using System.ComponentModel;

namespace Localization.Localization;

public class LocalizationSettings
{
	[DefaultValue("ru,en")]
	public string[] AvailableLocales { get; set; }

	[DefaultValue("ru")]
	public string DefaultLocale { get; set; }

	[DefaultValue("ru")]
	public string CurrentLocale { get; set; }
}