using ChartRendering.Attribute;
using Localization.Localization;
using Microsoft.Build.Framework;

namespace ChartRendering.ChartRenderModels.SettingsModels;

// ReSharper disable InconsistentNaming

public class InliningInFlowModeSettingsModel : BaseSettingsModels
{
	[Hidden] 
	public override double L { get; set; }

	[Translation(Locales.ru, "Номер автомобиля для перестроения")]
	[CustomDisplay(1)]
	[Required]
	public virtual int Number { get; set; }

	[Translation(Locales.ru, "Максимальное расстяоние до перестроения")]
	[CustomDisplay(2)]
	[Required]
	public virtual double Lenght { get; set; }

	public override object GetDefault()
	{
		var bpm = BaseParametersModel.Default();

		return new InliningInFlowModeSettingsModel
		{
			L = 300,
			Number = 1,
			Lenght = 100
		};
	}
}