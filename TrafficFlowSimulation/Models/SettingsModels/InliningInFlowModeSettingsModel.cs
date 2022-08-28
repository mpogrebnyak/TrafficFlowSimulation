using TrafficFlowSimulation.Models.Attribute;

namespace TrafficFlowSimulation.Models.SettingsModels;

public class InliningInFlowModeSettingsModel : BaseSettingsModels
{
	[Hidden] 
	public override double L { get; set; }

	public override object GetDefault()
	{
		return new InliningInFlowModeSettingsModel
		{
			L = 10000
		};
	}
}