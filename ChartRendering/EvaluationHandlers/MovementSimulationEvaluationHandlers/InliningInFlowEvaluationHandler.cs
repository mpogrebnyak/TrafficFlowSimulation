using System.Collections.Generic;
using System.Linq;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Constants;
using ChartRendering.Events;
using ChartRendering.Models;
using EvaluationKernel;
using EvaluationKernel.Equations;
using EvaluationKernel.Models;

namespace ChartRendering.EvaluationHandlers.MovementSimulationEvaluationHandlers;

public class InliningInFlowEvaluationHandler : EvaluationHandler
{
	private ModelParameters _modelParameters;

	private InliningInFlowModeSettingsModel _modeSettings;

	private int _index = -1;

	private bool _isInlining = true;

	private bool _isInliningEvent = true;

	protected override KernelEvaluationHandler CreateKernelEvaluationHandler(ModelParameters modelParameters, BaseSettingsModels baseSettingsModels)
	{
		_modelParameters = modelParameters;
		_modeSettings = (InliningInFlowModeSettingsModel) baseSettingsModels;

		var equation = new Equation(_modelParameters);
		return new KernelEvaluationHandler(_modelParameters, equation);
	}

	protected override void AdditionalEvaluation(double t, List<double> x, List<double> y)
	{
		var isInliningAvailable = IsInliningAvailable(_modelParameters, x, y);

		if (_isInlining && isInliningAvailable)
		{
			_modelParameters = ExtendModelParameters(_modelParameters, _modeSettings, _index, x, y);

			var time = KernelEvaluationHandler.GetTime();

			var equation = new Equation(_modelParameters);
			KernelEvaluationHandler = new KernelEvaluationHandler(_modelParameters, equation);
			KernelEvaluationHandler.SetInitialConditions(
				x.Take(_index).Concat(new[] {0.0}).Concat(x.Skip(_index)).ToList(),
				y.Take(_index).Concat(new[] {0.0}).Concat(y.Skip(_index)).ToList());

			KernelEvaluationHandler.SetTime(time);
			_isInlining = false;
		}
	}

	protected override void SendEvent(ChartEventHandler eventHandler, double t, List<double> x, List<double> y)
	{

		if(!_isInlining && _isInliningEvent)
		{
			eventHandler.Invoke(
				new List<ChartEventActions>
				{
					ChartEventActions.AddChartSeries
				},
				new AddChartEventHandlerArgs(_modelParameters, _index));

			_isInliningEvent = false;
		}

		eventHandler.Invoke(
			new List<ChartEventActions>
			{
				ChartEventActions.UpdateCharts
			},
			new ChartEventHandlerArgs(new CoordinatesArgs
			{
				T = t,
				X = x.ToList(),
				Y = y.ToList()
			}));
	}

	private ModelParameters ExtendModelParameters(ModelParameters modelParameters, InliningInFlowModeSettingsModel modeSettings, int index, IEnumerable<double> lambda, IEnumerable<double> Vn)
	{
		modelParameters.n++;
		modelParameters.a.Insert(index, modeSettings.a);
		modelParameters.q.Insert(index, modeSettings.q);
		modelParameters.lSafe.Insert(index, modeSettings.l_safe);
		modelParameters.lCar.Insert(index, modeSettings.l_car);
		modelParameters.Vmax.Insert(index, modeSettings.Vmax);
		modelParameters.k.Insert(index, modeSettings.k);

		modelParameters.lambda = lambda.ToList();
		modelParameters.Vn = Vn.ToList();
		modelParameters.lambda.Insert(index, 0);
		modelParameters.Vn.Insert(index, 0);

		return modelParameters;
	}

	private bool IsInliningAvailable(ModelParameters modelParameters, IReadOnlyList<double> x, IReadOnlyList<double> v)
	{
		for (var i = 0; i < x.Count; i++)
		{
			if (x[i] > 0)
				continue;
			_index = i;

			var s = modelParameters.k[i] * (x[i] + Equation.S(modelParameters, i, v[i]) + modelParameters.tau[i] * v[i]);

			if (s + x[i] < 0)
				return true;
			return false;
		}

		_index = x.Count;
		return true;
	}
}