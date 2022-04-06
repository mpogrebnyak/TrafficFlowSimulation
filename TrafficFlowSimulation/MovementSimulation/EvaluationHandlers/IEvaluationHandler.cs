using EvaluationKernel.Models;
using TrafficFlowSimulation.Models;

namespace TrafficFlowSimulation.EvaluationHandlers;

public interface IEvaluationHandler
{
	public void Execute(AllChartsModel charts, ModelParameters modelParameters, ModeSettings modeSettings);

	public void StartExecution();

	public void StopExecution();

	public void AbortExecution();
}