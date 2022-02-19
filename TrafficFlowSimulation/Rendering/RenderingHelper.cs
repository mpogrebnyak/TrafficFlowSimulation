using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using Settings;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Rendering.Renders;
using TrafficFlowSimulation.Сonstants;

namespace TrafficFlowSimulation.Rendering
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

		public static void ShowLegend(string chartText, LegendStyle style)
		{
			if (style == LegendStyle.Table)
				ShowLegend(chartText, LegendDisplayOptions.Full);
			if (style == LegendStyle.Column)
				ShowLegend(chartText, LegendDisplayOptions.Partially);
		}

		public static void ShowLegend(string chartText, LegendDisplayOptions option)
		{
			if (chartText == _scr?.ChartText)
				_scr?.ShowLegend(option);
			if (chartText == _dcr?.ChartText)
				_dcr?.ShowLegend(option);
			if (chartText == _slt?.ChartText)
				_slt?.ShowLegend(option);
		}

		public static void SaveChart(Chart chart)
		{
			using (SaveFileDialog sfd = new())
			{
				sfd.Title = "Сохранить изображение как ...";
				sfd.Filter = SettingsHelper.Get<Properties.Settings>().AvailableFileTypes;
				sfd.AddExtension = true;
				sfd.FileName = "graphicImage";
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					switch (sfd.FilterIndex)
					{
						case 1: chart.SaveImage(sfd.FileName, ChartImageFormat.Bmp); break;
						case 2: chart.SaveImage(sfd.FileName, ChartImageFormat.Png); break;
						case 3: chart.SaveImage(sfd.FileName, ChartImageFormat.Jpeg); break;
						case 4: chart.SaveImage(sfd.FileName, ChartImageFormat.Emf); break;
					}
				}
			}
		}
	}
}