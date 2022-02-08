using Localization;

namespace TrafficFlowSimulation.Properties
{
	public class ParametersResources
	{
		[Translation(Locales.ru, "Параметры движения:")]
		[Translation(Locales.en, "Movement parameters:")]
		public string MovementParametersGroupBoxText { get; set; }

		[Translation(Locales.ru, "Количество автомобилей")]
		[Translation(Locales.en, "Vehicles number")]
		public string VehiclesNumberLabel { get; set; }

		[Translation(Locales.ru, "Максимальная скорость")]
		[Translation(Locales.en, "Maximum speed")]
		public string MaximumSpeedLabel { get; set; }

		[Translation(Locales.ru, "Интенсивность разгона")]
		[Translation(Locales.en, "Acceleration intensity")]
		public string AccelerationIntensityLabel { get; set; }

		[Translation(Locales.ru, "Интенсивность торможения")]
		[Translation(Locales.en, "Deceleration intensity")]
		public string DecelerationIntensityLabel { get; set; }
	}
}
