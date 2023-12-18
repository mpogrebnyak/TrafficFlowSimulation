using System;
using System.ComponentModel.DataAnnotations;
using ChartRendering.Attribute;
using ChartRendering.ChartRenderModels.ParametersModels;
using ChartRendering.Constants;
using ChartRendering.Helpers;
using EvaluationKernel.Models;
using Localization.Localization;

// ReSharper disable InconsistentNaming

namespace ChartRendering.ChartRenderModels;

public interface IBaseParametersModel : IParametersModel
{
}

public class BaseParametersModel : ValidationModel, IBaseParametersModel
{
	[Translation(Locales.ru, "Количество автомобилей")]
	[Translation(Locales.en, "Vehicles number")]
	[CustomDisplay(1)]
	[Required, Range(1, 10000)]
	public virtual int n { get; set; }

	[Translation(Locales.ru, "Все автомобили одинаковы")]
	[Translation(Locales.en, "All vehicles are the same")]
	[CustomDisplay(2, enumType: typeof(IdenticalCars))]
	public virtual EnumItem IsCarsIdentical { get; set; }

	[Translation(Locales.ru, "Максимальная скорость")]
	[Translation(Locales.en, "Maximum speed")]
	[CustomDisplay(3)]
	[Required]
	public virtual double Vmax { get; set; }

	[CustomDisplay(4, true, true)] 
	public virtual string Vmax_multiple { get; set; }

	[Translation(Locales.ru, "Время реакции водителя")]
	[Translation(Locales.en, "Driver's response time")]
	[CustomDisplay(5)]
	[Required]
	public virtual double tau { get; set; }

	[CustomDisplay(6, true, true)] 
	public virtual string tau_multiple { get; set; }

	[Translation(Locales.ru, "Интенсивность разгона")]
	[Translation(Locales.en, "Acceleration intensity")]
	[CustomDisplay(7)]
	[Required]
	public virtual double a { get; set; }

	[CustomDisplay(8, true, true)] 
	public virtual string a_multiple { get; set; }

	[Translation(Locales.ru, "Интенсивность торможения")]
	[Translation(Locales.en, "Deceleration intensity")]
	[CustomDisplay(9)]
	[Required]
	public virtual double q { get; set; }

	[CustomDisplay(10, true, true)] 
	public virtual string q_multiple { get; set; }

	[Translation(Locales.ru, "Безопасное расстояние")]
	[Translation(Locales.en, "Safely Distance")]
	[CustomDisplay(11)]
	[Required]
	public virtual double l_safe { get; set; }

	[CustomDisplay(12, true, true)] 
	public virtual string l_safe_multiple { get; set; }

	[Translation(Locales.ru, "Длина автомобиля")]
	[Translation(Locales.en, "Vehicle length")]
	[CustomDisplay(13)]
	[Required]
	public virtual double l_car { get; set; }

	[CustomDisplay(14, true, true)] 
	public virtual string l_car_multiple { get; set; }

	[Translation(Locales.ru, "Коэффициент плавности")]
	[Translation(Locales.en, "Smoothness coefficient")]
	[CustomDisplay(15)]
	[Required]
	public virtual double k { get; set; }

	[CustomDisplay(16, true, true)] 
	public virtual string k_multiple { get; set; }

	public void MapTo(ModelParameters mp)
	{
		mp.n = n;
		mp.tau = tau;
		mp.tau_b = 0.1;

		switch (IsCarsIdentical.Value)
		{
			case IdenticalCars.Yes:
			{
				for (int i = 0; i < n; i++)
				{
					mp.Vmax.Add(Vmax);
					mp.a.Add(a);
					mp.q.Add(q);
					mp.lSafe.Add(l_safe);
					mp.lCar.Add(l_car);
					mp.k.Add(k);
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
		var vMaxDictionary = ChartRenderModelHelper.ParseMultipleValues(Vmax_multiple);
		var aDictionary = ChartRenderModelHelper.ParseMultipleValues(a_multiple);
		var qDictionary = ChartRenderModelHelper.ParseMultipleValues(q_multiple);
		var lDictionary = ChartRenderModelHelper.ParseMultipleValues(l_safe_multiple);
		var lCarDictionary = ChartRenderModelHelper.ParseMultipleValues(l_car_multiple);
		var kDictionary = ChartRenderModelHelper.ParseMultipleValues(k_multiple);

		for (int i = 0; i < n; i++)
		{
			mp.Vmax.Add(vMaxDictionary.ContainsKey(i) ? vMaxDictionary[i] : Vmax);
			mp.a.Add(aDictionary.ContainsKey(i) ? aDictionary[i] : a);
			mp.q.Add(qDictionary.ContainsKey(i) ? qDictionary[i] : q);
			mp.lSafe.Add(lDictionary.ContainsKey(i) ? lDictionary[i] : l_safe);
			mp.lCar.Add(lCarDictionary.ContainsKey(i) ? lCarDictionary[i] : l_car);
			mp.k.Add(kDictionary.ContainsKey(i) ? kDictionary[i] : k);
		}
	}

	public virtual object GetDefault()
	{
		return Default();
	}

	public static BaseParametersModel Default()
	{
		var defaultAPM = AdditionalParametersModel.Default();

		return new BaseParametersModel
		{
			IsCarsIdentical = new EnumItem(IdenticalCars.Yes),
			n = 2,
			Vmax = 16.7,
			Vmax_multiple = string.Empty,
			tau = 1,
			tau_multiple = string.Empty,
			a = 0.5,
			a_multiple = string.Empty,
			q = Math.Round(1 / (defaultAPM.g * defaultAPM.mu), 2),
			q_multiple = string.Empty,
			l_safe = 1,
			l_safe_multiple = string.Empty,
			l_car = 4,
			l_car_multiple = string.Empty,
			k = 0.5,
			k_multiple = string.Empty
		};
	}
}
