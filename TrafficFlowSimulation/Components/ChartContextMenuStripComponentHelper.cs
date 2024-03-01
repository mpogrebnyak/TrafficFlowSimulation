using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.Helpers;
using ChartRendering.Properties;
using Common;
using Localization;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Helpers;
using TrafficFlowSimulation.Properties;
using TrafficFlowSimulation.Properties.LocalizationResources;
using TrafficFlowSimulation.Windows;


namespace TrafficFlowSimulation.Components;

public class ChartContextMenuStripComponentHelper
{
	public ToolStripSeparator CreateToolStripSeparator(string name)
	{
		return new ToolStripSeparator
		{
			Name = name,
			Size = new Size(149, 6)
		};
	}

	public ContextMenuStrip CreateContextMenuStrip(string name)
	{
		return new ContextMenuStrip
		{
			BackColor = Color.FromArgb(249,246,247),
			ImageScalingSize = new Size(20, 20),
			Name = name,
			Size = new Size(153, 104)
		};
	}

	public ToolStripMenuItem CreateToolStripMenuItem(string name, string text, Image? image = null)
	{
		return new ToolStripMenuItem
		{
			Name = name,
			Size = new Size(244, 24),
			Text = text,
			Image = image
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
		sfd.Title = LocalizationHelper.Get<ContextMenuResources>().SaveImageText;
		sfd.Filter = SettingsHelper.Get<TrafficFlowSimulationSettings>().AvailableFileTypes;
		sfd.FileName = SettingsHelper.Get<TrafficFlowSimulationSettings>().DefaultFileName;
		sfd.AddExtension = true;
		if (sfd.ShowDialog() == DialogResult.OK)
		{
			var chartToSave = RenderingHelper.CreateChartToSave(chart);
			switch (sfd.FilterIndex)
			{
				case 1: chartToSave.SaveImage(sfd.FileName, ChartImageFormat.Bmp); break;
				case 2: chartToSave.SaveImage(sfd.FileName, ChartImageFormat.Png); break;
				case 3: chartToSave.SaveImage(sfd.FileName, ChartImageFormat.Jpeg); break;
				case 4: chartToSave.SaveImage(sfd.FileName, ChartImageFormat.Emf); break;
			}
		}
	}

	public void SaveAllChartsMenuItem_Click(object sender, EventArgs e)
	{
		var menuItem = sender as ToolStripMenuItem;

		if (menuItem?.Owner is not ContextMenuStrip menu || menu.SourceControl == null)
			return;

		var mainWindow = GetWindow(menu);

		if (mainWindow == null) 
			return;

		using FolderBrowserDialog fbd = new();
		fbd.Description = "Выберите папку для сохранения файлов";

		if (fbd.ShowDialog() == DialogResult.OK)
		{
			var selectedFolder = fbd.SelectedPath;

			var isVectorGraphicsSave = SettingsHelper.Get<TrafficFlowSimulationSettings>().AutomaticSaveToVectorGraphics;

			if (isVectorGraphicsSave)
			{
				RenderingHelper.CreateChartToSave(mainWindow.DistanceChart)
					.SaveImage(CommonFileHelper.CreateFilePath("DistanceChart", selectedFolder, CommonFileHelper.Extension.Emf), ChartImageFormat.EmfPlus);
				RenderingHelper.CreateChartToSave(mainWindow.SpeedChart)
					.SaveImage(CommonFileHelper.CreateFilePath("SpeedChart", selectedFolder,CommonFileHelper.Extension.Emf), ChartImageFormat.EmfPlus);
				RenderingHelper.CreateChartToSave(mainWindow.SpeedFromDistanceChart)
					.SaveImage(CommonFileHelper.CreateFilePath("SpeedFromDistanceChart", selectedFolder,CommonFileHelper.Extension.Emf), ChartImageFormat.EmfPlus);
			}
			else
			{
				RenderingHelper.CreateChartToSave(mainWindow.DistanceChart)
					.SaveImage(CommonFileHelper.CreateFilePath("DistanceChart", selectedFolder, CommonFileHelper.Extension.Png), ChartImageFormat.Png);
				RenderingHelper.CreateChartToSave(mainWindow.SpeedChart)
					.SaveImage(CommonFileHelper.CreateFilePath("SpeedChart", selectedFolder,CommonFileHelper.Extension.Png), ChartImageFormat.Png);
				RenderingHelper.CreateChartToSave(mainWindow.SpeedFromDistanceChart)
					.SaveImage(CommonFileHelper.CreateFilePath("SpeedFromDistanceChart", selectedFolder,CommonFileHelper.Extension.Png), ChartImageFormat.Png);
			}
		}
	}

	public void DisplaySpeedFromDistanceChart_Click(object sender, EventArgs e)
	{
		var menuItem = sender as ToolStripMenuItem;

		if (menuItem?.Owner is not ContextMenuStrip menu || menu.SourceControl == null)
			return;

		var mainWindow = GetWindow(menu);

		if (mainWindow == null) 
			return;

		var chartsSplitContainer = mainWindow.Controls
			.Find(ControlName.MainWindowControlName.ChartsSplitContainer, true)
			.Single() as SplitContainer;
		var speedAndDistanceSplitContainer = mainWindow.Controls
			.Find(ControlName.MainWindowControlName.SpeedAndDistanceSplitContainer, true)
			.Single() as SplitContainer;

		if (chartsSplitContainer == null || speedAndDistanceSplitContainer == null) return;

		if (chartsSplitContainer.Panel2Collapsed)
		{
			chartsSplitContainer.Panel2Collapsed = false;
			chartsSplitContainer.Panel2.Show();

			var width = chartsSplitContainer.Size.Width / 3;
			chartsSplitContainer.SplitterDistance = 2 * width;
			speedAndDistanceSplitContainer.SplitterDistance = width;
		}
		else
		{
			chartsSplitContainer.Panel2Collapsed = true;
			chartsSplitContainer.Panel2.Hide();
			speedAndDistanceSplitContainer.SplitterDistance = speedAndDistanceSplitContainer.Size.Width / 2;
		}
	}

	private MainWindow? GetWindow(ContextMenuStrip menu)
	{
		var chart = menu.SourceControl as Chart;
		if (chart == null) return null;

		var panel = chart.Parent as Panel;
		if (panel == null) return null;

		var splitContainer = panel.Parent as SplitContainer;
		if (splitContainer == null) return null;

		while (true)
		{
			if (splitContainer != null && splitContainer.Parent is Panel p && p.Parent is SplitContainer)
			{
				panel = splitContainer.Parent as Panel;

				if (panel != null)
					splitContainer = panel.Parent as SplitContainer;
			}
			else
			{
				if (splitContainer != null)
				{
					var mainWindow = splitContainer.Parent as MainWindow;
					if (mainWindow != null)
						return mainWindow;
				}

				break;
			}
		}

		return null;
	}
}