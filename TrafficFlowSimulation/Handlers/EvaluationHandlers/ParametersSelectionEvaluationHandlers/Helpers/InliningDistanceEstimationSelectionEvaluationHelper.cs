using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using Localization;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Properties.LocalizationResources;
using TrafficFlowSimulation.Renders;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders.Models;

namespace TrafficFlowSimulation.Handlers.EvaluationHandlers.ParametersSelectionEvaluationHandlers.Helpers;

public static class InliningDistanceEstimationSelectionEvaluationHelper
{ 
	public static void AddCoordinates(ModelParameters mp, List<InliningDistanceEstimationCoordinatesModel> cm, double x, double y, double intensity)
	{
		cm.Add(new InliningDistanceEstimationCoordinatesModel
		{
			X = x,
			Y = y,
			Color = GetColor(intensity, mp.Vmax[1]),
			Intensity = intensity
		});
	}

	public static void SavePoints(ModelParameters modelParameters, BaseSettingsModels modeSettings, List<InliningDistanceEstimationCoordinatesModel> coordinatesModel)
	{
		var parameters = new Dictionary<string, double>
		{
			{"k", modelParameters.k[1]},
			{"a", modelParameters.a[1]},
		};

		var pointsFileName = EvaluationCommonHelper.CreateFileName("Points", parameters);
		var pointsFilePath = EvaluationCommonHelper.CreateFile(pointsFileName, ".txt");

		SerializerPointsHelper.SerializePoints(pointsFileName, pointsFilePath, modelParameters, modeSettings, coordinatesModel);
	}

	public static void GenerateCharts(ModelParameters modelParameters, List<InliningDistanceEstimationCoordinatesModel> coordinatesModel)
	{
		var fullFIllChart = CreateFullFIllChart(modelParameters);
		var lineChart = CreateLineChart(modelParameters);

		foreach (var cm in coordinatesModel)
		{
			fullFIllChart.Series.Single(series => series.Name.Contains(cm.Color))
				.Points
				.AddXY(cm.X, cm.Y);

			if (cm.IsIntensityChangedToZero)
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

		var fullFIllFileName = EvaluationCommonHelper.CreateFileName("FullFIll", parameters);
		var fullFIllFilePath = EvaluationCommonHelper.CreateFile(fullFIllFileName, ".png");
		fullFIllChart.SaveImage(fullFIllFilePath, ChartImageFormat.Png);

		var lineFIllFileName = EvaluationCommonHelper.CreateFileName("LineFIll", parameters);
		var lineFIllFilePath = EvaluationCommonHelper.CreateFile(lineFIllFileName, ".png");
		lineChart.SaveImage(lineFIllFilePath, ChartImageFormat.Png);
	}

	private static Chart CreateFullFIllChart(ModelParameters modelParameters)
	{
		var chart = EvaluationCommonHelper.CreateBaseChart(GetChartAreaParameters(modelParameters));
		chart.Legends.Add(CreateLegend(modelParameters));
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

	private static Legend CreateLegend(ModelParameters modelParameters)
	{
		var legend = new Legend
		{
			Name = "Legend",
			TitleFont = new Font("Microsoft Sans Serif", 38F),
			LegendStyle = LegendStyle.Row,
			Docking = Docking.Top,
			Font = new Font("Microsoft Sans Serif", 38F),
			Alignment = StringAlignment.Center,
			Title = LocalizationHelper.Get<ParametersSelectionWindowResources>().SpeedReductionTitle2(modelParameters.k[1]).Replace(',', '.'),
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
					? "v"
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
				Text = i != 100 ? i.ToString() : "λ",
				FromPosition = ChartCommonHelper.CalculateFromPosition(i, 5),
				ToPosition = ChartCommonHelper.CalculateToPosition(i, 5),
				GridTicks = GridTickTypes.All
			});
		}

		return chartArea;
	}

	private static string GetColor(double intensity, double max)
	{
		var colorIntensity = GetColorIntensityDictionary();

		if (intensity <= 0)
		{
			return colorIntensity.Single(x => x.Value.IntValue == (int) intensity).Key.Name;
		}

		// на сколько процентов скорость снижения отличается от максимальной
		// 100 минус разница между числами в процентах
		var intensityInPercentage = 100 - (int) ((Math.Abs(intensity - max)) / max * 100);

		var color = colorIntensity.FirstOrDefault(x => intensityInPercentage <= x.Value.IntValue);

		return color.Key != Color.Empty
			? color.Key.Name
			: colorIntensity.Single(x => x.Value.IntValue == -1).Key.Name;
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
						IntValue = 100,
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