using System;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Helpers;
using ChartRendering.Models;
using ChartRendering.Properties;
using EvaluationKernel.Models;
using Localization;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.MovementThroughMultipleTrafficLights;

public class MovementThroughMultipleTrafficLightsDistanceChartRender : DistanceChartRender
{
	public MovementThroughMultipleTrafficLightsDistanceChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		foreach (var series in Chart.Series.Where(x => x.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));
			if (i == 0)
				series.Points.AddXY(0, modelParameters.lambda[i]);

			UpdateLegend(series, true, modelParameters.lambda[i]);
		}
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
		base.UpdateChart(coordinates);

		foreach (var series in Chart.Series.Where(series => series.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			series.Points.AddXY(coordinates.T, coordinates.X[i]);

			var showLegend = coordinates.X[i] > -30 && coordinates.X[i] < 30;
			UpdateLegend(series, showLegend, coordinates.X[i]);
		}
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var settings = (MovementThroughMultipleTrafficLightsModeSettingsModel)modeSettings;
		var trafficLightsParameters = settings.MapTo();

		var model = new ChartAreaCreationModel
		{
			Name = ChartAreaName,
			AxisX = new Axis
			{
				Minimum = 0,
				Maximum = 60,
				Interval = 60 / 5.0,
				Title = LocalizationHelper.Get<ChartRenderingResources>().TimeAxisTitleText,
			},
			AxisY = new Axis
			{
				Minimum = -30,
				Maximum = trafficLightsParameters.TrafficLightsPosition.Last() + 100,
				Interval = (30 + trafficLightsParameters.TrafficLightsPosition.Last() + 100) / 5.0,
				Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceAxisTitleText,
			}
		};
		var chartArea = ChartAreaRendersHelper.CreateChartArea(model);

		return chartArea;
	}

	protected override void CreateAxisSignature()
	{
		var chartArea = GetChartArea();
		chartArea.AxisX.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(chartArea.AxisX.Maximum, LocalizationHelper.Get<ChartRenderingResources>().TWithMeasurements));
		chartArea.AxisY.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(chartArea.AxisY.Maximum, LocalizationHelper.Get<ChartRenderingResources>().XWithMeasurements));
	}
}