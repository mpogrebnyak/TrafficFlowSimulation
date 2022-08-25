using System.Linq;
using Settings;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Handlers.EvaluationHandlers;
using TrafficFlowSimulation.Handlers.EvaluationHandlers.MovementSimulationEvaluationHandlers;
using TrafficFlowSimulation.Handlers.EvaluationHandlers.ParametersSelectionEvaluationHandlers;

namespace TrafficFlowSimulation.Handlers;

public class HandlersConfiguration : TrafficFlowSimulationModule
{
	public override void Initialize()
	{
		InitializeMovementSimulationEvaluationHandlers();
		InitializeParametersSelectionEvaluationHandlers();
	}

	private void InitializeMovementSimulationEvaluationHandlers()
	{
		var availableModes = SettingsHelper.Get<Properties.Settings>().AvailableDrivingModes.ToList();

		if (availableModes.Contains(DrivingMode.StartAndStopMovement))
		{
			_serviceRegistrator.RegisterInstance<IEvaluationHandler>(() => new StartAndStopMovementEvaluationHandler(),
				DrivingMode.StartAndStopMovement.ToString());
		}

		if (availableModes.Contains(DrivingMode.TrafficThroughOneTrafficLight))
		{
			_serviceRegistrator.RegisterInstance<IEvaluationHandler>(() => new MovementThroughOneTrafficLightEvaluationHandler(),
				DrivingMode.TrafficThroughOneTrafficLight.ToString());
		}

		if (availableModes.Contains(DrivingMode.InliningInFlow))
		{
			_serviceRegistrator.RegisterInstance<IEvaluationHandler>(() => new InliningInFlowEvaluationHandler(),
				DrivingMode.InliningInFlow.ToString());
		}
	}

	private void InitializeParametersSelectionEvaluationHandlers()
	{
		var parametersSelectionModes = SettingsHelper.Get<Properties.Settings>().AvailableParametersSelectionModes.ToList();

		if (parametersSelectionModes.Contains(ParametersSelectionMode.InliningDistance))
		{
			_serviceRegistrator.RegisterInstance<IEvaluationHandler>(() => new InliningDistanceSelectionEvaluationHandler(),
				ParametersSelectionMode.InliningDistance.ToString());
		}
	}
}