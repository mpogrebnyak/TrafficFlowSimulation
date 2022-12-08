using System;
using System.Linq;
using System.Windows.Forms;
using Localization;
using Localization.Localization;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Handlers.EvaluationHandlers;
using TrafficFlowSimulation.Properties.LocalizationResources;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders;
using TrafficFlowSimulation.Windows.Helpers;

namespace TrafficFlowSimulation.Windows.Components;

public class DrivingModeComponent : IComponent
{
	private ToolStripDropDownButton _modeButton;

	public DrivingModeComponent(ToolStripDropDownButton modeButton)
	{
		_modeButton = modeButton;
	}
	
	public void Initialize()
	{
		_modeButton.DropDownItems.Clear();
		var availableModes = SettingsHelper.Get<Properties.Settings>().AvailableDrivingModes.ToList();

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
			: LocalizationHelper.Get<MenuResources>().EmptyModeLabel;
	}

	private void MenuItem_Click(object sender, EventArgs e)
	{
		var selectedModeItem = sender as ToolStripMenuItem;
		if (selectedModeItem == null) return;

		var owner = (selectedModeItem.Owner as ToolStripDropDownMenu)?.OwnerItem;
		if (owner != null) owner.Text = selectedModeItem.Text;

		var currentDrivingMode = SettingsHelper.Get<Properties.Settings>().CurrentDrivingMode;
		ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentDrivingMode.ToString()).AbortExecution();

		var mode = (DrivingMode) Enum.Parse(typeof(DrivingMode), selectedModeItem.Name);

		var settings = SettingsHelper.Get<Properties.Settings>();
		settings.CurrentDrivingMode = mode;
		SettingsHelper.Set(settings);

		ServiceLocator.Current.GetInstance<MainWindowHelper>().InitializeModeSettingsTableLayoutPanelComponent();
		ServiceLocator.Current.GetInstance<RenderingHandler>().ChangeDrivingMode(mode);

		var modelParameters = ServiceLocator.Current.GetInstance<MainWindowHelper>().CollectParametersFromBindingSource();
		ServiceLocator.Current.GetInstance<MainWindowHelper>().CollectModeSettingsFromBindingSource(modelParameters);
		ServiceLocator.Current.GetInstance<RenderingHandler>().RenderCharts(modelParameters);
	}
}