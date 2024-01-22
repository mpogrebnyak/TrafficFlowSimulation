using ChartRendering.Attribute;
using Localization.Localization;
using Microsoft.Build.Framework;

namespace ChartRendering.ChartRenderModels.SettingsModels;

// ReSharper disable InconsistentNaming

public class InliningInFlowModeSettingsModel : BaseSettingsModels
{
	[Hidden] 
	public override double L { get; set; }

	[Translation(Locales.ru, "Максимальная скорость")]
	[Translation(Locales.en, "Maximum speed")]
	[CustomDisplay(1)]
	[Required]
	public virtual double Vmax { get; set; }

	[Translation(Locales.ru, "Интенсивность разгона")]
	[Translation(Locales.en, "Acceleration intensity")]
	[CustomDisplay(2)]
	[Required]
	public virtual double a { get; set; }

	[Translation(Locales.ru, "Интенсивность торможения")]
	[Translation(Locales.en, "Deceleration intensity")]
	[CustomDisplay(3)]
	[Required]
	public virtual double q { get; set; }

	[Translation(Locales.ru, "Безопасное расстояние")]
	[Translation(Locales.en, "Safely Distance")]
	[CustomDisplay(4)]
	[Required]
	public virtual double l_safe { get; set; }

	[Translation(Locales.ru, "Длина автомобиля")]
	[Translation(Locales.en, "Vehicle length")]
	[CustomDisplay(5)]
	[Required]
	public virtual double l_car { get; set; }

	[Translation(Locales.ru, "Коэффициент плавности")]
	[Translation(Locales.en, "Smoothness coefficient")]
	[CustomDisplay(6)]
	[Required]
	public virtual double k { get; set; }

	public override object GetDefault()
	{
		var bpm = BaseParametersModel.Default();

		return new InliningInFlowModeSettingsModel
		{
			L = 10000,
			Vmax = bpm.Vmax,
			a = bpm.a,
			k = bpm.k,
			l_car = bpm.l_car,
			l_safe = bpm.l_safe,
			q = bpm.q
		};
	}
}