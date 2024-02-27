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
	private FirstTrafficLightColor _firstSignal;

	private FirstTrafficLightColor _currentSignal;

	private bool _isFirst = true;

	private bool _isCarToStopNotFound = true;

	private MovementThroughOneTrafficLightModeSettingsModel _modeSettings;

	private Equation _equation;

	protected override KernelEvaluationHandler CreateKernelEvaluationHandler(ModelParameters modelParameters, BaseSettingsModels baseSettingsModels)
	{
		var extendModelParameters = ExtendModelParameters(modelParameters);
		//if (true)
		{
			
			_equation = new EquationWithStopThroughTheDriver(extendModelParameters);
		}
		//else
		{
	//		_equation = new EquationWithStop(modelParameters);
		}
		_modeSettings = (MovementThroughOneTrafficLightModeSettingsModel)baseSettingsModels;
		//_equation = new EquationWithStop(modelParameters);
		//_equation = new EquationWithStopThroughTheDriver(modelParameters);
		_currentSignal = (FirstTrafficLightColor)_modeSettings.FirstTrafficLightColor.Value;
		_firstSignal = (FirstTrafficLightColor)_modeSettings.FirstTrafficLightColor.Value;

	//	return new KernelEvaluationHandler(modelParameters, _equation);
		return new KernelEvaluationHandler(extendModelParameters, _equation);
	}

	protected override void AdditionalEvaluation(double t, List<double> x, List<double> y)
	{
		for (var i = 0; i < x.Count; i++)
		{
			if (_currentSignal == FirstTrafficLightColor.Green)
			{
				if (_isFirst)
				{
					//_equation.CleanFirstCarNumbers();
				}
				
				if (!_isCarToStopNotFound)
				{
					
					((EquationWithStopThroughTheDriver) _equation).CarToSTOP.Clear();
				//	_equation.CleanFirstCarNumbers();
					_isCarToStopNotFound = true;
				}
			}
			else
			{
				if (i % 2 == 1 && x[i] <= 0 && _isCarToStopNotFound)
				//if (x[i] <= 0 && _isCarToStopNotFound)
				{
					((EquationWithStopThroughTheDriver) _equation).CarToSTOP.Add(i);
					_equation.AddFirstCarNumbers(i);
					_isCarToStopNotFound = false;
				}
			}
		}

		GetRemainingTime2(t);
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
			//		X = x.ToList(),
			//		Y = y.ToList()
				},
				new EnvironmentArgs
				{
					IsGreenLight = _currentSignal == FirstTrafficLightColor.Green,
					Time = GetRemainingTime2(t)
				}));
	}

	private double GetRemainingTime(double t)
	{
		var time = t;
		if (_firstSignal == FirstTrafficLightColor.Green && _isFirst)
		{
			time += _modeSettings.SingleLightRedTime;
			_isFirst = false;
		}

		var cycleDuration = _modeSettings.SingleLightGreenTime + _modeSettings.SingleLightRedTime;

		var currentCycleTime = time % cycleDuration;

		if (currentCycleTime < _modeSettings.SingleLightRedTime)
		{
			_currentSignal = FirstTrafficLightColor.Red;
			return _modeSettings.SingleLightRedTime - currentCycleTime;
		}

		_currentSignal = FirstTrafficLightColor.Green; 
		return _modeSettings.SingleLightGreenTime - (currentCycleTime - _modeSettings.SingleLightRedTime);
	}
	
	private double GetRemainingTime2(double t)
	{
		var time = t;
		if (_firstSignal == FirstTrafficLightColor.Red && _isFirst)
		{
			time += _modeSettings.SingleLightRedTime;
			_isFirst = false;
		}

		var cycleDuration = _modeSettings.SingleLightGreenTime + _modeSettings.SingleLightRedTime;

		var currentCycleTime = time % cycleDuration;

		if (currentCycleTime < _modeSettings.SingleLightGreenTime)
		{
			_currentSignal = FirstTrafficLightColor.Green;
			return _modeSettings.SingleLightGreenTime - currentCycleTime;
		}

		_currentSignal = FirstTrafficLightColor.Red; 
		return _modeSettings.SingleLightRedTime - (currentCycleTime - _modeSettings.SingleLightGreenTime);
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