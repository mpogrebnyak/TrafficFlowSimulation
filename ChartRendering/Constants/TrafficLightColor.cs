using Localization.Localization;

// ReSharper disable UnusedMember.Global

namespace ChartRendering.Constants;

public class TrafficLightColorResources
{
	[Translation(Locales.ru, "Зел.")]
	[Translation(Locales.en, "Green")]
	public string Green { get; set; }

	[Translation(Locales.ru, "Крас.")]
	[Translation(Locales.en, "Red")]
	public string Red { get; set; }
}

public enum TrafficLightColor
{
	[LocalizedDescription("Green", typeof(TrafficLightColorResources))]
	Green = 1,

	[LocalizedDescription("Red", typeof(TrafficLightColorResources))]
	Red = 2
}