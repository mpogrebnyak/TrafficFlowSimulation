using System;
using System.ComponentModel.DataAnnotations;
using ChartRendering.Attribute;
using ChartRendering.ChartRenderModels.ParametersModels;
using ChartRendering.Constants;
using ChartRendering.Helpers;
using Common;
using EvaluationKernel.Models;
using Localization.Localization;

// ReSharper disable InconsistentNaming

namespace ChartRendering.ChartRenderModels;

public class BaseParametersModelForTwoFlows : ValidationModel, IBaseParametersModel
{
	[Translation(Locales.ru, "Все автомобили одинаковы")]
	[Translation(Locales.en, "All vehicles are the same")]
	[CustomDisplay(0, enumType: typeof(IdenticalCars))]
	public virtual EnumItem IsCarsIdentical { get; set; }

	[Translation(Locales.ru, "Первый поток")]
	[Translation(Locales.en, "")]
	[CustomDisplay(1, isHeader: true)] 
	public virtual string FirstFlowHeader { get; set; }

	[Translation(Locales.ru, "Количество автомобилей")]
	[Translation(Locales.en, "Vehicles number")]
	[CustomDisplay(1)]
	[Required, Range(2, 1000)]
	[RandomAttribute(noRandomGeneration: true)]
	public virtual int n1 { get; set; }

	[Translation(Locales.ru, "Максимальная скорость")]
	[Translation(Locales.en, "Maximum speed")]
	[CustomDisplay(3)]
	[Required, Range(1, 55)]
	[Random(16, 16.7)]
	public virtual double n_Vmax { get; set; }

	[CustomDisplay(4, true, true)] 
	public virtual string n_Vmax_multiple { get; set; }

	[Translation(Locales.ru, "Время реакции водителя")]
	[Translation(Locales.en, "Driver's response time")]
	[CustomDisplay(5)]
	[Required, Range(0.2, 2)]
	[Random(0.2, 0.6)]
	public virtual double n_tau { get; set; }

	[CustomDisplay(6, true, true)] 
	public virtual string n_tau_multiple { get; set; }

	[Translation(Locales.ru, "Время срабатывания\nтормозной системы")]
	[CustomDisplay(7)]
	[Required, Range(0.1, 0.3)]
	[Random(0.2, 0.3)]
	public virtual double n_tau_b { get; set; }

	[CustomDisplay(8, true, true)] 
	public virtual string n_tau_b_multiple { get; set; }

	[Translation(Locales.ru, "Интенсивность разгона")]
	[Translation(Locales.en, "Acceleration intensity")]
	[CustomDisplay(9)]
	[Required, Range(0.31, 0.92)]
	[Random(0.31, 0.92)]
	public virtual double n_a { get; set; }

	[CustomDisplay(10, true, true)] 
	public virtual string n_a_multiple { get; set; }

	[Translation(Locales.ru, "Интенсивность торможения")]
	[Translation(Locales.en, "Deceleration intensity")]
	[CustomDisplay(11)]
	[Required, Range(0.14, 0.17)]
	[Random(0.14, 0.17)]
	public virtual double n_q { get; set; }

	[CustomDisplay(12, true, true)] 
	public virtual string n_q_multiple { get; set; }

	[Translation(Locales.ru, "Безопасное расстояние")]
	[Translation(Locales.en, "Safely Distance")]
	[CustomDisplay(13)]
	[Required, Range(1, 2)]
	[Random(1, 2)]
	public virtual double n_l_safe { get; set; }

	[CustomDisplay(14, true, true)] 
	public virtual string n_l_safe_multiple { get; set; }

	[Translation(Locales.ru, "Длина автомобиля")]
	[Translation(Locales.en, "Vehicle length")]
	[CustomDisplay(15)]
	[Required, Range(3, 8)]
	[Random(3, 5)]
	public virtual double n_l_car { get; set; }

	[CustomDisplay(16, true, true)] 
	public virtual string n_l_car_multiple { get; set; }

	[Translation(Locales.ru, "Коэффициент плавности")]
	[Translation(Locales.en, "Smoothness coefficient")]
	[CustomDisplay(17)]
	[Required, Range(0.4, 0.5)]
	[Random(0.4, 0.5)]
	public virtual double n_k { get; set; }

	[CustomDisplay(18, true, true)] 
	public virtual string n_k_multiple { get; set; }

	[Translation(Locales.ru, "Второй поток")]
	[Translation(Locales.en, "")]
	[CustomDisplay(19, isHeader: true)] 
	public virtual string SecondFlowHeader { get; set; }

	[Translation(Locales.ru, "Количество автомобилей")]
	[Translation(Locales.en, "Vehicles number")]
	[CustomDisplay(20)]
	[Required, Range(2, 1000)]
	[RandomAttribute(noRandomGeneration: true)]
	public virtual int n2 { get; set; }

	[Translation(Locales.ru, "Максимальная скорость")]
	[Translation(Locales.en, "Maximum speed")]
	[CustomDisplay(21)]
	[Required, Range(1, 55)]
	[Random(16, 16.7)]
	public virtual double m_Vmax { get; set; }

	[CustomDisplay(22, true, true)] 
	public virtual string m_Vmax_multiple { get; set; }

	[Translation(Locales.ru, "Время реакции водителя")]
	[Translation(Locales.en, "Driver's response time")]
	[CustomDisplay(23)]
	[Required, Range(0.2, 2)]
	[Random(0.2, 0.6)]
	public virtual double m_tau { get; set; }

	[CustomDisplay(24, true, true)] 
	public virtual string m_tau_multiple { get; set; }

	[Translation(Locales.ru, "Время срабатывания\nтормозной системы")]
	[CustomDisplay(25)]
	[Required, Range(0.1, 0.3)]
	[Random(0.2, 0.3)]
	public virtual double m_tau_b { get; set; }

	[CustomDisplay(26, true, true)] 
	public virtual string m_tau_b_multiple { get; set; }

	[Translation(Locales.ru, "Интенсивность разгона")]
	[Translation(Locales.en, "Acceleration intensity")]
	[CustomDisplay(27)]
	[Required, Range(0.31, 0.92)]
	[Random(0.31, 0.92)]
	public virtual double m_a { get; set; }

	[CustomDisplay(28, true, true)] 
	public virtual string m_a_multiple { get; set; }

	[Translation(Locales.ru, "Интенсивность торможения")]
	[Translation(Locales.en, "Deceleration intensity")]
	[CustomDisplay(29)]
	[Required, Range(0.14, 0.17)]
	[Random(0.14, 0.17)]
	public virtual double m_q { get; set; }

	[CustomDisplay(30, true, true)] 
	public virtual string m_q_multiple { get; set; }

	[Translation(Locales.ru, "Безопасное расстояние")]
	[Translation(Locales.en, "Safely Distance")]
	[CustomDisplay(31)]
	[Required, Range(1, 2)]
	[Random(1, 2)]
	public virtual double m_l_safe { get; set; }

	[CustomDisplay(32, true, true)] 
	public virtual string m_l_safe_multiple { get; set; }

	[Translation(Locales.ru, "Длина автомобиля")]
	[Translation(Locales.en, "Vehicle length")]
	[CustomDisplay(33)]
	[Required, Range(3, 8)]
	[Random(3, 5)]
	public virtual double m_l_car { get; set; }

	[CustomDisplay(34, true, true)] 
	public virtual string m_l_car_multiple { get; set; }

	[Translation(Locales.ru, "Коэффициент плавности")]
	[Translation(Locales.en, "Smoothness coefficient")]
	[CustomDisplay(35)]
	[Required, Range(0.4, 0.5)]
	[Random(0.4, 0.5)]
	public virtual double m_k { get; set; }

	[CustomDisplay(36, true, true)] 
	public virtual string m_k_multiple { get; set; }

	public void MapTo(ModelParameters mp)
	{
		mp.n = n1 + n2;
		mp.n1 = n1;
		mp.n2 = n2;

		switch (IsCarsIdentical.Value)
		{
			case IdenticalCars.Yes:
			{
				for (var i = 0; i < n1; i++)
				{
					mp.tau.Add(n_tau);
					mp.tau_b.Add(n_tau_b);
					mp.Vmax.Add(n_Vmax);
					mp.a.Add(n_a);
					mp.q.Add(n_q);
					mp.lSafe.Add(n_l_safe);
					mp.lCar.Add(n_l_car);
					mp.k.Add(n_k);
				}
				
				for (var i = 0; i < n2; i++)
				{
					mp.tau.Add(m_tau);
					mp.tau_b.Add(m_tau_b);
					mp.Vmax.Add(m_Vmax);
					mp.a.Add(m_a);
					mp.q.Add(m_q);
					mp.lSafe.Add(m_l_safe);
					mp.lCar.Add(m_l_car);
					mp.k.Add(m_k);
				}

				break;
			}
			case IdenticalCars.No:
			{
				n_MapMultiple(mp);
				m_MapMultiple(mp);
				break;
			}
		}
	}

	private void n_MapMultiple(ModelParameters mp)
	{
		var n_vMaxDictionary = CommonParserHelper.ParseMultipleValues(n_Vmax_multiple);
		var n_aDictionary = CommonParserHelper.ParseMultipleValues(n_a_multiple);
		var n_qDictionary = CommonParserHelper.ParseMultipleValues(n_q_multiple);
		var n_lDictionary = CommonParserHelper.ParseMultipleValues(n_l_safe_multiple);
		var n_lCarDictionary = CommonParserHelper.ParseMultipleValues(n_l_car_multiple);
		var n_kDictionary = CommonParserHelper.ParseMultipleValues(n_k_multiple);
		var n_tauDictionary = CommonParserHelper.ParseMultipleValues(n_tau_multiple);
		var n_tau_bDictionary = CommonParserHelper.ParseMultipleValues(n_tau_b_multiple);

		for (var i = 0; i < n1; i++)
		{
			mp.Vmax.Add(n_vMaxDictionary.ContainsKey(i) ? n_vMaxDictionary[i] : n_Vmax);
			mp.a.Add(n_aDictionary.ContainsKey(i) ? n_aDictionary[i] : n_a);
			mp.q.Add(n_qDictionary.ContainsKey(i) ? n_qDictionary[i] : n_q);
			mp.lSafe.Add(n_lDictionary.ContainsKey(i) ? n_lDictionary[i] : n_l_safe);
			mp.lCar.Add(n_lCarDictionary.ContainsKey(i) ? n_lCarDictionary[i] : n_l_car);
			mp.k.Add(n_kDictionary.ContainsKey(i) ? n_kDictionary[i] : n_k);
			mp.tau.Add(n_tauDictionary.ContainsKey(i) ? n_tauDictionary[i] : n_tau);
			mp.tau_b.Add(n_tau_bDictionary.ContainsKey(i) ? n_tau_bDictionary[i] : n_tau_b);
		}
	}

	private void m_MapMultiple(ModelParameters mp)
	{
		var m_vMaxDictionary = CommonParserHelper.ParseMultipleValues(m_Vmax_multiple);
		var m_aDictionary = CommonParserHelper.ParseMultipleValues(m_a_multiple);
		var m_qDictionary = CommonParserHelper.ParseMultipleValues(m_q_multiple);
		var m_lDictionary = CommonParserHelper.ParseMultipleValues(m_l_safe_multiple);
		var m_lCarDictionary = CommonParserHelper.ParseMultipleValues(m_l_car_multiple);
		var m_kDictionary = CommonParserHelper.ParseMultipleValues(m_k_multiple);
		var m_tauDictionary = CommonParserHelper.ParseMultipleValues(m_tau_multiple);
		var m_tau_bDictionary = CommonParserHelper.ParseMultipleValues(m_tau_b_multiple);

		for (var i = 0; i < n1; i++)
		{
			mp.Vmax.Add(m_vMaxDictionary.ContainsKey(i) ? m_vMaxDictionary[i] : m_Vmax);
			mp.a.Add(m_aDictionary.ContainsKey(i) ? m_aDictionary[i] : m_a);
			mp.q.Add(m_qDictionary.ContainsKey(i) ? m_qDictionary[i] : m_q);
			mp.lSafe.Add(m_lDictionary.ContainsKey(i) ? m_lDictionary[i] : m_l_safe);
			mp.lCar.Add(m_lCarDictionary.ContainsKey(i) ? m_lCarDictionary[i] : m_l_car);
			mp.k.Add(m_kDictionary.ContainsKey(i) ? m_kDictionary[i] : m_k);
			mp.tau.Add(m_tauDictionary.ContainsKey(i) ? m_tauDictionary[i] : m_tau);
			mp.tau_b.Add(m_tau_bDictionary.ContainsKey(i) ? m_tau_bDictionary[i] : m_tau_b);
		}
	}

	public virtual object GetDefault()
	{
		return Default();
	}

	public object GetRandomValues()
	{
		var defaultBPM = Default();
		defaultBPM.IsCarsIdentical = new EnumItem(IdenticalCars.No);
		defaultBPM.n1 = 10;
		defaultBPM.n2 = 5;
		defaultBPM = ChartRenderModelHelper.CreateModelWithRandomValues(defaultBPM, defaultBPM.n1);
		defaultBPM = ChartRenderModelHelper.CreateModelWithRandomValues(defaultBPM, defaultBPM.n2);

		return defaultBPM;
	}

	public static BaseParametersModelForTwoFlows Default()
	{
		var defaultAPM = AdditionalParametersModel.Default();

		return new BaseParametersModelForTwoFlows
		{
			IsCarsIdentical = new EnumItem(IdenticalCars.Yes),
			n1 = 2,
			n_Vmax = 16.7,
			n_Vmax_multiple = string.Empty,
			n_tau = 0.5,
			n_tau_multiple = string.Empty,
			n_tau_b = 0.1,
			n_tau_b_multiple = string.Empty,
			n_a = 0.5,
			n_a_multiple = string.Empty,
			n_q = Math.Round(1 / (defaultAPM.g * defaultAPM.mu), 2),
			n_q_multiple = string.Empty,
			n_l_safe = 1,
			n_l_safe_multiple = string.Empty,
			n_l_car = 4,
			n_l_car_multiple = string.Empty,
			n_k = 0.5,
			n_k_multiple = string.Empty,

			n2 = 3,
			m_Vmax = 16.7,
			m_Vmax_multiple = string.Empty,
			m_tau = 0.5,
			m_tau_multiple = string.Empty,
			m_tau_b = 0.1,
			m_tau_b_multiple = string.Empty,
			m_a = 0.5,
			m_a_multiple = string.Empty,
			m_q = Math.Round(1 / (defaultAPM.g * defaultAPM.mu), 2),
			m_q_multiple = string.Empty,
			m_l_safe = 1,
			m_l_safe_multiple = string.Empty,
			m_l_car = 4,
			m_l_car_multiple = string.Empty,
			m_k = 0.5,
			m_k_multiple = string.Empty,
		};
	}
}
