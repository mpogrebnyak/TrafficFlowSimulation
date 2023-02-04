using System;
using System.Collections.Generic;
using System.Drawing;
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
				lineChart.Series.Single(series => series.Name.Contains(CustomColors.Black.Name))
					.Points
					.AddXY(cm.X, cm.Y);

				//fullFIllChart.Series.Single(series => series.Name.Contains(InliningDistanceEstimationColor.Black.Name))
				//	.Points
				//	.AddXY(cm.X, cm.Y);
			}
		}

		var parameters = new Dictionary<string, double>
		{
			{"k", modelParameters.k[1]},
			{"a", modelParameters.a[1]},
		};

		var fullFIllChartName = EvaluationCommonHelper.GetFileName("FullFIll", parameters);
		fullFIllChart.SaveImage(fullFIllChartName, ChartImageFormat.Png);
		var lineFIllChartName = EvaluationCommonHelper.GetFileName("LineFIll", parameters);
		lineChart.SaveImage(lineFIllChartName, ChartImageFormat.Png);;
	}

	private static Chart CreateFullFIllChart(ModelParameters modelParameters)
	{
		var chart = EvaluationCommonHelper.CreateBaseChart(GetChartAreaParameters(modelParameters));
		foreach (var color in CustomColors.GetColorsForInliningDistanceEstimation())
		{
			chart.Series.Add(new Series
			{
				Name = "InliningDistanceEstimationSeries" + color.Name,
				ChartType = SeriesChartType.Point,
			//	ChartArea = chartArea.Name,
			//	BorderWidth = 0,
				Color = color,
				MarkerStyle = MarkerStyle.Circle
			});
		}

		return chart;
	}

	private static Chart CreateLineChart(ModelParameters modelParameters)
	{
		var chart = EvaluationCommonHelper.CreateBaseChart(GetChartAreaParameters(modelParameters));
		//foreach (var color in InliningDistanceEstimationColor.GetAllColors())
		//{
			chart.Series.Add(new Series
			{
				Name = "InliningDistanceEstimationSeries" + CustomColors.Black.Name,
				ChartType = SeriesChartType.Spline,
				//ChartArea = chartArea.Name,
				BorderWidth = 1,
				Color = CustomColors.Black,
			//	MarkerStyle = MarkerStyle.Circle
			});
		//}

		return chart;
	}

	private static EvaluationCommonHelper.ChartAreaParameters GetChartAreaParameters(ModelParameters modelParameters)
	{
		return new EvaluationCommonHelper.ChartAreaParameters
		{
			Name = "InliningDistanceEstimationChartArea",
			AxisX = new Axis
			{
				Minimum = 0,
				Maximum = 100
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = modelParameters.Vmax[1],
				Interval = modelParameters.Vmax[1] / 2
			}
		};
	}

	public static Color GetColor(double intensity, double max)
	{
		if (intensity < 0)
		{
			return CustomColors.BrightRed;
		}

		if (intensity == 0)
		{
			return CustomColors.Green;
		}

		// на сколько процентов скорость снижения отличается от максимальной
		// 100 минус разница между числами в процентах
		var intensityInPercentage = 100 - (int) ((Math.Abs(intensity - max)) / max * 100);

		if (intensityInPercentage < 5)
		{
			return CustomColors.LightGreen;
		}

		if (intensityInPercentage < 50)
		{
			return CustomColors.LightOrange;
		}

		if (intensityInPercentage < 90)
		{
			return CustomColors.Orange;
		}

		return CustomColors.LightRed;
	}
}