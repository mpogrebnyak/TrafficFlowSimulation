using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using Settings;

namespace ChartRendering.Helpers;

public static class EvaluationCommonHelper
{
	public static string CreateFileName(string prefixName, Dictionary<string, double> parameters)
	{
		var fileName = prefixName;
		foreach (var p in parameters)
		{
			fileName += @"_" + p.Key + "=" + Math.Round(p.Value, 2);
		}

		return fileName;
	}

	public static string CreateFile(string fileName, string extension)
	{
		var folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
		var folderName = SettingsHelper.Get<Properties.ChartRenderingSettings>().ImageFolderName;
		folder += folderName;
		var folderExists = Directory.Exists(folder);
		if (!folderExists)
			Directory.CreateDirectory(folder);

		return folder +  @"\" + fileName + extension;
	}

	public static Chart CreateBaseChart(ChartAreaParameters chartParameters)
	{
		var chart = new Chart();
		chart.Size = new Size(1920, 1080);

		chart.Series.Clear();
		chart.ChartAreas.Clear();
		chart.Legends.Clear();

		var chartArea = CreateChartArea(chartParameters);
		chart.ChartAreas.Add(chartArea);

		return chart;
	}

	private static ChartArea CreateChartArea(ChartAreaParameters parameters)
	{
		return new ChartArea
		{
			Name = parameters.Name,
			AxisX = parameters.AxisX,
			AxisY = parameters.AxisY,
			BackColor = Color.Transparent
		};
	}

	public class ChartAreaParameters
	{
		public string Name { get; set; }

		public Axis AxisX { get; set; }

		public Axis AxisY { get; set; }
	}
}