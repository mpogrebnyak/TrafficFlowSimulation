using System;
using System.Windows.Forms;
using ChartRendering.EvaluationHandlers;
using Localization;
using Localization.Localization;
using Microsoft.Practices.ServiceLocation;
using Modes;
using Modes.Constants;
using TrafficFlowSimulation.Handlers;
using TrafficFlowSimulation.Helpers;
using TrafficFlowSimulation.Properties.LocalizationResources;
using TrafficFlowSimulation.Windows.Components;

namespace TrafficFlowSimulation.Components;

public class DrivingModeComponent : IComponent
{
	private readonly ToolStripDropDownButton _modeButton;

	private readonly Panel _panel;

	public DrivingModeComponent(ToolStripDropDownButton modeButton, Panel panel)
	{
		_modeButton = modeButton;
		_panel = panel;
	}

	public void Initialize()
	{
		_modeButton.DropDownItems.Clear();
		var availableModes = ModesHelper.GetAvailableDrivingModes();

		foreach (DrivingMode mode in Enum.GetValues(typeof(DrivingMode)))
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
			}
		}

		_modeButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold,
			System.Drawing.GraphicsUnit.Point, 204);

		_modeButton.Text = _modeButton.DropDownItems.Count > 0
			? _modeButton.DropDownItems[0].Text
			: LocalizationHelper.Get<MainWindowResources>().EmptyModeLabel;
	}

	private void MenuItem_Click(object sender, EventArgs e)
	{
		var selectedModeItem = sender as ToolStripMenuItem;
		if (selectedModeItem == null) return;

		var owner = (selectedModeItem.Owner as ToolStripDropDownMenu)?.OwnerItem;
		if (owner != null) owner.Text = selectedModeItem.Text;

		_panel.Hide();
		var currentDrivingMode = ModesHelper.GetCurrentDrivingMode();
		ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentDrivingMode).AbortExecution();

		var mode = (DrivingMode) Enum.Parse(typeof(DrivingMode), selectedModeItem.Name);
		ModesHelper.SetCurrentDrivingMode(mode);

		ServiceLocator.Current.GetInstance<ChartRenderingHandler>(ModesHelper.DrivingModeType).InitializeChartProviders(mode.ToString());
		ServiceLocator.Current.GetInstance<MainWindowHelper>().InitializeTableLayoutPanelComponent();

		var modelParameters = ServiceLocator.Current.GetInstance<MainWindowHelper>().CollectParametersFromBindingSource();
		var modeSettings = ServiceLocator.Current.GetInstance<MainWindowHelper>().CollectModeSettingsFromBindingSource(modelParameters);
		ServiceLocator.Current.GetInstance<ChartRenderingHandler>(ModesHelper.DrivingModeType).RenderCharts(modelParameters, modeSettings);
		ServiceLocator.Current.GetInstance<MainWindowHelper>().ResizeAllChart();
	}
}