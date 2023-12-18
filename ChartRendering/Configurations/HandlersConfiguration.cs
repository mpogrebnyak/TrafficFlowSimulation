using ChartRendering.EvaluationHandlers;
using ChartRendering.EvaluationHandlers.MovementSimulationEvaluationHandlers;
using ChartRendering.EvaluationHandlers.ParametersSelectionEvaluationHandlers;
using Common;
using Common.Modularity;
using Modes;
using Modes.Constants;

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
		var availableModes = ModesHelper.GetAvailableDrivingModes();

		if (availableModes.Contains(DrivingMode.StartAndStopMovement))
		{
			CommonHelper.ServiceRegistration.RegisterInstance<IEvaluationHandler>(() => new StartAndStopMovementEvaluationHandler(),
				DrivingMode.StartAndStopMovement.ToString());
		}

		if (availableModes.Contains(DrivingMode.TrafficThroughOneTrafficLight))
		{
			CommonHelper.ServiceRegistration.RegisterInstance<IEvaluationHandler>(() => new MovementThroughOneTrafficLightEvaluationHandler(),
				DrivingMode.TrafficThroughOneTrafficLight.ToString());
		}

		if (availableModes.Contains(DrivingMode.InliningInFlow))
		{
			CommonHelper.ServiceRegistration.RegisterInstance<IEvaluationHandler>(() => new InliningInFlowEvaluationHandler(),
				DrivingMode.InliningInFlow.ToString());
		}
		
		if (availableModes.Contains(DrivingMode.SpeedLimitChanging))
		{
			CommonHelper.ServiceRegistration.RegisterInstance<IEvaluationHandler>(() => new SpeedLimitChangingEvaluationHandler(),
				DrivingMode.SpeedLimitChanging.ToString());
		}
	}

	private void InitializeParametersSelectionEvaluationHandlers()
	{
		var parametersSelectionModes = ModesHelper.GetAvailableParametersSelectionMode();;

		if (parametersSelectionModes.Contains(ParametersSelectionMode.InliningDistanceEstimation))
		{
			CommonHelper.ServiceRegistration.RegisterInstance<IEvaluationHandler>(() => new InliningDistanceEstimationSelectionEvaluationHandler(),
				ParametersSelectionMode.InliningDistanceEstimation.ToString());
		}

		if (parametersSelectionModes.Contains(ParametersSelectionMode.AccelerationCoefficientEstimation))
		{
			CommonHelper.ServiceRegistration.RegisterInstance<IEvaluationHandler>(() => new AccelerationCoefficientEstimationSelectionEvaluationHandler(),
				ParametersSelectionMode.AccelerationCoefficientEstimation.ToString());
		}

		if (parametersSelectionModes.Contains(ParametersSelectionMode.DecelerationCoefficientEstimation))
		{
			CommonHelper.ServiceRegistration.RegisterInstance<IEvaluationHandler>(() => new DecelerationCoefficientEstimationSelectionEvaluationHandler(),
				ParametersSelectionMode.DecelerationCoefficientEstimation.ToString());
		}
	}
}