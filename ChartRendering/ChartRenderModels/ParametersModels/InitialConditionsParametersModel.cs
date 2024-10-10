using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ChartRendering.Attribute;
using ChartRendering.Constants;
using Common;
using EvaluationKernel.Models;
using Localization.Localization;

// ReSharper disable InconsistentNaming

namespace ChartRendering.ChartRenderModels.ParametersModels;

public interface IInitialConditionsParametersModel : IParametersModel
{
	IInitialConditionsParametersModel MapFrom(IBaseParametersModel baseParametersModel, IAdditionalParametersModel additionalParametersModel);
}

public class InitialConditionsParametersModel : ValidationModel, IInitialConditionsParametersModel
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

	public IInitialConditionsParametersModel MapFrom(IBaseParametersModel baseParametersModel, IAdditionalParametersModel additionalParametersModel)
	{
		var bpm = (BaseParametersModel) baseParametersModel;
		var apm = (AdditionalParametersModel) additionalParametersModel;

		lambda_multiple = string.Empty;
		var vn_multiple = CommonParserHelper.ParseMultipleValues(Vn_multiple);
		if (bpm.IsCarsIdentical.Value.Equals(IdenticalCars.No) || vn_multiple.Any())
		{
			var l_car_multiple = CommonParserHelper.ParseMultipleValues(bpm.l_car_multiple);
			var l_safe_multiple = CommonParserHelper.ParseMultipleValues(bpm.l_safe_multiple);
			var tau_multiple = CommonParserHelper.ParseMultipleValues(bpm.tau_multiple);
			var tau_b_multiple = CommonParserHelper.ParseMultipleValues(bpm.tau_b_multiple);

			var distance = 0.0;
			for (var i = 0; i < bpm.n; i++)
			{
				var safeDistance = 0.0;
				safeDistance += l_car_multiple.Any() && l_car_multiple.ContainsKey(i - 1)
					? l_car_multiple[i - 1]
					: i != 0 ? bpm.l_car : 0;

				safeDistance += l_safe_multiple.Any() && l_safe_multiple.ContainsKey(i)
					? i != 0 ? l_safe_multiple[i] : 0
					: i != 0 ? bpm.l_safe : 0;

				var speed = vn_multiple.Any() && vn_multiple.ContainsKey(i)
					? vn_multiple[i]
					: Vn;

				var stopDistance = Math.Pow(speed, 2) / (2 * apm.g * apm.mu);
				stopDistance += tau_multiple.Any() && tau_multiple.ContainsKey(i)
					? speed * tau_multiple[i]
					: speed * bpm.tau;

				stopDistance += tau_b_multiple.Any() && tau_b_multiple.ContainsKey(i)
					? speed * tau_b_multiple[i]
					: speed * bpm.tau_b;

				distance -= stopDistance + safeDistance;
				lambda_multiple += i + ":" + distance + " ";
			}
		}
		else
		{
			if (Vn == 0)
			{
				lambda = bpm.l_car + bpm.l_safe > lambda
					? bpm.l_car + bpm.l_safe
					: lambda;
			}
			else
			{
				var distance = 0.0;
				for (var i = 0; i < bpm.n; i++)
				{
					distance -= i != 0
						? Math.Pow(Vn, 2) / (2 * apm.g * apm.mu) + Vn * (bpm.tau + bpm.tau_b) + bpm.l_car + bpm.l_safe
						: 0;
					lambda_multiple += i + ":" + distance + " ";
				}
			}
		}

		return this;
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
