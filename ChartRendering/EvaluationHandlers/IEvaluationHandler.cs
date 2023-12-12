using System.Windows.Forms;
using ChartRendering.ChartRenderModels;
using EvaluationKernel.Models;

namespace ChartRendering.EvaluationHandlers;

public interface IEvaluationHandler
{
	public void Execute(Form form, ModelParameters modelParameters, BaseSettingsModels modeSettings);

	public void ExecutePreCalculated(Form form, ModelParameters modelParameters, BaseSettingsModels modeSettings, object preCalculatedParameters);

	public void StartExecution();

	public void StopExecution();

	public void AbortExecution();
}