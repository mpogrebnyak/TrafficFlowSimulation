﻿using System;
using System.ComponentModel.DataAnnotations;
using ChartRendering.Attribute;
using EvaluationKernel.Models;
using Localization.Localization;

// ReSharper disable InconsistentNaming

namespace ChartRendering.ChartRenderModels.ParametersModels;

public class InliningDistanceEstimationModelParametersModel : BaseParametersModel
{
	[Hidden]
	public override double k { get; set; }

	[Hidden] 
	public override string k_multiple { get; set; }

	[Translation(Locales.ru, "Количество автомобилей")]
	[Translation(Locales.en, "Vehicles number")]
	[CustomDisplay(1, isReadOnly: true)]
	[Required, Range(1, 10000)]
	public override int n { get; set; }

	[Translation(Locales.ru, "Ускорение свободного падения")]
	[Translation(Locales.en, "Gravitational acceleration")]
	[CustomDisplay(100)]
	[Required, Range(1, 10000)]
	public double g { get; set; }

	[Translation(Locales.ru, "Коэффициент трения")]
	[Translation(Locales.en, "Friction coefficient")]
	[CustomDisplay(101)]
	[Required, Range(0, 1)]
	public double mu { get; set; }

	public new void MapTo(ModelParameters mp)
	{
		base.MapTo(mp);
		mp.g = g;
		mp.mu = mu;
	}

	public override object GetDefault()
	{
		var defaultValues = (BaseParametersModel)base.GetDefault();
		var defaultAPM = AdditionalParametersModel.Default();

		defaultValues.l_car = 4;
		defaultValues.l_safe = 1;
		defaultValues.a = 0.45;
		defaultValues.q = Math.Round(1 / (defaultAPM.g * defaultAPM.mu), 2);

		return new InliningDistanceEstimationModelParametersModel
		{
			IsCarsIdentical = defaultValues.IsCarsIdentical,
			n = defaultValues.n,
			Vmax = defaultValues.Vmax,
			Vmax_multiple = defaultValues.Vmax_multiple,
			tau = defaultValues.tau,
			tau_multiple = defaultValues.tau_multiple,
			a = defaultValues.a,
			a_multiple = defaultValues.a_multiple,
			q = defaultValues.q,
			q_multiple = defaultValues.q_multiple,
			l_safe = defaultValues.l_safe,
			l_safe_multiple = defaultValues.l_safe_multiple,
			l_car = defaultValues.l_car,
			k = defaultValues.k,
			k_multiple = defaultValues.k_multiple,
			tau_b = defaultValues.tau_b,
			tau_b_multiple = defaultValues.tau_b_multiple,
			g = defaultAPM.g,
			mu = defaultAPM.mu
		};
	}
}