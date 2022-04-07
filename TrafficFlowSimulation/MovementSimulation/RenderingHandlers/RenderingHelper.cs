using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Renders;
using TrafficFlowSimulation.Сonstants;

namespace TrafficFlowSimulation.MovementSimulation.RenderingHandlers
{
	public static class RenderingHelper
	{
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