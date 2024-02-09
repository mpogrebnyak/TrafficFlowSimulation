using Localization.Localization;

namespace EvaluationKernel.Constants;

public class DrivingModeResources
{
	// ReSharper disable UnusedMember.Global
	[Translation(Locales.ru, "Движение и остановка")]
	[Translation(Locales.en, "Movement and stopping")]
	public string StartAndStopMovement { get; set; }

	[Translation(Locales.ru, "Движение через один светофор")]
	[Translation(Locales.en, "Traffic through one traffic light")]
	public string TrafficThroughOneTrafficLight { get; set; }

	[Translation(Locales.ru, "Встраивание в поток")]
	[Translation(Locales.en, "Inlining in the flow")]
	public string InliningInFlow { get; set; }

	[Translation(Locales.ru, "Изменение скоростного режима")]
	[Translation(Locales.en, "Speed limit changing")]
	public string SpeedLimitChanging { get; set; }

	[Translation(Locales.ru, "Препятствие на дороге")]
	[Translation(Locales.en, "A hole in the road")]
	public string RoadHole { get; set; }

	// ReSharper restore UnusedMember.Global
}

public enum DrivingMode
{
	[LocalizedDescription("StartAndStopMovement", typeof(DrivingModeResources))]
	StartAndStopMovement = 1,

	[LocalizedDescription("TrafficThroughOneTrafficLight", typeof(DrivingModeResources))]
	TrafficThroughOneTrafficLight = 2,

	[LocalizedDescription("InliningInFlow", typeof(DrivingModeResources))]
	InliningInFlow = 3,

	[LocalizedDescription("SpeedLimitChanging", typeof(DrivingModeResources))]
	SpeedLimitChanging = 4,

	[LocalizedDescription("RoadHole", typeof(DrivingModeResources))]
	RoadHole = 5
}