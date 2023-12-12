using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Constants;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Models.ChartRenderModels;
using TrafficFlowSimulation.Models.ChartRenderModels.ParametersSelectionSettingsModels;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders.Models;

namespace TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders;

public class DecelerationCoefficientEstimationSelectionChartRender : ChartsRender
{
	protected override string _seriesName => "DecelerationCoefficientEstimationSeries";

	protected override string _chartAreaName => "DecelerationCoefficientEstimationChartArea";

	protected override SeriesChartType _seriesChartType => SeriesChartType.Spline;

	private readonly List<Color> _pointColors = CustomColors.GetColorsForDecelerationCoefficientEstimation();

	public DecelerationCoefficientEstimationSelectionChartRender(Chart chart) : base(chart)
	{
		FullClearChart();
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		FullClearChart();

		var chartArea = CreateChartArea(modelParameters, modeSettings);
		_chart.ChartAreas.Add(chartArea);

		foreach (var color in _pointColors)
		{
			_chart.Series.Add(new Series
			{
				Name = _seriesName + color.Name,
				ChartType = _seriesChartType,
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
			_chart.Series.Add(series);
		}
	}

	public override void UpdateChart(object parameters)
	{
		var coordinatesModel = (List<DecelerationCoefficientEstimationCoordinatesModel>) parameters;

		foreach (var cm in coordinatesModel)
		{
			_chart.Series.Single(series => series.Name.Contains(CustomColors.Black.Name))
				.Points
				.AddXY(cm.X, cm.Y);
		}
		
		var optimalValue = coordinatesModel.Single(x => x.Color == CustomColors.Green.Name);
		_chart.Series.Single(series => series.Name.Contains(CustomColors.Green.Name))
			.Points
			.AddXY(optimalValue.X, optimalValue.Y);
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		return new ChartArea
		{
			Name = _chartAreaName,
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
		_chart.ChartAreas.First().AxisX.CustomLabels.Add(new CustomLabel
		{
			Text = maxQ.ToString(CultureInfo.InvariantCulture),
			FromPosition = ChartCommonHelper.CalculateFromPosition(maxQ),
			ToPosition = ChartCommonHelper.CalculateToPosition(maxQ),
			GridTicks = GridTickTypes.All
		});

		_chart.ChartAreas.First().AxisY.CustomLabels.Add(new CustomLabel
		{
			Text = "0",
			FromPosition = ChartCommonHelper.CalculateFromPosition(0),
			ToPosition = ChartCommonHelper.CalculateToPosition(0),
			GridTicks = GridTickTypes.All
		});

		_chart.ChartAreas.First().AxisY.CustomLabels.Add(new CustomLabel
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

		_chart.ChartAreas.First().AxisX.CustomLabels.Add(new CustomLabel
		{
			Text = Math.Round(environmentModel.OptimalQ.Value, 2).ToString(),
			FromPosition = ChartCommonHelper.CalculateFromPosition(environmentModel.OptimalQ.Value),
			ToPosition = ChartCommonHelper.CalculateToPosition(environmentModel.OptimalQ.Value),
			GridTicks = GridTickTypes.All
		});

		_chart.ChartAreas.First().AxisY.CustomLabels.Add(new CustomLabel
		{
			Text = Math.Round(environmentModel.StopTime, 2).ToString(),
			FromPosition = ChartCommonHelper.CalculateFromPosition(environmentModel.OptimalTime),
			ToPosition = ChartCommonHelper.CalculateToPosition(environmentModel.OptimalTime),
			GridTicks = GridTickTypes.All
		});

		if (environmentModel.DoubleOptimalQ.HasValue)
		{
			_chart.ChartAreas.First().AxisX.CustomLabels.Add(new CustomLabel
			{
				Text = Math.Round(environmentModel.DoubleOptimalQ.Value, 2).ToString(),
				FromPosition = ChartCommonHelper.CalculateFromPosition(environmentModel.DoubleOptimalQ.Value),
				ToPosition = ChartCommonHelper.CalculateToPosition(environmentModel.DoubleOptimalQ.Value),
				GridTicks = GridTickTypes.All
			});

			_chart.ChartAreas.First().AxisY.CustomLabels.Add(new CustomLabel
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
				ChartArea = _chartAreaName,
				BorderWidth = 1,
				Color = Color.Red,
				IsVisibleInLegend = false
			};

			redLine.Points.Add(new DataPoint(0, i));
			redLine.Points.Add(new DataPoint(environmentModel.OptimalQ.Value, i + 10));

			_chart.Series.Add(redLine);
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