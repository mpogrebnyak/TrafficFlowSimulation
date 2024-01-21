using Localization.Localization;

// ReSharper disable UnusedMember.Global

namespace ChartRendering.Constants;

public class SaveChartResources
{
	[Translation(Locales.ru, "Да")]
	[Translation(Locales.en, "Yes")]
	public string Yes { get; set; }

	[Translation(Locales.ru, "Нет")]
	[Translation(Locales.en, "No")]
	public string No { get; set; }
}

public enum SaveChart
{
	[LocalizedDescription("Yes", typeof(SaveChartResources))]
	Yes = 1,

	[LocalizedDescription("No", typeof(SaveChartResources))]
	No = 2
}