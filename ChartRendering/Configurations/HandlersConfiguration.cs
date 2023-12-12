using System.Linq;
using ChartRendering.Constants.Modes;
using ChartRendering.EvaluationHandlers;
using Common;
using Common.Modularity;
using Settings;
using TrafficFlowSimulation.Constants.Modes;
using TrafficFlowSimulation.Handlers.EvaluationHandlers.MovementSimulationEvaluationHandlers;
using TrafficFlowSimulation.Handlers.EvaluationHandlers.ParametersSelectionEvaluationHandlers;

namespace ChartRendering.Configurations;

public class HandlersConfiguration : IInitializable
{
	public void Initialize()
	{
		InitializeMovementSimulationEvaluationHandlers();
		InitializeParametersSelectionEvaluationHandlers();
	}

	private void InitializeMovementSimulationEvaluationHandlers()
	{
		var availableModes = SettingsHelper.Get<ChartRendering.Properties.Settings>().AvailableDrivingModes.ToList();

		if (availableModes.Contains(DrivingMode.StartAndStopMovement))
		{
			CommonHelper.ServiceRegistrator.RegisterInstance<IEvaluationHandler>(() => new StartAndStopMovementEvaluationHandler(),
				DrivingMode.StartAndStopMovement.ToString());
		}

		if (availableModes.Contains(DrivingMode.TrafficThroughOneTrafficLight))
		{
			CommonHelper.ServiceRegistrator.RegisterInstance<IEvaluationHandler>(() => new MovementThroughOneTrafficLightEvaluationHandler(),
				DrivingMode.TrafficThroughOneTrafficLight.ToString());
		}

		if (availableModes.Contains(DrivingMode.InliningInFlow))
		{
			CommonHelper.ServiceRegistrator.RegisterInstance<IEvaluationHandler>(() => new InliningInFlowEvaluationHandler(),
				DrivingMode.InliningInFlow.ToString());
		}
		
		if (availableModes.Contains(DrivingMode.SpeedLimitChanging))
		{
			CommonHelper.ServiceRegistrator.RegisterInstance<IEvaluationHandler>(() => new SpeedLimitChangingEvaluationHandler(),
				DrivingMode.SpeedLimitChanging.ToString());
		}
	}

	private void InitializeParametersSelectionEvaluationHandlers()
	{
		var parametersSelectionModes = SettingsHelper.Get<ChartRendering.Properties.Settings>().AvailableParametersSelectionModes.ToList();

		if (parametersSelectionModes.Contains(ParametersSelectionMode.InliningDistanceEstimation))
		{
			CommonHelper.ServiceRegistrator.RegisterInstance<IEvaluationHandler>(() => new InliningDistanceEstimationSelectionEvaluationHandler(),
				ParametersSelectionMode.InliningDistanceEstimation.ToString());
		}

		if (parametersSelectionModes.Contains(ParametersSelectionMode.AccelerationCoefficientEstimation))
		{
			CommonHelper.ServiceRegistrator.RegisterInstance<IEvaluationHandler>(() => new AccelerationCoefficientEstimationSelectionEvaluationHandler(),
				ParametersSelectionMode.AccelerationCoefficientEstimation.ToString());
		}

		if (parametersSelectionModes.Contains(ParametersSelectionMode.DecelerationCoefficientEstimation))
		{
			CommonHelper.ServiceRegistrator.RegisterInstance<IEvaluationHandler>(() => new DecelerationCoefficientEstimationSelectionEvaluationHandler(),
				ParametersSelectionMode.DecelerationCoefficientEstimation.ToString());
		}
	}
}