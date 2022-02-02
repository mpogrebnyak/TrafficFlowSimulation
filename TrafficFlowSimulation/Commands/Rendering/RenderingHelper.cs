using System.Windows.Forms.DataVisualization.Charting;
using TrafficFlowSimulation.Commands.Rendering;
using TrafficFlowSimulation.Models;

namespace TrafficFlowSimulation.Commands
{
	public static class RenderingHelper
	{
		public static void InitialRenderCharts(ChartsRenderingModel chartsRenderingModel)
		{
			var scr = new SpeedChartRender(chartsRenderingModel.ModelParameters, chartsRenderingModel.SpeedChart);
			scr.Render(SeriesChartType.Spline);

			var dcr = new DistanceChartRender(chartsRenderingModel.ModelParameters, chartsRenderingModel.DistanceChart);
			dcr.Render(SeriesChartType.Spline);

			var slt = new SingleLaneTraffic(chartsRenderingModel.ModelParameters, chartsRenderingModel.CarsMovementChart);
			slt.Render(SeriesChartType.Point);
		}
		
		public static void RenderCharts2(ChartsRenderingModel chartsRenderingModel)
		{
			var scr = new SpeedChartRender(chartsRenderingModel.ModelParameters, chartsRenderingModel.SpeedChart);
			scr.Render(SeriesChartType.Spline);

			var dcr = new DistanceChartRender(chartsRenderingModel.ModelParameters, chartsRenderingModel.DistanceChart);
			dcr.Render(SeriesChartType.Spline);

			var slt = new SingleLaneTraffic(chartsRenderingModel.ModelParameters, chartsRenderingModel.CarsMovementChart);
			slt.Render(SeriesChartType.Point);
		}
	}
}