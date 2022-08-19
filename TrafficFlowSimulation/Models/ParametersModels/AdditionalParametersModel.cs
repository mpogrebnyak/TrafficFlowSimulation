using System.ComponentModel.DataAnnotations;
using EvaluationKernel.Models;
using Localization.Localization;
using TrafficFlowSimulation.Models.Attribute;

namespace TrafficFlowSimulation.Models.ParametersModels;

public class AdditionalParametersModel : BaseParametersModel
{
	[Translation(Locales.ru, "Ускорение свободного падения")]
	[Translation(Locales.en, "Gravitational acceleration")]
	[CustomDisplay(1)]
	[Required, Range(1, 10000)]
	public double g { get; set; }

	[Translation(Locales.ru, "Коэффициент трения")]
	[Translation(Locales.en, "Friction coefficient")]
	[CustomDisplay(2)]
	[Required, Range(0, 1)]
	public double mu { get; set; }

	public override void MapTo(ModelParameters mp)
	{
		mp.g = g;
		mp.mu = mu;
	}
}