using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.ParametersModels;
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

namespace TrafficFlowSimulation.Helpers;

public class ParametersSelectionWindowHelper
{
	public readonly ChartEventHandler ChartEventHandler;

	private readonly ParametersSelectionWindow _parametersSelectionWindow;

	private readonly ErrorProvider _errorProvider;

	private readonly Dictionary<Type, BindingSource> _bindingSources;

	private readonly Control.ControlCollection _controls;

	public ParametersSelectionWindowHelper(ParametersSelectionWindow form)
	{
		_parametersSelectionWindow = form;
		_errorProvider = form.ParametersErrorProvider;
		_bindingSources = new();
		_controls = form.Controls;

		var formUpdateHandler = new FormUpdateHandler(form, ModesHelper.ParametersSelectionModeType);
		ChartEventHandler = formUpdateHandler.GetEvent();
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
		var currentParametersSelectionMode = ModesHelper.GetCurrentParametersSelectionMode();

		var baseParametersModel = ServiceLocator.Current.GetInstance<IParametersModel>(currentParametersSelectionMode);
		var baseParametersTableLayoutPanelComponent = new TableLayoutPanelComponent(
			baseParametersModel,
			_controls.Find(ControlName.ParametersSelectionWindowControlName.BasicParametersTableLayoutPanel, true).Single() as TableLayoutPanel,
			_bindingSources,
			_errorProvider);
		baseParametersTableLayoutPanelComponent.Initialize();

		var settingsModel = ServiceLocator.Current.GetInstance<ISettingsModel>(currentParametersSelectionMode);
		var settingsTableLayoutPanelComponent = new TableLayoutPanelComponent(
			settingsModel,
			_controls.Find(ControlName.ParametersSelectionWindowControlName.SettingsTableLayoutPanel, true).Single() as TableLayoutPanel,
			_bindingSources,
			_errorProvider);
		settingsTableLayoutPanelComponent.Initialize();
	}

	public BaseSettingsModels CollectModeSettingsFromBindingSource(ModelParameters modelParameters)
	{
		var currentParametersSelectionMode =  ModesHelper.GetCurrentParametersSelectionMode();
		_bindingSources.ForEach(x => x.Value.EndEdit());

		var settingsModel = ServiceLocator.Current.GetInstance<ISettingsModel>(currentParametersSelectionMode);

		var modeSettings = (BaseSettingsModels)_bindingSources[settingsModel.GetType()].DataSource;
		modeSettings.MapTo(modelParameters);

		return modeSettings;
	}

	public ModelParameters CollectParametersFromBindingSource()
	{
		var modelParameters = new ModelParameters();
		_bindingSources.ForEach(x => x.Value.EndEdit());

		var currentParametersSelectionMode = (ParametersSelectionMode)Enum.Parse(typeof(ParametersSelectionMode), ModesHelper.GetCurrentParametersSelectionMode());

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

	public void ResizeAllChart()
	{
		ResizeChart(_parametersSelectionWindow.ParametersSelectionChart);
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