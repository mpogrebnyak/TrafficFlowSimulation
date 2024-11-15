﻿using System;
using System.Collections.Generic;
using System.Linq;
using ChartRendering.ChartRenderModels;
using ChartRendering.Constants;
using ChartRendering.Events;
using ChartRendering.Models;
using EvaluationKernel;
using EvaluationKernel.Equations.SpecializedEquations;
using EvaluationKernel.Models;

namespace ChartRendering.EvaluationHandlers.MovementSimulationEvaluationHandlers;

public class MovementThroughOneTrafficLightThroughTheDriverEvaluationHandler : MovementThroughOneTrafficLightEvaluationHandler
{
	protected override KernelEvaluationHandler CreateKernelEvaluationHandler(ModelParameters modelParameters, BaseSettingsModels baseSettingsModels)
	{
		base.CreateKernelEvaluationHandler(modelParameters, baseSettingsModels);
		ModelParameters = ExtendModelParameters(modelParameters);
		Equation = new EquationWithStopThroughTheDriver(ModelParameters);
		ExtendEquation();

		return new KernelEvaluationHandler(ModelParameters, Equation);
	}

	protected override void SendEvent(ChartEventHandler eventHandler, double t, List<double> x, List<double> y)
	{
		var args = new MultipleTrafficLightsEnvironmentArgs { TrafficLight = new List<SingleTrafficLight>() };
		args.TrafficLight.Add(new SingleTrafficLight
		{
			IsGreenLight = TrafficLights.First().CurrentSignal == TrafficLightColor.Green,
			Time = TrafficLights.First().RemainingTime
		});

		var equation = (EquationWithStopThroughTheDriver) Equation;
		eventHandler.Invoke(
			new List<ChartEventActions>
			{
				ChartEventActions.UpdateCharts,
				ChartEventActions.UpdateChartEnvironments
			},
			new ChartEventHandlerArgs(new CoordinatesArgs
				{
					T = t,
					X = x.Where((_, index) => equation.IsVirtual(index) == false).ToList(),
					Y = y.Where((_, index) => equation.IsVirtual(index) == false).ToList()
				},
				args));
	}

	protected override bool AdditionalCondition(int n)
	{
		var equation = (EquationWithStopThroughTheDriver) Equation;
		return equation.IsVirtual(n);
	}

	protected override int GetPrevCarNumber(int n)
	{
		return n < 2
			? n - 1
			: n - 2;
	}

	private ModelParameters ExtendModelParameters(ModelParameters modelParameters)
	{
		var extendModelParameters = new ModelParameters
		{
			g = modelParameters.g,
			tau_b = modelParameters.tau_b,
			mu = modelParameters.mu,
			L = modelParameters.L,
			n = modelParameters.n + modelParameters.n - 2
		};

		for (var i = 0; i < modelParameters.n; i++)
		{
			if (i > 1)
			{
				extendModelParameters.tau.Add(modelParameters.tau[i - 1]);
				extendModelParameters.tau_b.Add(modelParameters.tau_b[i - 1]);
				extendModelParameters.Vmax.Add(modelParameters.Vmax[i - 1]);
				extendModelParameters.a.Add(modelParameters.a[i - 1]);
				extendModelParameters.q.Add(modelParameters.q[i - 1]);
				extendModelParameters.lSafe.Add(modelParameters.lSafe[i - 1]);
				extendModelParameters.lCar.Add(modelParameters.lCar[i - 1]);
				extendModelParameters.k.Add(modelParameters.k[i - 1]);
				extendModelParameters.lambda.Add(modelParameters.lambda[i - 1]);
				extendModelParameters.Vn.Add(modelParameters.Vn[i - 1]);
			}

			extendModelParameters.tau.Add(modelParameters.tau[i]);
			extendModelParameters.tau_b.Add(modelParameters.tau_b[i]);
			extendModelParameters.Vmax.Add(modelParameters.Vmax[i]);
			extendModelParameters.a.Add(modelParameters.a[i]);
			extendModelParameters.q.Add(modelParameters.q[i]);
			extendModelParameters.lSafe.Add(modelParameters.lSafe[i]);
			extendModelParameters.lCar.Add(modelParameters.lCar[i]);
			extendModelParameters.k.Add(modelParameters.k[i]);
			extendModelParameters.lambda.Add(modelParameters.lambda[i]);
			extendModelParameters.Vn.Add(modelParameters.Vn[i]);
		}

		return extendModelParameters;
	}

	protected override void ChangeSignal(TrafficLight trafficLight, int i)
	{
		var eq = (EquationWithStopThroughTheDriver) Equation;
		if (trafficLight.CurrentSignal == TrafficLightColor.Red)
		{
			if (eq.NumberAndPositionToStop.ContainsKey(Stop[i].N) == false && Stop[i].N >= 0)
			{
				eq.NumberAndPositionToStop.Add(Stop[i].N, Stop[i].Pos);
				eq.FirstAfterStop.Add(Stop[i].N);
			}
		}
	}

	private void ExtendEquation()
	{
		var equation = (EquationWithStopThroughTheDriver) Equation;

		for (var i = 0; i < ModelParameters.n; i++)
		{
			if (i < 2)
			{
				equation.VirtualCars.Add(i, false);
				continue;
			}

			equation.VirtualCars.Add(i, i % 2 == 0);
		}
	}
}