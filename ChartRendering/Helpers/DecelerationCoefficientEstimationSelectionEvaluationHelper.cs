using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.Constants;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Renders;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders.Models;

namespace ChartRendering.Helpers;

public static class DecelerationCoefficientEstimationSelectionEvaluationHelper
{
	public static void GenerateCharts(
		ModelParameters modelParameters,
		List<DecelerationCoefficientEstimationCoordinatesModel> coordinatesModel,
		DecelerationCoefficientEnvironmentModel environmentModel)
	{
		var optimalValue = coordinatesModel.Single(x => x.Color == CustomColors.Green.Name);
		var chart = CreateChart(modelParameters, environmentModel);

		foreach (var cm in coordinatesModel)
		{
			chart.Series.Single(series => series.Name.Contains(CustomColors.Black.Name))
				.Points
				.AddXY(cm.X, cm.Y);
		}

		chart.Series.Single(series => series.Name.Contains(CustomColors.Green.Name))
			.Points
			.AddXY(optimalValue.X, optimalValue.Y);

		var parameters = new Dictionary<string, double>
		{
			{"q", 1}
		};

		var fileName = EvaluationCommonHelper.CreateFileName("Q_Estimation", parameters);
		var chartFilePath = EvaluationCommonHelper.CreateFile(fileName, ".png");
		chart.SaveImage(chartFilePath, ChartImageFormat.Png);
	}

	private static Chart CreateChart(ModelParameters modelParameters, DecelerationCoefficientEnvironmentModel environmentModel)
	{
		var chartArea = GetChartAreaParameters(modelParameters, environmentModel);
		var chart = EvaluationCommonHelper.CreateBaseChart(chartArea);
		foreach (var color in CustomColors.GetColorsForDecelerationCoefficientEstimation())
		{
			chart.Series.Add(new Series
			{
				Name = "DecelerationCoefficientEstimationSeries" + color.Name,
				ChartType = SeriesChartType.Spline,
				Color = color,
				MarkerStyle = MarkerStyle.Circle,
				MarkerSize = 10,
				BorderWidth = 10
			});
		}

		if (environmentModel.OptimalQ.HasValue)
		{
			for (var i = -10.0; i <= 10; i += 0.2)
			{
				var redLine = new Series
				{
					Name = "RedLine" + i,
					ChartType = SeriesChartType.Line,
					ChartArea = chartArea.Name,
					BorderWidth = 1,
					Color = CustomColors.BrightRed,
					IsVisibleInLegend = false
				};

				redLine.Points.Add(new DataPoint(0, i));
				redLine.Points.Add(new DataPoint(environmentModel.OptimalQ.Value, i + 10));

				chart.Series.Add(redLine);
			}
		}

		return chart;
	}

	private static EvaluationCommonHelper.ChartAreaParameters GetChartAreaParameters(ModelParameters modelParameters, DecelerationCoefficientEnvironmentModel environmentModel)
	{
		var chartArea = new EvaluationCommonHelper.ChartAreaParameters
		{
			Name = "DecelerationCoefficientEstimationChartArea",
			AxisX = new Axis
			{
				Minimum = 0,
				Maximum = 3,
				LabelAutoFitMinFontSize = 60,
				LineWidth = 2,
				MajorGrid = new Grid
				{
					LineWidth = 2
				}
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = 10,
				LabelAutoFitMinFontSize = 60,
				LineWidth = 2,
				MajorGrid = new Grid
				{
					LineWidth = 2
				}
			}
		};

		chartArea.AxisX.CustomLabels.Add(new CustomLabel
		{
			Text = "q",
			FromPosition = ChartCommonHelper.CalculateFromPosition(3),
			ToPosition = ChartCommonHelper.CalculateToPosition(3),
			GridTicks = GridTickTypes.All
		});

		chartArea.AxisY.CustomLabels.Add(new CustomLabel
		{
			Text = "0",
			FromPosition = ChartCommonHelper.CalculateFromPosition(0),
			ToPosition = ChartCommonHelper.CalculateToPosition(0),
			GridTicks = GridTickTypes.All
		});

		chartArea.AxisY.CustomLabels.Add(new CustomLabel
		{
			Text = "t",
			FromPosition = ChartCommonHelper.CalculateFromPosition(10),
			ToPosition = ChartCommonHelper.CalculateToPosition(10),
			GridTicks = GridTickTypes.All
		});

		if (environmentModel.OptimalQ.HasValue)
		{
			chartArea.AxisX.CustomLabels.Add(new CustomLabel
			{
				Text = Math.Round(environmentModel.OptimalQ.Value, 2).ToString(),
				FromPosition = ChartCommonHelper.CalculateFromPosition(environmentModel.OptimalQ.Value),
				ToPosition = ChartCommonHelper.CalculateToPosition(environmentModel.OptimalQ.Value),
				GridTicks = GridTickTypes.All
			});

			chartArea.AxisY.CustomLabels.Add(new CustomLabel
			{
				Text = Math.Round(environmentModel.StopTime, 2).ToString(),
				FromPosition = ChartCommonHelper.CalculateFromPosition(environmentModel.OptimalTime),
				ToPosition = ChartCommonHelper.CalculateToPosition(environmentModel.OptimalTime),
				GridTicks = GridTickTypes.All
			});
		}

		if (environmentModel.DoubleOptimalQ.HasValue)
		{
			chartArea.AxisX.CustomLabels.Add(new CustomLabel
			{
				Text = Math.Round(environmentModel.DoubleOptimalQ.Value, 2).ToString(),
				FromPosition = ChartCommonHelper.CalculateFromPosition(environmentModel.DoubleOptimalQ.Value),
				ToPosition = ChartCommonHelper.CalculateToPosition(environmentModel.DoubleOptimalQ.Value),
				GridTicks = GridTickTypes.All
			});

			chartArea.AxisY.CustomLabels.Add(new CustomLabel
			{
				Text = Math.Round(2 * environmentModel.StopTime, 2).ToString(),
				FromPosition = ChartCommonHelper.CalculateFromPosition(environmentModel.DoubleOptimalTime),
				ToPosition = ChartCommonHelper.CalculateToPosition(environmentModel.DoubleOptimalTime),
				GridTicks = GridTickTypes.All
			});
		}

		return chartArea;
	}
}