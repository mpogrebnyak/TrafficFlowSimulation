using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.Renders.ChartRenders;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders.InliningInFlow;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders.MovementThroughOneTrafficLight;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders.RoadHole;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders.SpeedLimitChanging;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders.StartAndStopMovement;
using Common;
using Common.Modularity;
using Modes;
using Modes.Constants;
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
					_speedChart.Name + DrivingMode.StartAndStopMovement);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new StartAndStopMovementDistanceChartRender(_distanceChart),
					_distanceChart.Name + DrivingMode.StartAndStopMovement);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new StartAndStopMovementCarsChartRender(_carsMovementChart),
					_carsMovementChart.Name + DrivingMode.StartAndStopMovement);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new SpeedFromDistanceChartRender(_speedFromDistanceChart),
					_speedFromDistanceChart.Name + DrivingMode.StartAndStopMovement);
			}

			if (availableModes.Contains(DrivingMode.TrafficThroughOneTrafficLight))
			{
				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightSpeedChartRender(_speedChart),
					_speedChart.Name + DrivingMode.TrafficThroughOneTrafficLight);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightDistanceChartRender(_distanceChart),
					_distanceChart.Name + DrivingMode.TrafficThroughOneTrafficLight);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightCarsChartRender(_carsMovementChart),
					_carsMovementChart.Name + DrivingMode.TrafficThroughOneTrafficLight);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new SpeedFromDistanceChartRender(_speedFromDistanceChart),
					_speedFromDistanceChart.Name + DrivingMode.TrafficThroughOneTrafficLight);
			}

			if (availableModes.Contains(DrivingMode.InliningInFlow))
			{
				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new InliningInFlowSpeedChartRender(_speedChart),
					_speedChart.Name + DrivingMode.InliningInFlow);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new InliningInFlowDistanceChartRender(_distanceChart),
					_distanceChart.Name + DrivingMode.InliningInFlow);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new InliningInFlowCarsChartRender(_carsMovementChart),
					_carsMovementChart.Name + DrivingMode.InliningInFlow);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new SpeedFromDistanceChartRender(_speedFromDistanceChart),
					_speedFromDistanceChart.Name + DrivingMode.InliningInFlow);
			}

			if (availableModes.Contains(DrivingMode.SpeedLimitChanging))
			{
				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new SpeedLimitChangingSpeedChartRender(_speedChart),
					_speedChart.Name + DrivingMode.SpeedLimitChanging);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new SpeedLimitChangingDistanceChartRender(_distanceChart),
					_distanceChart.Name + DrivingMode.SpeedLimitChanging);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new SpeedLimitChangingCarsChartRender(_carsMovementChart),
					_carsMovementChart.Name + DrivingMode.SpeedLimitChanging);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new SpeedLimitChangingSpeedFromDistanceChartRender(_speedFromDistanceChart),
					_speedFromDistanceChart.Name + DrivingMode.SpeedLimitChanging);
			}

			if (availableModes.Contains(DrivingMode.RoadHole))
			{
				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new RoadHoleSpeedChartRender(_speedChart),
					_speedChart.Name + DrivingMode.RoadHole);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new RoadHoleDistanceChartRender(_distanceChart),
					_distanceChart.Name + DrivingMode.RoadHole);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new RoadHoleCarsChartRender(_carsMovementChart),
					_carsMovementChart.Name + DrivingMode.RoadHole);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new RoadHoleSpeedFromDistanceChartRender(_speedFromDistanceChart),
					_speedFromDistanceChart.Name + DrivingMode.RoadHole);
			}

			CommonHelper.ServiceRegistration.RegisterInstance(() => new ChartRenderingHandler(
				new List<string>
				{
					_speedChart.Name,
					_distanceChart.Name,
					_carsMovementChart.Name,
					_speedFromDistanceChart.Name
				},
				ModesHelper.GetCurrentDrivingMode()), ModesHelper.DrivingModeType);
		}
	}
}