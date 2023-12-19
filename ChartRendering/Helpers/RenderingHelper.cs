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