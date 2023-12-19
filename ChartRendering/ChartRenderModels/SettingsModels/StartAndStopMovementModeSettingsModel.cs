using ChartRendering.Constants;
using Localization.Localization;

namespace ChartRendering.ChartRenderModels.SettingsModels;

// ReSharper disable InconsistentNaming

public class StartAndStopMovementModeSettingsModel : BaseSettingsModels
{
	public override object GetDefault()
	{
		return new StartAndStopMovementModeSettingsModel
		{
			Scroll = new EnumItem(AutoScroll.No),
			ScrollFor = 0,
			L = 200
		};
	}
}