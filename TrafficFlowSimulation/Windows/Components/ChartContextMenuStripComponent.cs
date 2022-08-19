using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Localization;
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
		public static readonly string ChartContextMenuStrip = "ChartContextMenuStrip";
		public static readonly string LegendToolStripMenuItem = "LegendToolStripMenuItem";
		public static readonly string DisplayLegendFullMenuItem = "DisplayLegendFullMenuItem";
		public static readonly string DisplayLegendPartiallyMenuItem = "DisplayLegendPartiallyMenuItem";
		public static readonly string HideLegendMenuItem = "HideLegendMenuItem";
		public static readonly string DisplayAxesToolStripMenuItem = "DisplayAxesToolStripMenuItem";
		public static readonly string DisplayAxesMenuItem = "DisplayAxesMenuItem";
		public static readonly string HideAxesMenuItem = "HideAxesMenuItem";
		public static readonly string ToolStripSeparator = "ToolStripSeparator";
		public static readonly string SaveChartToolStripMenuItem = "SaveChartToolStripMenuItem";
	}

	public void Initialize()
	{
		_allChartsModel.DistanceChart.ContextMenuStrip = null;
		_allChartsModel.SpeedChart.ContextMenuStrip = null;
		_allChartsModel.CarsMovementChart.ContextMenuStrip = null;

		var helper = new ChartContextMenuStripComponentHelper();
		var resources = LocalizationHelper.Get<MenuResources>();

		var contextMenuStrip = helper.CreateContextMenuStrip(MenuItemName.ChartContextMenuStrip);

		var legendMenuItem = helper.CreateToolStripMenuItem(MenuItemName.LegendToolStripMenuItem, resources.LegendToolStripMenuItem);
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