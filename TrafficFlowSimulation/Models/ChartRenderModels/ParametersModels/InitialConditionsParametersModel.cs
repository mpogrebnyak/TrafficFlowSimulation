using System.ComponentModel.DataAnnotations;
using EvaluationKernel.Models;
using Localization.Localization;
using TrafficFlowSimulation.Models.Attribute;

// ReSharper disable InconsistentNaming

namespace TrafficFlowSimulation.Models.ChartRenderModels.ParametersModels;

public class InitialConditionsParametersModel : BaseChartRenderModel
{
	[Translation(Locales.ru, "Начальные скорости")]
	[Translation(Locales.en, "Initial speeds")]
	[CustomDisplay(1)]
	[Required]
	public double Vn { get; set; }

	[CustomDisplay(2, true)] 
	public string Vn_multiple { get; set; }

	[Translation(Locales.ru, "Начальные положения")]
	[Translation(Locales.en, "Initial positions")]
	[CustomDisplay(3)]
	[Required]
	public double lambda { get; set; }

	[CustomDisplay(4, true)] 
	public string lambda_multiple { get; set; }

	public void MapTo(ModelParameters mp)
	{
		var VnDictionary = ParseMultipleValues(Vn_multiple);
		var lambdaDictionary = ParseMultipleValues(lambda_multiple);

		for (int i = 0; i < mp.n; i++)
		{
			mp.Vn.Add(VnDictionary.ContainsKey(i) ? VnDictionary[i] : Vn);
			mp.lambda.Add(lambdaDictionary.ContainsKey(i) ? lambdaDictionary[i] : lambda * -i);
		}
	}

	public override object GetDefault()
	{
		return Default();
	}

	public static InitialConditionsParametersModel Default()
	{
		return new InitialConditionsParametersModel
		{
			lambda = 25,
			lambda_multiple = string.Empty,
			Vn = 0,
			Vn_multiple = string.Empty
		};
	}
}
