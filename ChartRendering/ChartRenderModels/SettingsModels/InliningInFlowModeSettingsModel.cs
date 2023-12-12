using ChartRendering.Attribute;

namespace ChartRendering.ChartRenderModels.SettingsModels;

// ReSharper disable InconsistentNaming

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