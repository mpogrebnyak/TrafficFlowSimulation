using Common;
using Common.Modularity;
using TrafficFlowSimulation.Models.ParametersModels;
using TrafficFlowSimulation.Models.ParametersSelectionSettingsModels;
using TrafficFlowSimulation.Models.SettingsModels;

namespace TrafficFlowSimulation.Models;

public class ModelsConfiguration : IInitializable
{
	public void Initialize()
	{
		CommonHelper.ServiceRegistrator.RegisterInstance<IModel>(() => new BasicParametersModel(),
			typeof(BasicParametersModel).ToString());
		CommonHelper.ServiceRegistrator.RegisterInstance<IModel>(() => new AdditionalParametersModel(),
			typeof(AdditionalParametersModel).ToString());
		CommonHelper.ServiceRegistrator.RegisterInstance<IModel>(() => new InitialConditionsParametersModel(),
			typeof(InitialConditionsParametersModel).ToString());

		CommonHelper.ServiceRegistrator.RegisterInstance<IModel>(() => new StartAndStopMovementModeSettingsModel(),
			typeof(StartAndStopMovementModeSettingsModel).ToString());
		CommonHelper.ServiceRegistrator.RegisterInstance<IModel>(() => new MovementThroughOneTrafficLightModeSettingsModel(),
			typeof(MovementThroughOneTrafficLightModeSettingsModel).ToString());
		CommonHelper.ServiceRegistrator.RegisterInstance<IModel>(() => new InliningInFlowModeSettingsModel(),
			typeof(InliningInFlowModeSettingsModel).ToString());
		CommonHelper.ServiceRegistrator.RegisterInstance<IModel>(() => new SpeedLimitChangingModeSettingsModel(),
			typeof(SpeedLimitChangingModeSettingsModel).ToString());

		CommonHelper.ServiceRegistrator.RegisterInstance<IModel>(() => new InliningDistanceEstimationSettingsModel(),
			typeof(InliningDistanceEstimationSettingsModel).ToString());
		CommonHelper.ServiceRegistrator.RegisterInstance<IModel>(() => new InliningDistanceEstimationModelParametersModel(),
			typeof(InliningDistanceEstimationModelParametersModel).ToString());
	}
}