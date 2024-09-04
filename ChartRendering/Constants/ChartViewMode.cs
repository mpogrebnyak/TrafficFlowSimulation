using Localization.Localization;

namespace ChartRendering.Constants;

public class ChartViewModeResources
{
	// ReSharper disable UnusedMember.Global
	[Translation(Locales.ru, "Отображать только первый поток")]
	public string OnlyFirstLane { get; set; }

	[Translation(Locales.ru, "Отображать только второй поток")]
	public string OnlySecondLane { get; set; }

	[Translation(Locales.ru, "Отображать оба потока")]
	public string BothLane { get; set; }
	// ReSharper restore UnusedMember.Global
}

public enum ChartViewMode
{
	[LocalizedDescription("OnlyFirstLane", typeof(ChartViewModeResources))]
	OnlyFirstLane = 1,

	[LocalizedDescription("OnlySecondLane", typeof(ChartViewModeResources))]
	OnlySecondLane = 2,

	[LocalizedDescription("BothLane", typeof(ChartViewModeResources))]
	BothLane = 3,
}