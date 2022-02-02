using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Models;

namespace TrafficFlowSimulation.Commands.Rendering
{
	public static class RenderingHelper
	{
		private static SpeedChartRender? _scr;

		private static DistanceChartRender? _dcr;

		private static SingleLaneTraffic? _slt;

		public static void CreateCharts(AllChartsModel charts, ModelParameters modelParameters)
		{
			_scr = new SpeedChartRender(modelParameters, charts.SpeedChart);
			_scr.Render(SeriesChartType.Spline);

			_dcr = new DistanceChartRender(modelParameters, charts.DistanceChart);
			_dcr.Render(SeriesChartType.Spline);

			_slt = new SingleLaneTraffic(modelParameters, charts.CarsMovementChart);
			_slt.Render(SeriesChartType.Point);
		}

		public static void UpdateCharts(double t, double[] x, double[] y )
		{
			_scr?.Update(new List<double> {t}, null!, y.ToList());
			_dcr?.Update(new List<double> {t}, x.ToList());
			_slt?.Update(new List<double> {t}, x.ToList(), y.ToList());
		}
	}
}