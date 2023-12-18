using System.ComponentModel.DataAnnotations;
using ChartRendering.Attribute;
using Localization.Localization;

// ReSharper disable InconsistentNaming

namespace ChartRendering.ChartRenderModels.SettingsModels;

public class AccelerationCoefficientEstimationSettingsModel : BaseSettingsModels
{
	[Hidden] 
	public override double L { get; set; }

	[Translation(Locales.ru, "Максимальное значение")]
	[Translation(Locales.en, "Maximum value")]
	[CustomDisplay(1)]
	[Required]
	public double MaxA { get; set; }

	[Translation(Locales.ru, "Минимальное время разгона")]
	[Translation(Locales.en, "Minimum acceleration time")]
	[CustomDisplay(2)]
	[Required]
	public double MinTime { get; set; }

	[Translation(Locales.ru, "Максимальное время разгона")]
	[Translation(Locales.en, "Maximum acceleration time")]
	[CustomDisplay(3)]
	[Required]
	public double MaxTime { get; set; }

	public override object GetDefault()
	{
		return new AccelerationCoefficientEstimationSettingsModel
		{
			L = 1000,
			MaxA = 1,
			MinTime = 5,
			MaxTime = 15
		};
	}
}