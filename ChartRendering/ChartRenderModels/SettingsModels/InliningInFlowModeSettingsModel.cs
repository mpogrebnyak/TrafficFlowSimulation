using ChartRendering.Attribute;
using ChartRendering.Constants;
using Localization.Localization;
using Microsoft.Build.Framework;

namespace ChartRendering.ChartRenderModels.SettingsModels;

// ReSharper disable InconsistentNaming

public class InliningInFlowModeSettingsModel : BaseSettingsModels
{
	[Hidden] 
	public override double L { get; set; }

	[Translation(Locales.ru, "Номер автомобиля\nдля перестроения")]
	[CustomDisplay(1)]
	[Required]
	public virtual int Number { get; set; }

	[Translation(Locales.ru, "Максимальное расстяоние\nдо перестроения")]
	[CustomDisplay(2)]
	[Required]
	public virtual double Lenght { get; set; }

	[Translation(Locales.ru, "Перестроение всего потока")]
	[CustomDisplay(3, enumType: typeof(AllCarsChangeLine))]
	[Required]
	public virtual EnumItem IsAllCarsChangeLine { get; set; }

	public override object GetDefault()
	{
		return new InliningInFlowModeSettingsModel
		{
			L = 500,
			Number = 1,
			Lenght = 100,
			IsAllCarsChangeLine = new EnumItem(AllCarsChangeLine.No)
		};
	}
}