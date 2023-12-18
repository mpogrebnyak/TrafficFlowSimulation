using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Models;
using ChartRendering.Renders.ChartRenders;
using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;
using Modes;
using Modes.Constants;

namespace TrafficFlowSimulation.Handlers;

public class ParametersSelectionRenderingHandler
{
	private Chart _chart { get; set; }

	private ParametersSelectionMode _parametersSelectionMode { get; set; }

	private IChartRender _provider { get; set; }

	public ParametersSelectionRenderingHandler(Chart chart)
	{
		_chart = chart;
		_parametersSelectionMode = ModesHelper.GetCurrentParametersSelectionMode();
		_provider = ServiceLocator.Current.GetInstance<IChartRender>(chart.Name + _parametersSelectionMode);
	}

	public void ChangeParametersSelectionMode(ParametersSelectionMode parametersSelectionMode)
	{
		_parametersSelectionMode = parametersSelectionMode;
		_provider = ServiceLocator.Current.GetInstance<IChartRender>(_chart.Name + _parametersSelectionMode);
	}

	public void UpdateChart(CoordinatesArgs coordinates)
	{
		_provider.UpdateChart(coordinates);
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