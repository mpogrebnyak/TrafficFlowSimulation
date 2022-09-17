using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using Common;
using Common.Modularity;
using Settings;
using TrafficFlowSimulation.Constants;

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

		if (parametersSelectionModes.Contains(ParametersSelectionMode.InliningDistanceChanging))
		{
			CommonHelper.ServiceRegistrator.RegisterInstance<IChartRender>(() => new InliningDistanceSelectionChartRender(_chart),
				_chart.Name + ParametersSelectionMode.InliningDistanceChanging, false);
		}
		
		CommonHelper.ServiceRegistrator.RegisterInstance<ParametersSelectionRenderingHandler>(() => new ParametersSelectionRenderingHandler(_chart));
	}
}