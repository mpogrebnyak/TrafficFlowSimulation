using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Renders;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders.Models;

namespace TrafficFlowSimulation.Handlers.EvaluationHandlers.ParametersSelectionEvaluationHandlers.Helpers;

public static class AccelerationCoefficientEstimationSelectionEvaluationHelper
{
	public static void GenerateCharts(
		ModelParameters modelParameters,
		List<CoefficientEstimationCoordinatesModel> coordinatesModel,
		AccelerationCoefficientEnvironmentModel environmentModel)
	{
		var chart = CreateChart(modelParameters, environmentModel);

		foreach (var cm in coordinatesModel)
		{
			chart.Series.Single(series => series.Name.Contains(cm.Color))
				.Points
				.AddXY(cm.X, cm.Y);
		}

		var parameters = new Dictionary<string, double>
		{
			{"a", modelParameters.a[0]}
		};

		var fileName = EvaluationCommonHelper.CreateFileName("A_Estimation", parameters);
		var chartFilePath = EvaluationCommonHelper.CreateFile(fileName, ".png");
		chart.SaveImage(chartFilePath, ChartImageFormat.Png);
	}

	private static Chart CreateChart(ModelParameters modelParameters, AccelerationCoefficientEnvironmentModel environmentModel)
	{
		var chart = EvaluationCommonHelper.CreateBaseChart(GetChartAreaParameters(modelParameters, environmentModel));
		foreach (var color in CustomColors.GetColorsForAccelerationCoefficientEstimation())
		{
			chart.Series.Add(new Series
			{
				Name = "AccelerationCoefficientEstimationSeries" + color.Name,
				ChartType = SeriesChartType.Point,
				Color = color,
				MarkerStyle = MarkerStyle.Circle,
				MarkerSize = 10
			});
		}

		return chart;
	}

	private static EvaluationCommonHelper.ChartAreaParameters GetChartAreaParameters(ModelParameters modelParameters, AccelerationCoefficientEnvironmentModel environmentModel)
	{
		var chartArea = new EvaluationCommonHelper.ChartAreaParameters
		{
			Name = "AccelerationCoefficientEstimationChartArea",
			AxisX = new Axis
			{
				Minimum = 0,
				Maximum = 1,
				LabelAutoFitMinFontSize = 40,
				LineWidth = 2,
				MajorGrid = new Grid
				{
					LineWidth = 2
				}
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = 20,
				LabelAutoFitMinFontSize = 40,
				LineWidth = 2,
				MajorGrid = new Grid
				{
					LineWidth = 2
				}
			}
		};

		chartArea.AxisX.CustomLabels.Add(new CustomLabel
		{
			Text = "a",
			FromPosition = ChartCommonHelper.CalculateFromPosition(1),
			ToPosition = ChartCommonHelper.CalculateToPosition(1),
			GridTicks = GridTickTypes.All,
		});
		for (var i = 0; i <= 20; i += 5)
		{
			if (i == 10)
				continue;

			var text = i == 20 ? "t₀" : i.ToString();
			chartArea.AxisY.CustomLabels.Add(new CustomLabel
			{
				Text = text,
				FromPosition = ChartCommonHelper.CalculateFromPosition(i),
				ToPosition = ChartCommonHelper.CalculateToPosition(i),
				GridTicks = GridTickTypes.All
			});
		}
		if (environmentModel.MaxAValue.HasValue)
		{
			chartArea.AxisX.CustomLabels.Add(new CustomLabel
			{
				Text = Math.Round(environmentModel.MaxAValue.Value, 2).ToString(),
				FromPosition = ChartCommonHelper.CalculateFromPosition(environmentModel.MaxAValue.Value),
				ToPosition = ChartCommonHelper.CalculateToPosition(environmentModel.MaxAValue.Value),
				GridTicks = GridTickTypes.All
			});
		}
		if (environmentModel.MinAValue.HasValue)
		{
			chartArea.AxisX.CustomLabels.Add(new CustomLabel
			{
				Text = Math.Round(environmentModel.MinAValue.Value, 2).ToString(),
				FromPosition = ChartCommonHelper.CalculateFromPosition(environmentModel.MinAValue.Value),
				ToPosition = ChartCommonHelper.CalculateToPosition(environmentModel.MinAValue.Value),
				GridTicks = GridTickTypes.All
			});
		}

		return chartArea;
	}
}