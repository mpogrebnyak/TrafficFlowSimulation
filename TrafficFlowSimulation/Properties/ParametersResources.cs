using Localization.Localization;

namespace TrafficFlowSimulation.Properties
{
	public class ParametersResources
	{
		[Translation(Locales.ru, "Параметры движения:")]
		[Translation(Locales.en, "Movement parameters:")]
		public string MovementParametersGroupBoxText { get; set; }

		[Translation(Locales.ru, "Настройки режима:")]
		[Translation(Locales.en, "Mode settings:")]
		public string ModeSettingsGroupBoxText { get; set; }

		[Translation(Locales.ru, "Количество автомобилей")]
		[Translation(Locales.en, "Vehicles number")]
		public string VehiclesNumberLabel { get; set; }

		[Translation(Locales.ru, "Все автомобили одинаковы")]
		[Translation(Locales.en, "All vehicles are the same")]
		public string IdenticalCarsLabel { get; set; }

		[Translation(Locales.ru, "Основные параметры:")]
		[Translation(Locales.en, "Basic parameters:")]
		public string BasicParametersGroupBoxText { get; set; }

		[Translation(Locales.ru, "Время реакции водителя")]
		[Translation(Locales.en, "Driver's response time")]
		public string DriverResponseTimeLabel { get; set; }

		[Translation(Locales.ru, "Максимальная скорость")]
		[Translation(Locales.en, "Maximum speed")]
		public string MaximumSpeedLabel { get; set; }

		[Translation(Locales.ru, "Интенсивность разгона")]
		[Translation(Locales.en, "Acceleration intensity")]
		public string AccelerationIntensityLabel { get; set; }

		[Translation(Locales.ru, "Интенсивность торможения")]
		[Translation(Locales.en, "Deceleration intensity")]
		public string DecelerationIntensityLabel { get; set; }

		[Translation(Locales.ru, "Безопасное расстояние")]
		[Translation(Locales.en, "Safely Distance")]
		public string SafelyDistanceLabel { get; set; }
	}
}
