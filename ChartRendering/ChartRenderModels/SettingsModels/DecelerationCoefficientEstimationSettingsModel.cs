using System.ComponentModel.DataAnnotations;
using ChartRendering.Attribute;
using ChartRendering.Constants;
using EvaluationKernel.Models;
using Localization.Localization;

// ReSharper disable InconsistentNaming

namespace ChartRendering.ChartRenderModels.SettingsModels;

public class DecelerationCoefficientEstimationSettingsModel : BaseSettingsModels
{
	[Hidden] 
	public override double L { get; set; }

	[Translation(Locales.ru, "Сохранить картинку в файл")]
	[CustomDisplay(1, enumType: typeof(SaveChart))]
	public EnumItem IsSaveChart { get; set; }

	[Translation(Locales.ru, "Максимальное значение")]
	[Translation(Locales.en, "Maximum value")]
	[CustomDisplay(2)]
	[Required]
	public double MaxQ { get; set; }
	
	public override void MapTo(ModelParameters mp)
	{
	}

	public override object GetDefault()
	{
		return new DecelerationCoefficientEstimationSettingsModel
		{
			IsSaveChart = new EnumItem(SaveChart.Yes),
			MaxQ = 0.2
		};
	}
}