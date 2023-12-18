using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.Renders.ChartRenders;
using ChartRendering.Renders.ChartRenders.ParametersSelectionRenders;
using Common;
using Common.Modularity;
using Modes;
using Modes.Constants;
using TrafficFlowSimulation.Handlers;

namespace TrafficFlowSimulation.Configurations;

public class ParametersSelectionConfiguration : IInitializable
{
	private readonly Chart _chart;

	public ParametersSelectionConfiguration(Chart chart)
	{
		_chart = chart;
	}

	public void Initialize()
	{
		var parametersSelectionModes = ModesHelper.GetAvailableParametersSelectionMode();;

		if (parametersSelectionModes.Contains(ParametersSelectionMode.InliningDistanceEstimation))
		{
			CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new InliningDistanceEstimationSelectionChartRender(_chart),
				_chart.Name + ParametersSelectionMode.InliningDistanceEstimation, false);
		}

		if (parametersSelectionModes.Contains(ParametersSelectionMode.AccelerationCoefficientEstimation))
		{
			CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new AccelerationCoefficientEstimationSelectionChartRender(_chart),
				_chart.Name + ParametersSelectionMode.AccelerationCoefficientEstimation, false);
		}

		if (parametersSelectionModes.Contains(ParametersSelectionMode.DecelerationCoefficientEstimation))
		{
			CommonHelper.ServiceRegistration.RegisterInstance<IChartRender>(() => new DecelerationCoefficientEstimationSelectionChartRender(_chart),
				_chart.Name + ParametersSelectionMode.DecelerationCoefficientEstimation, false);
		}

		CommonHelper.ServiceRegistration.RegisterInstance<ParametersSelectionRenderingHandler>(() => new ParametersSelectionRenderingHandler(_chart));
	}
}