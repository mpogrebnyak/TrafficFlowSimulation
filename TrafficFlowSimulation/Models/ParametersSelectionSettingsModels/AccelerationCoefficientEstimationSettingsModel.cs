using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EvaluationKernel.Models;
using Localization.Localization;
using TrafficFlowSimulation.Models.Attribute;

namespace TrafficFlowSimulation.Models.ParametersSelectionSettingsModels;

public class AccelerationCoefficientEstimationSettingsModel : BaseSettingsModels
{
	[Hidden] 
	public override double L { get; set; }

	[Translation(Locales.ru, "Максимальное значение")]
	[Translation(Locales.en, "Maximum value")]
	[CustomDisplay(1)]
	[Required]
	public double MaxA { get; set; }

	public override void MapTo(ModelParameters mp)
	{
		base.MapTo(mp);
		mp.a = new List<double> {MaxA};
	}

	public override object GetDefault()
	{
		return new AccelerationCoefficientEstimationSettingsModel
		{
			L = 1000,
			MaxA = 1
		};
	}
}