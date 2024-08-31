using System;
using System.Collections.Generic;
using System.Linq;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Constants;
using ChartRendering.Events;
using ChartRendering.Models;
using EvaluationKernel;
using EvaluationKernel.Equations;
using EvaluationKernel.Equations.SpecializedEquations;
using EvaluationKernel.Models;

namespace ChartRendering.EvaluationHandlers.MovementSimulationEvaluationHandlers;

public class MovementThroughMultipleTrafficLightsEvaluationHandler : EvaluationHandler
{
	protected List<TrafficLight> TrafficLights;

	protected Dictionary<int, NumberAndPositionToStop> Stop;

	protected ModelParameters ModelParameters;

	protected Equation Equation;

	protected int TrafficLightsNumber;

	protected TrafficLightsParameters TrafficLightsParameters;

	private MovementThroughMultipleTrafficLightsModeSettingsModel _modeSettings;

	protected override KernelEvaluationHandler CreateKernelEvaluationHandler(ModelParameters modelParameters, BaseSettingsModels baseSettingsModels)
	{
		TrafficLightsParameters = new() {TrafficLightsPosition = new List<double>(), TrafficLightsGreenTime = new List<double>(), TrafficLightsRedTime = new List<double>()};
		Stop = new Dictionary<int, NumberAndPositionToStop>();
		TrafficLights = new List<TrafficLight>();

		Equation = new EquationWithStop(modelParameters);
		ModelParameters = modelParameters;
		_modeSettings = (MovementThroughMultipleTrafficLightsModeSettingsModel)baseSettingsModels;
		TrafficLightsParameters = _modeSettings.MapTo();
		TrafficLightsNumber = _modeSettings.TrafficLightsNumber;

		for (var i = 0; i < TrafficLightsNumber; i++)
		{
			TrafficLights.Add(new TrafficLight
			{
				Signal = TrafficLightColor.Green,
				CurrentSignal = TrafficLightColor.Green
			});

			Stop.Add(i, new NumberAndPositionToStop(0, TrafficLightsParameters.TrafficLightsPosition[i]));
		}

		return new KernelEvaluationHandler(modelParameters, Equation);
	}

	protected override void AdditionalEvaluation(double t, List<double> x, List<double> y)
	{
		var remainingTimes = GetRemainingTime(t);
		foreach (var trafficLight in TrafficLights.Select((value, i) => new { i, value }))
		{
			trafficLight.value.RemainingTime = remainingTimes[trafficLight.i];
		}

		foreach (var trafficLight in TrafficLights.Select((value, i) => new { i, value }))
		{
			var eq = (EquationWithStop) Equation;
			switch (trafficLight.value.CurrentSignal)
			{
				case TrafficLightColor.Red:
					if (eq.NumberAndPositionToStop.ContainsKey(Stop[trafficLight.i].N) == false && Stop[trafficLight.i].N >= 0)
						eq.NumberAndPositionToStop.Add(Stop[trafficLight.i].N, Stop[trafficLight.i].Pos);
					break;
				case TrafficLightColor.Green:
					var item = eq.NumberAndPositionToStop.Where(x => Math.Abs(x.Value - Stop[trafficLight.i].Pos) < 0.001);
					var keyValuePairs = item.ToList();
					if (keyValuePairs.Any())
						eq.NumberAndPositionToStop.Remove(keyValuePairs.First().Key);
					break;
			}
		}

		for (var j = 0; j < TrafficLightsNumber; j++)
		{
			for (var i = 0; i < ModelParameters.n; i++)
			{
				if (AdditionalCondition(i) == false)
					continue;

				if (x[i] < TrafficLightsParameters.TrafficLightsPosition[j] && x[i] <= TrafficLightsParameters.TrafficLightsPosition[j] - Equation.S(ModelParameters, i, y[i]))
				{
					if (TrafficLights[j].CurrentSignal == TrafficLightColor.Red)
						break;

					Stop[j].N = i;
					break;
				}
				Stop[j].N = -1;
			}
		}
	}

	protected override void SendEvent(ChartEventHandler eventHandler, double t, List<double> x, List<double> y)
	{
		var args = new MultipleTrafficLightsEnvironmentArgs { TrafficLight = new List<SingleTrafficLight>() };
		for (var i = 0; i < TrafficLightsNumber; i++)
		{
			args.TrafficLight.Add(new SingleTrafficLight
			{
				IsGreenLight = TrafficLights[i].CurrentSignal == TrafficLightColor.Green,
				Time = TrafficLights[i].RemainingTime
			});
		}

		eventHandler.Invoke(
			new List<ChartEventActions>
			{
				ChartEventActions.UpdateCharts,
				ChartEventActions.UpdateChartEnvironments
			},
			new ChartEventHandlerArgs(new CoordinatesArgs
				{
					T = t,
					X = x.ToList(),
					Y = y.ToList()
				},
				args));
	}

	protected List<double> GetRemainingTime(double t)
	{
		var time = t;

		var remainingTime = new List<double>();
		for(var i = 0; i < TrafficLightsNumber; i++)
		{
			var cycleDuration = TrafficLightsParameters.TrafficLightsGreenTime[i] + TrafficLightsParameters.TrafficLightsRedTime[i];

			var currentCycleTime = time % cycleDuration;
			var lightTime = TrafficLights[i].Signal == TrafficLightColor.Green
				? TrafficLightsParameters.TrafficLightsGreenTime[i]
				: TrafficLightsParameters.TrafficLightsRedTime[i];

			if (currentCycleTime < lightTime)
			{
				TrafficLights[i].CurrentSignal = TrafficLights[i].Signal == TrafficLightColor.Green
					? TrafficLightColor.Green
					: TrafficLightColor.Red;

				remainingTime.Add(lightTime - currentCycleTime);
				continue;
			}

			TrafficLights[i].CurrentSignal = TrafficLights[i].Signal == TrafficLightColor.Green
				? TrafficLightColor.Red
				: TrafficLightColor.Green;

			remainingTime.Add(TrafficLights[i].Signal == TrafficLightColor.Green
				? TrafficLightsParameters.TrafficLightsGreenTime[i] - (currentCycleTime - TrafficLightsParameters.TrafficLightsRedTime[i])
				: TrafficLightsParameters.TrafficLightsRedTime[i] - (currentCycleTime - TrafficLightsParameters.TrafficLightsGreenTime[i]));
		}

		return remainingTime;
	}

	protected virtual bool AdditionalCondition(int n)
	{
		return true;
	}

	protected class TrafficLight
	{
		public double RemainingTime;

		public TrafficLightColor Signal;

		public TrafficLightColor CurrentSignal;
	}

	protected class NumberAndPositionToStop
	{
		public int N;

		public double Pos;

		public NumberAndPositionToStop(int n, double pos)
		{
			N = n;
			Pos = pos;
		}
	}
}