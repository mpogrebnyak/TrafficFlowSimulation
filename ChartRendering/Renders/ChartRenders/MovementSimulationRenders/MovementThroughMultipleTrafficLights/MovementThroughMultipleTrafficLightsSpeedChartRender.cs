using System;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Helpers;
using ChartRendering.Models;
using ChartRendering.Properties;
using EvaluationKernel.Models;
using Localization;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.MovementThroughMultipleTrafficLights;

public class MovementThroughMultipleTrafficLightsSpeedChartRender : SpeedChartRender
{
	public MovementThroughMultipleTrafficLightsSpeedChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		foreach (var series in Chart.Series.Where(x => x.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));
			if (i == 0)
				series.Points.AddXY(0, 0);

			UpdateLegend(series, true, 0);
		}
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
		foreach (var series in Chart.Series.Where(series => series.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			var showLegend = false;
			if (coordinates.X[i] > -30 && coordinates.X[i] < 20)
			{
				series.Points.AddXY(coordinates.T, coordinates.Y[i]);
				showLegend = true;
			}

			UpdateLegend(series, showLegend, coordinates.Y[i]);
		}
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
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
				Minimum = 0,
				Maximum = RenderingHelper.CalculateMaxSpeed(modelParameters.Vmax),
				Interval = RenderingHelper.CalculateMaxSpeed(modelParameters.Vmax) / 5.0,
				Title = LocalizationHelper.Get<ChartRenderingResources>().SpeedAxisTitleText,
			}
			
		};
		var chartArea = ChartAreaRendersHelper.CreateChartArea(model);

		return chartArea;
	}

	protected override void CreateAxisSignature()
	{
		var chartArea = GetChartArea();
		chartArea.AxisX.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(chartArea.AxisX.Maximum, LocalizationHelper.Get<ChartRenderingResources>().TWithMeasurements));
		chartArea.AxisY.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(chartArea.AxisY.Maximum, LocalizationHelper.Get<ChartRenderingResources>().DotXWithMeasurements));
	}
}