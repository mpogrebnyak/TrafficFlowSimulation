using ChartRendering.Attribute;
using ChartRendering.Constants;
using Localization.Localization;

namespace ChartRendering.ChartRenderModels.SettingsModels;

public class TrafficThroughBottleneckModeSettingsModel : InliningInFlowModeSettingsModel
{
	[Hidden]
	public override int Number { get; set; }

	[Hidden]
	public override double LenghtToInline { get; set; }

	public override object GetDefault()
	{
		return new InliningInFlowModeSettingsModel
		{
			L = 50000,
			ChangeFirstInliningInFlowCarColor = false,
			Number = 0,
			Lenght = 100,
			LenghtToInline = 0,
			IsAllCarsChangeLine = new EnumItem(AllCarsChangeLine.Yes)
		};
	}
}