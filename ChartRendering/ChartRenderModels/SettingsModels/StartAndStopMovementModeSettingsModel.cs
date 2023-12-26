using ChartRendering.Attribute;
using ChartRendering.Constants;
using Localization.Localization;

namespace ChartRendering.ChartRenderModels.SettingsModels;

// ReSharper disable InconsistentNaming

public class StartAndStopMovementModeSettingsModel : BaseSettingsModels
{
	[Translation(Locales.ru, "Следовать за автомобилем")]
	[CustomDisplay(1, enumType: typeof(AutoScroll))]
	public override EnumItem Scroll { get; set; }

	[Translation(Locales.ru, "Номер автомобиля")]
	[CustomDisplay(2)]
	public override int ScrollFor { get; set; }

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