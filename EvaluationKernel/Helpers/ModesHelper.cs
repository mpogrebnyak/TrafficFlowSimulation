using System.Collections.Generic;
using System.Linq;
using EvaluationKernel.Constants;
using EvaluationKernel.Properties;
using Settings;

namespace EvaluationKernel.Helpers;

public static class ModesHelper
{
	public static readonly string DrivingModeType = typeof(DrivingMode).ToString();

	public static readonly string ParametersSelectionModeType = typeof(ParametersSelectionMode).ToString();

	public static string GetCurrentDrivingMode()
	{
		return SettingsHelper.Get<ModesSettings>().CurrentDrivingMode.ToString();
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

	public static string GetCurrentParametersSelectionMode()
	{
		return SettingsHelper.Get<ModesSettings>().CurrentParametersSelectionMode.ToString();
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