﻿using System.Collections.Generic;
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

public class InliningInFlowEvaluationHandler : EvaluationHandler
{
	//protected EquationForInlining Equation;

	private ModelParameters _modelParameters;

	private InliningInFlowModeSettingsModel _modeSettings;

	private int _indexFrom = -1;

	private int _indexTo = -1;

	private bool _isInlining;

	private bool _isInliningEvent;

	protected override KernelEvaluationHandler CreateKernelEvaluationHandler(ModelParameters modelParameters, BaseSettingsModels baseSettingsModels)
	{
		_isInlining = false;
		_isInliningEvent = false;
		_modelParameters = modelParameters;
		_modeSettings = (InliningInFlowModeSettingsModel) baseSettingsModels;

		var equation = new EquationForInlining(_modelParameters, modelParameters.n1 + _modeSettings.Number, _modeSettings.Lenght);
		equation.AddFirstCarNumbers(_modelParameters.n1);

		return new KernelEvaluationHandler(_modelParameters, equation);
	}

	protected override void AdditionalEvaluation(double t, List<double> x, List<double> y)
	{
		if (IsInliningAvailable(x, y))
		{
			var time = KernelEvaluationHandler.GetTime();
			_modelParameters = ExtendModelParameters(_modelParameters, _indexTo, x, y);

			var equation = (AllCarsChangeLine)_modeSettings.IsAllCarsChangeLine.Value == AllCarsChangeLine.Yes
				? new EquationForInlining(_modelParameters, _modelParameters.n1, _modeSettings.Lenght)
				: new EquationForInlining(_modelParameters);

			equation.AddFirstCarNumbers(_modelParameters.n1);

			KernelEvaluationHandler = new KernelEvaluationHandler(_modelParameters, equation);
			KernelEvaluationHandler.SetInitialConditions(y, x, time);

			if ((AllCarsChangeLine)_modeSettings.IsAllCarsChangeLine.Value == AllCarsChangeLine.Yes)
			{
				_isInlining = false;
			}

			_isInliningEvent = true;
		}
	}

	protected override void SendEvent(ChartEventHandler eventHandler, double t, List<double> x, List<double> y)
	{
		if(_isInliningEvent)
		{
			eventHandler.Invoke(
				new List<ChartEventActions>
				{
				ChartEventActions.AddChartSeries
				},
				new AddChartEventHandlerArgs(_modelParameters, _indexFrom, _indexTo));

			_isInliningEvent = false;
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
			}, new InliningInFlowEnvironmentArgs
			{
				MinSpeedValue = y.Take(_modelParameters.n1).Where((_, index) => index != _indexTo && index != _indexTo + 1).Min()
			}));
	}

	private ModelParameters ExtendModelParameters(ModelParameters modelParameters, int index, List<double> lambda, List<double> Vn)
	{
		var num = _indexFrom;
		var newModelParameters = (ModelParameters) modelParameters.Clone();

		newModelParameters.n1++;
		newModelParameters.n2--;

		newModelParameters.a.RemoveAt(num);
		newModelParameters.k.RemoveAt(num);
		newModelParameters.lambda.RemoveAt(num);
		newModelParameters.q.RemoveAt(num);
		newModelParameters.tau.RemoveAt(num);
		newModelParameters.tau_b.RemoveAt(num);
		newModelParameters.lCar.RemoveAt(num);
		newModelParameters.lSafe.RemoveAt(num);
		newModelParameters.Vmax.RemoveAt(num);
		newModelParameters.Vn.RemoveAt(num);

		newModelParameters.a.Insert(index, modelParameters.a[num]);
		newModelParameters.k.Insert(index, modelParameters.k[num]);
		newModelParameters.lambda.Insert(index, modelParameters.lambda[num]);
		newModelParameters.q.Insert(index, modelParameters.q[num]);
		newModelParameters.tau.Insert(index, modelParameters.tau[num]);
		newModelParameters.tau_b.Insert(index, modelParameters.tau_b[num]);
		newModelParameters.lCar.Insert(index, modelParameters.lCar[num]);
		newModelParameters.lSafe.Insert(index, modelParameters.lSafe[num]);
		newModelParameters.Vmax.Insert(index, modelParameters.Vmax[num]);
		newModelParameters.Vn.Insert(index, modelParameters.Vn[num]);

		var lambdaValue = lambda[num];
		var vnValue = Vn[num];

		lambda.RemoveAt(num);
		Vn.RemoveAt(num);
		lambda.Insert(index, lambdaValue);
		Vn.Insert(index, vnValue);

		return newModelParameters;
	}

	private bool IsInliningAvailable(IReadOnlyList<double> x, IReadOnlyList<double> v)
	{
		var startNum = _modelParameters.n1 + _modeSettings.Number;
		if (startNum > _modelParameters.n || startNum < 0 || _isInlining || _modelParameters.n2 - _modeSettings.Number == 0)
		{
			return false;
		}

		var lenghtToInline = _modeSettings.LenghtToInline;

		var maxNum = (AllCarsChangeLine) _modeSettings.IsAllCarsChangeLine.Value == AllCarsChangeLine.Yes
			? _modelParameters.n
			: _modelParameters.n1 + _modeSettings.Number + 1;
		for (var num = startNum; num < maxNum; num++)
		{
			for (var i = 0; i < _modelParameters.n1; i++)
			{
				var lenght = lenghtToInline > 0
					? lenghtToInline
					: Equation.S(_modelParameters, i, v[i]);

				if (i == 0 && x[num] - x[i] > lenght)
				{
					_indexTo = 0;
					_isInlining = true;
					_indexFrom = num;
					return true;
				}

				if (i == _modelParameters.n1 - 1 && x[i] - x[num] > Equation.S(_modelParameters, num, v[num]))
				{
					_indexTo = i + 1;
					_isInlining = true;
					_indexFrom = num;
					return true;
				}

				if (x[num] - x[i] > lenght && x[i - 1] - x[num] > Equation.S(_modelParameters, num, v[num]))
				{
					_indexTo = i;
					_isInlining = true;
					_indexFrom = num;
					return true;
				}
			}
		}

		return false;
	}

	protected override bool IsEvent()
	{
		return _isInliningEvent;
	}
}