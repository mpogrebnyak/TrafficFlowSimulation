using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Rendering.Renders;
using TrafficFlowSimulation.Сonstants;

namespace TrafficFlowSimulation.Rendering
{
	public static class RenderingHelper
	{
		public static void CreateCharts(AllChartsModel charts, ModelParameters modelParameters)
		{
			var speedProvider =
				ServiceLocator.Current.GetInstance<IChartRender>(charts.SpeedChart.Name + DrivingMode.StartAndStopMovement);
			var distanceProvider =
				ServiceLocator.Current.GetInstance<IChartRender>(charts.DistanceChart.Name + DrivingMode.StartAndStopMovement);
			var carMovementProvider =
				ServiceLocator.Current.GetInstance<IChartRender>(charts.CarsMovementChart.Name + DrivingMode.StartAndStopMovement);

			speedProvider.RenderChart(modelParameters);
			distanceProvider.RenderChart(modelParameters);
			carMovementProvider.RenderChart(modelParameters);
		}

		public static void UpdateCharts(AllChartsModel charts, double t, double[] x, double[] y )
		{
			var speedProvider =
				ServiceLocator.Current.GetInstance<IChartRender>(charts.SpeedChart.Name + DrivingMode.StartAndStopMovement);
			var distanceProvider =
				ServiceLocator.Current.GetInstance<IChartRender>(charts.DistanceChart.Name + DrivingMode.StartAndStopMovement);
			var carMovementProvider =
				ServiceLocator.Current.GetInstance<IChartRender>(charts.CarsMovementChart.Name + DrivingMode.StartAndStopMovement);

			speedProvider.UpdateChart(new List<double> {t}, null!, y.ToList());
			distanceProvider.UpdateChart(new List<double> {t}, x.ToList());
			carMovementProvider.UpdateChart(new List<double> {t}, x.ToList(), y.ToList());
		}

		public static void ShowLegend(Chart chart, LegendStyle? legendStyle)
		{
			var provider =
				ServiceLocator.Current.GetInstance<IChartRender>(chart.Name + DrivingMode.StartAndStopMovement);

			provider.ShowChartLegend(legendStyle);
		}

		public static void ShowAxis(Chart chart, bool isHidden = false)
		{
			var provider =
				ServiceLocator.Current.GetInstance<IChartRender>(chart.Name + DrivingMode.StartAndStopMovement);
			
			provider.SetChartAreaAxisTitle(isHidden);
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