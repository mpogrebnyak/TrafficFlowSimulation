using Localization.Localization;

namespace TrafficFlowSimulation.Constants;

public class ParametersSelectionModeResources
{
	// ReSharper disable UnusedMember.Global
	[Translation(Locales.ru, "Оценка расстояния")]
	[Translation(Locales.en, "Distance estimation")]
	public string InliningDistanceEstimation { get; set; }
	// ReSharper restore UnusedMember.Global
}

public enum ParametersSelectionMode
{
	[LocalizedDescription("InliningDistanceEstimation", typeof(ParametersSelectionModeResources))]
	InliningDistanceEstimation = 1,
}