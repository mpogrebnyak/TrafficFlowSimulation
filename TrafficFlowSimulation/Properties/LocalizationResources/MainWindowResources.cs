using Localization.Localization;

namespace TrafficFlowSimulation.Properties.LocalizationResources;

public class MainWindowResources
{
	[Translation(Locales.ru, "Старт")]
	[Translation(Locales.en, "Start")]
	public string StartButtonTitle { get; set; }

	[Translation(Locales.ru, "Стоп")]
	[Translation(Locales.en, "Stop")]
	public string StopButtonTitle { get; set; }

	[Translation(Locales.ru, "Продолжить")]
	[Translation(Locales.en, "Continue")]
	public string ContinueButtonTitle { get; set; }

	[Translation(Locales.ru, "Применить")]
	[Translation(Locales.en, "Submit")]
	public string SubmitButtonText { get; set; }

	[Translation(Locales.ru, "Оценка параметров")]
	[Translation(Locales.en, "Parameters evaluation")]
	public string ParametersSelectionButtonText { get; set; }

	[Translation(Locales.ru, "Режим движения:")]
	[Translation(Locales.en, "Driving mode:")]
	public string DrivingModeLabel { get; set; }

	[Translation(Locales.ru, "Нет доступных режимов")]
	[Translation(Locales.en, "No modes available")]
	public string EmptyModeLabel { get; set; }

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

	[Translation(Locales.ru, "Оценить пропускную способность")]
	[Translation(Locales.en, "Estimate traffic capacity ")]
	public string EstimateTrafficCapacityCheckBoxText { get; set; }
}