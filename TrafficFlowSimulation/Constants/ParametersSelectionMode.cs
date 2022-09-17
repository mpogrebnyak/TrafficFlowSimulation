using Localization.Localization;

namespace TrafficFlowSimulation.Constants;

public class ParametersSelectionModeResources
{
	// ReSharper disable UnusedMember.Global
	[Translation(Locales.ru, "Оценка расстояния")]
	[Translation(Locales.en, "Distance estimation")]
	public string InliningDistance { get; set; }

	[Translation(Locales.ru, "Оценка изменения расстояния")]
	[Translation(Locales.en, "Estimation of distance change")]
	public string InliningDistanceChanging { get; set; }
	// ReSharper restore UnusedMember.Global
}

public enum ParametersSelectionMode
{
	[LocalizedDescription("InliningDistanceChanging", typeof(ParametersSelectionModeResources))]
	InliningDistanceChanging = 1,
}