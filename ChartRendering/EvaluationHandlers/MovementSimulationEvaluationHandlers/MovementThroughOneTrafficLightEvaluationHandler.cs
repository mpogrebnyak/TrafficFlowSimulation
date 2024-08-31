using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using EvaluationKernel;
using EvaluationKernel.Models;

namespace ChartRendering.EvaluationHandlers.MovementSimulationEvaluationHandlers;

public class MovementThroughOneTrafficLightEvaluationHandler : MovementThroughMultipleTrafficLightsEvaluationHandler
{

	protected override KernelEvaluationHandler CreateKernelEvaluationHandler(ModelParameters modelParameters, BaseSettingsModels baseSettingsModels)
	{
		base.CreateKernelEvaluationHandler(modelParameters, new MovementThroughMultipleTrafficLightsModeSettingsModel().MapFrom((MovementThroughOneTrafficLightModeSettingsModel)baseSettingsModels));

		return new KernelEvaluationHandler(modelParameters, Equation);
	}
}