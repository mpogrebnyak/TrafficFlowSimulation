﻿using System.ComponentModel.DataAnnotations;
using EvaluationKernel.Models;
using Localization.Localization;
using TrafficFlowSimulation.Models.Attribute;
using TrafficFlowSimulation.Models.ParametersModels.Constants;
using TrafficFlowSimulation.Windows;
using TrafficFlowSimulation.Windows.CustomControls;

namespace TrafficFlowSimulation.Models.ParametersModels;

public class BasicParametersModel : BaseParametersModel
{
	[Translation(Locales.ru, "Количество автомобилей")]
	[Translation(Locales.en, "Vehicles number")]
	[CustomDisplay(1)]
	[Required, Range(1, 10000)]
	public int n { get; set; }

	[Translation(Locales.ru, "Все автомобили одинаковы")]
	[Translation(Locales.en, "All vehicles are the same")]
	[CustomDisplay(2, enumType: typeof(IdenticalCars))]
	public object IsCarsIdentical { get; set; }

	[Translation(Locales.ru, "Максимальная скорость")]
	[Translation(Locales.en, "Maximum speed")]
	[CustomDisplay(3)]
	[Required]
	public double Vmax { get; set; }

	[CustomDisplay(4, true, true)] 
	public string Vmax_multiple { get; set; }

	[Translation(Locales.ru, "Время реакции водителя")]
	[Translation(Locales.en, "Driver's response time")]
	[CustomDisplay(5)]
	[Required]
	public double tau { get; set; }

	[CustomDisplay(6, true, true)] 
	public string tau_multiple { get; set; }

	[Translation(Locales.ru, "Интенсивность разгона")]
	[Translation(Locales.en, "Acceleration intensity")]
	[CustomDisplay(7)]
	[Required]
	public double a { get; set; }

	[CustomDisplay(8, true, true)] 
	public string a_multiple { get; set; }

	[Translation(Locales.ru, "Интенсивность торможения")]
	[Translation(Locales.en, "Deceleration intensity")]
	[CustomDisplay(9)]
	[Required]
	public double q { get; set; }

	[CustomDisplay(10, true, true)] 
	public string q_multiple { get; set; }

	[Translation(Locales.ru, "Безопасное расстояние")]
	[Translation(Locales.en, "Safely Distance")]
	[CustomDisplay(11)]
	[Required]
	public double l_safe { get; set; }

	[CustomDisplay(12, true, true)] 
	public string l_safe_multiple { get; set; }

	[Translation(Locales.ru, "Длина автомобиля")]
	[Translation(Locales.en, "Vehicle length")]
	[CustomDisplay(13)]
	[Required]
	public double l_car { get; set; }

	[CustomDisplay(14, true, true)] 
	public string l_car_multiple { get; set; }

	[Translation(Locales.ru, "Коэффициент плавности")]
	[Translation(Locales.en, "Smoothness coefficient")]
	[CustomDisplay(15)]
	[Required]
	public double k { get; set; }

	[CustomDisplay(16, true, true)] 
	public string k_multiple { get; set; }

	[Translation(Locales.ru, "Расстояние влияния")]
	[Translation(Locales.en, "Influence distance")]
	[CustomDisplay(17)]
	[Required]
	public double s { get; set; }

	[CustomDisplay(18, true, true)] 
	public string s_multiple { get; set; }

	public override void MapTo(ModelParameters mp)
	{
		mp.n = n;
		mp.tau = tau;

		switch (((ComboBoxItem) IsCarsIdentical).Value)
		{
			case IdenticalCars.Yes:
			{
				for (int i = 0; i < n; i++)
				{
					mp.Vmax.Add(Vmax);
					mp.a.Add(a);
					mp.q.Add(q);
					mp.l.Add(l_safe);
					mp.k.Add(k);
					mp.s.Add(s);
				}

				break;
			}
			case IdenticalCars.No:
			{
				MapMultiple(mp);
				break;
			}
		}
	}

	private void MapMultiple(ModelParameters mp)
	{
		var vMaxDictionary = ParseMultipleValues(Vmax_multiple);
		var aDictionary = ParseMultipleValues(a_multiple);
		var qDictionary = ParseMultipleValues(q_multiple);
		var lDictionary = ParseMultipleValues(l_safe_multiple);
		var kDictionary = ParseMultipleValues(k_multiple);
		var sDictionary = ParseMultipleValues(s_multiple);

		for (int i = 0; i < n; i++)
		{
			mp.Vmax.Add(vMaxDictionary.ContainsKey(i) ? vMaxDictionary[i] : Vmax);
			mp.a.Add(aDictionary.ContainsKey(i) ? aDictionary[i] : a);
			mp.q.Add(qDictionary.ContainsKey(i) ? qDictionary[i] : q);
			mp.l.Add(lDictionary.ContainsKey(i) ? lDictionary[i] : l_safe);
			mp.k.Add(kDictionary.ContainsKey(i) ? kDictionary[i] : k);
			mp.s.Add(sDictionary.ContainsKey(i) ? sDictionary[i] : s);
		}
	}
}