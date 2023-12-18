using Modes.Constants;
using Modes.Properties;
using Settings;

namespace Modes;

public static class ModesHelper
{
	public static DrivingMode GetCurrentDrivingMode()
	{
		return SettingsHelper.Get<ModesSettings>().CurrentDrivingMode;
	}

	public static void SetCurrentDrivingMode(DrivingMode mode)
	{
		var settings = SettingsHelper.Get<ModesSettings>();
		settings.CurrentDrivingMode = mode;
		SettingsHelper.Set(settings);
	}

	public static List<DrivingMode> GetAvailableDrivingModes()
	{
		return SettingsHelper.Get<ModesSettings>().AvailableDrivingModes.ToList();
	}

	public static ParametersSelectionMode GetCurrentParametersSelectionMode()
	{
		return SettingsHelper.Get<ModesSettings>().CurrentParametersSelectionMode;
	}

	public static void SetCurrentParametersSelectionMode(ParametersSelectionMode mode)
	{
		var settings = SettingsHelper.Get<ModesSettings>();
		settings.CurrentParametersSelectionMode = mode;
		SettingsHelper.Set(settings);
	}

	public static List<ParametersSelectionMode> GetAvailableParametersSelectionMode()
	{
		return SettingsHelper.Get<ModesSettings>().AvailableParametersSelectionModes.ToList();
	}
}