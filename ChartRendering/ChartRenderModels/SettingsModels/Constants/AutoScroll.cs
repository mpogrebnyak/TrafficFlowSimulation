using Localization.Localization;

namespace ChartRendering.ChartRenderModels.SettingsModels.Constants
{
	public class AutoScrollResources
	{
		[Translation(Locales.ru, "Да")]
		[Translation(Locales.en, "Yes")]
		public string Yes { get; set; }

		[Translation(Locales.ru, "Нет")]
		[Translation(Locales.en, "No")]
		public string No { get; set; }
	}

	public enum AutoScroll
	{
		[LocalizedDescription("Yes", typeof(AutoScrollResources))]
		Yes = 2,

		[LocalizedDescription("No", typeof(AutoScrollResources))]
		No = 1
	}
}
