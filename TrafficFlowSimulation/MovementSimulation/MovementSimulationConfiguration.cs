using System.Linq;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.MovementSimulation.EvaluationHandlers;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Renders;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Renders.InliningInFlow;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Renders.MovementThroughOneTrafficLight;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Renders.StartAndStopMovement;
using TrafficFlowSimulation.Windows.Models;
using TrafficFlowSimulation.Сonstants;

namespace TrafficFlowSimulation.MovementSimulation;

public class MovementSimulationConfiguration : TrafficFlowSimulationModule
{
	private readonly AllChartsModel _allCharts;
	public MovementSimulationConfiguration(AllChartsModel allCharts)
	{
		_allCharts = allCharts;
	}

	public override void Initialize()
	{
		var availableModes = SettingsHelper.Get<Properties.Settings>().AvailableDrivingModes.ToList();

		if (availableModes.Contains(DrivingMode.StartAndStopMovement))
		{
			_serviceRegistrator.RegisterInstance<IChartRender>(() => new StartAndStopMovementSpeedChartRender(_allCharts.SpeedChart),
				_allCharts.SpeedChart.Name + DrivingMode.StartAndStopMovement);

			_serviceRegistrator.RegisterInstance<IChartRender>(() => new StartAndStopMovementDistanceChartRender(_allCharts.DistanceChart),
				_allCharts.DistanceChart.Name + DrivingMode.StartAndStopMovement);

			_serviceRegistrator.RegisterInstance<IChartRender>(() => new StartAndStopMovementCarsChartRender(_allCharts.CarsMovementChart),
				_allCharts.CarsMovementChart.Name + DrivingMode.StartAndStopMovement);

			_serviceRegistrator.RegisterInstance<IEvaluationHandler>(() => new StartAndStopMovementEvaluationHandler(),
				DrivingMode.StartAndStopMovement.ToString());
		}

		if (availableModes.Contains(DrivingMode.TrafficThroughOneTrafficLight))
		{
			_serviceRegistrator.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightSpeedChartRender(_allCharts.SpeedChart),
				_allCharts.SpeedChart.Name + DrivingMode.TrafficThroughOneTrafficLight);

			_serviceRegistrator.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightDistanceChartRender(_allCharts.DistanceChart),
				_allCharts.DistanceChart.Name + DrivingMode.TrafficThroughOneTrafficLight);

			_serviceRegistrator.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightCarsChartRender(_allCharts.CarsMovementChart),
				_allCharts.CarsMovementChart.Name + DrivingMode.TrafficThroughOneTrafficLight);

			_serviceRegistrator.RegisterInstance<IEvaluationHandler>(() => new MovementThroughOneTrafficLightEvaluationHandler(),
				DrivingMode.TrafficThroughOneTrafficLight.ToString());
		}

		if (availableModes.Contains(DrivingMode.InliningInFlow))
		{
			_serviceRegistrator.RegisterInstance<IChartRender>(() => new InliningInFlowSpeedChartRender(_allCharts.SpeedChart),
				_allCharts.SpeedChart.Name + DrivingMode.InliningInFlow);

			_serviceRegistrator.RegisterInstance<IChartRender>(() => new InliningInFlowDistanceChartRender(_allCharts.DistanceChart),
				_allCharts.DistanceChart.Name + DrivingMode.InliningInFlow);

			_serviceRegistrator.RegisterInstance<IChartRender>(() => new InliningInFlowCarsChartRender(_allCharts.CarsMovementChart),
				_allCharts.CarsMovementChart.Name + DrivingMode.InliningInFlow);

			_serviceRegistrator.RegisterInstance<IEvaluationHandler>(() => new InliningInFlowEvaluationHandler(),
				DrivingMode.InliningInFlow.ToString());
		}

		_serviceRegistrator.RegisterInstance<RenderingHandler>(() => new RenderingHandler(_allCharts));
	}
}