﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ChartRendering.Attribute;
using ChartRendering.Constants;
using EvaluationKernel.Models;
using Localization.Localization;

// ReSharper disable InconsistentNaming

namespace ChartRendering.ChartRenderModels.ParametersModels;

public class DecelerationCoefficientEstimationModelParametersModel : BaseParametersModel
{
	[Translation(Locales.ru, "Количество автомобилей")]
	[Translation(Locales.en, "Vehicles number")]
	[CustomDisplay(1, isReadOnly: true)]
	[Required, Range(1, 10000)]
	public override int n { get; set; }

	[Translation(Locales.ru, "Максимальная скорость")]
	[Translation(Locales.en, "Maximum speed")]
	[CustomDisplay(2, isReadOnly: true)]
	[Required]
	public override double Vmax { get; set; }

	[Translation(Locales.ru, "Ускорение свободного падения")]
	[Translation(Locales.en, "Gravitational acceleration")]
	[CustomDisplay(3, isReadOnly: true)]
	[Required, Range(1, 10000)]
	public double g { get; set; }

	[Translation(Locales.ru, "Коэффициент трения")]
	[Translation(Locales.en, "Friction coefficient")]
	[CustomDisplay(4, isReadOnly: true)]
	[Required, Range(0, 1)]
	public double mu { get; set; }

	[Hidden]
	public override EnumItem IsCarsIdentical { get; set; }

	[Hidden]
	public override string Vmax_multiple { get; set; }

	[Hidden]
	public override double tau { get; set; }

	[Hidden]
	public override string tau_multiple { get; set; }

	[Hidden]
	public override double tau_b { get; set; }

	[Hidden]
	public override string tau_b_multiple { get; set; }

	[Hidden]
	public override double a { get; set; }

	[Hidden]
	public override string a_multiple { get; set; }

	[Hidden]
	public override double q { get; set; }

	[Hidden]
	public override string q_multiple { get; set; }

	[Translation(Locales.ru, "Безопасное расстояние")]
	[Translation(Locales.en, "Safely Distance")]
	[CustomDisplay(5, isReadOnly: true)]
	[Required]
	public override double l_safe { get; set; }

	[Hidden]
	public override string l_safe_multiple { get; set; }

	[Hidden]
	public override double l_car { get; set; }

	[Hidden] 
	public override string l_car_multiple { get; set; }

	[Hidden]
	public override double k { get; set; }

	[Hidden]
	public override string k_multiple { get; set; }

	public new void MapTo(ModelParameters mp)
	{
		base.MapTo(mp);
		mp.g = g;
		mp.mu = mu;
		mp.Vn = mp.Vmax;
		mp.lambda = new List<double> { 0 };
		// добавка 0.1 нужна, чтобы в уравнении знаменатель не менял знак
		mp.L = Math.Pow(mp.Vmax[0], 2) / (2 * mp.g * mp.mu) + 0.1;
		mp.Vmax = null;
	}

	public override object GetDefault()
	{
		return new DecelerationCoefficientEstimationModelParametersModel
		{
			IsCarsIdentical = new EnumItem(IdenticalCars.No),
			n = 1,
			Vmax = 100 / 3.6,
			mu = 0.7,
			g = 9.8,
			l_safe = 0,
			tau = 0.5
		};
	}
}