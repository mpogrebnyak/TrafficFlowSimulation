using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Localization;
using Settings;
using TrafficFlowSimulation.Properties.LocalizationResources;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders;

namespace TrafficFlowSimulation.Windows.Components;

public class ChartContextMenuStripComponentHelper
{
	public ChartContextMenuStripComponentHelper()
	{
		
	}

	public ToolStripSeparator CreateToolStripSeparator(string name)
	{
		return new ToolStripSeparator
		{
			Name = name,
			Size = new System.Drawing.Size(149, 6)
		};
	}

	public ContextMenuStrip CreateContextMenuStrip(string name)
	{
		return new ContextMenuStrip
		{
			BackColor = System.Drawing.Color.FromArgb(249,246,247),
			ImageScalingSize = new System.Drawing.Size(20, 20),
			Name = name,
			Size = new System.Drawing.Size(153, 104)
		};
	}

	public ToolStripMenuItem CreateToolStripMenuItem(string name, string text)
	{
		return new ToolStripMenuItem
		{
			Name = name,
			Size = new System.Drawing.Size(244, 24),
			Text = text
		};
	}

	public ToolStripMenuItem CreateChartLegendMenuItem(string name, string text, LegendStyle? legendStyle)
	{
		var legendToolStripMenuItem = CreateToolStripMenuItem(name, text);
		legendToolStripMenuItem.Tag = legendStyle;

		legendToolStripMenuItem.Click += DisplayLegendMenuItem_Click;

		return legendToolStripMenuItem;
	}

	public ToolStripMenuItem CreateChartAxesMenuItem(string name, string text, bool isHidden)
	{
		var axesToolStripMenuItem = CreateToolStripMenuItem(name, text);
		axesToolStripMenuItem.Tag = isHidden;

		axesToolStripMenuItem.Click += DisplayAxesMenuItem_Click;

		return axesToolStripMenuItem;
	}

	private void DisplayLegendMenuItem_Click(object sender, EventArgs e)
	{
		var menuItem = sender as ToolStripMenuItem;

		if (menuItem?.Owner is not ToolStripDropDownMenu menu || menu.OwnerItem == null)
			return;

		var owner = (menu.OwnerItem as ToolStripMenuItem)?.Owner;
		var chart = (owner as ContextMenuStrip)?.SourceControl as Chart;

		if (chart == null)
			return;

		switch (menuItem.Tag)
		{
			case LegendStyle.Column:
			{
				RenderingHelper.DisplayChartLegend(chart, LegendStyle.Column);
				break;
			}
			case LegendStyle.Row:
			{
				RenderingHelper.DisplayChartLegend(chart, LegendStyle.Row);
				break;
			}
			case LegendStyle.Table:
			{
				RenderingHelper.DisplayChartLegend(chart, LegendStyle.Table);
				break;
			}
			default:
			{
				RenderingHelper.DisplayChartLegend(chart, null);
				break;
			}
		}
	}

	private void DisplayAxesMenuItem_Click(object sender, EventArgs e)
	{
		var menuItem = sender as ToolStripMenuItem;

		if (menuItem?.Owner is not ToolStripDropDownMenu menu || menu.OwnerItem == null)
			return;

		var owner = (menu.OwnerItem as ToolStripMenuItem)?.Owner;
		var chart = (owner as ContextMenuStrip)?.SourceControl as Chart;

		if (chart == null)
			return;

		var isHidden = !(bool)menuItem.Tag;
		RenderingHelper.DisplayChartAxes(chart, isHidden);
	}

	public void SaveChartMenuItem_Click(object sender, EventArgs e)
	{
		var menuItem = sender as ToolStripMenuItem;

		if (menuItem?.Owner is not ContextMenuStrip menu || menu.SourceControl == null)
			return;

		var chart = menu.SourceControl as Chart;

		if (chart == null)
			return;

		using SaveFileDialog sfd = new();
		sfd.Title = LocalizationHelper.Get<MenuResources>().SaveImageText;
		sfd.Filter = SettingsHelper.Get<Properties.Settings>().AvailableFileTypes;
		sfd.AddExtension = true;
		sfd.FileName = "image";
		if (sfd.ShowDialog() == DialogResult.OK)
		{
			switch (sfd.FilterIndex)
			{
				case 1: chart.SaveImage(sfd.FileName, ChartImageFormat.Bmp); break;
				case 2: chart.SaveImage(sfd.FileName, ChartImageFormat.Png); break;
				case 3: chart.SaveImage(sfd.FileName, ChartImageFormat.Jpeg); break;
				case 4: chart.SaveImage(sfd.FileName, ChartImageFormat.Emf); break;
			}
		}
	}
}