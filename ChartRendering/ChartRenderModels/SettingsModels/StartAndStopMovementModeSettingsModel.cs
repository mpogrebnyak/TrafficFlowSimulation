namespace ChartRendering.ChartRenderModels.SettingsModels;

// ReSharper disable InconsistentNaming

public class StartAndStopMovementModeSettingsModel : BaseSettingsModels
{
	public override object GetDefault()
	{
		return new StartAndStopMovementModeSettingsModel
		{
			L = 200
		};
	}
}