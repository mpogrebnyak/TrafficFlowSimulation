namespace TrafficFlowSimulation.Models.ChartRenderModels.SettingsModels;

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