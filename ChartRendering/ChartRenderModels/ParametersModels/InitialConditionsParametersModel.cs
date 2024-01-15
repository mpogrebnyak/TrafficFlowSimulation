using System.ComponentModel.DataAnnotations;
using ChartRendering.Attribute;
using ChartRendering.Helpers;
using Common;
using EvaluationKernel.Equations;
using EvaluationKernel.Models;
using Localization.Localization;

// ReSharper disable InconsistentNaming

namespace ChartRendering.ChartRenderModels.ParametersModels;

public interface IInitialConditionsParametersModel : IParametersModel
{
}

public class InitialConditionsParametersModel : IInitialConditionsParametersModel
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
		var VnDictionary = CommonParserHelper.ParseMultipleValues(Vn_multiple);
		var lambdaDictionary = CommonParserHelper.ParseMultipleValues(lambda_multiple);

		for (var i = 0; i < mp.n; i++)
		{
			mp.Vn.Add(VnDictionary.ContainsKey(i) ? VnDictionary[i] : Vn);
			mp.lambda.Add(lambdaDictionary.ContainsKey(i) ? lambdaDictionary[i] : lambda * -i);
		}
	}

	public virtual object GetDefault()
	{
		return Default();
	}

	public static InitialConditionsParametersModel Default()
	{
		var defaultBPM = BaseParametersModel.Default();

		return new InitialConditionsParametersModel
		{
			lambda = defaultBPM.l_car + defaultBPM.l_safe,
			lambda_multiple = string.Empty,
			Vn = 0,
			Vn_multiple = string.Empty
		};
	}
}
