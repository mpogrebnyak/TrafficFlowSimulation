using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.ParametersModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Constants.Modes;
using ChartRendering.Models;
using ChartRendering.Properties;
using EvaluationKernel.Models;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.Components;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Windows.Components;
using TrafficFlowSimulation.Windows.Helpers;
using TrafficFlowSimulation.Windows.Models;

namespace TrafficFlowSimulation.Helpers
{
	public class MainWindowHelper
	{
		private readonly LocalizationWindowHelper _localizationWindowHelper;

		private readonly ChartContextMenuStripComponent _chartContextMenuStripComponent;

		private readonly ErrorProvider _errorProvider;

		private readonly Dictionary<Type, BindingSource> _bindingSources;

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
			//_allCharts = allCharts;
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
			var currentDrivingMode = SettingsHelper.Get<ChartRendering.Properties.ChartRenderingSettings>().CurrentDrivingMode;

			var basicParametersModel = ServiceLocator.Current.GetInstance<IBasicParametersModel>(currentDrivingMode.ToString());
			var basicParametersTableLayoutPanelComponent = new TableLayoutPanelComponent(
				basicParametersModel,
				_controls.Find(ControlName.MainWindowControlName.BasicParametersTableLayoutPanel, true).Single() as TableLayoutPanel, 
				_bindingSources,
				_errorProvider);
			basicParametersTableLayoutPanelComponent.Initialize();

			var additionalParametersModel = ServiceLocator.Current.GetInstance<IAdditionalParametersModel>(currentDrivingMode.ToString());
			var additionalParametersTableLayoutPanelComponent = new TableLayoutPanelComponent(
				additionalParametersModel,
				_controls.Find(ControlName.MainWindowControlName.AdditionalParametersTableLayoutPanel, true).Single() as TableLayoutPanel, 
				_bindingSources,
				_errorProvider);
			additionalParametersTableLayoutPanelComponent.Initialize();

			var initialConditionsParametersModel = ServiceLocator.Current.GetInstance<IInitialConditionsParametersModel>(currentDrivingMode.ToString());
			var initialConditionsTableLayoutPanelComponent = new TableLayoutPanelComponent(
				initialConditionsParametersModel,
				_controls.Find(ControlName.MainWindowControlName.InitialConditionsTableLayoutPanel, true).Single() as TableLayoutPanel, 
				_bindingSources,
				_errorProvider);
			initialConditionsTableLayoutPanelComponent.Initialize();

			InitializeModeSettingsTableLayoutPanelComponent();
		}

		private void InitializeModeSettingsTableLayoutPanelComponent()
		{
			var currentDrivingMode = SettingsHelper.Get<ChartRendering.Properties.ChartRenderingSettings>().CurrentDrivingMode;
			var settingsTableLayoutPanel = _controls.Find(ControlName.MainWindowControlName.SettingsTableLayoutPanel, true).Single() as TableLayoutPanel; 

			var settingsModel = ServiceLocator.Current.GetInstance<ISettingsModel>(currentDrivingMode.ToString());

			var settingsTableLayoutPanelComponent = new TableLayoutPanelComponent(
				settingsModel,
				settingsTableLayoutPanel,
				_bindingSources,
				_errorProvider);

			settingsTableLayoutPanelComponent.Initialize();
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
			var currentDrivingMode = SettingsHelper.Get<ChartRendering.Properties.ChartRenderingSettings>().CurrentDrivingMode;
			_bindingSources.ForEach(x => x.Value.EndEdit());

			var settingsModel = ServiceLocator.Current.GetInstance<ISettingsModel>(currentDrivingMode.ToString());

			var modeSettings = (BaseSettingsModels)_bindingSources[settingsModel.GetType()].DataSource;
			modeSettings.MapTo(modelParameters);

			return modeSettings;
		}

		public ModelParameters CollectParametersFromBindingSource()
		{
			var modelParameters = new ModelParameters();

			var currentDrivingMode = SettingsHelper.Get<ChartRendering.Properties.ChartRenderingSettings>().CurrentDrivingMode;
			_bindingSources.ForEach(x => x.Value.EndEdit());

			var basicParametersModel = ServiceLocator.Current.GetInstance<IBasicParametersModel>(currentDrivingMode.ToString());
			var additionalParametersModel = ServiceLocator.Current.GetInstance<IAdditionalParametersModel>(currentDrivingMode.ToString());
			var initialConditionsParametersModel = ServiceLocator.Current.GetInstance<IInitialConditionsParametersModel>(currentDrivingMode.ToString());

			((IBasicParametersModel)_bindingSources[basicParametersModel.GetType()].DataSource).MapTo(modelParameters);
			((IAdditionalParametersModel)_bindingSources[additionalParametersModel.GetType()].DataSource).MapTo(modelParameters);
			((IInitialConditionsParametersModel)_bindingSources[initialConditionsParametersModel.GetType()].DataSource).MapTo(modelParameters);

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

			var currentDrivingMode = SettingsHelper.Get<ChartRenderingSettings>().CurrentDrivingMode;
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