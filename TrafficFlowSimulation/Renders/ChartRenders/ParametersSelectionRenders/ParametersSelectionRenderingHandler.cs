using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.Constants.Modes;
using TrafficFlowSimulation.Models;

namespace TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders;

public class ParametersSelectionRenderingHandler
{
	private Chart _chart { get; set; }

	private ParametersSelectionMode _parametersSelectionMode { get; set; }

	private IChartRender _provider { get; set; }

	public ParametersSelectionRenderingHandler(Chart chart)
	{
		_chart = chart;
		_parametersSelectionMode = SettingsHelper.Get<Properties.Settings>().CurrentParametersSelectionMode;
		_provider = ServiceLocator.Current.GetInstance<IChartRender>(chart.Name + _parametersSelectionMode);
	}

	public void ChangeParametersSelectionMode(ParametersSelectionMode parametersSelectionMode)
	{
		_parametersSelectionMode = parametersSelectionMode;
		_provider = ServiceLocator.Current.GetInstance<IChartRender>(_chart.Name + _parametersSelectionMode);
	}

	public void UpdateChart(object parameters)
	{
		_provider.UpdateChart(parameters);
	}

	public void RenderCharts(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		_provider.RenderChart(modelParameters, modeSettings);
	}

	public void UpdateChartEnvironments(object parameters)
	{
		_provider.UpdateEnvironment(parameters);
	}
}