using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EvaluationKernel.Models;
using Microsoft.Practices.ObjectBuilder2;
using Settings;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Models.ParametersSelectionSettingsModels;
using TrafficFlowSimulation.Windows.Components;

namespace TrafficFlowSimulation.Windows.Helpers;

public class ParametersSelectionWindowHelper
{
	//private LocalizationWindowHelper _localizationWindowHelper;

	//private ChartContextMenuStripComponent _chartContextMenuStripComponent;

	//private AllChartsModel _allCharts;

	private ErrorProvider _errorProvider;

	private Dictionary<Type, BindingSource> _bindingSources;

	private readonly Control.ControlCollection _controls;

	public ParametersSelectionWindowHelper(
		//LocalizationComponentsModel localizationComponentsModel,
		//AllChartsModel allCharts,
		ErrorProvider errorProvider,
		Control.ControlCollection controls
	)
	{
		//	_localizationWindowHelper = new LocalizationWindowHelper(localizationComponentsModel);
		//	_chartContextMenuStripComponent = new ChartContextMenuStripComponent(allCharts);
		//	_allCharts = allCharts;
			_errorProvider = errorProvider;
			_bindingSources = new();
		_controls = controls;
	}

	public void InitializeInterface()
	{
		InitializeTableLayoutPanelComponent();
		InitializeParametersSelectionModeComponent();
		//InitializeLanguageComponent();
		//_chartContextMenuStripComponent.Initialize();

		//_localizationWindowHelper.LocalizeComponents();
		//LocalizationWindowHelper.Translate(_localizationComponents);
		//LocalizationService.Translate(_localizationComponents);

		//var defaultModeSettings = ModeSettingsMapper.GetDefault();
		//ModeSettingsBinding.DataSource = defaultModeSettings;

		//MainWindowHelper.ShowCurrentModeSettingsFields(Controls.Owner);
	}

	private void InitializeParametersSelectionModeComponent()
	{
		var controlMenuStrip = _controls.Find(ControlName.ParametersSelectionWindowControlName.ControlMenuStrip, true).Single() as ToolStrip;
		var parametersSelectionStripDropDownButton =
			controlMenuStrip?.Items.Find(ControlName.ParametersSelectionWindowControlName.ParametersSelectionStripDropDownButton, false).Single() as
				ToolStripDropDownButton;

		if (parametersSelectionStripDropDownButton != null)
		{
			var parametersSelectionModeComponent =
				new ParametersSelectionModeComponent(parametersSelectionStripDropDownButton);
			parametersSelectionModeComponent.Initialize();
		}
	}

	public void InitializeTableLayoutPanelComponent()
	{
		var qq = _controls.Find(ControlName.ParametersSelectionWindowControlName.BasicParametersTableLayoutPanel, true)
			.Single() as TableLayoutPanel;

		var basicParametersTableLayoutPanelComponent = new TableLayoutPanelComponent(
			typeof(InliningDistanceModelParametersModel),
			_controls.Find(ControlName.ParametersSelectionWindowControlName.BasicParametersTableLayoutPanel, true).Single() as TableLayoutPanel, 
			_bindingSources,
			_errorProvider);
		basicParametersTableLayoutPanelComponent.Initialize();

		var currentParametersSelectionMode = SettingsHelper.Get<Properties.Settings>().CurrentParametersSelectionMode;
		var settingsTableLayoutPanel = _controls.Find(ControlName.ParametersSelectionWindowControlName.SettingsTableLayoutPanel, true).Single() as TableLayoutPanel;

		TableLayoutPanelComponent settingsTableLayoutPanelComponent = null;

		switch (currentParametersSelectionMode)
		{
			case ParametersSelectionMode.InliningDistanceChanging:
			{
				settingsTableLayoutPanelComponent = new TableLayoutPanelComponent(
					typeof(InliningDistanceSettingsModel),
					settingsTableLayoutPanel,
					_bindingSources,
					_errorProvider);
				break;
			}
		}

		settingsTableLayoutPanelComponent?.Initialize();
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
				modeSettings = (InliningDistanceSettingsModel) _bindingSources[typeof(InliningDistanceSettingsModel)].DataSource;
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

		((InliningDistanceModelParametersModel)_bindingSources[typeof(InliningDistanceModelParametersModel)].DataSource).MapTo(modelParameters);

		return modelParameters;
	}
}