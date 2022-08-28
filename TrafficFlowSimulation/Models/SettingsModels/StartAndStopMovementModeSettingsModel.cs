namespace TrafficFlowSimulation.Models.SettingsModels;

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