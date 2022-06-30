using Localization.Localization;

namespace TrafficFlowSimulation.Properties.TranslationResources
{
	public class ParametersResources
	{
		[Translation(Locales.ru, "Параметры движения:")]
		[Translation(Locales.en, "Movement parameters:")]
		public string MovementParametersGroupBoxText { get; set; }

		[Translation(Locales.ru, "Настройки режима:")]
		[Translation(Locales.en, "Mode settings:")]
		public string ModeSettingsGroupBoxText { get; set; }

		[Translation(Locales.ru, "Основные параметры:")]
		[Translation(Locales.en, "Basic parameters:")]
		public string BasicParametersGroupBoxText { get; set; }

		[Translation(Locales.ru, "Дополнительные параметры:")]
		[Translation(Locales.en, "Additional parameters:")]
		public string AdditionalParametersGroupBoxText { get; set; }

		[Translation(Locales.ru, "Начальные условия:")]
		[Translation(Locales.en, "Initial conditions:")]
		public string InitialConditionsGroupBoxText { get; set; }

		[Translation(Locales.ru, "Элементы управления:")]
		[Translation(Locales.en, "Controls:")]
		public string ControlsGroupBoxText { get; set; }
	}
}
