using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.ParametersModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Constants;
using ChartRendering.Events;
using ChartRendering.Helpers;
using EvaluationKernel.Models;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.ServiceLocation;
using TrafficFlowSimulation.Components;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Handlers;
using TrafficFlowSimulation.Windows;
using TrafficFlowSimulation.Windows.Components;

namespace TrafficFlowSimulation.Helpers
{
	public class MainWindowHelper
	{
		public readonly ChartEventHandler ChartEventHandler;

		private readonly MainWindow _mainWindow;

		private readonly LocalizationWindowHelper _localizationWindowHelper;

		private readonly ChartContextMenuStripComponent _chartContextMenuStripComponent;

		private readonly ErrorProvider _errorProvider;

		private readonly Dictionary<Type, BindingSource> _bindingSources;

		private readonly Control.ControlCollection _controls;

		public MainWindowHelper(MainWindow form)
		{
			_mainWindow = form;
			_bindingSources = new();
			_localizationWindowHelper = new LocalizationWindowHelper(form, _bindingSources);
			_chartContextMenuStripComponent = new ChartContextMenuStripComponent(form);
			_errorProvider = form.ParametersErrorProvider;
			_controls = form.Controls;

			var formUpdateHandler = new FormUpdateHandler(form, ModesHelper.DrivingModeType);
			ChartEventHandler = formUpdateHandler.GetEvent();
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
			var currentDrivingMode = ModesHelper.GetCurrentDrivingMode();

			var basicParametersModel = ServiceLocator.Current.GetInstance<IBaseParametersModel>(currentDrivingMode);
			var basicParametersTableLayoutPanelComponent = new TableLayoutPanelComponent(
				basicParametersModel,
				_controls.Find(ControlName.MainWindowControlName.BasicParametersTableLayoutPanel, true).Single() as TableLayoutPanel, 
				_bindingSources,
				_errorProvider);
			basicParametersTableLayoutPanelComponent.Initialize();

			var additionalParametersModel = ServiceLocator.Current.GetInstance<IAdditionalParametersModel>(currentDrivingMode);
			var additionalParametersTableLayoutPanelComponent = new TableLayoutPanelComponent(
				additionalParametersModel,
				_controls.Find(ControlName.MainWindowControlName.AdditionalParametersTableLayoutPanel, true).Single() as TableLayoutPanel, 
				_bindingSources,
				_errorProvider);
			additionalParametersTableLayoutPanelComponent.Initialize();

			var initialConditionsParametersModel = ServiceLocator.Current.GetInstance<IInitialConditionsParametersModel>(currentDrivingMode);
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
			var currentDrivingMode = ModesHelper.GetCurrentDrivingMode();
			var settingsTableLayoutPanel = _controls.Find(ControlName.MainWindowControlName.SettingsTableLayoutPanel, true).Single() as TableLayoutPanel; 

			var settingsModel = ServiceLocator.Current.GetInstance<ISettingsModel>(currentDrivingMode);

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
				if (_controls.Find(ControlName.CommonControlName.ParametersPanelName, true).Single() is not Panel parametersPanel)
					parametersPanel = null!;

				var drivingModeComponent = new DrivingModeComponent(drivingModeStripDropDownButton, parametersPanel);
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
			var currentDrivingMode = ModesHelper.GetCurrentDrivingMode();
			_bindingSources.ForEach(x => x.Value.EndEdit());

			var settingsModel = ServiceLocator.Current.GetInstance<ISettingsModel>(currentDrivingMode);

			var modeSettings = (BaseSettingsModels)_bindingSources[settingsModel.GetType()].DataSource;
			modeSettings.MapTo(modelParameters);
			modeSettings.MapToSelf();

			return modeSettings;
		}

		public ModelParameters CollectParametersFromBindingSource()
		{
			var modelParameters = new ModelParameters();

			var currentDrivingMode = ModesHelper.GetCurrentDrivingMode();
			_bindingSources.ForEach(x => x.Value.EndEdit());

			var basicParametersModel = ServiceLocator.Current.GetInstance<IBaseParametersModel>(currentDrivingMode);
			var additionalParametersModel = ServiceLocator.Current.GetInstance<IAdditionalParametersModel>(currentDrivingMode);
			var initialConditionsParametersModel = ServiceLocator.Current.GetInstance<IInitialConditionsParametersModel>(currentDrivingMode);

			((IBaseParametersModel)_bindingSources[basicParametersModel.GetType()].DataSource).MapTo(modelParameters);
			((IAdditionalParametersModel)_bindingSources[additionalParametersModel.GetType()].DataSource).MapTo(modelParameters);
			((IInitialConditionsParametersModel)_bindingSources[initialConditionsParametersModel.GetType()].DataSource).MapTo(modelParameters);

			return modelParameters;
		}

		public bool IsParametersValid()
		{
			foreach (var source in _bindingSources)
			{
				var dataSource = source.Value.DataSource;
				var errors = ((ValidationModel) dataSource).Error;

				if (errors != null)
				{
					return false;
				}
			}

			return true;
		}

		public void LocalizeComponents()
		{
			_chartContextMenuStripComponent.Initialize();

			_localizationWindowHelper.LocalizeComponents();

			_localizationWindowHelper.LocalizePanel(typeof(BaseParametersModel),
				_controls.Find(ControlName.MainWindowControlName.BasicParametersTableLayoutPanel, true).Single() as TableLayoutPanel);
			_localizationWindowHelper.LocalizePanel(typeof(AdditionalParametersModel),
				_controls.Find(ControlName.MainWindowControlName.AdditionalParametersTableLayoutPanel, true).Single() as TableLayoutPanel);
			_localizationWindowHelper.LocalizePanel(typeof(InitialConditionsParametersModel),
				_controls.Find(ControlName.MainWindowControlName.InitialConditionsTableLayoutPanel, true).Single() as TableLayoutPanel);

			var currentDrivingMode = (DrivingMode)Enum.Parse(typeof(DrivingMode), ModesHelper.GetCurrentDrivingMode());
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

		public void ResizeAllChart()
		{
			ResizeChart(_mainWindow.DistanceChart);
			ResizeChart(_mainWindow.SpeedChart);
			ResizeChart(_mainWindow.SpeedFromDistanceChart);
		}

		public void ResizeChart(Chart chart)
		{
			if (chart.Visible == false)
				return;

			chart.Update();
			foreach (var chartArea in chart.ChartAreas)
			{
				ChartAreaRendersHelper.CreateCustomLabels(chartArea.AxisX, Math.Abs(chartArea.AxisX.ValueToPixelPosition(0) - chartArea.AxisX.ValueToPixelPosition(1)));
				ChartAreaRendersHelper.CreateCustomLabels(chartArea.AxisY, Math.Abs(chartArea.AxisY.ValueToPixelPosition(0) - chartArea.AxisY.ValueToPixelPosition(1)));
			}
		}
	}
}