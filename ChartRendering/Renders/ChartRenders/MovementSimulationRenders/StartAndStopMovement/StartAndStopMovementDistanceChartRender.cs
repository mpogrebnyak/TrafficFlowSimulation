using System;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Helpers;
using ChartRendering.Models;
using ChartRendering.Properties;
using EvaluationKernel.Models;
using Localization;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.StartAndStopMovement;

public class StartAndStopMovementDistanceChartRender : DistanceChartRender
{
	public StartAndStopMovementDistanceChartRender(Chart chart) : base(chart)
	{
	}
	
	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		foreach (var series in Chart.Series.Where(x => x.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));
			if (i == 0)
				Chart.Series[i].Points.AddXY(0, modelParameters.lambda[i]);

			UpdateLegend(i, true, modelParameters.lambda[i]);
		}
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
		foreach (var series in Chart.Series.Where(series => series.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			var showLegend = false;
			if (coordinates.X[i] > GetChartArea(ChartAreaName).AxisY.Minimum)
			{
				Chart.Series[i].Points.AddXY(coordinates.T, coordinates.X[i]);
				showLegend = true;
			}

			UpdateLegend(i, showLegend, coordinates.X[i]);
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
				Title = LocalizationHelper.Get<ChartRenderingResources>().TimeAxisTitleText,
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = modelParameters.L + 100,
				Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceAxisTitleText,
			}
		};
		var chartArea = ChartAreaRendersHelper.CreateChartArea(model);

		return chartArea;
	}
}