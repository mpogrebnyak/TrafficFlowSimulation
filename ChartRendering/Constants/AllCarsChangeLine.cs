using Localization.Localization;

namespace ChartRendering.Constants;

public class AllCarsChangeLineResources
{
	[Translation(Locales.ru, "Да")]
	[Translation(Locales.en, "Yes")]
	public string Yes { get; set; }

	[Translation(Locales.ru, "Нет")]
	[Translation(Locales.en, "No")]
	public string No { get; set; }
}

public enum AllCarsChangeLine
{
	[LocalizedDescription("Yes", typeof(AllCarsChangeLineResources))]
	Yes = 2,

	[LocalizedDescription("No", typeof(AllCarsChangeLineResources))]
	No = 1
}