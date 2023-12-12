using System.Linq;
using ChartRendering.Constants.Modes;
using ChartRendering.Handlers;
using ChartRendering.Models;
using ChartRendering.Renders.ChartRenders;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.InliningInFlow;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.MovementThroughOneTrafficLight;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.SpeedLimitChanging;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.StartAndStopMovement;
using Common;
using Common.Modularity;
using Settings;
using TrafficFlowSimulation.Constants.Modes;
using TrafficFlowSimulation.Renders.ChartRenders;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.MovementThroughOneTrafficLight;
using TrafficFlowSimulation.Windows.Models;

namespace TrafficFlowSimulation.Configurations
{
	public class MovementSimulationConfiguration : IInitializable
	{
		private readonly AllChartsModel _allCharts;

		public MovementSimulationConfiguration(AllChartsModel allCharts)
		{
			_allCharts = allCharts;
		}

		public void Initialize()
		{
			var availableModes = SettingsHelper.Get<ChartRendering.Properties.ChartRenderingSettings>().AvailableDrivingModes.ToList();

			if (availableModes.Contains(DrivingMode.StartAndStopMovement))
			{
				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new StartAndStopMovementSpeedChartRender(_allCharts.SpeedChart),
					_allCharts.SpeedChart.Name + DrivingMode.StartAndStopMovement);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new StartAndStopMovementDistanceChartRender(_allCharts.DistanceChart),
					_allCharts.DistanceChart.Name + DrivingMode.StartAndStopMovement);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new StartAndStopMovementCarsChartRender(_allCharts.CarsMovementChart),
					_allCharts.CarsMovementChart.Name + DrivingMode.StartAndStopMovement);
			}

			if (availableModes.Contains(DrivingMode.TrafficThroughOneTrafficLight))
			{
				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightSpeedChartRender(_allCharts.SpeedChart),
					_allCharts.SpeedChart.Name + DrivingMode.TrafficThroughOneTrafficLight);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightDistanceChartRender(_allCharts.DistanceChart),
					_allCharts.DistanceChart.Name + DrivingMode.TrafficThroughOneTrafficLight);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new MovementThroughOneTrafficLightCarsChartRender(_allCharts.CarsMovementChart),
					_allCharts.CarsMovementChart.Name + DrivingMode.TrafficThroughOneTrafficLight);
			}

			if (availableModes.Contains(DrivingMode.InliningInFlow))
			{
				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new InliningInFlowSpeedChartRender(_allCharts.SpeedChart),
					_allCharts.SpeedChart.Name + DrivingMode.InliningInFlow);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new InliningInFlowDistanceChartRender(_allCharts.DistanceChart),
					_allCharts.DistanceChart.Name + DrivingMode.InliningInFlow);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new InliningInFlowCarsChartRender(_allCharts.CarsMovementChart),
					_allCharts.CarsMovementChart.Name + DrivingMode.InliningInFlow);
			}

			if (availableModes.Contains(DrivingMode.SpeedLimitChanging))
			{
				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new SpeedLimitChangingSpeedChartRender(_allCharts.SpeedChart),
					_allCharts.SpeedChart.Name + DrivingMode.SpeedLimitChanging);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new SpeedLimitChangingDistanceChartRender(_allCharts.DistanceChart),
					_allCharts.DistanceChart.Name + DrivingMode.SpeedLimitChanging);

				CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new SpeedLimitChangingCarsChartRender(_allCharts.CarsMovementChart),
					_allCharts.CarsMovementChart.Name + DrivingMode.SpeedLimitChanging);
			}

			CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new SpeedFromDistanceChartRender(_allCharts.SpeedFromDistanceChart),
				_allCharts.SpeedFromDistanceChart.Name);

			CommonHelper.ServiceRegistration.RegisterInstance<RenderingHandler>(() => new RenderingHandler(_allCharts));
		}
	}
}