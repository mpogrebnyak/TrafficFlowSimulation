using System.ComponentModel.DataAnnotations;
using EvaluationKernel.Models;
using Localization.Localization;

namespace TrafficFlowSimulation.Models;

public class EditAdditionalModelParameters : EditModelParameters
{
	[Translation(Locales.ru, "123")]
	[Translation(Locales.en, "321")]
	[CustomDisplayAttribute(1)]
	[Required, Range(1, 10000)]
	public double g { get; set; }

	[Translation(Locales.ru, "7777")]
	[Translation(Locales.en, "88888")]
	[CustomDisplayAttribute(2)]
	[Required, Range(0, 1)]
	public double mu { get; set; }

	public void MapTo(ModelParameters mp)
	{
		mp.g = g;
		mp.mu = mu;
	}
}