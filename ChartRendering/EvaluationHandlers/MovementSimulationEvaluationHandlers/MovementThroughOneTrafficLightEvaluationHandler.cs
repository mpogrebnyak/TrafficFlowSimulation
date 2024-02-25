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
	private bool _isGreenLight = true;

	private bool _isCarToStopNotFound = true;

	private MovementThroughOneTrafficLightModeSettingsModel _modeSettings;

	private Equation _equation;

	protected override KernelEvaluationHandler CreateKernelEvaluationHandler(ModelParameters modelParameters, BaseSettingsModels baseSettingsModels)
	{
		_modeSettings = (MovementThroughOneTrafficLightModeSettingsModel)baseSettingsModels;
		_equation = new EquationWithStop(modelParameters);
		_isGreenLight = _modeSettings.FirstTrafficLightColor.Value.Equals(FirstTrafficLightColor.Green);

		return new KernelEvaluationHandler(modelParameters, _equation);
	}

	protected override void AdditionalEvaluation(double t, List<double> x, List<double> y)
	{
		for (var i = 0; i < x.Count; i++)
		{
			if (_isGreenLight)
			{
				if (!_isCarToStopNotFound)
				{
					_equation.CleanFirstCarNumbers();
					_isCarToStopNotFound = true;
				}
			}
			else
			{
				if (x[i] < 0 && _isCarToStopNotFound)
				{
					_equation.AddFirstCarNumbers(i);
					_isCarToStopNotFound = false;
				}
			}
		}

		var circleTime = _modeSettings.SingleLightGreenTime + _modeSettings.SingleLightRedTime;
		_isGreenLight = t % circleTime < _modeSettings.SingleLightGreenTime;
	}

	protected override void SendEvent(ChartEventHandler eventHandler, double t, List<double> x, List<double> y)
	{
		var circleTime = _modeSettings.SingleLightGreenTime + _modeSettings.SingleLightRedTime;

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
					IsGreenLight = _isGreenLight,
					GreenTime = _modeSettings.SingleLightGreenTime - t % circleTime,
					RedTime = circleTime - t % circleTime
				}));
	}
}