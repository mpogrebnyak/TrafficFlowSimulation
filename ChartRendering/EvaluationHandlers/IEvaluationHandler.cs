using ChartRendering.ChartRenderModels;
using ChartRendering.Events;
using EvaluationKernel.Models;

namespace ChartRendering.EvaluationHandlers;

public interface IEvaluationHandler
{
	public void Execute(ModelParameters modelParameters, BaseSettingsModels modeSettings, ChartEventHandler chartEventHandler);

	public void ExecutePreCalculated(ModelParameters modelParameters, BaseSettingsModels modeSettings, ChartEventHandler chartEventHandler, object preCalculatedParameters);

	public void StartExecution();

	public void StopExecution();

	public void AbortExecution();

	public bool IsExecuted();
}