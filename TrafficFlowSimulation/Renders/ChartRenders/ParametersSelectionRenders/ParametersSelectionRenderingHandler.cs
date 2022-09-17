using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.Constants;

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
		_parametersSelectionMode = ParametersSelectionMode.InliningDistanceChanging;
		_provider = ServiceLocator.Current.GetInstance<IChartRender>(chart.Name + _parametersSelectionMode);
	}

	public void ChangeParametersSelectionMode(ParametersSelectionMode parametersSelectionMode)
	{
		_parametersSelectionMode = parametersSelectionMode;
		_provider = ServiceLocator.Current.GetInstance<IChartRender>(_chart.Name + _parametersSelectionMode);
	}
	
	public void UpdateChart(List<double> x, List<double>  y)
	{
		_provider.UpdateChart(x, y);
	}

	public void RenderCharts(ModelParameters modelParameters)
	{
		_provider.RenderChart(modelParameters);
	}
}