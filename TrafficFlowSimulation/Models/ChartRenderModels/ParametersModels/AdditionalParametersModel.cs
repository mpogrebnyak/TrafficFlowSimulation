using System.ComponentModel.DataAnnotations;
using EvaluationKernel.Models;
using Localization.Localization;
using TrafficFlowSimulation.Models.Attribute;

// ReSharper disable InconsistentNaming

namespace TrafficFlowSimulation.Models.ChartRenderModels.ParametersModels;

public class AdditionalParametersModel : BaseChartRenderModel
{
	[Translation(Locales.ru, "Ускорение свободного\nпадения")]
	[Translation(Locales.en, "Gravitational acceleration")]
	[CustomDisplay(1)]
	[Required, Range(1, 10000)]
	public double g { get; set; }

	[Translation(Locales.ru, "Коэффициент трения,\nскольжения")]
	[Translation(Locales.en, "Friction coefficient")]
	[CustomDisplay(2)]
	[Required, Range(0, 1)]
	public double mu { get; set; }

	public void MapTo(ModelParameters mp)
	{
		mp.g = g;
		mp.mu = mu;
	}

	public override object GetDefault()
	{
		return Default();
	}

	public static AdditionalParametersModel Default()
	{
		return new AdditionalParametersModel
		{
			g = 9.8,
			mu = 0.6
		};
	}
}