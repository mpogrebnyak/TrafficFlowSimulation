using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Constants;
using ChartRendering.Models;
using Common;
using EvaluationKernel.Models;
using Settings;
using TrafficFlowSimulation.Renders;

namespace ChartRendering.Helpers;

public static class InliningDistanceEstimationSelectionEvaluationHelper
{
	private static readonly Dictionary<Color, ColorValue> ColorIntensity = GetColorIntensityDictionary();

	public static void AddCoordinates(double maxSpeed, List<InliningDistanceEstimationCoordinatesModel> cm, double x, double y, double intensity)
	{
		var intensityInPercentage = 0.0;
		if (maxSpeed != 0)
		{
				maxSpeed = maxSpeed > 4
				? maxSpeed
				: 4;
			// на сколько процентов скорость снижения отличается от максимальной
			// 100 минус разница между числами в процентах
			intensityInPercentage = intensity <= 0
				? intensity
				: 100 - (int) ((Math.Abs(intensity - maxSpeed)) / maxSpeed * 100);
		}

		cm.Add(new InliningDistanceEstimationCoordinatesModel
		{
			X = x,
			Y = y,
			Color = GetColor(intensityInPercentage),
			Intensity = intensityInPercentage
		});
	}

	public static string CreatePointsFile(double k)
	{
		var parameters = new Dictionary<string, double>
		{
			{"k",k}
		};
		var pointsFileName = CommonFileHelper.CreateFileName("Points", parameters);
		var folderName = SettingsHelper.Get<Properties.ChartRenderingSettings>().ImageFolderName;
		return CommonFileHelper.CreateFile(pointsFileName, folderName, ".txt");
	}

	public static void SavePoints(string path, ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var fileName = Path.GetFileName(path);
		var serializerData = new SerializerPointsModel
		{
			Name = fileName,
			ModelParameters = modelParameters,
			ModeSettings = modeSettings,
			CoordinatesModel = new List<InliningDistanceEstimationCoordinatesModel>()
		};

		TrySavePoints(path, serializerData);
	}

	public static void SavePoints(string path, List<InliningDistanceEstimationCoordinatesModel> coordinatesModel, double lastValue)
	{
		var pointsModel = SerializerPointsHelper.DeserializePoints(path);
		pointsModel.CoordinatesModel.AddRange(coordinatesModel);
		pointsModel.LastValue = lastValue;

		TrySavePoints(path, pointsModel);
	}

	public static bool TryGetLastValue(string path, out double lastValue)
	{
		try
		{
			var pointsModel = SerializerPointsHelper.DeserializePoints(path);
			lastValue = pointsModel.LastValue;
			return true;
		}
		catch
		{
			lastValue = 0;
		}

		return false;
	}

	public static void GenerateCharts(string path)
	{
		var pointsModel = SerializerPointsHelper.DeserializePoints(path);
		var modelParameters = pointsModel.ModelParameters;

		var fullFIllChart = CreateFullFIllChart(modelParameters);
		var lineChart = CreateLineChart(modelParameters);

		foreach (var cm in pointsModel.CoordinatesModel)
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

		var lineL = CreateLineL(modelParameters);
		fullFIllChart.Series.Add(lineL);

		var parameters = new Dictionary<string, double>
		{
			{"k", modelParameters.k[1]}
		};

		var folderName = SettingsHelper.Get<Properties.ChartRenderingSettings>().ImageFolderName;

		var fullFIllFileName = CommonFileHelper.CreateFileName("FullFIll", parameters);
		var fullFIllFilePath = CommonFileHelper.CreateFile(fullFIllFileName, folderName, ".png");
		fullFIllChart.SaveImage(fullFIllFilePath, ChartImageFormat.Png);

		var lineFIllFileName = CommonFileHelper.CreateFileName("LineFIll", parameters);
		var lineFIllFilePath = CommonFileHelper.CreateFile(lineFIllFileName, folderName, ".png");
		lineChart.SaveImage(lineFIllFilePath, ChartImageFormat.Png);
	}

	private static void TrySavePoints(string path, SerializerPointsModel serializerPointsModel)
	{
		var attempt = 5;
		while (true)
		{
			try
			{
				attempt--;
				SerializerPointsHelper.SerializePoints(path, serializerPointsModel);
				return;
			}
			catch (Exception e)
			{
				if (attempt == 0)
				{
					throw new Exception(e.Message);
				}
				GC.Collect();
				System.Threading.Thread.Sleep(1000);
			}
		}
	}

	private static Chart CreateFullFIllChart(ModelParameters modelParameters)
	{
	/*	var chart = EvaluationCommonHelper.CreateBaseChart(GetChartAreaParameters(modelParameters));
		chart.Legends.Add(CreateLegend(modelParameters));
		chart.ChartAreas[0].InnerPlotPosition = new ElementPosition
		{
			Auto = false,
			X = 7,
			Width = 93,
			Height = 93
		};

		foreach (var color in CustomColors.GetColorsForInliningDistanceEstimation())
		{
			chart.Series.Add(new Series
			{
				Name = "InliningDistanceEstimationSeries" + color.Name,
				ChartType = SeriesChartType.Point,
				Color = color,
				MarkerStyle = MarkerStyle.Circle,
				MarkerSize = color != CustomColors.Black
					? 3
					: 4,
				IsVisibleInLegend = false
			});
		}

		return chart;*/
	return new Chart();
	}

	private static Series CreateLineL(ModelParameters modelParameters)
	{
		var lineL = new Series
		{
			Name = "lineL",
			ChartType = SeriesChartType.Line,
			BorderWidth = 2,
			Color = CustomColors.Black,
			IsVisibleInLegend = false,
			
		};
		lineL.Points.Add(new DataPoint(modelParameters.lCar[0] + modelParameters.lSafe[1], 0));
		lineL.Points.Add(new DataPoint(modelParameters.lCar[0] + modelParameters.lSafe[1],  modelParameters.Vmax[1] + 1));

		return lineL;
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
			//Title = LocalizationHelper.Get<ParametersSelectionWindowResources>().SpeedReductionTitle(modelParameters.k[1]).Replace(',', '.'),
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
		/*var chart = EvaluationCommonHelper.CreateBaseChart(GetChartAreaParameters(modelParameters));

			chart.Series.Add(new Series
			{
				Name = "InliningDistanceEstimationSeries" + CustomColors.Black.Name,
				ChartType = SeriesChartType.Spline,
				BorderWidth = 2,
				Color = CustomColors.Green
			});

			return chart;*/
		return new Chart();
	}

/*	private static EvaluationCommonHelper.ChartAreaParameters GetChartAreaParameters(ModelParameters modelParameters)
	{
		var chartArea = new EvaluationCommonHelper.ChartAreaParameters
		{
			Name = "InliningDistanceEstimationChartArea",
			AxisX = new Axis
			{
				Minimum = 0,
				Maximum = 100,
				LabelAutoFitMinFontSize = 50
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = modelParameters.Vmax[1],
				LabelAutoFitMinFontSize = 50
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
				FromPosition = ChartCommonHelper.CalculateFromPosition(i, 50),
				ToPosition = ChartCommonHelper.CalculateToPosition(i, 50),
				GridTicks = GridTickTypes.All
			});
		}

		chartArea.AxisX.CustomLabels.Add(new CustomLabel
		{
			Text = "ℓ",
			FromPosition = ChartCommonHelper.CalculateFromPosition(modelParameters.lCar[0] + modelParameters.lSafe[1], 50),
			ToPosition = ChartCommonHelper.CalculateToPosition(modelParameters.lCar[0] + modelParameters.lSafe[1], 50),
			GridTicks = GridTickTypes.All
		});

		return chartArea;
	}*/

	private static string GetColor(double intensityInPercentage)
	{
		var colorIntensity = ColorIntensity;

		if (intensityInPercentage <= 0)
		{
			return colorIntensity.Single(x => x.Value.IntValue == (int) intensityInPercentage).Key.Name;
		}

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
						//DisplayValue = LocalizationHelper.Get<ParametersSelectionWindowResources>().CrashTitle
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