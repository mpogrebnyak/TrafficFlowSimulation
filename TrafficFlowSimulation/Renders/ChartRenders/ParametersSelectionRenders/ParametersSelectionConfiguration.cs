using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using Common;
using Common.Modularity;
using Settings;
using TrafficFlowSimulation.Constants.Modes;

namespace TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders;

public class ParametersSelectionConfiguration : IInitializable
{
	private readonly Chart _chart;

	public ParametersSelectionConfiguration(Chart chart)
	{
		_chart = chart;
	}

	public void Initialize()
	{
		var parametersSelectionModes = SettingsHelper.Get<Properties.Settings>().AvailableParametersSelectionModes.ToList();

		if (parametersSelectionModes.Contains(ParametersSelectionMode.InliningDistanceEstimation))
		{
			CommonHelper.ServiceRegistrator.RegisterInstance<IChartRender>(() => new InliningDistanceEstimationSelectionChartRender(_chart),
				_chart.Name + ParametersSelectionMode.InliningDistanceEstimation, false);
		}

		if (parametersSelectionModes.Contains(ParametersSelectionMode.AccelerationCoefficientEstimation))
		{
			CommonHelper.ServiceRegistrator.RegisterInstance<IChartRender>(() => new AccelerationCoefficientEstimationSelectionChartRender(_chart),
				_chart.Name + ParametersSelectionMode.AccelerationCoefficientEstimation, false);
		}

		if (parametersSelectionModes.Contains(ParametersSelectionMode.DecelerationCoefficientEstimation))
		{
			CommonHelper.ServiceRegistrator.RegisterInstance<IChartRender>(() => new DecelerationCoefficientEstimationSelectionChartRender(_chart),
				_chart.Name + ParametersSelectionMode.DecelerationCoefficientEstimation, false);
		}

		CommonHelper.ServiceRegistrator.RegisterInstance<ParametersSelectionRenderingHandler>(() => new ParametersSelectionRenderingHandler(_chart));
	}
}