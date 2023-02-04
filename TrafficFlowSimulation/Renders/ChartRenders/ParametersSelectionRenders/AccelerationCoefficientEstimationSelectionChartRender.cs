using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders.Models;

namespace TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders;

public class AccelerationCoefficientEstimationSelectionChartRender : ChartsRender
{
	protected override string _seriesName => "AccelerationCoefficientEstimationSeries";

	protected override string _chartAreaName => "AccelerationCoefficientEstimationChartArea";

	protected override SeriesChartType _seriesChartType => SeriesChartType.Point;

	private readonly List<Color> _pointColors = CustomColors.GetColorsForAccelerationCoefficientEstimation();

	// задает в каком диапазоне будет отображаться label
	private readonly int _stepForLabel = 1;

	public AccelerationCoefficientEstimationSelectionChartRender(Chart chart) : base(chart)
	{
		FullClearChart();
	}

	public override void RenderChart(ModelParameters modelParameters)
	{
		FullClearChart();

		var chartArea = CreateChartArea(modelParameters);
		_chart.ChartAreas.Add(chartArea);

		foreach (var color in _pointColors)
		{
			_chart.Series.Add(new Series
			{
				Name = _seriesName + color.Name,
				ChartType = _seriesChartType,
				ChartArea = chartArea.Name,
				BorderWidth = 1,
				Color = color,
				MarkerStyle = MarkerStyle.Circle
			});
		}

		var environmentSeries = CreateEnvironment(modelParameters);
		foreach (var series in environmentSeries)
		{
			_chart.Series.Add(series);
		}
	}

	public override void UpdateChart(object parameters)
	{
		var coordinatesModel = (List<AccelerationCoefficientEstimationCoordinatesModel>) parameters;

		foreach (var cm in coordinatesModel)
		{
			_chart.Series.Single(series => series.Name.Contains(cm.Color.Name))
				.Points
				.AddXY(cm.X, cm.Y);
		}
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters)
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
				Maximum = 20,
				Interval = 5
			}
		};
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters)
	{
		_chart.ChartAreas.First().AxisX.CustomLabels.Add(new CustomLabel
		{
			Text = "1",
			FromPosition = 1 - _stepForLabel,
			ToPosition = 1 + _stepForLabel,
			GridTicks = GridTickTypes.All
		});

		var startLineSeries = new Series
		{
			Name = "UpperBound",
			ChartType = SeriesChartType.Line,
			ChartArea = _chartAreaName,
			BorderWidth = 1,
			Color = Color.Red,
			IsVisibleInLegend = false
		};
		startLineSeries.Points.Add(new DataPoint(0, 5));
		startLineSeries.Points.Add(new DataPoint(modelParameters.a.Single(), 5));

		var endLineSeries = new Series
		{
			Name = "LowerBound",
			ChartType = SeriesChartType.Line,
			ChartArea = _chartAreaName,
			BorderWidth = 1,
			Color = Color.Red,
			IsVisibleInLegend = false
		};
		endLineSeries.Points.Add(new DataPoint(0, 15));
		endLineSeries.Points.Add(new DataPoint(modelParameters.a.Single(), 15));

		return new[]
		{
			startLineSeries,
			endLineSeries
		};
	}

	public override void UpdateEnvironment(object parameters)
	{
		var environmentModel = (AccelerationCoefficientEnvironmentModel) parameters;

		if (environmentModel.MinAValue.HasValue)
		{
			_chart.ChartAreas.First().AxisX.CustomLabels.Add(new CustomLabel
			{
				Text = Math.Round(environmentModel.MinAValue.Value, 2).ToString(),
				FromPosition = environmentModel.MinAValue.Value - _stepForLabel,
				ToPosition = environmentModel.MinAValue.Value + _stepForLabel,
				GridTicks = GridTickTypes.All
			});
		}

		if (environmentModel.MaxAValue.HasValue)
		{
			_chart.ChartAreas.First().AxisX.CustomLabels.Add(new CustomLabel
			{
				Text = Math.Round(environmentModel.MaxAValue.Value, 2).ToString(),
				FromPosition = environmentModel.MaxAValue.Value - _stepForLabel,
				ToPosition = environmentModel.MaxAValue.Value + _stepForLabel,
				GridTicks = GridTickTypes.All
			});
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