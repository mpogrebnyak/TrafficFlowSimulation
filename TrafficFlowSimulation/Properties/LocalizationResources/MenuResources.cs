using Localization.Localization;

namespace TrafficFlowSimulation.Properties.LocalizationResources
{
	public class MenuResources
	{
		[Translation(Locales.ru, "Русский")]
		[Translation(Locales.en, "English")]
		public string LanguagesSwitcheButtomTitle { get; set; }

		[Translation(Locales.ru, "Старт")]
		[Translation(Locales.en, "Start")]
		public string StartButtonTitle { get; set; }

		[Translation(Locales.ru, "Стоп")]
		[Translation(Locales.en, "Stop")]
		public string StopButtonTitle { get; set; }

		[Translation(Locales.ru, "Продолжить")]
		[Translation(Locales.en, "Continue")]
		public string ContinueButtonTitle { get; set; }

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

		[Translation(Locales.ru, "Легенда")]
		[Translation(Locales.en, "Legend")]
		public string LegendToolStripMenuItem { get; set; }

		[Translation(Locales.ru, "Отображать полностью")]
		[Translation(Locales.en, "Display full")]
		public string DisplayLegendFullMenuItem { get; set; }

		[Translation(Locales.ru, "Отображать частично")]
		[Translation(Locales.en, "Display partially")]
		public string DisplayLegendPartiallyMenuItem { get; set; }

		[Translation(Locales.ru, "Скрыть")]
		[Translation(Locales.en, "Hide")]
		public string HideLegendMenuItem { get; set; }

		[Translation(Locales.ru, "Оси")]
		[Translation(Locales.en, "Axes")]
		public string AxesToolStripMenuItem { get; set; }

		[Translation(Locales.ru, "Показать")]
		[Translation(Locales.en, "Display")]
		public string DisplayAxesMenuItem { get; set; }

		[Translation(Locales.ru, "Скрыть")]
		[Translation(Locales.en, "Hide")]
		public string HideAxesMenuItem { get; set; }

		[Translation(Locales.ru, "Показать график скорости от расстояния")]
		[Translation(Locales.en, "Show speed from distance chart")]
		public string ShowSpeedFromDistanceChartMenuItem { get; set; }

		[Translation(Locales.ru, "Сохранить")]
		[Translation(Locales.en, "Save")]
		public string SaveChartToolStripMenuItem { get; set; }

		[Translation(Locales.ru, "Сохранить изображение как ...")]
		[Translation(Locales.en, "Save image as ...")]
		public string SaveImageText { get; set; }

		// Возможно стоит сделать ресурсы для чартов
		[Translation(Locales.ru, "V: {0} \nS: {1}")]
		[Translation(Locales.en, "V: {0} \nS: {1}")]
		public string CarsMovementChartLegendText { get; set; }

		[Translation(Locales.ru, "Скорости и положения:")]
		[Translation(Locales.en, "Speeds and positions:")]
		public string CarsMovementChartLegendTitleText { get; set; }

		[Translation(Locales.ru, "{0}")]
		[Translation(Locales.en, "{0}")]
		public string SpeedChartLegendText { get; set; }

		[Translation(Locales.ru, "Cкорости:")]
		[Translation(Locales.en, "Speeds:")]
		public string SpeedChartLegendTitleText { get; set; }

		[Translation(Locales.ru, "{0}")]
		[Translation(Locales.en, "{0}")]
		public string DistanceChartLegendText { get; set; }

		[Translation(Locales.ru, "Положения:")]
		[Translation(Locales.en, "Positions:")]
		public string DistanceChartLegendTitleText { get; set; }

		[Translation(Locales.ru, "Время")]
		[Translation(Locales.en, "Time")]
		public string TimeAxisTitleText { get; set; }

		[Translation(Locales.ru, "Cкорость")]
		[Translation(Locales.en, "Speed")]
		public string SpeedAxisTitleText { get; set; }

		[Translation(Locales.ru, "Расстояние")]
		[Translation(Locales.en, "Distance")]
		public string DistanceAxisTitleText { get; set; }

		[Translation(Locales.ru, "x")]
		[Translation(Locales.en, "x")]
		public string XAxisTitleText { get; set; }
		
		[Translation(Locales.ru, "y")]
		[Translation(Locales.en, "y")]
		public string YAxisTitleText { get; set; }
		
		[Translation(Locales.ru, "V:")]
		[Translation(Locales.en, "V:")]
		public string SpeedText { get; set; }
		
		[Translation(Locales.ru, "S:")]
		[Translation(Locales.en, "S:")]
		public string DistanceText { get; set; }
	}
}
