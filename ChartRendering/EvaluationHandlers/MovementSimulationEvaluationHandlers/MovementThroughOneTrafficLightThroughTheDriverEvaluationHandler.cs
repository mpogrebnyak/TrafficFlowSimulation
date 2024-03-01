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

namespace ChartRendering.EvaluationHandlers.MovementSimulationEvaluationHandlers;

public class MovementThroughOneTrafficLightThroughTheDriverEvaluationHandler : MovementThroughOneTrafficLightEvaluationHandler
{
	protected override KernelEvaluationHandler CreateKernelEvaluationHandler(ModelParameters modelParameters, BaseSettingsModels baseSettingsModels)
	{
		var extendModelParameters = ExtendModelParameters(modelParameters);
		Equation = new EquationWithStopThroughTheDriver(extendModelParameters);
		ModeSettings = (MovementThroughOneTrafficLightModeSettingsModel)baseSettingsModels;
		CurrentSignal = (TrafficLightColor)ModeSettings.FirstTrafficLightColor.Value;
		Signal = (TrafficLightColor)ModeSettings.FirstTrafficLightColor.Value;

		return new KernelEvaluationHandler(extendModelParameters, Equation);
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

		for (var i = 0; i < x.Count; i++)
		{
			if ((i == 0 || i % 2 == 1) && x[i] <= 0 && IsCarToStopNotFound)
			{
				((EquationWithStopThroughTheDriver) Equation).StopCar.Add(i);
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
					X = x.Where((_, index) => index % 2 != 0 || index == 0).ToList(),
					Y = y.Where((_, index) => index % 2 != 0 || index == 0).ToList()
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
}