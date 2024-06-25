using System.Collections.Generic;
using System.Linq;
using ChartRendering.ChartRenderModels;
using ChartRendering.Constants;
using ChartRendering.Events;
using ChartRendering.Models;
using EvaluationKernel;
using EvaluationKernel.Equations;
using EvaluationKernel.Equations.SpecializedEquations;
using EvaluationKernel.Models;

namespace ChartRendering.EvaluationHandlers.MovementSimulationEvaluationHandlers;

public class ThroughTheDriverEvaluationHandler : EvaluationHandler
{
	private Equation _equation;

	protected override KernelEvaluationHandler CreateKernelEvaluationHandler(ModelParameters modelParameters, BaseSettingsModels baseSettingsModels)
	{
		var extendModelParameters = ExtendModelParameters(modelParameters);
		_equation = new EquationThroughTheDriver(extendModelParameters);
		ExtendEquation(modelParameters);
		return new KernelEvaluationHandler(extendModelParameters, _equation);
	}

	protected override void SendEvent(ChartEventHandler eventHandler, double t, List<double> x, List<double> y)
	{
		var equation = (EquationThroughTheDriver) _equation;
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

	private void ExtendEquation(ModelParameters modelParameters)
	{
		var equation = (EquationThroughTheDriver) _equation;
		var index = 0;

		for (var i = 0; i < modelParameters.n; i++)
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