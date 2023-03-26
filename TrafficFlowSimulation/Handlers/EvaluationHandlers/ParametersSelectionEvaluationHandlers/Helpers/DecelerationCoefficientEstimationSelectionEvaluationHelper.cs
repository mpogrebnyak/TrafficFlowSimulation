using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Renders;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders.Models;

namespace TrafficFlowSimulation.Handlers.EvaluationHandlers.ParametersSelectionEvaluationHandlers.Helpers;

public static class DecelerationCoefficientEstimationSelectionEvaluationHelper
{
	public static void GenerateCharts(
		ModelParameters modelParameters,
		List<DecelerationCoefficientEstimationCoordinatesModel> coordinatesModel)
	{
		var optimalValue = coordinatesModel.Single(x => x.Color == CustomColors.Green);
		var chart = CreateChart(modelParameters, optimalValue.X);

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

		var chartName = EvaluationCommonHelper.GetFileName("Q_Estimation", parameters, ".png");
		chart.SaveImage(chartName, ChartImageFormat.Png);
	}

	private static Chart CreateChart(ModelParameters modelParameters, double value)
	{
		var chartArea = GetChartAreaParameters(modelParameters, value);
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

		for (var i = -10.0; i <= 10; i+=0.2)
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
			redLine.Points.Add(new DataPoint(value, i+10));

			chart.Series.Add(redLine);
		}

		return chart;
	}

	private static EvaluationCommonHelper.ChartAreaParameters GetChartAreaParameters(ModelParameters modelParameters, double value)
	{
		var chartArea = new EvaluationCommonHelper.ChartAreaParameters
		{
			Name = "DecelerationCoefficientEstimationChartArea",
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
				Maximum = 8,
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
			Text = "1",
			FromPosition = ChartCommonHelper.CalculateFromPosition(1),
			ToPosition = ChartCommonHelper.CalculateToPosition(1),
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
			Text = "8",
			FromPosition = ChartCommonHelper.CalculateFromPosition(8),
			ToPosition = ChartCommonHelper.CalculateToPosition(8),
			GridTicks = GridTickTypes.All
		});

		var tStop = modelParameters.Vn[0] / (modelParameters.g * modelParameters.mu);
		chartArea.AxisY.CustomLabels.Add(new CustomLabel
		{
			Text = Math.Round(tStop, 2).ToString(),
			FromPosition = ChartCommonHelper.CalculateFromPosition(tStop),
			ToPosition = ChartCommonHelper.CalculateToPosition(tStop),
			GridTicks = GridTickTypes.All
		});

		chartArea.AxisX.CustomLabels.Add(new CustomLabel
		{
			Text = Math.Round(value, 2).ToString(),
			FromPosition = ChartCommonHelper.CalculateFromPosition(value),
			ToPosition = ChartCommonHelper.CalculateToPosition(value),
			GridTicks = GridTickTypes.All
		});

		return chartArea;
	}
}