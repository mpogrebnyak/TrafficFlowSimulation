using System.Windows.Forms;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Models.SettingsModels;

namespace TrafficFlowSimulation.Handlers.EvaluationHandlers;

public interface IEvaluationHandler
{
	public void Execute(Form form, ModelParameters modelParameters, BaseSettingsModels modeSettings);

	public void StartExecution();

	public void StopExecution();

	public void AbortExecution();
}