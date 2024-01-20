using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Constants;
using ChartRendering.Helpers;
using ChartRendering.Models;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Renders;

namespace ChartRendering.Renders.ChartRenders.ParametersSelectionRenders;

public class AccelerationCoefficientEstimationSelectionChartRender : ChartsRender
{
	protected override string SeriesName => "AccelerationCoefficientEstimationSeries";

	protected override string ChartAreaName => "AccelerationCoefficientEstimationChartArea";

	protected override SeriesChartType SeriesChartType => SeriesChartType.Point;

	private readonly List<Color> _pointColors = CustomColors.GetColorsForAccelerationCoefficientEstimation();

	public AccelerationCoefficientEstimationSelectionChartRender(Chart chart) : base(chart)
	{
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
				BorderWidth = 1,
				Color = color,
				MarkerStyle = MarkerStyle.Circle,
				IsVisibleInLegend = false
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
		var coordinatesModel = (CoefficientEstimationCoordinatesArgs) coordinates;

		for (var i = 0; i < coordinatesModel.Color.Count; i++)
		{
			Chart.Series.Single(series => series.Name.Contains(coordinatesModel.Color[i]))
				.Points
				.AddXY(coordinatesModel.X[i], coordinatesModel.Y[i]);
		}
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var settings = (AccelerationCoefficientEstimationSettingsModel) modeSettings;

		var model = new ChartAreaCreationModel
		{
			Name = ChartAreaName,
			AxisX = new Axis
			{
				Minimum = 0,
				Maximum = settings.MaxA,
				Interval = 1,
				LabelAutoFitMinFontSize = 15,
				CustomLabels =
				{
					ChartAreaRendersHelper.CreateCustomLabel(settings.MaxA,"a")
				}
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = 20,
				LabelAutoFitMinFontSize = 15,
				CustomLabels =
				{
					ChartAreaRendersHelper.CreateCustomLabel(5),
					ChartAreaRendersHelper.CreateCustomLabel(15),
					ChartAreaRendersHelper.CreateCustomLabel(20,"t₀")
				}
			}
		};

		var chartArea = ChartAreaRendersHelper.CreateChartArea(model);

		return chartArea;
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var settings = (AccelerationCoefficientEstimationSettingsModel) modeSettings;

		var startLineSeries = new Series
		{
			Name = "UpperBound",
			ChartType = SeriesChartType.Line,
			ChartArea = ChartAreaName,
			BorderWidth = 2,
			Color = Color.Black,
			IsVisibleInLegend = false
		};
		startLineSeries.Points.Add(new DataPoint(0, settings.MinTime));
		startLineSeries.Points.Add(new DataPoint(settings.MaxA, settings.MinTime));

		var endLineSeries = new Series
		{
			Name = "LowerBound",
			ChartType = SeriesChartType.Line,
			ChartArea = ChartAreaName,
			BorderWidth = 2,
			Color = Color.Black,
			IsVisibleInLegend = false
		};
		endLineSeries.Points.Add(new DataPoint(0, settings.MaxTime));
		endLineSeries.Points.Add(new DataPoint(settings.MaxA, settings.MaxTime));

		return new[]
		{
			startLineSeries,
			endLineSeries
		};
	}

	public override void UpdateEnvironment(object parameters)
	{
		var environmentModel = (AccelerationCoefficientEnvironmentArgs) parameters;

		if (environmentModel.MinAValue.HasValue)
		{
			Chart.ChartAreas.First().AxisX.CustomLabels.Add(new CustomLabel
			{
				Text = Math.Round(environmentModel.MinAValue.Value, 2).ToString(),
				FromPosition = ChartCommonHelper.CalculateFromPosition(environmentModel.MinAValue.Value),
				ToPosition = ChartCommonHelper.CalculateToPosition(environmentModel.MinAValue.Value),
				GridTicks = GridTickTypes.All
			});
		}

		if (environmentModel.MaxAValue.HasValue)
		{
			Chart.ChartAreas.First().AxisX.CustomLabels.Add(new CustomLabel
			{
				Text = Math.Round(environmentModel.MaxAValue.Value, 2).ToString(),
				FromPosition = ChartCommonHelper.CalculateFromPosition(environmentModel.MaxAValue.Value),
				ToPosition = ChartCommonHelper.CalculateToPosition(environmentModel.MaxAValue.Value),
				GridTicks = GridTickTypes.All
			});
		}
	}
}