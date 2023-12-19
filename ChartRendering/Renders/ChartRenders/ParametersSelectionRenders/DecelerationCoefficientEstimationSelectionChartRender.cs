using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Constants;
using ChartRendering.Models;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Renders;

namespace ChartRendering.Renders.ChartRenders.ParametersSelectionRenders;

public class DecelerationCoefficientEstimationSelectionChartRender : ChartsRender
{
	protected override string SeriesName => "DecelerationCoefficientEstimationSeries";

	protected override string ChartAreaName => "DecelerationCoefficientEstimationChartArea";

	protected override SeriesChartType SeriesChartType => SeriesChartType.Spline;

	private readonly List<Color> _pointColors = CustomColors.GetColorsForDecelerationCoefficientEstimation();

	public DecelerationCoefficientEstimationSelectionChartRender(Chart chart) : base(chart)
	{
		FullClearChart();
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		FullClearChart();

		var chartArea = CreateChartArea(modelParameters, modeSettings);
		Chart.ChartAreas.Add(chartArea);

		foreach (var color in _pointColors)
		{
			Chart.Series.Add(new Series
			{
				Name = SeriesName + color.Name,
				ChartType = SeriesChartType,
				ChartArea = chartArea.Name,
				Color = color,
				MarkerStyle = MarkerStyle.Circle,
				MarkerSize = 5,
				BorderWidth = 5
			});
		}

		var environmentSeries = CreateEnvironment(modelParameters, modeSettings);
		foreach (var series in environmentSeries)
		{
			Chart.Series.Add(series);
		}
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
	/*	var coordinatesModel = (List<DecelerationCoefficientEstimationCoordinatesModel>) parameters;

		foreach (var cm in coordinatesModel)
		{
			_chart.Series.Single(series => series.Name.Contains(CustomColors.Black.Name))
				.Points
				.AddXY(cm.X, cm.Y);
		}
		
		var optimalValue = coordinatesModel.Single(x => x.Color == CustomColors.Green.Name);
		_chart.Series.Single(series => series.Name.Contains(CustomColors.Green.Name))
			.Points
			.AddXY(optimalValue.X, optimalValue.Y);*/
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		return new ChartArea
		{
			Name = ChartAreaName,
			AxisX = new Axis
			{
				Minimum = 0,
				Maximum = ((DecelerationCoefficientEstimationSettingsModel)modeSettings).MaxQ,
				Interval = 1
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = 10,
				Interval = 5
			}
		};
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var maxQ = ((DecelerationCoefficientEstimationSettingsModel) modeSettings).MaxQ;
		Chart.ChartAreas.First().AxisX.CustomLabels.Add(new CustomLabel
		{
			Text = maxQ.ToString(CultureInfo.InvariantCulture),
			FromPosition = ChartCommonHelper.CalculateFromPosition(maxQ),
			ToPosition = ChartCommonHelper.CalculateToPosition(maxQ),
			GridTicks = GridTickTypes.All
		});

		Chart.ChartAreas.First().AxisY.CustomLabels.Add(new CustomLabel
		{
			Text = "0",
			FromPosition = ChartCommonHelper.CalculateFromPosition(0),
			ToPosition = ChartCommonHelper.CalculateToPosition(0),
			GridTicks = GridTickTypes.All
		});

		Chart.ChartAreas.First().AxisY.CustomLabels.Add(new CustomLabel
		{
			Text = "10",
			FromPosition = ChartCommonHelper.CalculateFromPosition(10),
			ToPosition = ChartCommonHelper.CalculateToPosition(10),
			GridTicks = GridTickTypes.All
		});

		return new Series[] { };
	}

	public override void UpdateEnvironment(object parameters)
	{
		var environmentModel = (DecelerationCoefficientEnvironmentModel) parameters;

		if (!environmentModel.OptimalQ.HasValue)
		 return;

		Chart.ChartAreas.First().AxisX.CustomLabels.Add(new CustomLabel
		{
			Text = Math.Round(environmentModel.OptimalQ.Value, 2).ToString(),
			FromPosition = ChartCommonHelper.CalculateFromPosition(environmentModel.OptimalQ.Value),
			ToPosition = ChartCommonHelper.CalculateToPosition(environmentModel.OptimalQ.Value),
			GridTicks = GridTickTypes.All
		});

		Chart.ChartAreas.First().AxisY.CustomLabels.Add(new CustomLabel
		{
			Text = Math.Round(environmentModel.StopTime, 2).ToString(),
			FromPosition = ChartCommonHelper.CalculateFromPosition(environmentModel.OptimalTime),
			ToPosition = ChartCommonHelper.CalculateToPosition(environmentModel.OptimalTime),
			GridTicks = GridTickTypes.All
		});

		if (environmentModel.DoubleOptimalQ.HasValue)
		{
			Chart.ChartAreas.First().AxisX.CustomLabels.Add(new CustomLabel
			{
				Text = Math.Round(environmentModel.DoubleOptimalQ.Value, 2).ToString(),
				FromPosition = ChartCommonHelper.CalculateFromPosition(environmentModel.DoubleOptimalQ.Value),
				ToPosition = ChartCommonHelper.CalculateToPosition(environmentModel.DoubleOptimalQ.Value),
				GridTicks = GridTickTypes.All
			});

			Chart.ChartAreas.First().AxisY.CustomLabels.Add(new CustomLabel
			{
				Text = Math.Round(2 * environmentModel.StopTime, 2).ToString(),
				FromPosition = ChartCommonHelper.CalculateFromPosition(environmentModel.DoubleOptimalTime),
				ToPosition = ChartCommonHelper.CalculateToPosition(environmentModel.DoubleOptimalTime),
				GridTicks = GridTickTypes.All
			});
		}

		for (var i = -10.0; i <= 10; i+=0.5)
		{
			var redLine = new Series
			{
				Name = "RedLine" + i,
				ChartType = SeriesChartType.Line,
				ChartArea = ChartAreaName,
				BorderWidth = 1,
				Color = Color.Red,
				IsVisibleInLegend = false
			};

			redLine.Points.Add(new DataPoint(0, i));
			redLine.Points.Add(new DataPoint(environmentModel.OptimalQ.Value, i + 10));

			Chart.Series.Add(redLine);
		}
	}

	protected override Legend CreateLegend(LegendStyle legendStyle)
	{
		throw new System.NotImplementedException();
	}

	public override void SetChartAreaAxisTitle(bool isHidden = false)
	{
		throw new System.NotImplementedException();
	}
}