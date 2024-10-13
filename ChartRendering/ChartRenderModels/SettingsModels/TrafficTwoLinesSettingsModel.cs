using ChartRendering.Attribute;
using ChartRendering.Constants;
using Localization.Localization;

namespace ChartRendering.ChartRenderModels.SettingsModels;

public class TrafficTwoLinesSettingsModel : InliningInFlowModeSettingsModel
{
	[Translation(Locales.ru, "Расстояние до остановки")]
	[Translation(Locales.en, "Distance to the stop")]
	[CustomDisplay(3)]
	public new double L { get; set; }

	[Hidden] 
	public override bool ChangeFirstInliningInFlowCarColor{ get; set; }

	[Hidden]
	public override int Number { get; set; }

	[Hidden] 
	public override double Lenght { get; set; }

	[Hidden]
	public override EnumItem IsAllCarsChangeLine { get; set; }

	public override object GetDefault()
	{
		return new InliningInFlowModeSettingsModel
		{
			L = 500,
			ChangeFirstInliningInFlowCarColor = true,
			Number = int.MaxValue,
			Lenght = 500,
			IsAllCarsChangeLine = new EnumItem(AllCarsChangeLine.No)
		};
	}
}