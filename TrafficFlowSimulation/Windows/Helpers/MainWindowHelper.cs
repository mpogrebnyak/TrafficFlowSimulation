using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EvaluationKernel.Models;
using Microsoft.Practices.ObjectBuilder2;
using Settings;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Constants.Modes;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Models.ChartRenderModels;
using TrafficFlowSimulation.Models.ChartRenderModels.ParametersModels;
using TrafficFlowSimulation.Models.ChartRenderModels.SettingsModels;
using TrafficFlowSimulation.Windows.Components;
using TrafficFlowSimulation.Windows.Models;

namespace TrafficFlowSimulation.Windows.Helpers
{
	public class MainWindowHelper
	{
		private LocalizationWindowHelper _localizationWindowHelper;

		private ChartContextMenuStripComponent _chartContextMenuStripComponent;

		private AllChartsModel _allCharts;

		private ErrorProvider _errorProvider;

		private Dictionary<Type, BindingSource> _bindingSources;

		private readonly Control.ControlCollection _controls;

		public MainWindowHelper(
			LocalizationComponentsModel localizationComponentsModel,
			AllChartsModel allCharts,
			ErrorProvider errorProvider,
			Control.ControlCollection controls
			)
		{
			_localizationWindowHelper = new LocalizationWindowHelper(localizationComponentsModel);
			_chartContextMenuStripComponent = new ChartContextMenuStripComponent(allCharts);
			_allCharts = allCharts;
			_errorProvider = errorProvider;
			_bindingSources = new();
			_controls = controls;
		}

			public void InitializeInterface()
		{
			var slamPanelComponent = new SlamPanelComponent(_controls);
			slamPanelComponent.Initialize();

			InitializeTableLayoutPanelComponent();
			InitializeDrivingModeComponent();
			InitializeLanguageComponent();
			_chartContextMenuStripComponent.Initialize();

			_localizationWindowHelper.LocalizeComponents();
		}

		public void InitializeTableLayoutPanelComponent()
		{
			var basicParametersTableLayoutPanelComponent = new TableLayoutPanelComponent(
				typeof(BasicParametersModel),
				_controls.Find(ControlName.MainWindowControlName.BasicParametersTableLayoutPanel, true).Single() as TableLayoutPanel, 
				_bindingSources,
				_errorProvider);
			basicParametersTableLayoutPanelComponent.Initialize();

			var additionalParametersTableLayoutPanelComponent = new TableLayoutPanelComponent(
				typeof(AdditionalParametersModel),
				_controls.Find(ControlName.MainWindowControlName.AdditionalParametersTableLayoutPanel, true).Single() as TableLayoutPanel, 
				_bindingSources,
				_errorProvider);
			additionalParametersTableLayoutPanelComponent.Initialize();

			var initialConditionsTableLayoutPanelComponent = new TableLayoutPanelComponent(
				typeof(InitialConditionsParametersModel),
				_controls.Find(ControlName.MainWindowControlName.InitialConditionsTableLayoutPanel, true).Single() as TableLayoutPanel, 
				_bindingSources,
				_errorProvider);
			initialConditionsTableLayoutPanelComponent.Initialize();

			InitializeModeSettingsTableLayoutPanelComponent();
		}

		public void InitializeModeSettingsTableLayoutPanelComponent()
		{
			var currentDrivingMode = SettingsHelper.Get<Properties.Settings>().CurrentDrivingMode;
			var settingsTableLayoutPanel = _controls.Find(ControlName.MainWindowControlName.SettingsTableLayoutPanel, true).Single() as TableLayoutPanel; 

			TableLayoutPanelComponent? settingsTableLayoutPanelComponent = null;

			switch (currentDrivingMode)
			{
				case DrivingMode.StartAndStopMovement:
				{
					settingsTableLayoutPanelComponent = new TableLayoutPanelComponent(
						typeof(StartAndStopMovementModeSettingsModel),
						settingsTableLayoutPanel,
						_bindingSources,
						_errorProvider);
					break;
				}
				case DrivingMode.TrafficThroughOneTrafficLight:
				{
					settingsTableLayoutPanelComponent = new TableLayoutPanelComponent(
						typeof(MovementThroughOneTrafficLightModeSettingsModel),
						settingsTableLayoutPanel,
						_bindingSources,
						_errorProvider);
					break;
				}
				case DrivingMode.InliningInFlow:
				{
					settingsTableLayoutPanelComponent = new TableLayoutPanelComponent(
						typeof(InliningInFlowModeSettingsModel),
						settingsTableLayoutPanel,
						_bindingSources,
						_errorProvider);
					break;
				}
				case DrivingMode.SpeedLimitChanging:
				{
					settingsTableLayoutPanelComponent = new TableLayoutPanelComponent(
						typeof(SpeedLimitChangingModeSettingsModel),
						settingsTableLayoutPanel,
						_bindingSources,
						_errorProvider);
					break;
				}
			}

			settingsTableLayoutPanelComponent?.Initialize();
		}

		private void InitializeDrivingModeComponent()
		{
			var controlMenuStrip = _controls.Find(ControlName.MainWindowControlName.ControlMenuStrip, true).Single() as ToolStrip;
			var drivingModeStripDropDownButton = controlMenuStrip?.Items.Find(ControlName.MainWindowControlName.DrivingModeStripDropDownButton, false).Single() as ToolStripDropDownButton;

			if (drivingModeStripDropDownButton != null)
			{
				var drivingModeComponent = new DrivingModeComponent(drivingModeStripDropDownButton);
				drivingModeComponent.Initialize();
			}
		}

		private void InitializeLanguageComponent()
		{
			var controlMenuStrip = _controls.Find(ControlName.MainWindowControlName.ControlMenuStrip, true).Single() as ToolStrip;
			var languagesSwitcherButton = controlMenuStrip?.Items.Find(ControlName.MainWindowControlName.LanguagesSwitcherButton, false).Single() as ToolStripDropDownButton;

			if (languagesSwitcherButton != null)
			{
				var languageComponent = new LanguageComponent(languagesSwitcherButton);
				languageComponent.Initialize();
			}
		}

		public BaseSettingsModels CollectModeSettingsFromBindingSource(ModelParameters modelParameters)
		{
			var currentDrivingMode = SettingsHelper.Get<Properties.Settings>().CurrentDrivingMode;
			_bindingSources.ForEach(x => x.Value.EndEdit());

			var modeSettings = new BaseSettingsModels();
			switch (currentDrivingMode)
			{
				case DrivingMode.StartAndStopMovement:
				{
					modeSettings = (StartAndStopMovementModeSettingsModel) _bindingSources[typeof(StartAndStopMovementModeSettingsModel)].DataSource;
					break;
				}
				case DrivingMode.TrafficThroughOneTrafficLight:
				{
					modeSettings = (MovementThroughOneTrafficLightModeSettingsModel) _bindingSources[typeof(MovementThroughOneTrafficLightModeSettingsModel)].DataSource;
					break;
				}
				case DrivingMode.InliningInFlow:
				{
					modeSettings = (InliningInFlowModeSettingsModel) _bindingSources[typeof(InliningInFlowModeSettingsModel)].DataSource;
					break;
				}
				case DrivingMode.SpeedLimitChanging:
				{
					modeSettings = (SpeedLimitChangingModeSettingsModel) _bindingSources[typeof(SpeedLimitChangingModeSettingsModel)].DataSource;
					break;
				}
			}
			modeSettings.MapTo(modelParameters);

			return modeSettings;
		}

		public ModelParameters CollectParametersFromBindingSource()
		{
			var modelParameters = new ModelParameters();
			_bindingSources.ForEach(x => x.Value.EndEdit());

			((BasicParametersModel)_bindingSources[typeof(BasicParametersModel)].DataSource).MapTo(modelParameters);
			((AdditionalParametersModel)_bindingSources[typeof(AdditionalParametersModel)].DataSource).MapTo(modelParameters);
			((InitialConditionsParametersModel)_bindingSources[typeof(InitialConditionsParametersModel)].DataSource).MapTo(modelParameters);

			return modelParameters;
		}

		public void LocalizeComponents()
		{
			_chartContextMenuStripComponent.Initialize();

			_localizationWindowHelper.LocalizeComponents();

			_localizationWindowHelper.LocalizePanel(typeof(BasicParametersModel),
				_controls.Find(ControlName.MainWindowControlName.BasicParametersTableLayoutPanel, true).Single() as TableLayoutPanel);
			_localizationWindowHelper.LocalizePanel(typeof(AdditionalParametersModel),
				_controls.Find(ControlName.MainWindowControlName.AdditionalParametersTableLayoutPanel, true).Single() as TableLayoutPanel);
			_localizationWindowHelper.LocalizePanel(typeof(InitialConditionsParametersModel),
				_controls.Find(ControlName.MainWindowControlName.InitialConditionsTableLayoutPanel, true).Single() as TableLayoutPanel);

			var currentDrivingMode = SettingsHelper.Get<Properties.Settings>().CurrentDrivingMode;
			var settingsTableLayoutPanel = _controls.Find(ControlName.MainWindowControlName.SettingsTableLayoutPanel, true).Single() as TableLayoutPanel; 

			switch (currentDrivingMode)
			{
				case DrivingMode.StartAndStopMovement:
				{
					_localizationWindowHelper.LocalizePanel(typeof(StartAndStopMovementModeSettingsModel),
						settingsTableLayoutPanel);
					break;
				}
				case DrivingMode.TrafficThroughOneTrafficLight:
				{
					_localizationWindowHelper.LocalizePanel(typeof(MovementThroughOneTrafficLightModeSettingsModel),
						settingsTableLayoutPanel);
					break;
				}
			}
		}

		public void ShowError(string controlName, Exception error)
		{
			var control = _controls.Find(controlName, true).SingleOrDefault();

			if (control == null)
			{
				foreach (var prefix in Prefixes.All())
				{
					control = _controls.Find(prefix + controlName, true).SingleOrDefault();

					if (control != null)
					{
						break;
					}
				}
			}

			if (control == null)
			{
				MessageBox.Show($"Произошла ошибка: {error.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			_errorProvider.SetError(control, error.Message);
		}
	}
}