using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.Renders.ChartRenders;
using Microsoft.Practices.ServiceLocation;
using Modes;

namespace ChartRendering.Helpers;

public static class RenderingHelper
{
	public static Chart CreateChartToSave(Chart chart)
	{
		var newChart = CreateCleanChart();

		foreach (var originalSeries in chart.Series)
		{
			var newSeries = new Series(originalSeries.Name);
			newSeries.ChartType = originalSeries.ChartType;
			newSeries.BorderWidth = 10;

			foreach (var originalPoint in originalSeries.Points)
			{
				newSeries.Points.AddXY(originalPoint.XValue, originalPoint.YValues.Single());
				newSeries.Color = originalSeries.Color;
			}

			newChart.Series.Add(newSeries);
		}

		var originalChartArea = chart.ChartAreas.Single();

		var model = new ChartAreaCreationModel
		{
			Name = originalChartArea.Name,
			AxisX = new Axis
			{
				Minimum = originalChartArea.AxisX.Minimum,
				Maximum = originalChartArea.AxisX.Maximum,
				//Title = originalChartArea.AxisX.Title,
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
				//Title = originalChartArea.AxisY.Title,
				LineWidth = 2,
				LabelAutoFitMinFontSize = 50,
				MajorGrid = new Grid
				{
					LineWidth = 2
				}
			}
		};
		var newChartArea = ChartAreaRendersHelper.CreateChartArea(model);
		newChart.ChartAreas.Add(newChartArea);

		return newChart;
	}

	public static Chart CreateCleanChart()
	{
		var chart = new Chart();
		chart.Size = new Size(1920, 1080);

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
}