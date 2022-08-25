using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Renders;

namespace TrafficFlowSimulation.MovementSimulation.RenderingHandlers
{
	public static class RenderingHelper
	{
		public static double CalculateMaxSpeed(List<double> v)
		{
			var round = Math.Round(v.Max() / 10) * 10;
			return round > v.Max() ? round : round + 10;
		}

		public static void DisplayChartLegend(Chart chart, LegendStyle? legendStyle)
		{
			var currentDrivingMode = SettingsHelper.Get<Properties.Settings>().CurrentDrivingMode;
			var provider = ServiceLocator.Current.GetInstance<IChartRender>(chart.Name + currentDrivingMode);

			provider.ShowChartLegend(legendStyle);
		}

		public static void DisplayChartAxes(Chart chart, bool isHidden = false)
		{
			var currentDrivingMode = SettingsHelper.Get<Properties.Settings>().CurrentDrivingMode;
			var provider = ServiceLocator.Current.GetInstance<IChartRender>(chart.Name + currentDrivingMode);

			provider.SetChartAreaAxisTitle(isHidden);
		}
	}
}