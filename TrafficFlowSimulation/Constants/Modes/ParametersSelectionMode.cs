using Localization.Localization;

namespace TrafficFlowSimulation.Constants.Modes;

public class ParametersSelectionModeResources
{
	// ReSharper disable UnusedMember.Global
	[Translation(Locales.ru, "Оценка расстояния")]
	[Translation(Locales.en, "Distance estimation")]
	public string InliningDistanceEstimation { get; set; }

	[Translation(Locales.ru, "Оценка коэффициента разгона")]
	[Translation(Locales.en, "Acceleration coefficient estimation")]
	public string AccelerationCoefficientEstimation { get; set; }
	// ReSharper restore UnusedMember.Global
}

public enum ParametersSelectionMode
{
	[LocalizedDescription("InliningDistanceEstimation", typeof(ParametersSelectionModeResources))]
	InliningDistanceEstimation = 1,

	[LocalizedDescription("AccelerationCoefficientEstimation", typeof(ParametersSelectionModeResources))]
	AccelerationCoefficientEstimation = 2,
}