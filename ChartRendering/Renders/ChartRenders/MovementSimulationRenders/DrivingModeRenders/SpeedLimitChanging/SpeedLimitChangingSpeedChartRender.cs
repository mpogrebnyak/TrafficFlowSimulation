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

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.SpeedLimitChanging;

public class SpeedLimitChangingSpeedChartRender : SpeedChartRender
{
	public SpeedLimitChangingSpeedChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		foreach (var series in _chart.Series.Where(x => x.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));
			_chart.Series[i].Points.AddXY(0, 0);

			UpdateLegend(i, true, 0);
		}
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
		foreach (var series in _chart.Series.Where(series => series.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));
			_chart.Series[i].Points.AddXY(coordinates.t, coordinates.y[i]);

			UpdateLegend(i, true, coordinates.y[i]);
		}
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		
		var model = new ChartAreaCreationModel
		{
			Name = _chartAreaName,
			AxisX = new Axis
			{
				Minimum = 0,
				Maximum = 60,
				Title = LocalizationHelper.Get<ChartRenderingResources>().TimeAxisTitleText,
				TitleAlignment = StringAlignment.Far
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = RenderingHelper.CalculateMaxSpeed(modelParameters.Vmax),
				Title = LocalizationHelper.Get<ChartRenderingResources>().SpeedAxisTitleText,
				TitleAlignment = StringAlignment.Far
			}
		};
		var chartArea = ChartAreaRendersHelper.CreateChartArea(model);

		return chartArea;
	}
}