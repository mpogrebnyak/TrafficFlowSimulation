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

public class MovementThroughOneTrafficLightEvaluationHandler : EvaluationHandler
{
	protected double RemainingTime;

	protected TrafficLightColor Signal;

	protected TrafficLightColor CurrentSignal;

	protected bool IsCarToStopNotFound;

	protected ModelParameters ModelParameters;

	protected MovementThroughOneTrafficLightModeSettingsModel ModeSettings;

	protected Equation Equation;

	protected override KernelEvaluationHandler CreateKernelEvaluationHandler(ModelParameters modelParameters, BaseSettingsModels baseSettingsModels)
	{
		Equation = new EquationWithStop(modelParameters);
		ModelParameters = modelParameters;
		ModeSettings = (MovementThroughOneTrafficLightModeSettingsModel)baseSettingsModels;
		CurrentSignal = (TrafficLightColor)ModeSettings.FirstTrafficLightColor.Value;
		Signal = (TrafficLightColor)ModeSettings.FirstTrafficLightColor.Value;

		return new KernelEvaluationHandler(modelParameters, Equation);
	}

	protected override void AdditionalEvaluation(double t, List<double> x, List<double> y)
	{
		RemainingTime = GetRemainingTime(t);

		if (CurrentSignal == TrafficLightColor.Green)
		{
			if (!IsCarToStopNotFound)
			{
				((EquationWithStop) Equation).StopCar.Clear();
				IsCarToStopNotFound = true;
			}

			return;
		}

		for (var i = 0; i < ModelParameters.n; i++)
		{
			if (x[i] <= 0 - Equation.S(ModelParameters, i, y[i]) && IsCarToStopNotFound)
			{
				((EquationWithStop) Equation).StopCar.Add(i);
				Equation.AddFirstCarNumbers(i);
				IsCarToStopNotFound = false;
			}
		}
	}

	protected override void SendEvent(ChartEventHandler eventHandler, double t, List<double> x, List<double> y)
	{
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
				new EnvironmentArgs
				{
					IsGreenLight = CurrentSignal == TrafficLightColor.Green,
					Time = RemainingTime
				}));
	}

	protected double GetRemainingTime(double t)
	{
		var time = t;
		var cycleDuration = ModeSettings.SingleLightGreenTime + ModeSettings.SingleLightRedTime;

		var currentCycleTime = time % cycleDuration;
		var lightTime = Signal == TrafficLightColor.Green
			? ModeSettings.SingleLightGreenTime
			: ModeSettings.SingleLightRedTime;

		if (currentCycleTime < lightTime)
		{
			CurrentSignal = Signal == TrafficLightColor.Green
				? TrafficLightColor.Green
				: TrafficLightColor.Red;

			return lightTime - currentCycleTime;
		}

		CurrentSignal = Signal == TrafficLightColor.Green
			? TrafficLightColor.Red
			: TrafficLightColor.Green;

		return Signal == TrafficLightColor.Green
			? ModeSettings.SingleLightGreenTime - (currentCycleTime - ModeSettings.SingleLightRedTime)
			: ModeSettings.SingleLightRedTime - (currentCycleTime - ModeSettings.SingleLightGreenTime);
	}
}