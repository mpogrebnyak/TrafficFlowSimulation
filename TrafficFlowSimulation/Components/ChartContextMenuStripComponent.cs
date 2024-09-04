using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.Constants;
using Localization;
using TrafficFlowSimulation.Properties.LocalizationResources;
using TrafficFlowSimulation.Windows;
using TrafficFlowSimulation.Windows.Components;

namespace TrafficFlowSimulation.Components;

public class ChartContextMenuStripComponent : IComponent
{
	private readonly MainWindow _form;

	public ChartContextMenuStripComponent(MainWindow form)
	{
		_form = form;
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
		public const string SaveAllChartsToolStripMenuItem = "SaveAllChartsToolStripMenuItem";
		public const string DisplaySpeedFromDistanceChartMenuItem = "DisplaySpeedFromDistanceChartMenuItem";
		public const string ChartViewModeToolStripMenuItem = "ChartViewModeToolStripMenuItem";
		public const string ChartViewModeOnlyFirstLaneMenuItem = "ChartViewModeOnlyFirstLaneMenuItem";
		public const string ChartViewModeOnlySecondLaneMenuItem = "ChartViewModeOnlySecondLaneMenuItem";
		public const string ChartViewModeBothLaneMenuItem = "ChartViewModeBothLaneMenuItem";
	}

	public void Initialize()
	{
		_form.DistanceChart.ContextMenuStrip = null;
		_form.SpeedChart.ContextMenuStrip = null;
		_form.CarsMovementChart.ContextMenuStrip = null;
		_form.SpeedFromDistanceChart.ContextMenuStrip = null;

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

		var chartViewModeMenuItem = helper.CreateToolStripMenuItem(MenuItemName.ChartViewModeToolStripMenuItem, resources.ChartViewModeToolStripMenuItem);
		var chartViewModeOnlyFirstLane = helper.CreateChartViewModeMenuItem(MenuItemName.ChartViewModeOnlyFirstLaneMenuItem, resources.ChartViewModeOnlyFirstLaneMenuItem, ChartViewMode.OnlyFirstLane);
		var chartViewModeOnlySecondLane = helper.CreateChartViewModeMenuItem(MenuItemName.ChartViewModeOnlySecondLaneMenuItem, resources.ChartViewModeOnlySecondLaneMenuItem, ChartViewMode.OnlySecondLane);
		var cChartViewModeBothLane = helper.CreateChartViewModeMenuItem(MenuItemName.ChartViewModeBothLaneMenuItem, resources.ChartViewModeBothLaneMenuItem, ChartViewMode.BothLane);
		chartViewModeMenuItem.DropDownItems.AddRange(new ToolStripItem[] {chartViewModeOnlyFirstLane, chartViewModeOnlySecondLane, cChartViewModeBothLane});
		contextMenuStrip.Items.Add(chartViewModeMenuItem);

		contextMenuStrip.Items.Add(helper.CreateToolStripSeparator(MenuItemName.ToolStripSeparator));

		var saveChartMenuItem = helper.CreateToolStripMenuItem(MenuItemName.SaveChartToolStripMenuItem, resources.SaveChartToolStripMenuItem);
		saveChartMenuItem.Click += helper.SaveChartMenuItem_Click;
		contextMenuStrip.Items.Add(saveChartMenuItem);

		var saveAllChartsMenuItem = helper.CreateToolStripMenuItem(MenuItemName.SaveAllChartsToolStripMenuItem, resources.SaveAllChartsToolStripMenuItem);
		saveAllChartsMenuItem.Click += helper.SaveAllChartsMenuItem_Click;
		contextMenuStrip.Items.Add(saveAllChartsMenuItem);

		contextMenuStrip.Renderer = new ToolStripProfessionalRenderer(new SubMenuCustomColorTable());

		_form.DistanceChart.ContextMenuStrip = contextMenuStrip;
		_form.SpeedChart.ContextMenuStrip = contextMenuStrip;
		_form.CarsMovementChart.ContextMenuStrip = contextMenuStrip;
		_form.SpeedFromDistanceChart.ContextMenuStrip = contextMenuStrip;
	}
}