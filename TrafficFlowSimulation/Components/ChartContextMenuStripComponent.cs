using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.Models;
using Localization;
using TrafficFlowSimulation.Components;
using TrafficFlowSimulation.Properties.LocalizationResources;
using TrafficFlowSimulation.Windows.Models;

namespace TrafficFlowSimulation.Windows.Components;

public class ChartContextMenuStripComponent : IComponent
{
	private AllChartsModel _allChartsModel;

	public ChartContextMenuStripComponent(AllChartsModel allChartsModel)
	{
		_allChartsModel = allChartsModel;
	}

	private static class MenuItemName
	{
		public const string ChartContextMenuStrip = "ChartContextMenuStrip";
		public const string LegendToolStripMenuItem = "LegendToolStripMenuItem";
		public const string DisplayLegendFullMenuItem = "DisplayLegendFullMenuItem";
		public const string DisplayLegendPartiallyMenuItem = "DisplayLegendPartiallyMenuItem";
		public const string HideLegendMenuItem = "HideLegendMenuItem";
		public const string DisplayAxesToolStripMenuItem = "DisplayAxesToolStripMenuItem";
		public const string DisplayAxesMenuItem = "DisplayAxesMenuItem";
		public const string HideAxesMenuItem = "HideAxesMenuItem";
		public const string ToolStripSeparator = "ToolStripSeparator";
		public const string SaveChartToolStripMenuItem = "SaveChartToolStripMenuItem";
		public const string DisplaySpeedFromDistanceChartMenuItem = "DisplaySpeedFromDistanceChartMenuItem";
	}

	public void Initialize()
	{
		_allChartsModel.DistanceChart.ContextMenuStrip = null;
		_allChartsModel.SpeedChart.ContextMenuStrip = null;
		_allChartsModel.CarsMovementChart.ContextMenuStrip = null;

		var helper = new ChartContextMenuStripComponentHelper();
		var resources = LocalizationHelper.Get<ContextMenuResources>();

		var contextMenuStrip = helper.CreateContextMenuStrip(MenuItemName.ChartContextMenuStrip);

		var displaySpeedFromDistanceChartMenuItem = helper.CreateToolStripMenuItem(MenuItemName.DisplaySpeedFromDistanceChartMenuItem, resources.ShowSpeedFromDistanceChartMenuItem, Properties.Resources.speedFromDistanceChart_icon);
		displaySpeedFromDistanceChartMenuItem.Click += helper.DisplaySpeedFromDistanceChart_Click;
		contextMenuStrip.Items.Add(displaySpeedFromDistanceChartMenuItem);

		contextMenuStrip.Items.Add(helper.CreateToolStripSeparator(MenuItemName.ToolStripSeparator));

		var legendMenuItem = helper.CreateToolStripMenuItem(MenuItemName.LegendToolStripMenuItem, resources.LegendToolStripMenuItem, Properties.Resources.legend_icon);
		var displayFullLegend = helper.CreateChartLegendMenuItem(MenuItemName.DisplayLegendFullMenuItem, resources.DisplayLegendFullMenuItem, LegendStyle.Table);
		var displayPartiallyLegend = helper.CreateChartLegendMenuItem(MenuItemName.DisplayLegendPartiallyMenuItem, resources.DisplayLegendPartiallyMenuItem, LegendStyle.Column);
		var hideLegend = helper.CreateChartLegendMenuItem(MenuItemName.HideLegendMenuItem, resources.HideLegendMenuItem, null);
		legendMenuItem.DropDownItems.AddRange(new ToolStripItem[] {displayFullLegend, displayPartiallyLegend, hideLegend});
		contextMenuStrip.Items.Add(legendMenuItem);

		var axesMenuItem = helper.CreateToolStripMenuItem(MenuItemName.DisplayAxesToolStripMenuItem, resources.AxesToolStripMenuItem);
		var displayAxes = helper.CreateChartAxesMenuItem(MenuItemName.DisplayAxesMenuItem, resources.DisplayAxesMenuItem, true);
		var hideAxes = helper.CreateChartAxesMenuItem(MenuItemName.HideAxesMenuItem, resources.HideAxesMenuItem, false);
		axesMenuItem.DropDownItems.AddRange(new ToolStripItem[] {displayAxes, hideAxes});
		contextMenuStrip.Items.Add(axesMenuItem);

		contextMenuStrip.Items.Add(helper.CreateToolStripSeparator(MenuItemName.ToolStripSeparator));

		var saveMenuItem = helper.CreateToolStripMenuItem(MenuItemName.SaveChartToolStripMenuItem, resources.SaveChartToolStripMenuItem);
		saveMenuItem.Click += helper.SaveChartMenuItem_Click;
		contextMenuStrip.Items.Add(saveMenuItem);

		contextMenuStrip.Renderer = new ToolStripProfessionalRenderer(new SubMenuCustomColorTable());

		_allChartsModel.DistanceChart.ContextMenuStrip = contextMenuStrip;
		_allChartsModel.SpeedChart.ContextMenuStrip = contextMenuStrip;
		_allChartsModel.CarsMovementChart.ContextMenuStrip = contextMenuStrip;
	}
}