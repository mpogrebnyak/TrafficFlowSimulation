using Settings;
using TrafficFlowSimulation.Models.ModeSettingsModels;
using TrafficFlowSimulation.MovementSimulation;
using TrafficFlowSimulation.Сonstants;

namespace TrafficFlowSimulation.Services;

public static class DefaultModeSettingsService
{
	public static ModeSettings GetModeSettings()
	{
		var currentDrivingMode = SettingsHelper.Get<Properties.Settings>().CurrentDrivingMode;

		if (currentDrivingMode == DrivingMode.TrafficThroughTrafficLights)
		{
			return MovementThroughOneTrafficLightModeSettings.GetDefault();
		}

		return new ModeSettings();
	}
}