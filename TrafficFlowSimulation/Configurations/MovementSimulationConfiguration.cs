using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.Constants;
using ChartRendering.Helpers;
using ChartRendering.Renders.ChartRenders;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders.InliningInFlow;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders.MovementThroughMultipleTrafficLights;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders.MovementThroughOneTrafficLight;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders.RoadHole;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders.SpeedLimitChanging;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders.StartAndStopMovement;
using Common;
using Common.Modularity;
using TrafficFlowSimulation.Handlers;
using TrafficFlowSimulation.Windows;

namespace TrafficFlowSimulation.Configurations
{
	public class MovementSimulationConfiguration : IInitializable
	{
		private readonly Chart _speedChart;
		private readonly Chart _distanceChart;
		private readonly Chart _speedFromDistanceChart;
		private readonly Chart _carsMovementChart;

		public MovementSimulationConfiguration(MainWindow form)
		{
			_speedChart = form.SpeedChart;
			_distanceChart = form.DistanceChart;
			_speedFromDistanceChart = form.SpeedFromDistanceChart;
			_carsMovementChart = form.CarsMovementChart;
		}

		public void Initialize()
		{
			var availableModes = ModesHelper.GetAvailableDrivingModes();

			if (availableModes.Contains(DrivingMode.StartAndStopMovement))
			{
				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new StartAndStopMovementSpeedChartRender(_speedChart),
					_speedChart.Name + DrivingMode.StartAndStopMovement, false);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new StartAndStopMovementDistanceChartRender(_distanceChart),
					_distanceChart.Name + DrivingMode.StartAndStopMovement, false);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new StartAndStopMovementCarsChartRender(_carsMovementChart),
					_carsMovementChart.Name + DrivingMode.StartAndStopMovement, false);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new SpeedFromDistanceChartRender(_speedFromDistanceChart),
					_speedFromDistanceChart.Name + DrivingMode.StartAndStopMovement, false);
			}

			if (availableModes.Contains(DrivingMode.TrafficThroughOneTrafficLight))
			{
				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightSpeedChartRender(_speedChart),
					_speedChart.Name + DrivingMode.TrafficThroughOneTrafficLight, false);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightDistanceChartRender(_distanceChart),
					_distanceChart.Name + DrivingMode.TrafficThroughOneTrafficLight, false);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightCarsChartRender(_carsMovementChart),
					_carsMovementChart.Name + DrivingMode.TrafficThroughOneTrafficLight, false);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightSpeedFromDistanceChartRender(_speedFromDistanceChart),
					_speedFromDistanceChart.Name + DrivingMode.TrafficThroughOneTrafficLight, false);
			}

			if (availableModes.Contains(DrivingMode.InliningInFlow))
			{
				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new InliningInFlowSpeedChartRender(_speedChart),
					_speedChart.Name + DrivingMode.InliningInFlow, false);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new InliningInFlowDistanceChartRender(_distanceChart),
					_distanceChart.Name + DrivingMode.InliningInFlow, false);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new InliningInFlowCarsChartRender(_carsMovementChart),
					_carsMovementChart.Name + DrivingMode.InliningInFlow, false);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new InliningInFlowSpeedFromDistanceChartRender(_speedFromDistanceChart),
					_speedFromDistanceChart.Name + DrivingMode.InliningInFlow, false);
			}

			if (availableModes.Contains(DrivingMode.SpeedLimitChanging))
			{
				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new SpeedLimitChangingSpeedChartRender(_speedChart),
					_speedChart.Name + DrivingMode.SpeedLimitChanging, false);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new SpeedLimitChangingDistanceChartRender(_distanceChart),
					_distanceChart.Name + DrivingMode.SpeedLimitChanging, false);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new SpeedLimitChangingCarsChartRender(_carsMovementChart),
					_carsMovementChart.Name + DrivingMode.SpeedLimitChanging, false);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new SpeedLimitChangingSpeedFromDistanceChartRender(_speedFromDistanceChart),
					_speedFromDistanceChart.Name + DrivingMode.SpeedLimitChanging, false);
			}

			if (availableModes.Contains(DrivingMode.RoadHole))
			{
				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new RoadHoleSpeedChartRender(_speedChart),
					_speedChart.Name + DrivingMode.RoadHole, false);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new RoadHoleDistanceChartRender(_distanceChart),
					_distanceChart.Name + DrivingMode.RoadHole, false);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new RoadHoleCarsChartRender(_carsMovementChart),
					_carsMovementChart.Name + DrivingMode.RoadHole, false);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new RoadHoleSpeedFromDistanceChartRender(_speedFromDistanceChart),
					_speedFromDistanceChart.Name + DrivingMode.RoadHole, false);
			}

			if (availableModes.Contains(DrivingMode.ThroughTheDriver))
			{
				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new StartAndStopMovementSpeedChartRender(_speedChart),
					_speedChart.Name + DrivingMode.ThroughTheDriver, false);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new StartAndStopMovementDistanceChartRender(_distanceChart),
					_distanceChart.Name + DrivingMode.ThroughTheDriver, false);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new StartAndStopMovementCarsChartRender(_carsMovementChart),
					_carsMovementChart.Name + DrivingMode.ThroughTheDriver, false);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new SpeedFromDistanceChartRender(_speedFromDistanceChart),
					_speedFromDistanceChart.Name + DrivingMode.ThroughTheDriver, false);
			}

			if (availableModes.Contains(DrivingMode.TrafficThroughOneTrafficLightThroughTheDriver))
			{
				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightSpeedChartRender(_speedChart),
					_speedChart.Name + DrivingMode.TrafficThroughOneTrafficLightThroughTheDriver, false);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightDistanceChartRender(_distanceChart),
					_distanceChart.Name + DrivingMode.TrafficThroughOneTrafficLightThroughTheDriver, false);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightCarsChartRender(_carsMovementChart),
					_carsMovementChart.Name + DrivingMode.TrafficThroughOneTrafficLightThroughTheDriver, false);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightSpeedFromDistanceChartRender(_speedFromDistanceChart),
					_speedFromDistanceChart.Name + DrivingMode.TrafficThroughOneTrafficLightThroughTheDriver, false);
			}
			
			if (availableModes.Contains(DrivingMode.TrafficThroughMultipleTrafficLights))
			{
				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new MovementThroughMultipleTrafficLightsSpeedChartRender(_speedChart),
					_speedChart.Name + DrivingMode.TrafficThroughMultipleTrafficLights, false);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new MovementThroughMultipleTrafficLightsDistanceChartRender(_distanceChart),
					_distanceChart.Name + DrivingMode.TrafficThroughMultipleTrafficLights, false);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new MovementThroughMultipleTrafficLightsCarsChartRender(_carsMovementChart),
					_carsMovementChart.Name + DrivingMode.TrafficThroughMultipleTrafficLights, false);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new MovementThroughMultipleTrafficLightsSpeedFromDistanceChartRender(_speedFromDistanceChart),
					_speedFromDistanceChart.Name + DrivingMode.TrafficThroughMultipleTrafficLights, false);
			}

			CommonHelper.ServiceRegistration.RegisterInstance(() => new ChartRenderingHandler(
				new List<string>
				{
					_speedChart.Name,
					_distanceChart.Name,
					_carsMovementChart.Name,
					_speedFromDistanceChart.Name
				},
				ModesHelper.GetCurrentDrivingMode()), ModesHelper.DrivingModeType, false);
		}
	}
}