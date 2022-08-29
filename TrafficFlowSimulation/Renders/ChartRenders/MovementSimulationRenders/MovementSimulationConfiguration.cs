using System.Linq;
using Common;
using Common.Modularity;
using Settings;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.InliningInFlow;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.MovementThroughOneTrafficLight;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.StartAndStopMovement;
using TrafficFlowSimulation.Windows.Models;

namespace TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders;

public class MovementSimulationConfiguration : IInitializable
{
	private readonly AllChartsModel _allCharts;

	public MovementSimulationConfiguration(AllChartsModel allCharts)
	{
		_allCharts = allCharts;
	}

	public void Initialize()
	{
		var availableModes = SettingsHelper.Get<Properties.Settings>().AvailableDrivingModes.ToList();

		if (availableModes.Contains(DrivingMode.StartAndStopMovement))
		{
			CommonHelper.ServiceRegistrator.RegisterInstance<IChartRender>(() => new StartAndStopMovementSpeedChartRender(_allCharts.SpeedChart),
				_allCharts.SpeedChart.Name + DrivingMode.StartAndStopMovement);

			CommonHelper.ServiceRegistrator.RegisterInstance<IChartRender>(() => new StartAndStopMovementDistanceChartRender(_allCharts.DistanceChart),
				_allCharts.DistanceChart.Name + DrivingMode.StartAndStopMovement);

			CommonHelper.ServiceRegistrator.RegisterInstance<IChartRender>(() => new StartAndStopMovementCarsChartRender(_allCharts.CarsMovementChart),
				_allCharts.CarsMovementChart.Name + DrivingMode.StartAndStopMovement);
		}

		if (availableModes.Contains(DrivingMode.TrafficThroughOneTrafficLight))
		{
			CommonHelper.ServiceRegistrator.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightSpeedChartRender(_allCharts.SpeedChart),
				_allCharts.SpeedChart.Name + DrivingMode.TrafficThroughOneTrafficLight);

			CommonHelper.ServiceRegistrator.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightDistanceChartRender(_allCharts.DistanceChart),
				_allCharts.DistanceChart.Name + DrivingMode.TrafficThroughOneTrafficLight);

			CommonHelper.ServiceRegistrator.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightCarsChartRender(_allCharts.CarsMovementChart),
				_allCharts.CarsMovementChart.Name + DrivingMode.TrafficThroughOneTrafficLight);
		}

		if (availableModes.Contains(DrivingMode.InliningInFlow))
		{
			CommonHelper.ServiceRegistrator.RegisterInstance<IChartRender>(() => new InliningInFlowSpeedChartRender(_allCharts.SpeedChart),
				_allCharts.SpeedChart.Name + DrivingMode.InliningInFlow);

			CommonHelper.ServiceRegistrator.RegisterInstance<IChartRender>(() => new InliningInFlowDistanceChartRender(_allCharts.DistanceChart),
				_allCharts.DistanceChart.Name + DrivingMode.InliningInFlow);

			CommonHelper.ServiceRegistrator.RegisterInstance<IChartRender>(() => new InliningInFlowCarsChartRender(_allCharts.CarsMovementChart),
				_allCharts.CarsMovementChart.Name + DrivingMode.InliningInFlow);
		}

		CommonHelper.ServiceRegistrator.RegisterInstance<RenderingHandler>(() => new RenderingHandler(_allCharts));
	}
}