﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Helpers;
using ChartRendering.Models;
using ChartRendering.Properties;
using EvaluationKernel.Models;
using Localization;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders;

public class SpeedFromDistanceChartRender : ChartsRender
{
	protected override SeriesChartType SeriesChartType => SeriesChartType.Spline;

	protected override string SeriesName => "SpeedFromDistance";

	protected override string ChartAreaName => "SpeedFromDistance";

	public SpeedFromDistanceChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		foreach (var series in Chart.Series.Where(x => x.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));
			if (i == 0)
				series.Points.AddXY(modelParameters.lambda[i], modelParameters.Vn[i]);

			UpdateLegend(series, true, 0);
		}
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
		foreach (var series in Chart.Series.Where(series => series.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			var showLegend = false;
			if (coordinates.X[i] > GetChartArea().AxisX.Minimum - 10)
			{
				series.Points.AddXY(coordinates.X[i], coordinates.Y[i]);
				showLegend = true;
			}

			UpdateLegend(series, showLegend, coordinates.Y[i]);
		}
	}

	public override void SetChartAreaAxisTitle(bool isHidden = false)
	{
		if (Chart.ChartAreas.Any())
		{
			if (isHidden)
			{
				Chart.ChartAreas[0].AxisX.Title = string.Empty;
				Chart.ChartAreas[0].AxisY.Title = string.Empty;
			}
			else
			{
				Chart.ChartAreas[0].AxisX.Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceAxisTitleText;
				Chart.ChartAreas[0].AxisY.Title = LocalizationHelper.Get<ChartRenderingResources>().SpeedAxisTitleText;
			}
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
				Maximum = modelParameters.L + 100,
				Interval = (modelParameters.L + 100) / 5.0,
				Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceAxisTitleText,
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = RenderingHelper.CalculateMaxSpeed(modelParameters.Vmax),
				Interval = RenderingHelper.CalculateMaxSpeed(modelParameters.Vmax) / 5.0,
				Title = LocalizationHelper.Get<ChartRenderingResources>().SpeedAxisTitleText,
			}
		};
	//	model.AxisX.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(modelParameters.L + 100, LocalizationHelper.Get<ChartRenderingResources>().XWithMeasurements));
	//	model.AxisY.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(RenderingHelper.CalculateMaxSpeed(modelParameters.Vmax), LocalizationHelper.Get<ChartRenderingResources>().DotXWithMeasurements));

		var chartArea = ChartAreaRendersHelper.CreateChartArea(model);

		return chartArea;
	}

	protected override Legend CreateLegend(LegendStyle legendStyle, ModelParameters? modelParameters = null, BaseSettingsModels modeSettings = null)
	{
		return new Legend
		{
			Name = "Legend",
			Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceChartLegendTitleText,
			TitleFont = new Font("Microsoft Sans Serif", 10F),
			LegendStyle = legendStyle,
			Font = new Font("Microsoft Sans Serif", 10F),
		};
	}

	protected override void CreateAxisSignature()
	{
		var chartArea = GetChartArea();
		chartArea.AxisX.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(chartArea.AxisX.Maximum, LocalizationHelper.Get<ChartRenderingResources>().XWithMeasurements));
		chartArea.AxisY.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(chartArea.AxisY.Maximum, LocalizationHelper.Get<ChartRenderingResources>().DotXWithMeasurements));
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		return new Series[] { };
	}
}