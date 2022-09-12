using System.ComponentModel.DataAnnotations;
using Localization.Localization;
using TrafficFlowSimulation.Models.Attribute;

namespace TrafficFlowSimulation.Models.SettingsModels;

public class SpeedLimitChangingModeSettingsModel : BaseSettingsModels
{
	[Translation(Locales.ru, "Начало отрезка")]
	[Translation(Locales.en, "")]
	[CustomDisplay(2)]
	[Required]
	public double SegmentBeginning { get; set; }

	[Translation(Locales.ru, "Конец отрезка")]
	[Translation(Locales.en, "")]
	[CustomDisplay(3)]
	[Required]
	public double SegmentEnding { get; set; }

	[Translation(Locales.ru, "Скорость")]
	[Translation(Locales.en, "")]
	[CustomDisplay(4)]
	[Required]
	public double SpeedInSegment { get; set; }
	public override object GetDefault()
	{
		return new SpeedLimitChangingModeSettingsModel
		{
			L = 400,
			SegmentBeginning = 100,
			SegmentEnding = 200,
			SpeedInSegment = 5
		};
	}
}