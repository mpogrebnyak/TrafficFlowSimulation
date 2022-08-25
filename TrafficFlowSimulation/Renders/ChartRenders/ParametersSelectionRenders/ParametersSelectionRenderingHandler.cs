using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Renders;
using TrafficFlowSimulation.Services;
using TrafficFlowSimulation.Windows.Models;

namespace TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders;

public class ParametersSelectionRenderingHandler
{
	private Chart _chart { get; set; }

	private ParametersSelectionMode _parametersSelectionMode { get; set; }

	private IChartRender _provider { get; set; }

	public ParametersSelectionRenderingHandler(Chart chart)
	{
		_chart = chart;
		//Сделать дефолтное значение
		_parametersSelectionMode = ParametersSelectionMode.InliningDistance;
		_provider = ServiceLocator.Current.GetInstance<IChartRender>(chart.Name + _parametersSelectionMode);
	}

	public void ChangeParametersSelectionMode(ParametersSelectionMode parametersSelectionMode)
	{
		_parametersSelectionMode = parametersSelectionMode;
		_provider = ServiceLocator.Current.GetInstance<IChartRender>(_chart.Name + _parametersSelectionMode);

		var modelParameters = ServiceLocator.Current.GetInstance<IDefaultParametersValuesService>().GetDefaultModelParameters();
		RenderCharts(modelParameters);
	}
	
	public void UpdateChart(double t, double[] x, double[] y )
	{
		_provider.UpdateChart(new List<double> {t}, x.ToList(), y.ToList());
	}

	public void RenderCharts(ModelParameters modelParameters)
	{
		_provider.RenderChart(modelParameters);
	}
}