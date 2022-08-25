using System.Linq;
using Settings;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.InliningInFlow;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.MovementThroughOneTrafficLight;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.StartAndStopMovement;
using TrafficFlowSimulation.Windows.Models;

namespace TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders;

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
		}

		if (availableModes.Contains(DrivingMode.TrafficThroughOneTrafficLight))
		{
			_serviceRegistrator.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightSpeedChartRender(_allCharts.SpeedChart),
				_allCharts.SpeedChart.Name + DrivingMode.TrafficThroughOneTrafficLight);

			_serviceRegistrator.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightDistanceChartRender(_allCharts.DistanceChart),
				_allCharts.DistanceChart.Name + DrivingMode.TrafficThroughOneTrafficLight);

			_serviceRegistrator.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightCarsChartRender(_allCharts.CarsMovementChart),
				_allCharts.CarsMovementChart.Name + DrivingMode.TrafficThroughOneTrafficLight);
		}

		if (availableModes.Contains(DrivingMode.InliningInFlow))
		{
			_serviceRegistrator.RegisterInstance<IChartRender>(() => new InliningInFlowSpeedChartRender(_allCharts.SpeedChart),
				_allCharts.SpeedChart.Name + DrivingMode.InliningInFlow);

			_serviceRegistrator.RegisterInstance<IChartRender>(() => new InliningInFlowDistanceChartRender(_allCharts.DistanceChart),
				_allCharts.DistanceChart.Name + DrivingMode.InliningInFlow);

			_serviceRegistrator.RegisterInstance<IChartRender>(() => new InliningInFlowCarsChartRender(_allCharts.CarsMovementChart),
				_allCharts.CarsMovementChart.Name + DrivingMode.InliningInFlow);
		}

		_serviceRegistrator.RegisterInstance<RenderingHandler>(() => new RenderingHandler(_allCharts));
	}
}