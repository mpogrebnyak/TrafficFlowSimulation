using Localization.Localization;

namespace ChartRendering.Constants;

public class DrivingModeResources
{
	// ReSharper disable UnusedMember.Global
	[Translation(Locales.ru, "Движение и остановка")]
	[Translation(Locales.en, "Movement and stopping")]
	public string StartAndStopMovement { get; set; }

	[Translation(Locales.ru, "Движение через один светофор")]
	[Translation(Locales.en, "Traffic through one traffic light")]
	public string TrafficThroughOneTrafficLight { get; set; }

	[Translation(Locales.ru, "Движение через произвольное количество светофоров")]
	[Translation(Locales.en, "Traffic through multiple traffic lights")]
	public string TrafficThroughMultipleTrafficLights { get; set; }

	[Translation(Locales.ru, "Встраивание в поток")]
	[Translation(Locales.en, "Inlining in the flow")]
	public string InliningInFlow { get; set; }

	[Translation(Locales.ru, "Изменение скоростного режима")]
	[Translation(Locales.en, "Speed limit changing")]
	public string SpeedLimitChanging { get; set; }

	[Translation(Locales.ru, "Препятствие на дороге")]
	[Translation(Locales.en, "A hole in the road")]
	public string RoadHole { get; set; }

	[Translation(Locales.ru, "Обращать внимание через водителя")]
	public string ThroughTheDriver { get; set; }

	[Translation(Locales.ru, "Обращать внимание через водителя на светофоре")]
	public string TrafficThroughOneTrafficLightThroughTheDriver { get; set; }
	
	[Translation(Locales.ru, "Движение через бутылочное горлышко")]
	public string TrafficThroughBottleneck{ get; set; }

	// ReSharper restore UnusedMember.Global
}

public enum DrivingMode
{
	[LocalizedDescription("StartAndStopMovement", typeof(DrivingModeResources))]
	StartAndStopMovement = 1,

	[LocalizedDescription("TrafficThroughOneTrafficLight", typeof(DrivingModeResources))]
	TrafficThroughOneTrafficLight = 2,

	[LocalizedDescription("TrafficThroughMultipleTrafficLights", typeof(DrivingModeResources))]
	TrafficThroughMultipleTrafficLights = 3,

	[LocalizedDescription("InliningInFlow", typeof(DrivingModeResources))]
	InliningInFlow = 4,

	[LocalizedDescription("SpeedLimitChanging", typeof(DrivingModeResources))]
	SpeedLimitChanging = 5,

	[LocalizedDescription("RoadHole", typeof(DrivingModeResources))]
	RoadHole = 6,

	[LocalizedDescription("ThroughTheDriver", typeof(DrivingModeResources))]
	ThroughTheDriver = 7,

	[LocalizedDescription("TrafficThroughOneTrafficLightThroughTheDriver", typeof(DrivingModeResources))]
	TrafficThroughOneTrafficLightThroughTheDriver = 8,

	[LocalizedDescription("TrafficThroughBottleneck", typeof(DrivingModeResources))]
	TrafficThroughBottleneck = 9
}