using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.ParametersSelectionSettingsModels;
using ChartRendering.Properties;
using EvaluationKernel.Models;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Constants.Modes;
using TrafficFlowSimulation.Windows.Components;

namespace TrafficFlowSimulation.Helpers;

public class ParametersSelectionWindowHelper
{
	private ErrorProvider _errorProvider;

	private Dictionary<Type, BindingSource> _bindingSources;

	private readonly Control.ControlCollection _controls;

	public ParametersSelectionWindowHelper(
		ErrorProvider errorProvider,
		Control.ControlCollection controls
	)
	{
		_errorProvider = errorProvider;
		_bindingSources = new();
		_controls = controls;
	}

	public void InitializeInterface()
	{
		InitializeTableLayoutPanelComponent();
		InitializeParametersSelectionModeComponent();
	}

	private void InitializeParametersSelectionModeComponent()
	{
		var controlMenuStrip = _controls.Find(ControlName.ParametersSelectionWindowControlName.ControlMenuStrip, true).Single() as ToolStrip;
		var parametersSelectionStripDropDownButton =
			controlMenuStrip?.Items.Find(ControlName.ParametersSelectionWindowControlName.ParametersSelectionStripDropDownButton, false).Single() as ToolStripDropDownButton;

		if (parametersSelectionStripDropDownButton != null)
		{
			var parametersSelectionModeComponent =
				new ParametersSelectionModeComponent(parametersSelectionStripDropDownButton);
			parametersSelectionModeComponent.Initialize();
		}
	}

	public void InitializeTableLayoutPanelComponent()
	{
		GetModelTypes(out var modelType, out var settingsModelType);

		if (modelType != null && settingsModelType != null)
		{
			var parametersTableLayoutPanel = _controls.Find(ControlName.ParametersSelectionWindowControlName.BasicParametersTableLayoutPanel, true).Single() as TableLayoutPanel; 
			var settingsTableLayoutPanel = _controls.Find(ControlName.ParametersSelectionWindowControlName.SettingsTableLayoutPanel, true).Single() as TableLayoutPanel;

		/*	var basicParametersTableLayoutPanelComponent = new TableLayoutPanelComponent(
				modelType,
				parametersTableLayoutPanel,
				_bindingSources,
				_errorProvider);
			basicParametersTableLayoutPanelComponent.Initialize();

			var settingsTableLayoutPanelComponent = new TableLayoutPanelComponent(
				settingsModelType,
				settingsTableLayoutPanel,
				_bindingSources,
				_errorProvider);
			settingsTableLayoutPanelComponent.Initialize();*/
		}
	}

	public BaseSettingsModels CollectModeSettingsFromBindingSource(ModelParameters modelParameters)
	{
		var currentParametersSelectionMode = SettingsHelper.Get<ChartRenderingSettings>().CurrentParametersSelectionMode;
		_bindingSources.ForEach(x => x.Value.EndEdit());

		var settingsModel = ServiceLocator.Current.GetInstance<ISettingsModel>(currentParametersSelectionMode.ToString());

		var modeSettings = (BaseSettingsModels)_bindingSources[settingsModel.GetType()].DataSource;
		modeSettings.MapTo(modelParameters);

		return modeSettings;
	}

	public ModelParameters CollectParametersFromBindingSource()
	{
		var modelParameters = new ModelParameters();
		_bindingSources.ForEach(x => x.Value.EndEdit());

		var currentParametersSelectionMode = SettingsHelper.Get<ChartRendering.Properties.ChartRenderingSettings>().CurrentParametersSelectionMode;

		switch (currentParametersSelectionMode)
		{
			case ParametersSelectionMode.InliningDistanceEstimation:
			{
				((InliningDistanceEstimationModelParametersModel) _bindingSources[
					typeof(InliningDistanceEstimationModelParametersModel)].DataSource).MapTo(modelParameters);
				break;
			}
			case ParametersSelectionMode.AccelerationCoefficientEstimation:
			{
				((AccelerationCoefficientEstimationModelParametersModel) _bindingSources[
					typeof(AccelerationCoefficientEstimationModelParametersModel)].DataSource).MapTo(modelParameters);
				break;
			}
			case ParametersSelectionMode.DecelerationCoefficientEstimation:
			{
				((DecelerationCoefficientEstimationModelParametersModel) _bindingSources[
					typeof(DecelerationCoefficientEstimationModelParametersModel)].DataSource).MapTo(modelParameters);
				break;
			}
		}

		return modelParameters;
	}

	public string? GetFilePathFromFileDialog()
	{
		var openFileDialog = new OpenFileDialog();
		var result = openFileDialog.ShowDialog();
		if (result == DialogResult.OK)
		{
			return openFileDialog.FileName;
		}

		return null;
	}

	private void GetModelTypes(out Type? modelType, out Type? settingsModelType)
	{
		var currentParametersSelectionMode = SettingsHelper.Get<ChartRendering.Properties.ChartRenderingSettings>().CurrentParametersSelectionMode;

		switch (currentParametersSelectionMode)
		{
			case ParametersSelectionMode.InliningDistanceEstimation:
			{
				settingsModelType = typeof(InliningDistanceEstimationSettingsModel);
				modelType = typeof(InliningDistanceEstimationModelParametersModel);
				break;
			}
			case ParametersSelectionMode.AccelerationCoefficientEstimation:
			{
				settingsModelType = typeof(AccelerationCoefficientEstimationSettingsModel);
				modelType = typeof(AccelerationCoefficientEstimationModelParametersModel);
				break;
			}
			case ParametersSelectionMode.DecelerationCoefficientEstimation:
			{
				settingsModelType = typeof(DecelerationCoefficientEstimationSettingsModel);
				modelType = typeof(DecelerationCoefficientEstimationModelParametersModel);
				break;
			}
			default:
			{
				settingsModelType = null;
				modelType = null;
				break;
			}
		}
	}
}