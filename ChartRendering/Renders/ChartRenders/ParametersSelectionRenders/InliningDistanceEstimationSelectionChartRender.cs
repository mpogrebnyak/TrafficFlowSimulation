using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Constants;
using ChartRendering.Helpers;
using ChartRendering.Models;
using ChartRendering.Properties;
using EvaluationKernel.Models;
using Localization;

namespace ChartRendering.Renders.ChartRenders.ParametersSelectionRenders;

public class InliningDistanceEstimationSelectionChartRender : ChartsRender
{
	protected override string SeriesName => "InliningDistanceEstimationSeries";

	protected override string ChartAreaName => "InliningDistanceEstimationChartArea";

	protected override SeriesChartType SeriesChartType => SeriesChartType.Point;

	private readonly List<Color> _pointColors = CustomColors.GetColorsForInliningDistanceEstimation();

	public InliningDistanceEstimationSelectionChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		FullClearChart();

		var chartArea = CreateChartArea(modelParameters, modeSettings);
		Chart.ChartAreas.Add(chartArea);

		foreach (var color in _pointColors)
		{
			if (color == CustomColors.Black)
			{
				Chart.Series.Add(new Series
				{
					Name = SeriesName + color.Name,
					ChartType = SeriesChartType.Spline,
					ChartArea = chartArea.Name,
					BorderWidth = 5,
					Color = color,
					IsVisibleInLegend = false
				});

				continue;
			}

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

		Chart.Legends.Add(CreateLegend(LegendStyle.Row, modelParameters));
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
		var settings = (InliningDistanceEstimationSettingsModel) modeSettings;

		var model = new ChartAreaCreationModel
		{
			Name = ChartAreaName,
			AxisX = new Axis
			{
				Minimum = 0,
				Maximum = settings.MaximumDistanceBetweenCars,
				Interval = 20,
				LabelAutoFitMinFontSize = 15,
				CustomLabels =
				{
					ChartAreaRendersHelper.CreateCustomLabel(settings.MaximumDistanceBetweenCars,"λ")
				}
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = modelParameters.Vmax[1],
				Interval = modelParameters.Vmax[1] / 5,
				LabelAutoFitMinFontSize = 15,
				CustomLabels =
				{
					ChartAreaRendersHelper.CreateCustomLabel(modelParameters.Vmax[1],"v")
				}
			}
		};

		var chartArea = ChartAreaRendersHelper.CreateChartArea(model);

		return chartArea;
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var lLineSeries = new Series
		{
			Name = "lLineSeries",
			ChartType = SeriesChartType.Line,
			ChartArea = ChartAreaName,
			BorderWidth = 2,
			Color = Color.Black,
			IsVisibleInLegend = false
		};
		lLineSeries.Points.Add(new DataPoint(modelParameters.lCar[0] + modelParameters.lSafe[1], 0));
		lLineSeries.Points.Add(new DataPoint(modelParameters.lCar[0] + modelParameters.lSafe[1], modelParameters.Vmax[1]));

		GetChartArea().AxisX.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(modelParameters.lCar[0] + modelParameters.lSafe[1], "ℓ"));

		return new[]
		{
			lLineSeries
		};
	}

	protected override Legend CreateLegend(LegendStyle legendStyle, ModelParameters? modelParameters = null)
	{
		var legend = new Legend
		{
			Name = "Legend",
			TitleFont = new Font("Microsoft Sans Serif", 15F),
			LegendStyle = legendStyle,
			Docking = Docking.Top,
			Font = new Font("Microsoft Sans Serif", 15F),
			Alignment = StringAlignment.Center,
			Title = modelParameters != null
				? LocalizationHelper.Get<ChartRenderingResources>().SpeedReductionTitle(modelParameters.k[1]).Replace(',', '.')
				: null,
			TitleAlignment = StringAlignment.Near,
			TableStyle = LegendTableStyle.Wide
		};

		var colorsIntensityDictionary = InliningDistanceEstimationSelectionEvaluationRenderingHelper.GetColorIntensity();
		foreach (var colorIntensity in colorsIntensityDictionary)
		{
			legend.CustomItems.Add(colorIntensity.Key, colorIntensity.Value.DisplayValue);
		}

		return legend;
	}
}