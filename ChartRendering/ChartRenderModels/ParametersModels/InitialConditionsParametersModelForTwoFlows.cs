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

public class InitialConditionsParametersModelForTwoFlows : ValidationModel, IInitialConditionsParametersModel
{
	[Translation(Locales.ru, "Первый поток")]
	[Translation(Locales.en, "")]
	[CustomDisplay(0, isHeader: true)] 
	public virtual string FirstFlowHeader { get; set; }

	[Translation(Locales.ru, "Начальные скорости")]
	[Translation(Locales.en, "Initial speeds")]
	[CustomDisplay(1)]
	[Required]
	public double n_Vn { get; set; }

	[CustomDisplay(2, true)] 
	public string n_Vn_multiple { get; set; }

	[Translation(Locales.ru, "Начальные положения")]
	[Translation(Locales.en, "Initial positions")]
	[CustomDisplay(3)]
	[Required]
	public double n_lambda { get; set; }

	[CustomDisplay(4, true)] 
	public string n_lambda_multiple { get; set; }

	[Translation(Locales.ru, "Второй поток")]
	[Translation(Locales.en, "")]
	[CustomDisplay(5, isHeader: true)] 
	public virtual string SecondFlowHeader { get; set; }

	[Translation(Locales.ru, "Начальные скорости")]
	[Translation(Locales.en, "Initial speeds")]
	[CustomDisplay(6)]
	[Required]
	public double m_Vn { get; set; }

	[CustomDisplay(7, true)] 
	public string m_Vn_multiple { get; set; }

	[Translation(Locales.ru, "Начальные положения")]
	[Translation(Locales.en, "Initial positions")]
	[CustomDisplay(8)]
	[Required]
	public double m_lambda { get; set; }

	[CustomDisplay(9, true)] 
	public string m_lambda_multiple { get; set; }

	public void MapTo(ModelParameters mp)
	{
		var n_VnDictionary = CommonParserHelper.ParseMultipleValues(n_Vn_multiple);
		var n_lambdaDictionary = CommonParserHelper.ParseMultipleValues(n_lambda_multiple);

		for (var i = 0; i < mp.n1; i++)
		{
			mp.Vn.Add(n_VnDictionary.ContainsKey(i) ? n_VnDictionary[i] : n_Vn);
			mp.lambda.Add(n_lambdaDictionary.ContainsKey(i) ? n_lambdaDictionary[i] : n_lambda * -i);
		}

		var m_VnDictionary = CommonParserHelper.ParseMultipleValues(m_Vn_multiple);
		var m_lambdaDictionary = CommonParserHelper.ParseMultipleValues(m_lambda_multiple);

		for (var i = 0; i < mp.n2; i++)
		{
			mp.Vn.Add(m_VnDictionary.ContainsKey(i) ? m_VnDictionary[i] : m_Vn);
			mp.lambda.Add(m_lambdaDictionary.ContainsKey(i) ? m_lambdaDictionary[i] : m_lambda * -i);
		}
	}

	public IInitialConditionsParametersModel MapFrom(IBaseParametersModel baseParametersModel, IAdditionalParametersModel additionalParametersModel)
	{
		var bpm = (BaseParametersModelForTwoFlows) baseParametersModel;
		var apm = (AdditionalParametersModel) additionalParametersModel;

		var n_vn_multiple = CommonParserHelper.ParseMultipleValues(n_Vn_multiple);
		if (bpm.IsCarsIdentical.Value.Equals(IdenticalCars.No) || n_vn_multiple.Any())
		{
			var n_l_car_multiple = CommonParserHelper.ParseMultipleValues(bpm.n_l_car_multiple);
			var n_l_safe_multiple = CommonParserHelper.ParseMultipleValues(bpm.n_l_safe_multiple);
			var n_tau_multiple = CommonParserHelper.ParseMultipleValues(bpm.n_tau_multiple);
			var n_tau_b_multiple = CommonParserHelper.ParseMultipleValues(bpm.n_tau_b_multiple);

			n_lambda_multiple = string.Empty;
			var distance = 0.0;
			for (var i = 0; i < bpm.n1; i++)
			{
				var safeDistance = 0.0;
				safeDistance += n_l_car_multiple.Any() && n_l_car_multiple.ContainsKey(i - 1)
					? n_l_car_multiple[i - 1]
					: i != 0 ? bpm.n_l_car : 0;

				safeDistance += n_l_safe_multiple.Any() && n_l_safe_multiple.ContainsKey(i)
					? i != 0 ? n_l_safe_multiple[i] : 0
					: i != 0 ? bpm.n_l_safe : 0;

				var speed = n_vn_multiple.Any() && n_vn_multiple.ContainsKey(i)
					? n_vn_multiple[i]
					: n_Vn;

				var stopDistance = Math.Pow(speed, 2) / (2 * apm.g * apm.mu);
				stopDistance += n_tau_multiple.Any() && n_tau_multiple.ContainsKey(i)
					? speed * n_tau_multiple[i]
					: speed * bpm.n_tau;

				stopDistance += n_tau_b_multiple.Any() && n_tau_b_multiple.ContainsKey(i)
					? speed * n_tau_b_multiple[i]
					: speed * bpm.n_tau_b;

				distance -= stopDistance + safeDistance;
				n_lambda_multiple += i + ":" + distance + " ";
			}
		}
		else
		{
			n_lambda = bpm.n_l_car + bpm.n_l_safe;
		}

		var m_vn_multiple = CommonParserHelper.ParseMultipleValues(m_Vn_multiple);
		if (bpm.IsCarsIdentical.Value.Equals(IdenticalCars.No) || m_vn_multiple.Any())
		{
			var m_l_car_multiple = CommonParserHelper.ParseMultipleValues(bpm.m_l_car_multiple);
			var m_l_safe_multiple = CommonParserHelper.ParseMultipleValues(bpm.m_l_safe_multiple);
			var m_tau_multiple = CommonParserHelper.ParseMultipleValues(bpm.m_tau_multiple);
			var m_tau_b_multiple = CommonParserHelper.ParseMultipleValues(bpm.m_tau_b_multiple);

			m_lambda_multiple = string.Empty;
			var distance = 0.0;
			for (var i = 0; i < bpm.n2; i++)
			{
				var safeDistance = 0.0;
				safeDistance += m_l_car_multiple.Any() && m_l_car_multiple.ContainsKey(i - 1)
					? m_l_car_multiple[i - 1]
					: i != 0 ? bpm.m_l_car : 0;

				safeDistance += m_l_safe_multiple.Any() && m_l_safe_multiple.ContainsKey(i)
					? i != 0 ? m_l_safe_multiple[i] : 0
					: i != 0 ? bpm.m_l_safe : 0;

				var speed = m_vn_multiple.Any() && m_vn_multiple.ContainsKey(i)
					? m_vn_multiple[i]
					: m_Vn;

				var stopDistance = Math.Pow(speed, 2) / (2 * apm.g * apm.mu);
				stopDistance += m_tau_multiple.Any() && m_tau_multiple.ContainsKey(i)
					? speed * m_tau_multiple[i]
					: speed * bpm.m_tau;

				stopDistance += m_tau_b_multiple.Any() && m_tau_b_multiple.ContainsKey(i)
					? speed * m_tau_b_multiple[i]
					: speed * bpm.m_tau_b;

				distance -= stopDistance + safeDistance;
				m_lambda_multiple += i + ":" + distance + " ";
			}
		}
		else
		{
			m_lambda = bpm.m_l_car + bpm.m_l_safe;
		}

		return this;
	}

	public virtual object GetDefault()
	{
		return Default();
	}

	public static InitialConditionsParametersModelForTwoFlows Default()
	{
		var defaultBPM = BaseParametersModelForTwoFlows.Default();

		return new InitialConditionsParametersModelForTwoFlows
		{
			n_lambda = defaultBPM.n_l_car + defaultBPM.n_l_safe,
			n_lambda_multiple = string.Empty,
			n_Vn = 0,
			n_Vn_multiple = string.Empty,

			m_lambda = defaultBPM.m_l_car + defaultBPM.m_l_safe,
			m_lambda_multiple = string.Empty,
			m_Vn = 0,
			m_Vn_multiple = string.Empty
		};
	}
}
