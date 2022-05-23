using System.Linq;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.MovementSimulation.EvaluationHandlers;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Renders;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Renders.InliningInFlow;
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
			serviceRegistrator.RegisterInstance<IChartRender>(() => new StartAndStopMovementSpeedChartRender(allCharts.SpeedChart),
				allCharts.SpeedChart.Name + DrivingMode.StartAndStopMovement);

			serviceRegistrator.RegisterInstance<IChartRender>(() => new StartAndStopMovementDistanceChartRender(allCharts.DistanceChart),
				allCharts.DistanceChart.Name + DrivingMode.StartAndStopMovement);

			serviceRegistrator.RegisterInstance<IChartRender>(() => new StartAndStopMovementCarsChartRender(allCharts.CarsMovementChart),
				allCharts.CarsMovementChart.Name + DrivingMode.StartAndStopMovement);

			serviceRegistrator.RegisterInstance<IEvaluationHandler>(() => new StartAndStopMovementEvaluationHandler(),
				DrivingMode.StartAndStopMovement.ToString());
		}

		if (availableModes.Contains(DrivingMode.TrafficThroughOneTrafficLight))
		{
			serviceRegistrator.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightSpeedChartRender(allCharts.SpeedChart),
				allCharts.SpeedChart.Name + DrivingMode.TrafficThroughOneTrafficLight);

			serviceRegistrator.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightDistanceChartRender(allCharts.DistanceChart),
				allCharts.DistanceChart.Name + DrivingMode.TrafficThroughOneTrafficLight);

			serviceRegistrator.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightCarsChartRender(allCharts.CarsMovementChart),
				allCharts.CarsMovementChart.Name + DrivingMode.TrafficThroughOneTrafficLight);

			serviceRegistrator.RegisterInstance<IEvaluationHandler>(() => new MovementThroughOneTrafficLightEvaluationHandler(),
				DrivingMode.TrafficThroughOneTrafficLight.ToString());
		}

		if (availableModes.Contains(DrivingMode.InliningInFlow))
		{
			serviceRegistrator.RegisterInstance<IChartRender>(() => new InliningInFlowSpeedChartRender(allCharts.SpeedChart),
				allCharts.SpeedChart.Name + DrivingMode.InliningInFlow);

			serviceRegistrator.RegisterInstance<IChartRender>(() => new InliningInFlowDistanceChartRender(allCharts.DistanceChart),
				allCharts.DistanceChart.Name + DrivingMode.InliningInFlow);

			serviceRegistrator.RegisterInstance<IChartRender>(() => new InliningInFlowCarsChartRender(allCharts.CarsMovementChart),
				allCharts.CarsMovementChart.Name + DrivingMode.InliningInFlow);

			serviceRegistrator.RegisterInstance<IEvaluationHandler>(() => new InliningInFlowEvaluationHandler(),
				DrivingMode.InliningInFlow.ToString());
		}

		serviceRegistrator.RegisterInstance<RenderingHandler>(() => new RenderingHandler(allCharts));
	}
}