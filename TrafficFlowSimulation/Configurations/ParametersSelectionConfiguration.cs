using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.Renders.ChartRenders;
using ChartRendering.Renders.ChartRenders.ParametersSelectionRenders;
using Common;
using Common.Modularity;
using EvaluationKernel.Constants;
using EvaluationKernel.Helpers;
using TrafficFlowSimulation.Handlers;
using TrafficFlowSimulation.Windows;

namespace TrafficFlowSimulation.Configurations;

public class ParametersSelectionConfiguration : IInitializable
{
	private readonly Chart _parametersSelectionChart;

	public ParametersSelectionConfiguration(ParametersSelectionWindow form)
	{
		_parametersSelectionChart = form.ParametersSelectionChart;
	}

	public void Initialize()
	{
		var parametersSelectionModes = ModesHelper.GetAvailableParametersSelectionMode();

		if (parametersSelectionModes.Contains(ParametersSelectionMode.InliningDistanceEstimation))
		{
			CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new InliningDistanceEstimationSelectionChartRender(_parametersSelectionChart),
				_parametersSelectionChart.Name + ParametersSelectionMode.InliningDistanceEstimation, false);
		}

		if (parametersSelectionModes.Contains(ParametersSelectionMode.AccelerationCoefficientEstimation))
		{
			CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new AccelerationCoefficientEstimationSelectionChartRender(_parametersSelectionChart),
				_parametersSelectionChart.Name + ParametersSelectionMode.AccelerationCoefficientEstimation, false);
		}

		if (parametersSelectionModes.Contains(ParametersSelectionMode.DecelerationCoefficientEstimation))
		{
			CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new DecelerationCoefficientEstimationSelectionChartRender(_parametersSelectionChart),
				_parametersSelectionChart.Name + ParametersSelectionMode.DecelerationCoefficientEstimation, false);
		}

		CommonHelper.ServiceRegistration.RegisterInstance(() => new ChartRenderingHandler(
			new List<string>
			{
				_parametersSelectionChart.Name
			},
			ModesHelper.GetCurrentParametersSelectionMode()), ModesHelper.ParametersSelectionModeType, false);
	}
}