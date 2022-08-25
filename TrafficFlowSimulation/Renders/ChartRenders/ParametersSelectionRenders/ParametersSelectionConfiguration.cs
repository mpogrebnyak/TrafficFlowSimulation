using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using Settings;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Renders;

namespace TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders;

public class ParametersSelectionConfiguration : TrafficFlowSimulationModule
{
	private readonly Chart _chart;

	public ParametersSelectionConfiguration(Chart chart)
	{
		_chart = chart;
	}

	public override void Initialize()
	{
		var parametersSelectionModes = SettingsHelper.Get<Properties.Settings>().AvailableParametersSelectionModes.ToList();

		if (parametersSelectionModes.Contains(ParametersSelectionMode.InliningDistance))
		{
			_serviceRegistrator.RegisterInstance<IChartRender>(() => new InliningDistanceEvaluationChartRender(_chart),
				_chart.Name + ParametersSelectionMode.InliningDistance);
		}
		
		_serviceRegistrator.RegisterInstance<ParametersSelectionRenderingHandler>(() => new ParametersSelectionRenderingHandler(_chart));

	}
}