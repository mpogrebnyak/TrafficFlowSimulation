using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders.Models;

namespace TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders;

public class DecelerationCoefficientEstimationSelectionChartRender : ChartsRender
{
	protected override string _seriesName => "DecelerationCoefficientEstimationSeries";

	protected override string _chartAreaName => "DecelerationCoefficientEstimationChartArea";

	protected override SeriesChartType _seriesChartType => SeriesChartType.Point;

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
				BorderWidth = 2,
				Color = color,
				MarkerStyle = MarkerStyle.Circle
				//BorderDashStyle = ChartDashStyle.Dash
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
			_chart.Series.Single(series => series.Name.Contains(cm.Color.Name))
				.Points
				.AddXY(cm.X, cm.Y);
		}
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		return new ChartArea
		{
			Name = _chartAreaName,
			AxisX = new Axis
			{
				Minimum = 0,
				Maximum = 1,
				Interval = 1
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = 8,
				Interval = 5
			}
		};
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		_chart.ChartAreas.First().AxisX.CustomLabels.Add(new CustomLabel
		{
			Text = "1",
			FromPosition = ChartCommonHelper.CalculateFromPosition(1),
			ToPosition = ChartCommonHelper.CalculateToPosition(1),
			GridTicks = GridTickTypes.All
		});

		_chart.ChartAreas.First().AxisX.CustomLabels.Add(new CustomLabel
		{
			Text = "0",
			FromPosition = ChartCommonHelper.CalculateFromPosition(0),
			ToPosition = ChartCommonHelper.CalculateToPosition(0),
			GridTicks = GridTickTypes.All
		});

		_chart.ChartAreas.First().AxisX.CustomLabels.Add(new CustomLabel
		{
			Text = "0",
			FromPosition = ChartCommonHelper.CalculateFromPosition(0),
			ToPosition = ChartCommonHelper.CalculateToPosition(0),
			GridTicks = GridTickTypes.All
		});

		var tStop = modelParameters.Vn[0] / (modelParameters.g * modelParameters.mu);
		_chart.ChartAreas.First().AxisY.CustomLabels.Add(new CustomLabel
		{
			Text = Math.Round(tStop, 2).ToString(),
			FromPosition = ChartCommonHelper.CalculateFromPosition(tStop),
			ToPosition = ChartCommonHelper.CalculateToPosition(tStop),
			GridTicks = GridTickTypes.All
		});
		
		return new Series[] { };
	}

	public override void UpdateEnvironment(object parameters)
	{
		var environmentModel = (double) parameters;

		_chart.ChartAreas.First().AxisX.CustomLabels.Add(new CustomLabel
		{
			Text = Math.Round(environmentModel, 2).ToString(),
			FromPosition = ChartCommonHelper.CalculateFromPosition(environmentModel),
			ToPosition = ChartCommonHelper.CalculateToPosition(environmentModel),
			GridTicks = GridTickTypes.All
		});

		for (var i = -10.0; i <= 10; i+=0.5)
		{
			var ee = new Series
			{
				Name = "ee" + i,
				ChartType = SeriesChartType.Line,
				ChartArea = _chartAreaName,
				BorderWidth = 1,
				Color = Color.Red,
				IsVisibleInLegend = false
			};

			ee.Points.Add(new DataPoint(0, i));
			ee.Points.Add(new DataPoint(environmentModel, i+10));

			_chart.Series.Add(ee);
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