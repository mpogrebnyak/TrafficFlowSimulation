﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Renders.ChartRenders;
using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;
using Modes;

namespace ChartRendering.Helpers;

public static class RenderingHelper
{
	private const int Width = 1920;

	private const int Height = 1080;

	public static Chart CreateChartToSave(Chart chart)
	{
		var newChart = CreateCleanChart();

		foreach (var originalSeries in chart.Series)
		{
			var newSeries = new Series(originalSeries.Name);
			newSeries.ChartType = originalSeries.ChartType;
			newSeries.MarkerStyle = originalSeries.MarkerStyle;
			newSeries.BorderDashStyle = originalSeries.BorderDashStyle;
			newSeries.BorderWidth = 10;
			newSeries.MarkerSize = 10;
			newSeries.IsVisibleInLegend = false;

			foreach (var originalPoint in originalSeries.Points)
			{
				newSeries.Points.AddXY(originalPoint.XValue, originalPoint.YValues.Single());
				newSeries.Color = originalSeries.Color;
			}

			newChart.Series.Add(newSeries);
		}

		foreach (var legend in chart.Legends)
		{
			if (legend.CustomItems.Any())
			{
				var newLegend = new Legend
				{
					Name = legend.Name,
					TitleFont = new Font("Microsoft Sans Serif", 38F),
					LegendStyle = legend.LegendStyle,
					Docking = legend.Docking,
					Font = new Font("Microsoft Sans Serif", 38F),
					Alignment = legend.Alignment,
					Title = legend.Title,
					TitleAlignment = legend.TitleAlignment,
					TableStyle = legend.TableStyle
				};

				foreach (var customItem in legend.CustomItems)
				{
					newLegend.CustomItems.Add(customItem);
				}

				newChart.Legends.Add(newLegend);
			}
		}

		var originalChartArea = chart.ChartAreas.Single();

		var model = new ChartAreaCreationModel
		{
			Name = originalChartArea.Name,
			AxisX = new Axis
			{
				Minimum = originalChartArea.AxisX.Minimum,
				Maximum = originalChartArea.AxisX.Maximum,
				Interval = originalChartArea.AxisX.Interval,
				LineWidth = 2,
				LabelAutoFitMinFontSize = 50,
				MajorGrid = new Grid
				{
					LineWidth = 2
				}
			},
			AxisY = new Axis
			{
				Minimum = originalChartArea.AxisY.Minimum,
				Maximum = originalChartArea.AxisY.Maximum,
				Interval = originalChartArea.AxisY.Interval,
				LineWidth = 2,
				LabelAutoFitMinFontSize = 50,
				MajorGrid = new Grid
				{
					LineWidth = 2
				}
			}
		};
		foreach (var customLabel in originalChartArea.AxisY.CustomLabels)
		{
			model.AxisY.CustomLabels.Add(customLabel);
		}
		foreach (var customLabel in originalChartArea.AxisX.CustomLabels)
		{
			model.AxisX.CustomLabels.Add(customLabel);
		}
		var newChartArea = ChartAreaRendersHelper.CreateChartArea(model);
		CreateCustomLabels(newChartArea);

		newChart.ChartAreas.Add(newChartArea);

		return newChart;
	}

	public static Chart CreateCleanChart()
	{
		var chart = new Chart();
		chart.Size = new Size(Width, Height);

		chart.Series.Clear();
		chart.ChartAreas.Clear();
		chart.Legends.Clear();

		return chart;
	}

	public static Series CreateLineSeries(string name, Color color)
	{
		return new Series
		{
			Name = name,
			ChartType = SeriesChartType.Line,
			BorderWidth = 2,
			Color = color,
			IsVisibleInLegend = false
		};
	}

	public static double CalculateMaxSpeed(List<double> v)
	{
		var round = Math.Round(v.Max() / 10) * 10;
		return round > v.Max() ? round : round + 10;
	}

	public static void DisplayChartLegend(Chart chart, LegendStyle? legendStyle)
	{
		var currentDrivingMode = ModesHelper.GetCurrentDrivingMode();
		var provider = ServiceLocator.Current.GetInstance<IChartRender>(chart.Name + currentDrivingMode);

		provider.ShowChartLegend(legendStyle);
	}

	public static void DisplayChartAxes(Chart chart, bool isHidden = false)
	{
		var currentDrivingMode = ModesHelper.GetCurrentDrivingMode();
		var provider = ServiceLocator.Current.GetInstance<IChartRender>(chart.Name + currentDrivingMode);

		provider.SetChartAreaAxisTitle(isHidden);
	}

	public static List<double> GetSegmentBeginningList(SpeedLimitChangingModeSettingsModel settings)
	{
		var segmentSpeeds = new SortedDictionary<int, SegmentModel>();
		settings.MapTo(segmentSpeeds);

		settings.GetSegmentBeginningList(segmentSpeeds, out var segmentBeginningList, out _);
		return segmentBeginningList;
	}

	public static List<double> GetSegmentSpeedList(SpeedLimitChangingModeSettingsModel settings)
	{
		var segmentSpeeds = new SortedDictionary<int, SegmentModel>();
		settings.MapTo(segmentSpeeds);

		settings.GetSegmentBeginningList(segmentSpeeds, out _, out var segmentSpeedList);
		return segmentSpeedList;
	}

	private static void CreateCustomLabels(ChartArea chartArea)
	{
		if (chartArea.AxisX.CustomLabels.Any())
		{
			var distance = chartArea.AxisX.Maximum - chartArea.AxisX.Minimum;
			var singleSegmentInPixels = Width / distance;
			ChartAreaRendersHelper.CreateCustomLabels(chartArea.AxisX, singleSegmentInPixels, 140);
		}
		if (chartArea.AxisY.CustomLabels.Any())
		{
			var distance = chartArea.AxisY.Maximum - chartArea.AxisY.Minimum;
			var singleSegmentInPixels = Height / distance;
			ChartAreaRendersHelper.CreateCustomLabels(chartArea.AxisY, singleSegmentInPixels, 70);
		}
	}
}