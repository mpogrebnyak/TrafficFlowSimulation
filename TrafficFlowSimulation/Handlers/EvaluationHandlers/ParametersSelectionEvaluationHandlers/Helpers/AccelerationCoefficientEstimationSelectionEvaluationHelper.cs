﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders.Models;

namespace TrafficFlowSimulation.Handlers.EvaluationHandlers.ParametersSelectionEvaluationHandlers.Helpers;

public static class AccelerationCoefficientEstimationSelectionEvaluationHelper
{
	public static void GenerateCharts(
		ModelParameters modelParameters,
		List<AccelerationCoefficientEstimationCoordinatesModel> coordinatesModel,
		AccelerationCoefficientEnvironmentModel environmentModel)
	{
		var chart = CreateChart(modelParameters, environmentModel);

		foreach (var cm in coordinatesModel)
		{
			chart.Series.Single(series => series.Name.Contains(cm.Color.Name))
				.Points
				.AddXY(cm.X, cm.Y);
		}

		var parameters = new Dictionary<string, double>
		{
			{"a", modelParameters.a[0]}
		};

		var chartName = EvaluationCommonHelper.GetFileName("A_Estimation", parameters);
		chart.SaveImage(chartName, ChartImageFormat.Png);
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

		var stepForLabel = 1;
		chartArea.AxisX.CustomLabels.Add(new CustomLabel
		{
			Text = "1",
			FromPosition = 1 - stepForLabel,
			ToPosition = 1 + stepForLabel,
			GridTicks = GridTickTypes.All,
		});
		for (var i = 0; i <= 20; i += 5)
		{
			if (i == 10)
				continue;
			chartArea.AxisY.CustomLabels.Add(new CustomLabel
			{
				Text = i.ToString(),
				FromPosition = i - stepForLabel,
				ToPosition = i + stepForLabel,
				GridTicks = GridTickTypes.All
			});
		}
		if (environmentModel.MaxAValue.HasValue)
		{
			chartArea.AxisX.CustomLabels.Add(new CustomLabel
			{
				Text = Math.Round(environmentModel.MaxAValue.Value, 2).ToString(),
				FromPosition = environmentModel.MaxAValue.Value - stepForLabel,
				ToPosition = environmentModel.MaxAValue.Value + stepForLabel,
				GridTicks = GridTickTypes.All
			});
		}
		if (environmentModel.MinAValue.HasValue)
		{
			chartArea.AxisX.CustomLabels.Add(new CustomLabel
			{
				Text = Math.Round(environmentModel.MinAValue.Value, 2).ToString(),
				FromPosition = environmentModel.MinAValue.Value - stepForLabel,
				ToPosition = environmentModel.MinAValue.Value + stepForLabel,
				GridTicks = GridTickTypes.All
			});
		}

		return chartArea;
	}
}