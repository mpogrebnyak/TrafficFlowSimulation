using System;
using Settings;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
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
		private LocalizationComponentsModel _localizationComponents;

		private AllChartsModel _allCharts;

		private TableLayoutPanelsModel _tableLayoutPanels;

		private ErrorProvider _errorProvider;

		private Dictionary<Type, BindingSource> _bindingSources;

		public MainWindowHelper(
			LocalizationComponentsModel localizationComponentsModel,
			AllChartsModel allCharts,
			TableLayoutPanelsModel tableLayoutPanels,
			ErrorProvider errorProvider)
		{
			_localizationComponents = localizationComponentsModel;
			_allCharts = allCharts;
			_tableLayoutPanels = tableLayoutPanels;
			_errorProvider = errorProvider;
			_bindingSources = new();
		}

		public void InitializeInterface()
		{
			InitializeTableLayoutPanelComponent();
			LocalizationService.Translate(_localizationComponents);

			//var defaultModeSettings = ModeSettingsMapper.GetDefault();
			//ModeSettingsBinding.DataSource = defaultModeSettings;

			//MainWindowHelper.ShowCurrentModeSettingsFields(Controls.Owner);
		}
		
		public LocalizationComponentsModel LocalizationComponents => _localizationComponents;

		public AllChartsModel AllCharts => _allCharts;

		public TableLayoutPanelsModel TableLayoutPanels => _tableLayoutPanels;

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
				_tableLayoutPanels.BasicParametersTableLayoutPanel, 
				_bindingSources,
				_errorProvider);
			basicParametersTableLayoutPanelComponent.Initialize();

			var additionalParametersTableLayoutPanelComponent = new TableLayoutPanelComponent(
				typeof(AdditionalParametersModel),
				_tableLayoutPanels.AdditionalParametersTableLayoutPanel,
				_bindingSources,
				_errorProvider);
			additionalParametersTableLayoutPanelComponent.Initialize();

			var initialConditionsTableLayoutPanelComponent = new TableLayoutPanelComponent(
				typeof(InitialConditionsParametersModel),
				_tableLayoutPanels.InitialConditionsTableLayoutPanel,
				_bindingSources,
				_errorProvider);
			initialConditionsTableLayoutPanelComponent.Initialize();

			InitializeModeSettingsTableLayoutPanelComponent();
		}

		public void InitializeModeSettingsTableLayoutPanelComponent()
		{
			var currentDrivingMode = SettingsHelper.Get<Properties.Settings>().CurrentDrivingMode;
			TableLayoutPanelComponent settingsTableLayoutPanelComponent = null;

			switch (currentDrivingMode)
			{
				case DrivingMode.StartAndStopMovement:
				{
					settingsTableLayoutPanelComponent = new TableLayoutPanelComponent(
						typeof(StartAndStopMovementModeSettingsModel),
						_tableLayoutPanels.SettingsTableLayoutPanel,
						_bindingSources,
						_errorProvider);
					break;
				}
				case DrivingMode.TrafficThroughOneTrafficLight:
				{
					settingsTableLayoutPanelComponent = new TableLayoutPanelComponent(
						typeof(MovementThroughOneTrafficLightModeSettingsModel),
						_tableLayoutPanels.SettingsTableLayoutPanel,
						_bindingSources,
						_errorProvider);
					break;
				}
			}

			settingsTableLayoutPanelComponent?.Initialize();
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
	}
}