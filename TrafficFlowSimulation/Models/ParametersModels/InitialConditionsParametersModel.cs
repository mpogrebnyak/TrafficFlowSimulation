using System.ComponentModel.DataAnnotations;
using EvaluationKernel.Models;
using Localization.Localization;

namespace TrafficFlowSimulation.Models.ParametersModels;

public class InitialConditionsParametersModel : BaseParametersModel
{
	[Translation(Locales.ru, "Нчальные скорости")]
	[Translation(Locales.en, "Initial speeds")]
	[CustomDisplayAttribute(1)]
	[Required]
	public double Vn { get; set; }

	[CustomDisplayAttribute(2, true)] 
	public string Vn_multiple { get; set; }

	[Translation(Locales.ru, "Начальные положения")]
	[Translation(Locales.en, "Initial positions")]
	[CustomDisplayAttribute(3)]
	[Required]
	public double lambda { get; set; }

	[CustomDisplayAttribute(4, true)] 
	public string lambda_multiple { get; set; }

	public override void MapTo(ModelParameters mp)
	{
		var VnDictionary = ParseMultipleValues(Vn_multiple);
		var lambdaDictionary = ParseMultipleValues(lambda_multiple);

		for (int i = 0; i < mp.n; i++)
		{
			mp.Vn.Add(VnDictionary.ContainsKey(i) ? VnDictionary[i] : Vn);
			mp.lambda.Add(lambdaDictionary.ContainsKey(i) ? lambdaDictionary[i] : lambda * -i);
		}
	}
}
