using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.ParametersModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using Common;
using Common.Modularity;
using EvaluationKernel.Constants;
using EvaluationKernel.Helpers;

namespace ChartRendering.Configurations;

public class ModelsConfiguration : IInitializable
{
	public void Initialize()
	{
		var availableDrivingModes = ModesHelper.GetAvailableDrivingModes();
		var availableParametersSelectionModes = ModesHelper.GetAvailableParametersSelectionMode();;

		foreach (var mode in availableDrivingModes)
		{
			switch (mode)
			{
				case DrivingMode.StartAndStopMovement:
				{
					var m = DrivingMode.StartAndStopMovement.ToString();
					CommonHelper.ServiceRegistration.RegisterInstance<IBaseParametersModel>(() => new BaseParametersModel(), m, false);
					CommonHelper.ServiceRegistration.RegisterInstance<IAdditionalParametersModel>(() => new AdditionalParametersModel(), m, false);
					CommonHelper.ServiceRegistration.RegisterInstance<IInitialConditionsParametersModel>(() => new InitialConditionsParametersModel(), m, false);

					CommonHelper.ServiceRegistration.RegisterInstance<ISettingsModel>(() => new StartAndStopMovementModeSettingsModel(), m, false);

					break;
				}
				case DrivingMode.TrafficThroughOneTrafficLight:
				{
					var m = DrivingMode.TrafficThroughOneTrafficLight.ToString();
					CommonHelper.ServiceRegistration.RegisterInstance<IBaseParametersModel>(() => new BaseParametersModel(), m, false);
					CommonHelper.ServiceRegistration.RegisterInstance<IAdditionalParametersModel>(() => new AdditionalParametersModel(), m, false);
					CommonHelper.ServiceRegistration.RegisterInstance<IInitialConditionsParametersModel>(() => new InitialConditionsParametersModel(), m, false);

					CommonHelper.ServiceRegistration.RegisterInstance<ISettingsModel>(() => new MovementThroughOneTrafficLightModeSettingsModel(), m, false);

					break;
				}
				case DrivingMode.InliningInFlow:
				{
					var m = DrivingMode.InliningInFlow.ToString();
					CommonHelper.ServiceRegistration.RegisterInstance<IBaseParametersModel>(() => new BaseParametersModel(), m, false);
					CommonHelper.ServiceRegistration.RegisterInstance<IAdditionalParametersModel>(() => new AdditionalParametersModel(), m, false);
					CommonHelper.ServiceRegistration.RegisterInstance<IInitialConditionsParametersModel>(() => new InitialConditionsParametersModel(), m, false);

					CommonHelper.ServiceRegistration.RegisterInstance<ISettingsModel>(() => new InliningInFlowModeSettingsModel(), m, false);

					break;
				}
				case DrivingMode.SpeedLimitChanging:
				{
					var m = DrivingMode.SpeedLimitChanging.ToString();
					CommonHelper.ServiceRegistration.RegisterInstance<IBaseParametersModel>(() => new SpeedLimitChangingModeParametersModel(), m, false);
					CommonHelper.ServiceRegistration.RegisterInstance<IAdditionalParametersModel>(() => new AdditionalParametersModel(), m, false);
					CommonHelper.ServiceRegistration.RegisterInstance<IInitialConditionsParametersModel>(() => new SpeedLimitChangingInitialConditionsParametersModel(), m, false);

					CommonHelper.ServiceRegistration.RegisterInstance<ISettingsModel>(() => new SpeedLimitChangingModeSettingsModel(), m, false);

					break;
				}

				case DrivingMode.RoadHole:
				{
					var m = DrivingMode.RoadHole.ToString();
					CommonHelper.ServiceRegistration.RegisterInstance<IBaseParametersModel>(() => new SpeedLimitChangingModeParametersModel(), m, false);
					CommonHelper.ServiceRegistration.RegisterInstance<IAdditionalParametersModel>(() => new AdditionalParametersModel(), m, false);
					CommonHelper.ServiceRegistration.RegisterInstance<IInitialConditionsParametersModel>(() => new SpeedLimitChangingInitialConditionsParametersModel(), m, false);

					CommonHelper.ServiceRegistration.RegisterInstance<ISettingsModel>(() => new RoadHoleModeSettingsModel(), m, false);

					break;
				}

				case DrivingMode.ThroughTheDriver:
				{
					var m = DrivingMode.ThroughTheDriver.ToString();
					CommonHelper.ServiceRegistration.RegisterInstance<IBaseParametersModel>(() => new BaseParametersModel(), m, false);
					CommonHelper.ServiceRegistration.RegisterInstance<IAdditionalParametersModel>(() => new AdditionalParametersModel(), m, false);
					CommonHelper.ServiceRegistration.RegisterInstance<IInitialConditionsParametersModel>(() => new InitialConditionsParametersModel(), m, false);

					CommonHelper.ServiceRegistration.RegisterInstance<ISettingsModel>(() => new StartAndStopMovementModeSettingsModel(), m, false);

					break;
				}
			}
		}

		foreach (var mode in availableParametersSelectionModes)
		{
			switch (mode)
			{
				case ParametersSelectionMode.AccelerationCoefficientEstimation:
				{
					var m = ParametersSelectionMode.AccelerationCoefficientEstimation.ToString();
					CommonHelper.ServiceRegistration.RegisterInstance<ISettingsModel>(() => new AccelerationCoefficientEstimationSettingsModel(), m, false);
					CommonHelper.ServiceRegistration.RegisterInstance<IParametersModel>(() => new AccelerationCoefficientEstimationModelParametersModel(), m, false);

					break;
				}

				case ParametersSelectionMode.DecelerationCoefficientEstimation:
				{
					var m = ParametersSelectionMode.DecelerationCoefficientEstimation.ToString();
					CommonHelper.ServiceRegistration.RegisterInstance<ISettingsModel>(() => new DecelerationCoefficientEstimationSettingsModel(), m, false);
					CommonHelper.ServiceRegistration.RegisterInstance<IParametersModel>(() => new DecelerationCoefficientEstimationModelParametersModel(), m, false);

					break;
			}

				case ParametersSelectionMode.InliningDistanceEstimation:
				{
					var m = ParametersSelectionMode.InliningDistanceEstimation.ToString();
					CommonHelper.ServiceRegistration.RegisterInstance<ISettingsModel>(() => new InliningDistanceEstimationSettingsModel(), m, false);
					CommonHelper.ServiceRegistration.RegisterInstance<IParametersModel>(() => new InliningDistanceEstimationModelParametersModel(), m, false);

					break;
				}
			}
		}
	}
}