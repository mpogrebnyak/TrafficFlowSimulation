using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders.Models;

namespace TrafficFlowSimulation.Handlers.EvaluationHandlers.ParametersSelectionEvaluationHandlers.Helpers;

public static class InliningDistanceEstimationSelectionEvaluationHelper
{
	public static void AddCoordinates(ModelParameters mp, List<InliningDistanceEstimationCoordinatesModel> cm, double x, double y, double intensity, bool isIntensityChange = false)
	{
		cm.Add(new InliningDistanceEstimationCoordinatesModel
		{
			X = x,
			Y = y,
			Color = GetColor(intensity, mp.Vmax[1]),
			IsIntensityChange = isIntensityChange
		});
	}

	public static void GenerateCharts(ModelParameters modelParameters, List<InliningDistanceEstimationCoordinatesModel> coordinatesModel)
	{
		var fullFIllChart = CreateFullFIllChart(modelParameters);
		var lineChart = CreateLineChart(modelParameters);

		foreach (var cm in coordinatesModel)
		{
			fullFIllChart.Series.Single(series => series.Name.Contains(cm.Color.Name))
				.Points
				.AddXY(cm.X, cm.Y);

			if (cm.IsIntensityChange)
			{
				lineChart.Series.Single(series => series.Name.Contains(InliningDistanceEstimationColor.Black.Name))
					.Points
					.AddXY(cm.X, cm.Y);

				//fullFIllChart.Series.Single(series => series.Name.Contains(InliningDistanceEstimationColor.Black.Name))
				//	.Points
				//	.AddXY(cm.X, cm.Y);
			}
		}

		var fullFIllChartName = GetFileName("FullFIll", modelParameters.k[1], modelParameters.a[1]);
		fullFIllChart.SaveImage(fullFIllChartName, ChartImageFormat.Png);
		var lineFIllChartName = GetFileName("LineFIll", modelParameters.k[1], modelParameters.a[1]);
		lineChart.SaveImage(lineFIllChartName, ChartImageFormat.Png);;
	}

	private static string GetFileName(string chartName, double k, double a)
	{
		var folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
		folder += @"\Images";
		var folderExists = Directory.Exists(folder);
		if (!folderExists)
			Directory.CreateDirectory(folder);

		var name =
			@"\" + 
			chartName +
			@"_k=" + Math.Round(k, 2) +
			@"_a=" + Math.Round(a, 2);
		return folder + name + ".png";
	}

	private static Chart CreateFullFIllChart(ModelParameters modelParameters)
	{
		var chart = CreateBaseChart(modelParameters);
		foreach (var color in InliningDistanceEstimationColor.GetAllColors())
		{
			chart.Series.Add(new Series
			{
				Name = "InliningDistanceEstimationSeries" + color.Name,
				ChartType = SeriesChartType.Point,
			//	ChartArea = chartArea.Name,
				BorderWidth = 1,
				Color = color,
				MarkerStyle = MarkerStyle.Circle
			});
		}

		return chart;
	}

	private static Chart CreateLineChart(ModelParameters modelParameters)
	{
		var chart = CreateBaseChart(modelParameters);
		//foreach (var color in InliningDistanceEstimationColor.GetAllColors())
		//{
			chart.Series.Add(new Series
			{
				Name = "InliningDistanceEstimationSeries" + InliningDistanceEstimationColor.Black.Name,
				ChartType = SeriesChartType.Line,
				//ChartArea = chartArea.Name,
				BorderWidth = 1,
				Color = InliningDistanceEstimationColor.Black,
			//	MarkerStyle = MarkerStyle.Circle
			});
		//}

		return chart;
	}

	private static Chart CreateBaseChart(ModelParameters modelParameters)
	{
		var chart = new Chart();
		chart.Size = new Size(800, 600);

		chart.Series.Clear();
		chart.ChartAreas.Clear();
		chart.Legends.Clear();

		var chartArea = CreateChartArea(modelParameters);
		chart.ChartAreas.Add(chartArea);

		return chart;
	}

	private static ChartArea CreateChartArea(ModelParameters modelParameters)
	{
		return new ChartArea
		{
			Name = "InliningDistanceEstimationChartArea",
			AxisX = new Axis
			{
				Minimum = 0,
				Maximum = 100,
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = modelParameters.Vmax[1],
				Interval = modelParameters.Vmax[1] / 2,
			}
		};
	}

	public static Color GetColor(double intensity, double max)
	{
		if (intensity < 0)
		{
			return InliningDistanceEstimationColor.Red;
		}

		if (intensity == 0)
		{
			return InliningDistanceEstimationColor.Green;
		}

		// на сколько процентов скорость снижения отличается от максимальной
		// 100 минус разница между числами в процентах
		var intensityInPercentage = 100 - (int) ((Math.Abs(intensity - max)) / max * 100);

		if (intensityInPercentage < 5)
		{
			return InliningDistanceEstimationColor.LightGreen;
		}

		if (intensityInPercentage < 50)
		{
			return InliningDistanceEstimationColor.LightOrange;
		}

		if (intensityInPercentage < 90)
		{
			return InliningDistanceEstimationColor.Orange;
		}

		return InliningDistanceEstimationColor.LightRed;
	}
}