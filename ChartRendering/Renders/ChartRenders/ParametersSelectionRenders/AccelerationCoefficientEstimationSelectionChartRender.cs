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
				Interval = 0.2,
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
				Interval = 5,
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
			BorderWidth = 3,
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
			BorderWidth = 3,
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
			var minAValueLineSeries = new Series
			{
				Name = "minAValueLineSeries",
				ChartType = SeriesChartType.Line,
				ChartArea = ChartAreaName,
				BorderWidth = 3,
				Color = Color.Black,
				IsVisibleInLegend = false
			};
			minAValueLineSeries.Points.Add(new DataPoint(environmentModel.MinAValue.Value, 0));
			minAValueLineSeries.Points.Add(new DataPoint(environmentModel.MinAValue.Value, 20));
			GetChartArea().AxisX.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(environmentModel.MinAValue.Value));

			Chart.Series.Add(minAValueLineSeries);
		}

		if (environmentModel.MaxAValue.HasValue)
		{
			var maxAValueLineSeries = new Series
			{
				Name = "maxAValueLineSeries",
				ChartType = SeriesChartType.Line,
				ChartArea = ChartAreaName,
				BorderWidth = 3,
				Color = Color.Black,
				IsVisibleInLegend = false
			};
			maxAValueLineSeries.Points.Add(new DataPoint(environmentModel.MaxAValue.Value, 0));
			maxAValueLineSeries.Points.Add(new DataPoint(environmentModel.MaxAValue.Value, 20));
			GetChartArea().AxisX.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(environmentModel.MaxAValue.Value));

			Chart.Series.Add(maxAValueLineSeries);
		}
	}
}