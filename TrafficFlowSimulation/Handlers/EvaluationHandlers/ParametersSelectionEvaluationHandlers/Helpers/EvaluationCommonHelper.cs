using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace TrafficFlowSimulation.Handlers.EvaluationHandlers.ParametersSelectionEvaluationHandlers.Helpers;

public static class EvaluationCommonHelper
{
	public static string GetFileName(string chartName, Dictionary<string, double> parameters, string extension)
	{
		var folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
		folder += @"\Images";
		var folderExists = Directory.Exists(folder);
		if (!folderExists)
			Directory.CreateDirectory(folder);

		var name = @"\" + chartName;
		foreach (var p in parameters)
		{
			name += @"_" + p.Key + "=" + Math.Round(p.Value, 2);
		}

		return folder + name + extension;
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