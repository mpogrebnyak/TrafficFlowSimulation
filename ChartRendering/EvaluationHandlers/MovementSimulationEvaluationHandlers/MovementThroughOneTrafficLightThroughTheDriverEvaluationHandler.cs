using System.Collections.Generic;
using System.Linq;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Constants;
using ChartRendering.Events;
using ChartRendering.Models;
using EvaluationKernel;
using EvaluationKernel.Equations.SpecializedEquations;
using EvaluationKernel.Models;
using EvaluationKernel.Equations;

namespace ChartRendering.EvaluationHandlers.MovementSimulationEvaluationHandlers;

public class MovementThroughOneTrafficLightThroughTheDriverEvaluationHandler : MovementThroughOneTrafficLightEvaluationHandler
{
	protected override KernelEvaluationHandler CreateKernelEvaluationHandler(ModelParameters modelParameters, BaseSettingsModels baseSettingsModels)
	{
		ModelParameters = ExtendModelParameters(modelParameters);
		Equation = new EquationWithStopThroughTheDriver(ModelParameters);
		ExtendEquation();
		ModeSettings = (MovementThroughOneTrafficLightModeSettingsModel)baseSettingsModels;
		CurrentSignal = (TrafficLightColor)ModeSettings.FirstTrafficLightColor.Value;
		Signal = (TrafficLightColor)ModeSettings.FirstTrafficLightColor.Value;

		if (Signal == TrafficLightColor.Green)
		{
			((EquationWithStopThroughTheDriver) Equation).StopCar.Clear();
		}

		return new KernelEvaluationHandler(ModelParameters, Equation);
	}

	protected override void AdditionalEvaluation(double t, List<double> x, List<double> y)
	{
		RemainingTime = GetRemainingTime(t);

		if (CurrentSignal == TrafficLightColor.Green)
		{
			if (!IsCarToStopNotFound)
			{
				((EquationWithStopThroughTheDriver) Equation).StopCar.Clear();
				IsCarToStopNotFound = true;
			}

			return;
		}

		var equation = (EquationWithStopThroughTheDriver) Equation;
		for (var i = 0; i < x.Count; i++)
		{
			if (equation.IsVirtual(i) == false && x[i] <= 0  && IsCarToStopNotFound)
			{
				equation.StopCar.Add(i);
				equation.AddFirstCarNumbers(i);
				IsCarToStopNotFound = false;
			}
		}
	}

	protected override void SendEvent(ChartEventHandler eventHandler, double t, List<double> x, List<double> y)
	{
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
				new EnvironmentArgs
				{
					IsGreenLight = CurrentSignal == TrafficLightColor.Green,
					Time = RemainingTime
				}));
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

	private void ExtendEquation()
	{
		var equation = (EquationWithStopThroughTheDriver) Equation;

		var index = 0;
		for (var i = 0; i < ModelParameters.n; i++)
		{

			if (i > 1)
			{
				equation.VirtualCars.Add(index, true);
				index++;
			}
			equation.VirtualCars.Add(index, false);
			index++;
		}
	}
}