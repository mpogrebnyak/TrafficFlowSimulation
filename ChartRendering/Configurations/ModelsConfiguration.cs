using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.ParametersModels;
using ChartRendering.ChartRenderModels.ParametersSelectionSettingsModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Constants.Modes;
using Common;
using Common.Modularity;
using Settings;
using TrafficFlowSimulation.Constants.Modes;
//using TrafficFlowSimulation.Models.ChartRenderModels.ParametersModels;
using TrafficFlowSimulation.Models.ChartRenderModels.ParametersSelectionSettingsModels;
using TrafficFlowSimulation.Models.ChartRenderModels.SettingsModels;

namespace ChartRendering.Configurations;

public class ModelsConfiguration : IInitializable
{
	public void Initialize()
	{
		var availableDrivingModes = SettingsHelper.Get<ChartRendering.Properties.Settings>().AvailableDrivingModes;
		var availableParametersSelectionModes = SettingsHelper.Get<ChartRendering.Properties.Settings>().AvailableParametersSelectionModes;

		foreach (var mode in availableDrivingModes)
		{
			switch (mode)
			{
				case DrivingMode.StartAndStopMovement:
				{
					var m = DrivingMode.StartAndStopMovement.ToString();
					CommonHelper.ServiceRegistrator.RegisterInstance<IBasicParametersModel>(() => new BasicParametersModel(), m );
					CommonHelper.ServiceRegistrator.RegisterInstance<IAdditionalParametersModel>(() => new AdditionalParametersModel(), m);
					CommonHelper.ServiceRegistrator.RegisterInstance<IInitialConditionsParametersModel>(() => new InitialConditionsParametersModel(), m);

					CommonHelper.ServiceRegistrator.RegisterInstance<ISettingsModel>(() => new StartAndStopMovementModeSettingsModel(), m);

					break;
				}
				case DrivingMode.TrafficThroughOneTrafficLight:
				{
					var m = DrivingMode.TrafficThroughOneTrafficLight.ToString();
					CommonHelper.ServiceRegistrator.RegisterInstance<IBasicParametersModel>(() => new BasicParametersModel(), m);
					CommonHelper.ServiceRegistrator.RegisterInstance<IAdditionalParametersModel>(() => new AdditionalParametersModel(), m);
					CommonHelper.ServiceRegistrator.RegisterInstance<IInitialConditionsParametersModel>(() => new InitialConditionsParametersModel(), m);

					CommonHelper.ServiceRegistrator.RegisterInstance<ISettingsModel>(() => new MovementThroughOneTrafficLightModeSettingsModel(), m);

					break;
				}
				case DrivingMode.InliningInFlow:
				{
					var m = DrivingMode.InliningInFlow.ToString();
					CommonHelper.ServiceRegistrator.RegisterInstance<IBasicParametersModel>(() => new BasicParametersModel(), m);
					CommonHelper.ServiceRegistrator.RegisterInstance<IAdditionalParametersModel>(() => new AdditionalParametersModel(), m);
					CommonHelper.ServiceRegistrator.RegisterInstance<IInitialConditionsParametersModel>(() => new InitialConditionsParametersModel(), m);

					CommonHelper.ServiceRegistrator.RegisterInstance<ISettingsModel>(() => new InliningInFlowModeSettingsModel(), m);

					break;
				}
				case DrivingMode.SpeedLimitChanging:
				{
					var m = DrivingMode.SpeedLimitChanging.ToString();
					CommonHelper.ServiceRegistrator.RegisterInstance<IBasicParametersModel>(() => new SpeedLimitChangingModeParametersModel(), m);
					CommonHelper.ServiceRegistrator.RegisterInstance<IAdditionalParametersModel>(() => new AdditionalParametersModel(), m);
					CommonHelper.ServiceRegistrator.RegisterInstance<IInitialConditionsParametersModel>(() => new InitialConditionsParametersModel(), m);

					CommonHelper.ServiceRegistrator.RegisterInstance<ISettingsModel>(() => new SpeedLimitChangingModeSettingsModel(), m);

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
					CommonHelper.ServiceRegistrator.RegisterInstance<ISettingsModel>(() => new AccelerationCoefficientEstimationSettingsModel(), m);
					CommonHelper.ServiceRegistrator.RegisterInstance<IParametersModel>(() => new AccelerationCoefficientEstimationModelParametersModel(), m);

					break;
				}

				case ParametersSelectionMode.DecelerationCoefficientEstimation:
				{
					var m = ParametersSelectionMode.DecelerationCoefficientEstimation.ToString();
					CommonHelper.ServiceRegistrator.RegisterInstance<ISettingsModel>(() => new DecelerationCoefficientEstimationSettingsModel(), m);
					CommonHelper.ServiceRegistrator.RegisterInstance<IParametersModel>(() => new DecelerationCoefficientEstimationModelParametersModel(), m);

					break;
			}

				case ParametersSelectionMode.InliningDistanceEstimation:
				{
					var m = ParametersSelectionMode.InliningDistanceEstimation.ToString();
					CommonHelper.ServiceRegistrator.RegisterInstance<ISettingsModel>(() => new InliningDistanceEstimationSettingsModel(), m);
					CommonHelper.ServiceRegistrator.RegisterInstance<IParametersModel>(() => new InliningDistanceEstimationModelParametersModel(), m);

					break;
				}
			}
		}
	}
}