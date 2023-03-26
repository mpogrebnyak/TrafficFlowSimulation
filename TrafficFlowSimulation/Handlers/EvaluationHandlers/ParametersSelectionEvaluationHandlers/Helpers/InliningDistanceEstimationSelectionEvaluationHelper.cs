using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using Localization;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Properties.LocalizationResources;
using TrafficFlowSimulation.Renders;
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

				fullFIllChart.Series.Single(series => series.Name.Contains(CustomColors.Black.Name))
					.Points
					.AddXY(cm.X, cm.Y);
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
		chart.Legends.Add(CreateLegend());
		chart.ChartAreas[0].InnerPlotPosition = new ElementPosition
		{
			Auto = false,
			X = 7,
			Width = 93,
			Height = 95
		};

		foreach (var color in CustomColors.GetColorsForInliningDistanceEstimation())
		{
			chart.Series.Add(new Series
			{
				Name = "InliningDistanceEstimationSeries" + color.Name,
				ChartType = SeriesChartType.Point,
				Color = color,
				MarkerStyle = MarkerStyle.Circle,
				IsVisibleInLegend = false
			});
		}

		return chart;
	}

	private static Legend CreateLegend()
	{
		var legend = new Legend
		{
			Name = "Legend",
			TitleFont = new Font("Microsoft Sans Serif", 38F),
			LegendStyle = LegendStyle.Row,
			Docking = Docking.Top,
			Font = new Font("Microsoft Sans Serif", 38F),
			Alignment = StringAlignment.Center,
			Title = LocalizationHelper.Get<ParametersSelectionWindowResources>().SpeedReductionTitle,
			TitleAlignment = StringAlignment.Near,
			TableStyle = LegendTableStyle.Wide
		};

		var colorsIntensityDictionary = GetColorIntensityDictionary();
		foreach (var colorIntensity in colorsIntensityDictionary)
		{
			legend.CustomItems.Add(colorIntensity.Key, colorIntensity.Value.DisplayValue);
		}

		return legend;
	}

	private static Chart CreateLineChart(ModelParameters modelParameters)
	{
		var chart = EvaluationCommonHelper.CreateBaseChart(GetChartAreaParameters(modelParameters));

			chart.Series.Add(new Series
			{
				Name = "InliningDistanceEstimationSeries" + CustomColors.Black.Name,
				ChartType = SeriesChartType.Spline,
				BorderWidth = 2,
				Color = CustomColors.Green
			});

			return chart;
	}

	private static EvaluationCommonHelper.ChartAreaParameters GetChartAreaParameters(ModelParameters modelParameters)
	{
		var chartArea = new EvaluationCommonHelper.ChartAreaParameters
		{
			Name = "InliningDistanceEstimationChartArea",
			AxisX = new Axis
			{
				Minimum = 0,
				Maximum = 100,
				LabelAutoFitMinFontSize = 40
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = modelParameters.Vmax[1],
				LabelAutoFitMinFontSize = 40
			}
		};

		for (var i = 0.0; i <= modelParameters.Vmax[1]; i += modelParameters.Vmax[1] / 4)
		{
			chartArea.AxisY.CustomLabels.Add(new CustomLabel
			{
				Text = i == modelParameters.Vmax[1]
					? modelParameters.Vmax[1].ToString()
					: Math.Round(i, 0).ToString(),
				FromPosition = ChartCommonHelper.CalculateFromPosition(i, 5),
				ToPosition = ChartCommonHelper.CalculateToPosition(i, 5),
				GridTicks = GridTickTypes.All,
			});
		}

		for (var i = 20; i <= 100; i += 20)
		{
			chartArea.AxisX.CustomLabels.Add(new CustomLabel
			{
				Text = i.ToString(),
				FromPosition = ChartCommonHelper.CalculateFromPosition(i, 5),
				ToPosition = ChartCommonHelper.CalculateToPosition(i, 5),
				GridTicks = GridTickTypes.All
			});
		}

		return chartArea;
	}

	private static Color GetColor(double intensity, double max)
	{
		var colorIntensity = GetColorIntensityDictionary();

		if (intensity <= 0)
		{
			return colorIntensity.Single(x => x.Value.IntValue == (int) intensity).Key;
		}

		// на сколько процентов скорость снижения отличается от максимальной
		// 100 минус разница между числами в процентах
		var intensityInPercentage = 100 - (int) ((Math.Abs(intensity - max)) / max * 100);

		var color = colorIntensity.FirstOrDefault(x => intensityInPercentage <= x.Value.IntValue);

		return color.Key != Color.Empty
			? color.Key
			: colorIntensity.Single(x => x.Value.IntValue == -1).Key;
	}

	private static Dictionary<Color, ColorValue> GetColorIntensityDictionary()
	{
		return new Dictionary<Color, ColorValue>
			{
				{
					CustomColors.BrightRed,
					new ColorValue
					{
						IntValue = -1,
						DisplayOrder = 6,
						DisplayValue = LocalizationHelper.Get<ParametersSelectionWindowResources>().CrashTitle
					}
				},
				{
					CustomColors.Green,
					new ColorValue
					{
						IntValue = 0,
						DisplayOrder = 1,
						DisplayValue = "0"
					}
				},
				{
					CustomColors.LightGreen,
					new ColorValue
					{
						IntValue = 25,
						DisplayOrder = 2,
						DisplayValue = "≤25"
					}
				},
				{
					CustomColors.Yellow,
					new ColorValue
					{
						IntValue = 50,
						DisplayOrder = 3,
						DisplayValue = "≤50"
					}
				},
				{
					CustomColors.Orange,
					new ColorValue
					{
						IntValue = 75,
						DisplayOrder = 4,
						DisplayValue = "≤75"
					}
				},
				{
					CustomColors.LightRed,
					new ColorValue
					{
						IntValue = 98,
						DisplayOrder = 5,
						DisplayValue = "≤100"
					}
				}
			}
			.OrderBy(x => x.Value.DisplayOrder)
			.ToDictionary(x => x.Key, x => x.Value);
	}

	private class ColorValue
	{
		public int IntValue;

		public int DisplayOrder;

		public string DisplayValue;
	}
}