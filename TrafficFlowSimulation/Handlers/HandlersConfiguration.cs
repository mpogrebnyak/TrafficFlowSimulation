using System.Linq;
using Common;
using Common.Modularity;
using Settings;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Handlers.EvaluationHandlers;
using TrafficFlowSimulation.Handlers.EvaluationHandlers.MovementSimulationEvaluationHandlers;
using TrafficFlowSimulation.Handlers.EvaluationHandlers.ParametersSelectionEvaluationHandlers;

namespace TrafficFlowSimulation.Handlers;

public class HandlersConfiguration : IInitializable
{
	public void Initialize()
	{
		InitializeMovementSimulationEvaluationHandlers();
		InitializeParametersSelectionEvaluationHandlers();
	}

	private void InitializeMovementSimulationEvaluationHandlers()
	{
		var availableModes = SettingsHelper.Get<Properties.Settings>().AvailableDrivingModes.ToList();

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
		var parametersSelectionModes = SettingsHelper.Get<Properties.Settings>().AvailableParametersSelectionModes.ToList();

		if (parametersSelectionModes.Contains(ParametersSelectionMode.InliningDistanceEstimation))
		{
			CommonHelper.ServiceRegistrator.RegisterInstance<IEvaluationHandler>(() => new InliningDistanceEstimationSelectionEvaluationHandler(),
				ParametersSelectionMode.InliningDistanceEstimation.ToString());
		}
	}
}