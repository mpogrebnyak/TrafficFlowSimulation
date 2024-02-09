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

public class DecelerationCoefficientEstimationSelectionChartRender : ChartsRender
{
	protected override string SeriesName => "DecelerationCoefficientEstimationSeries";

	protected override string ChartAreaName => "DecelerationCoefficientEstimationChartArea";

	protected override SeriesChartType SeriesChartType => SeriesChartType.Spline;

	private readonly List<Color> _pointColors = CustomColors.GetColorsForDecelerationCoefficientEstimation();

	public DecelerationCoefficientEstimationSelectionChartRender(Chart chart) : base(chart)
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
		var settings = (DecelerationCoefficientEstimationSettingsModel) modeSettings;

		var model = new ChartAreaCreationModel
		{
			Name = ChartAreaName,
			AxisX = new Axis
			{
				Minimum = 0,
				Maximum = settings.MaxQ + 0.0001,
				LabelAutoFitMinFontSize = 15,
				Interval = settings.MaxQ / 5,
				CustomLabels =
				{
					ChartAreaRendersHelper.CreateCustomLabel(settings.MaxQ,"q")
				}
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = 2,
				LabelAutoFitMinFontSize = 15,
				Interval = 0.4,
				CustomLabels =
				{
					ChartAreaRendersHelper.CreateCustomLabel(2,"v")
				}
			}
		};

		var chartArea = ChartAreaRendersHelper.CreateChartArea(model);

		return chartArea;
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var optimalQ = 1 / (modelParameters.g * modelParameters.mu);

		var optimalQSeries = new Series
		{
			Name = "optimalQLineSeries",
			ChartType = SeriesChartType.Line,
			ChartArea = ChartAreaName,
			BorderWidth = 2,
			Color = Color.Black,
			IsVisibleInLegend = false
		};
		optimalQSeries.Points.Add(new DataPoint(optimalQ, 0));
		optimalQSeries.Points.Add(new DataPoint(optimalQ, 2));

		GetChartArea().AxisX.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(optimalQ));

		return new[]
		{
			optimalQSeries
		};
	}

	public override void UpdateEnvironment(object parameters)
	{
		var environmentModel = (DecelerationCoefficientEnvironmentArgs) parameters;

		if (!environmentModel.OptimalQ.HasValue)
			return;

		var qSeries = new Series
		{
			Name = "qSeries",
			ChartType = SeriesChartType.Line,
			ChartArea = ChartAreaName,
			BorderWidth = 2,
			Color = Color.Black,
			IsVisibleInLegend = false
		};
		qSeries.Points.Add(new DataPoint(environmentModel.OptimalQ.Value, 0));
		qSeries.Points.Add(new DataPoint(environmentModel.OptimalQ.Value, 2));

		GetChartArea().AxisX.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(environmentModel.OptimalQ.Value));
		Chart.Series.Add(qSeries);
	}
}