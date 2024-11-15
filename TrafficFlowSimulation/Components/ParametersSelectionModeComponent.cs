﻿using System;
using System.Windows.Forms;
using ChartRendering.Constants;
using ChartRendering.Helpers;
using EvaluationKernel.Helpers;
using Localization;
using Localization.Localization;
using Microsoft.Practices.ServiceLocation;
using TrafficFlowSimulation.Handlers;
using TrafficFlowSimulation.Helpers;
using TrafficFlowSimulation.Properties.LocalizationResources;
using TrafficFlowSimulation.Windows.Components;

namespace TrafficFlowSimulation.Components;

public class ParametersSelectionModeComponent : IComponent
{
	private readonly ToolStripDropDownButton _modeButton;

	public ParametersSelectionModeComponent(ToolStripDropDownButton modeButton)
	{
		_modeButton = modeButton;
	}

	public void Initialize()
	{
		_modeButton.DropDownItems.Clear();
		var availableModes = ModesHelper.GetAvailableParametersSelectionMode();
		var currentMode = ModesHelper.GetCurrentParametersSelectionMode();
		string? modeButtonText = null;

		foreach (ParametersSelectionMode mode in Enum.GetValues(typeof(ParametersSelectionMode)))
		{
			if (availableModes.Contains(mode))
			{
				var menuItem = new ToolStripMenuItem
				{
					Name = mode.ToString(),
					Text = mode.GetDescription(),
					Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular,
						System.Drawing.GraphicsUnit.Point, 204)
				};

				menuItem.Click += MenuItem_Click;
				_modeButton.DropDownItems.Add(menuItem);

				if (currentMode == mode.ToString())
				{
					modeButtonText = mode.GetDescription();
				}
			}
		}

		_modeButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold,
			System.Drawing.GraphicsUnit.Point, 204);

		_modeButton.Text = _modeButton.DropDownItems.Count > 0
			? modeButtonText ?? _modeButton.DropDownItems[0].Text
			: LocalizationHelper.Get<MainWindowResources>().EmptyModeLabel;
	}

	private void MenuItem_Click(object sender, EventArgs e)
	{
		var selectedModeItem = sender as ToolStripMenuItem;
		if (selectedModeItem == null) return;

		var owner = (selectedModeItem.Owner as ToolStripDropDownMenu)?.OwnerItem;
		if (owner == null) return;

		owner.Text = selectedModeItem.Text;

		var mode = (ParametersSelectionMode) Enum.Parse(typeof(ParametersSelectionMode), selectedModeItem.Name);
		ModesHelper.SetCurrentParametersSelectionMode(mode);

		ServiceLocator.Current.GetInstance<ParametersSelectionWindowHelper>().InitializeTableLayoutPanelComponent();
		ServiceLocator.Current.GetInstance<ChartRenderingHandler>(ModesHelper.ParametersSelectionModeType).InitializeChartProviders(mode.ToString());

		var modelParameters = ServiceLocator.Current.GetInstance<ParametersSelectionWindowHelper>().CollectParametersFromBindingSource();
		var modeSettings = ServiceLocator.Current.GetInstance<ParametersSelectionWindowHelper>().CollectModeSettingsFromBindingSource(modelParameters);
		ServiceLocator.Current.GetInstance<ChartRenderingHandler>(ModesHelper.ParametersSelectionModeType).RenderCharts(modelParameters, modeSettings);
		ServiceLocator.Current.GetInstance<ParametersSelectionWindowHelper>().ResizeAllChart();
	}
}