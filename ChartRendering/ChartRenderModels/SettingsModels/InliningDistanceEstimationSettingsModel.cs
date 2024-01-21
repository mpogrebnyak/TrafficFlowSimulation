using System.Collections.Generic;
using ChartRendering.Attribute;
using ChartRendering.Constants;
using EvaluationKernel.Models;
using Localization.Localization;
using Microsoft.Build.Framework;

// ReSharper disable InconsistentNaming

namespace ChartRendering.ChartRenderModels.SettingsModels;

public class InliningDistanceEstimationSettingsModel : BaseSettingsModels
{
	[Hidden] 
	public override double L { get; set; }

	[Translation(Locales.ru, "Коэффициент плавности")]
	[Translation(Locales.en, "Smoothness coefficient")]
	[CustomDisplay(0)]
	[Required]
	public double k { get; set; }

	[Translation(Locales.ru, "Сохранить картинку в файл")]
	[CustomDisplay(1, enumType: typeof(SaveChart))]
	public EnumItem IsSaveChart { get; set; }

	[Translation(Locales.ru, "Продолжить из файла")]
	[CustomDisplay(2, enumType: typeof(ContinueEvaluate))]
	public EnumItem IsContinueEvaluate { get; set; }

	[Translation(Locales.ru, "Скорость первого\nавтомобиля")]
	[Translation(Locales.en, "First car speed")]
	[CustomDisplay(3, isReadOnly: true)]
	public double FirstCarSpeed { get; set; }

	[Translation(Locales.ru, "Максимальное расстояние\nмежду автомобилями")]
	[Translation(Locales.en, "Maximum distance between cars")]
	[CustomDisplay(4, isReadOnly: true)]
	public double MaximumDistanceBetweenCars { get; set; }

	public override void MapTo(ModelParameters mp)
	{
		mp.L = L;
		mp.Vn = new List<double> {FirstCarSpeed, 0};
		mp.lambda = new List<double> {0, 0};
	}

	public override object GetDefault()
	{
		return new InliningDistanceEstimationSettingsModel
		{
			k = 0.5,
			IsSaveChart = new EnumItem(SaveChart.Yes),
			IsContinueEvaluate = new EnumItem(ContinueEvaluate.Yes),
			L = 1000,
			FirstCarSpeed = 0,
			MaximumDistanceBetweenCars = 100
		};
	}
}