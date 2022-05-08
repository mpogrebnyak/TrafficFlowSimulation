using System.Windows.Forms;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Models.ModeSettingsModels;

namespace TrafficFlowSimulation.MovementSimulation.EvaluationHandlers;

public interface IEvaluationHandler
{
	public void Execute(Form form, ModelParameters modelParameters, ModeSettings modeSettings);

	public void StartExecution();

	public void StopExecution();

	public void AbortExecution();
}