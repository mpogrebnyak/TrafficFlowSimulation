using System.Collections.Generic;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Constants;
using ChartRendering.Events;
using ChartRendering.Models;
using EvaluationKernel;
using EvaluationKernel.Equations.SpecializedEquations;
using EvaluationKernel.Models;

namespace ChartRendering.EvaluationHandlers.MovementSimulationEvaluationHandlers;

public class SpeedLimitChangingEvaluationHandler : EvaluationHandler
{
	protected override KernelEvaluationHandler CreateKernelEvaluationHandler(ModelParameters modelParameters, BaseSettingsModels baseSettingsModels)
	{
		var modeSettings = (SpeedLimitChangingModeSettingsModel) baseSettingsModels;
		var segmentSpeeds = new SortedDictionary<int, SegmentModel>();
		modeSettings.MapTo(segmentSpeeds);

		var equation = new EquationWithSpeedLimitChanging(modelParameters, segmentSpeeds);
		return new KernelEvaluationHandler(modelParameters, equation);
	}

	protected override void SendEvent(ChartEventHandler eventHandler, double t, List<double> x, List<double> y)
	{
		eventHandler.Invoke(
			new List<ChartEventActions>
			{
				ChartEventActions.UpdateCharts
			},
			new ChartEventHandlerArgs(new CoordinatesArgs
			{
				T = t,
				X = x,
				Y = y
			}));
	}
}