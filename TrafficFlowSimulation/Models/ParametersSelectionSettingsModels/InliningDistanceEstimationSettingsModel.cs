using System.Collections.Generic;
using EvaluationKernel.Models;
using Localization.Localization;
using TrafficFlowSimulation.Models.Attribute;

namespace TrafficFlowSimulation.Models.ParametersSelectionSettingsModels;

public class InliningDistanceEstimationSettingsModel : BaseSettingsModels
{
	[Hidden] 
	public override double L { get; set; }

	[Translation(Locales.ru, "Скорость первого\nавтомобиля")]
	[Translation(Locales.en, "First car speed")]
	[CustomDisplay(1, isReadOnly: true)]
	public double FirstCarSpeed { get; set; }
	
	[Translation(Locales.ru, "Максимальное расстояние\nмежду автомобилями")]
	[Translation(Locales.en, "Maximum distance between cars")]
	[CustomDisplay(1, isReadOnly: true)]
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
			L = 1000,
			FirstCarSpeed = 0,
			MaximumDistanceBetweenCars = 60
		};
	}
}