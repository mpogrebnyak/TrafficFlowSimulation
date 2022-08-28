using TrafficFlowSimulation.Models.ParametersModels;
using TrafficFlowSimulation.Models.ParametersSelectionSettingsModels;
using TrafficFlowSimulation.Models.SettingsModels;

namespace TrafficFlowSimulation.Models;

public class ModelsConfiguration : TrafficFlowSimulationModule
{
	public override void Initialize()
	{
		_serviceRegistrator.RegisterInstance<IModel>(() => new BasicParametersModel(),
			typeof(BasicParametersModel).ToString());
		_serviceRegistrator.RegisterInstance<IModel>(() => new AdditionalParametersModel(),
			typeof(AdditionalParametersModel).ToString());
		_serviceRegistrator.RegisterInstance<IModel>(() => new InitialConditionsParametersModel(),
			typeof(InitialConditionsParametersModel).ToString());

		_serviceRegistrator.RegisterInstance<IModel>(() => new StartAndStopMovementModeSettingsModel(),
			typeof(StartAndStopMovementModeSettingsModel).ToString());
		_serviceRegistrator.RegisterInstance<IModel>(() => new MovementThroughOneTrafficLightModeSettingsModel(),
			typeof(MovementThroughOneTrafficLightModeSettingsModel).ToString());
		_serviceRegistrator.RegisterInstance<IModel>(() => new InliningInFlowModeSettingsModel(),
			typeof(InliningInFlowModeSettingsModel).ToString());

		_serviceRegistrator.RegisterInstance<IModel>(() => new InliningDistanceSettingsModel(),
			typeof(InliningDistanceSettingsModel).ToString());
	}
}