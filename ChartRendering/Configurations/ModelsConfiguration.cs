using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.ParametersModels;
using ChartRendering.ChartRenderModels.ParametersSelectionSettingsModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Constants.Modes;
using Common;
using Common.Modularity;
using Settings;
using TrafficFlowSimulation.Constants.Modes;

namespace ChartRendering.Configurations;

public class ModelsConfiguration : IInitializable
{
	public void Initialize()
	{
		var availableDrivingModes = SettingsHelper.Get<Properties.ChartRenderingSettings>().AvailableDrivingModes;
		var availableParametersSelectionModes = SettingsHelper.Get<Properties.ChartRenderingSettings>().AvailableParametersSelectionModes;

		foreach (var mode in availableDrivingModes)
		{
			switch (mode)
			{
				case DrivingMode.StartAndStopMovement:
				{
					var m = DrivingMode.StartAndStopMovement.ToString();
					CommonHelper.ServiceRegistration.RegisterInstance<IBasicParametersModel>(() => new BasicParametersModel(), m );
					CommonHelper.ServiceRegistration.RegisterInstance<IAdditionalParametersModel>(() => new AdditionalParametersModel(), m);
					CommonHelper.ServiceRegistration.RegisterInstance<IInitialConditionsParametersModel>(() => new InitialConditionsParametersModel(), m);

					CommonHelper.ServiceRegistration.RegisterInstance<ISettingsModel>(() => new StartAndStopMovementModeSettingsModel(), m);

					break;
				}
				case DrivingMode.TrafficThroughOneTrafficLight:
				{
					var m = DrivingMode.TrafficThroughOneTrafficLight.ToString();
					CommonHelper.ServiceRegistration.RegisterInstance<IBasicParametersModel>(() => new BasicParametersModel(), m);
					CommonHelper.ServiceRegistration.RegisterInstance<IAdditionalParametersModel>(() => new AdditionalParametersModel(), m);
					CommonHelper.ServiceRegistration.RegisterInstance<IInitialConditionsParametersModel>(() => new InitialConditionsParametersModel(), m);

					CommonHelper.ServiceRegistration.RegisterInstance<ISettingsModel>(() => new MovementThroughOneTrafficLightModeSettingsModel(), m);

					break;
				}
				case DrivingMode.InliningInFlow:
				{
					var m = DrivingMode.InliningInFlow.ToString();
					CommonHelper.ServiceRegistration.RegisterInstance<IBasicParametersModel>(() => new BasicParametersModel(), m);
					CommonHelper.ServiceRegistration.RegisterInstance<IAdditionalParametersModel>(() => new AdditionalParametersModel(), m);
					CommonHelper.ServiceRegistration.RegisterInstance<IInitialConditionsParametersModel>(() => new InitialConditionsParametersModel(), m);

					CommonHelper.ServiceRegistration.RegisterInstance<ISettingsModel>(() => new InliningInFlowModeSettingsModel(), m);

					break;
				}
				case DrivingMode.SpeedLimitChanging:
				{
					var m = DrivingMode.SpeedLimitChanging.ToString();
					CommonHelper.ServiceRegistration.RegisterInstance<IBasicParametersModel>(() => new SpeedLimitChangingModeParametersModel(), m);
					CommonHelper.ServiceRegistration.RegisterInstance<IAdditionalParametersModel>(() => new AdditionalParametersModel(), m);
					CommonHelper.ServiceRegistration.RegisterInstance<IInitialConditionsParametersModel>(() => new InitialConditionsParametersModel(), m);

					CommonHelper.ServiceRegistration.RegisterInstance<ISettingsModel>(() => new SpeedLimitChangingModeSettingsModel(), m);

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
					CommonHelper.ServiceRegistration.RegisterInstance<ISettingsModel>(() => new AccelerationCoefficientEstimationSettingsModel(), m);
					CommonHelper.ServiceRegistration.RegisterInstance<IParametersModel>(() => new AccelerationCoefficientEstimationModelParametersModel(), m);

					break;
				}

				case ParametersSelectionMode.DecelerationCoefficientEstimation:
				{
					var m = ParametersSelectionMode.DecelerationCoefficientEstimation.ToString();
					CommonHelper.ServiceRegistration.RegisterInstance<ISettingsModel>(() => new DecelerationCoefficientEstimationSettingsModel(), m);
					CommonHelper.ServiceRegistration.RegisterInstance<IParametersModel>(() => new DecelerationCoefficientEstimationModelParametersModel(), m);

					break;
			}

				case ParametersSelectionMode.InliningDistanceEstimation:
				{
					var m = ParametersSelectionMode.InliningDistanceEstimation.ToString();
					CommonHelper.ServiceRegistration.RegisterInstance<ISettingsModel>(() => new InliningDistanceEstimationSettingsModel(), m);
					CommonHelper.ServiceRegistration.RegisterInstance<IParametersModel>(() => new InliningDistanceEstimationModelParametersModel(), m);

					break;
				}
			}
		}
	}
}