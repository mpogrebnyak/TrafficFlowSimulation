using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Rendering.Renders;
using TrafficFlowSimulation.Rendering.Renders.StartAndStopMovement;
using TrafficFlowSimulation.Сonstants;

namespace TrafficFlowSimulation.Rendering;

public static class RenderConfiguration
{
	public static void RegistrateCharts(AllChartsModel allCharts)
	{
		var serviceRegistrator = new UnityServiceRegistrator();

		var locator = serviceRegistrator.CreateLocator();
		ServiceLocator.SetLocatorProvider(() => locator);

		var availableModes = SettingsHelper.Get<Properties.Settings>().AvailableDrivingModes.ToList();

		if (availableModes.Contains(DrivingMode.StartAndStopMovement))
		{
			serviceRegistrator.RegisterInstance<IChartRender>(() => new SpeedChartRender(allCharts.SpeedChart),
				allCharts.SpeedChart.Name + DrivingMode.StartAndStopMovement);

			serviceRegistrator.RegisterInstance<IChartRender>(() => new DistanceChartRender(allCharts.DistanceChart),
				allCharts.DistanceChart.Name  + DrivingMode.StartAndStopMovement);

			serviceRegistrator.RegisterInstance<IChartRender>(() => new StartAndStopMovementChartRender(allCharts.CarsMovementChart),
				allCharts.CarsMovementChart.Name + DrivingMode.StartAndStopMovement);
		}

		//serviceRegistrator.RegisterInstance<IChartRender, SpeedChartRender()>("SpeedChart");
	}
}