using System.ComponentModel.DataAnnotations;
using EvaluationKernel.Models;
using Localization.Localization;
using TrafficFlowSimulation.Models.Attribute;

namespace TrafficFlowSimulation.Models.ParametersModels;

public class InitialConditionsParametersModel : BaseParametersModel
{
	[Translation(Locales.ru, "Нчальные скорости")]
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
