using TrafficFlowSimulation.Models.Attribute;

namespace TrafficFlowSimulation.Models.SettingsModels;

public class InliningInFlowModeSettingsModel : BaseSettingsModels
{
	[Hidden] 
	public override double L { get; set; }
}