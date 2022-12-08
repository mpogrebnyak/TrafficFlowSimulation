using System;
using System.Linq;
using System.Windows.Forms;
using Localization;
using Localization.Localization;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Properties.LocalizationResources;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders;
using TrafficFlowSimulation.Windows.Helpers;

namespace TrafficFlowSimulation.Windows.Components;

public class ParametersSelectionModeComponent : IComponent
{
	private ToolStripDropDownButton _modeButton;

	public ParametersSelectionModeComponent(ToolStripDropDownButton modeButton)
	{
		_modeButton = modeButton;
	}

	public void Initialize()
	{
		_modeButton.DropDownItems.Clear();
		var availableModes = SettingsHelper.Get<Properties.Settings>().AvailableParametersSelectionModes.ToList();

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
		if (owner == null) return;

		owner.Text = selectedModeItem.Text;

		var mode = (ParametersSelectionMode) Enum.Parse(typeof(ParametersSelectionMode), selectedModeItem.Name);

		var settings = SettingsHelper.Get<Properties.Settings>();
		settings.CurrentParametersSelectionMode = mode;
		SettingsHelper.Set(settings);

		ServiceLocator.Current.GetInstance<ParametersSelectionWindowHelper>().InitializeTableLayoutPanelComponent();
		ServiceLocator.Current.GetInstance<ParametersSelectionRenderingHandler>().ChangeParametersSelectionMode(mode);

		var modelParameters = ServiceLocator.Current.GetInstance<MainWindowHelper>().CollectParametersFromBindingSource();
		ServiceLocator.Current.GetInstance<MainWindowHelper>().CollectModeSettingsFromBindingSource(modelParameters);
		ServiceLocator.Current.GetInstance<ParametersSelectionRenderingHandler>().RenderCharts(modelParameters);
	}
}