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
	private readonly List<TrafficLight> _trafficLights = new();

	private readonly Dictionary<int, NumberAndPositionToStop> _stop = new ();

	private ModelParameters _modelParameters;

	private TrafficLightsParameters _trafficLightsParameters;

	private MovementThroughMultipleTrafficLightsModeSettingsModel _modeSettings;

	private Equation _equation;

	protected override KernelEvaluationHandler CreateKernelEvaluationHandler(ModelParameters modelParameters, BaseSettingsModels baseSettingsModels)
	{
		_equation = new EquationWithStop(modelParameters);
		_modelParameters = modelParameters;
		_modeSettings = (MovementThroughMultipleTrafficLightsModeSettingsModel)baseSettingsModels;
		_trafficLightsParameters = _modeSettings.MapTo();

		_stop.Clear();
		for (var i = 0; i < _modeSettings.TrafficLightsNumber; i++)
		{
			_trafficLights.Add(new TrafficLight
			{
				Signal = TrafficLightColor.Green,
				CurrentSignal = TrafficLightColor.Green
			});

			_stop.Add(i, new NumberAndPositionToStop(0, _trafficLightsParameters.TrafficLightsPosition[i]));
		}

		return new KernelEvaluationHandler(modelParameters, _equation);
	}

	protected override void AdditionalEvaluation(double t, List<double> x, List<double> y)
	{
		var remainingTimes = GetRemainingTime(t);
		foreach (var trafficLight in _trafficLights.Select((value, i) => new { i, value }))
		{
			trafficLight.value.RemainingTime = remainingTimes[trafficLight.i];
		}

		foreach (var trafficLight in _trafficLights.Select((value, i) => new { i, value }))
		{
			var eq = (EquationWithStop) _equation;
			switch (trafficLight.value.CurrentSignal)
			{
				case TrafficLightColor.Red:
					if (eq.NumberAndPositionToStop.ContainsKey(_stop[trafficLight.i].N) == false && _stop[trafficLight.i].N >= 0)
						eq.NumberAndPositionToStop.Add(_stop[trafficLight.i].N, _stop[trafficLight.i].Pos);
					break;
				case TrafficLightColor.Green:
					var item = eq.NumberAndPositionToStop.Where(x => Math.Abs(x.Value - _stop[trafficLight.i].Pos) < 0.001);
					var keyValuePairs = item.ToList();
					if (keyValuePairs.Any())
						eq.NumberAndPositionToStop.Remove(keyValuePairs.First().Key);
					break;
			}
		}

		for (var j = 0; j < _modeSettings.TrafficLightsNumber; j++)
		{
			for (var i = 0; i < _modelParameters.n; i++)
			{
				if (x[i] < _trafficLightsParameters.TrafficLightsPosition[j] && x[i] <= _trafficLightsParameters.TrafficLightsPosition[j] - Equation.S(_modelParameters, i, y[i]))
				{
					if (_trafficLights[j].CurrentSignal == TrafficLightColor.Red)
						break;

					_stop[j].N = i;
					break;
				}
				_stop[j].N = -1;
			}
		}
	}

	protected override void SendEvent(ChartEventHandler eventHandler, double t, List<double> x, List<double> y)
	{
		var args = new MultipleTrafficLightsEnvironmentArgs { TrafficLight = new List<SingleTrafficLight>() };
		for (var i = 0; i < _modeSettings.TrafficLightsNumber; i++)
		{
			args.TrafficLight.Add(new SingleTrafficLight
			{
				IsGreenLight = _trafficLights[i].CurrentSignal == TrafficLightColor.Green,
				Time = _trafficLights[i].RemainingTime
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
		for(var i = 0; i < _modeSettings.TrafficLightsNumber; i++)
		{
			var cycleDuration = _trafficLightsParameters.TrafficLightsGreenTime[i] + _trafficLightsParameters.TrafficLightsRedTime[i];

			var currentCycleTime = time % cycleDuration;
			var lightTime = _trafficLights[i].Signal == TrafficLightColor.Green
				? _trafficLightsParameters.TrafficLightsGreenTime[i]
				: _trafficLightsParameters.TrafficLightsRedTime[i];

			if (currentCycleTime < lightTime)
			{
				_trafficLights[i].CurrentSignal = _trafficLights[i].Signal == TrafficLightColor.Green
					? TrafficLightColor.Green
					: TrafficLightColor.Red;

				remainingTime.Add(lightTime - currentCycleTime);
				continue;
			}

			_trafficLights[i].CurrentSignal = _trafficLights[i].Signal == TrafficLightColor.Green
				? TrafficLightColor.Red
				: TrafficLightColor.Green;

			remainingTime.Add(_trafficLights[i].Signal == TrafficLightColor.Green
				? _trafficLightsParameters.TrafficLightsGreenTime[i] - (currentCycleTime - _trafficLightsParameters.TrafficLightsRedTime[i])
				: _trafficLightsParameters.TrafficLightsRedTime[i] - (currentCycleTime - _trafficLightsParameters.TrafficLightsGreenTime[i]));
		}

		return remainingTime;
	}

	private class TrafficLight
	{
		public double RemainingTime;

		public TrafficLightColor Signal;

		public TrafficLightColor CurrentSignal;
	}

	private class NumberAndPositionToStop
	{
		public int N;

		public double Pos;

		public NumberAndPositionToStop(int n, double pos)
		{
			N = n;
			Pos = pos;
		}
	};
}