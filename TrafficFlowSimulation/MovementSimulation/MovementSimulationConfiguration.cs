using System.Linq;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.MovementSimulation.EvaluationHandlers;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Renders;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Renders.MovementThroughOneTrafficLight;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Renders.StartAndStopMovement;
using TrafficFlowSimulation.Сonstants;

namespace TrafficFlowSimulation.MovementSimulation;

public static class MovementSimulationConfiguration
{
	public static void Registrate(AllChartsModel allCharts)
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
				allCharts.DistanceChart.Name + DrivingMode.StartAndStopMovement);

			serviceRegistrator.RegisterInstance<IChartRender>(() => new StartAndStopMovementChartRender(allCharts.CarsMovementChart),
				allCharts.CarsMovementChart.Name + DrivingMode.StartAndStopMovement);

			serviceRegistrator.RegisterInstance<IEvaluationHandler>(() => new StartAndStopMovementEvaluationHandler(),
				DrivingMode.StartAndStopMovement.ToString());
		}

		if (availableModes.Contains(DrivingMode.TrafficThroughTrafficLights))
		{
			serviceRegistrator.RegisterInstance<IChartRender>(() => new SpeedChartRender(allCharts.SpeedChart),
				allCharts.SpeedChart.Name + DrivingMode.TrafficThroughTrafficLights);

			serviceRegistrator.RegisterInstance<IChartRender>(() => new DistanceChartRender(allCharts.DistanceChart),
				allCharts.DistanceChart.Name + DrivingMode.TrafficThroughTrafficLights);

			serviceRegistrator.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightChartRender(allCharts.CarsMovementChart),
				allCharts.CarsMovementChart.Name + DrivingMode.TrafficThroughTrafficLights);
		}

		serviceRegistrator.RegisterInstance<RenderingHandler>(() => new RenderingHandler(allCharts));
	}
}