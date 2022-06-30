using System;
using Settings;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using Localization.Localization;
using Microsoft.Practices.ObjectBuilder2;
using TrafficFlowSimulation.Commands;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Models.ParametersModels;
using TrafficFlowSimulation.Models.SettingsModels;
using TrafficFlowSimulation.Windows.Components;
using TrafficFlowSimulation.Windows.Models;
using TrafficFlowSimulation.Сonstants;

namespace TrafficFlowSimulation.Windows
{
	public class MainWindowHelper
	{
		public LocalizationComponentsModel _localizationComponents;

		public AllChartsModel _allCharts;

		public ErrorProvider _errorProvider;

		public Dictionary<Type, BindingSource> _bindingSources;

		private readonly Control.ControlCollection _controls;

		public MainWindowHelper(
			LocalizationComponentsModel localizationComponentsModel,
			AllChartsModel allCharts,
			ErrorProvider errorProvider,
			Control.ControlCollection controls
			//Component component
			)
		{
			_localizationComponents = localizationComponentsModel;
			_allCharts = allCharts;
			_errorProvider = errorProvider;
			_bindingSources = new();
			_controls = controls;
		}

		public void InitializeInterface()
		{
			InitializeTableLayoutPanelComponent();
			InitializeDrivingModeComponent();
			
			LocalizationService.Translate(_localizationComponents);

			//var defaultModeSettings = ModeSettingsMapper.GetDefault();
			//ModeSettingsBinding.DataSource = defaultModeSettings;

			//MainWindowHelper.ShowCurrentModeSettingsFields(Controls.Owner);
		}
		
		public LocalizationComponentsModel LocalizationComponents => _localizationComponents;

		public AllChartsModel AllCharts => _allCharts;

		public Dictionary<Type, BindingSource> BindingSources => _bindingSources;


		public Chart GetChartFromContextMenu(object o)
		{
			var owner = (o as ToolStripMenuItem).Owner;

			if ((owner as ToolStripDropDownMenu).OwnerItem != null)
			{
				owner = ((owner as ToolStripDropDownMenu).OwnerItem as ToolStripMenuItem).Owner;
			}
			
			return (owner as ContextMenuStrip).SourceControl as Chart;
		}

		public void InitializeTableLayoutPanelComponent()
		{
			var basicParametersTableLayoutPanelComponent = new TableLayoutPanelComponent(
				typeof(BasicParametersModel),
				_controls.Find(ControlName.BasicParametersTableLayoutPanel, true).Single() as TableLayoutPanel, 
				_bindingSources,
				_errorProvider);
			basicParametersTableLayoutPanelComponent.Initialize();

			var additionalParametersTableLayoutPanelComponent = new TableLayoutPanelComponent(
				typeof(AdditionalParametersModel),
				_controls.Find(ControlName.AdditionalParametersTableLayoutPanel, true).Single() as TableLayoutPanel, 
				_bindingSources,
				_errorProvider);
			additionalParametersTableLayoutPanelComponent.Initialize();

			var initialConditionsTableLayoutPanelComponent = new TableLayoutPanelComponent(
				typeof(InitialConditionsParametersModel),
				_controls.Find(ControlName.InitialConditionsTableLayoutPanel, true).Single() as TableLayoutPanel, 
				_bindingSources,
				_errorProvider);
			initialConditionsTableLayoutPanelComponent.Initialize();

			InitializeModeSettingsTableLayoutPanelComponent();
		}

		public void InitializeModeSettingsTableLayoutPanelComponent()
		{
			var currentDrivingMode = SettingsHelper.Get<Properties.Settings>().CurrentDrivingMode;
			var settingsTableLayoutPanel = _controls.Find(ControlName.SettingsTableLayoutPanel, true).Single() as TableLayoutPanel; 

			TableLayoutPanelComponent settingsTableLayoutPanelComponent = null;

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
			}

			settingsTableLayoutPanelComponent?.Initialize();
		}

		public void InitializeDrivingModeComponent()
		{
			var controlMenuStrip = _controls.Find(ControlName.ControlMenuStrip, true).Single() as ToolStrip;
			var drivingModeStripDropDownButton = controlMenuStrip?.Items.Find(ControlName.DrivingModeStripDropDownButton, false).Single() as ToolStripDropDownButton;
			
			if (drivingModeStripDropDownButton != null)
				DrivingModeComponent.Initialize(drivingModeStripDropDownButton);
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

		public void TranslateComponents(string locale)
		{
			var controlMenuStrip = _controls.Find(ControlName.ControlMenuStrip, true).Single() as ToolStrip;
			var languagesSwitcherButton = controlMenuStrip?.Items.Find(ControlName.LanguagesSwitcherButton, true).Single() as ToolStripDropDownButton;
			var settings = SettingsHelper.Get<LocalizationSettings>();

			if (languagesSwitcherButton != null)
			{
				switch (locale)
				{
					case Locales.ru:
					{
						settings.CurrentLocale = Locales.ru;
						languagesSwitcherButton.Image = Properties.Resources.russia;
						break;
					}

					case Locales.en:
					{
						settings.CurrentLocale = Locales.en;
						languagesSwitcherButton.Image = Properties.Resources.united_kingdom;
						break;
					}
				}
			}
			SettingsHelper.Set<LocalizationSettings>(settings);
			InitializeTableLayoutPanelComponent();
			LocalizationService.Translate(_localizationComponents);
		}
	}
}