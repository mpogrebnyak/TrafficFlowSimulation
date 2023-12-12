using Localization.Localization;

namespace ChartRendering.Constants;

// ReSharper disable UnusedMember.Global

public class IdenticalCarsResources
{
	[Translation(Locales.ru, "Да")]
	[Translation(Locales.en, "Yes")]
	public string Yes { get; set; }

	[Translation(Locales.ru, "Нет")]
	[Translation(Locales.en, "No")]
	public string No { get; set; }
}

public enum IdenticalCars
{
	[LocalizedDescription("Yes", typeof(IdenticalCarsResources))]
	Yes = 1,

	[LocalizedDescription("No", typeof(IdenticalCarsResources))]
	No = 2
}
