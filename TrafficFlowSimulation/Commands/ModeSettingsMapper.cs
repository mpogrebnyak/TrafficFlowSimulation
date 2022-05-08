using System;
using Settings;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Models.ModeSettingsModels;
using TrafficFlowSimulation.Сonstants;

namespace TrafficFlowSimulation.Commands;

public static class ModeSettingsMapper
{
	public static ModeSettingsModel GetDefault()
	{
		var modeSettingsModel = new ModeSettingsModel
		{
			SingleLightGreenTime = 10,
			SingleLightRedTime = 10
		};

		return modeSettingsModel;
	}

	public static ModeSettings MapModel(Object parameters)
	{
		var modelParametersModel = (ModeSettingsModel)parameters;

		var currentDrivingMode = SettingsHelper.Get<Properties.Settings>().CurrentDrivingMode;

		switch (currentDrivingMode)
		{
			case DrivingMode.TrafficThroughOneTrafficLight:
				return MapMovementThroughOneTrafficLightModeSettings(modelParametersModel);

			default:
				return null;
		}
	}

	private static MovementThroughOneTrafficLightModeSettings MapMovementThroughOneTrafficLightModeSettings (ModeSettingsModel model)
	{
		return new MovementThroughOneTrafficLightModeSettings
		{
			TrafficLight = new TrafficLightModel
			{
				Number = 1,
				Position = 0,
				GreenSignalTime = model.SingleLightGreenTime,
				RedSignalTime = model.SingleLightRedTime
			}
		};
	}
}