using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Models.ChartRenderModels;

namespace TrafficFlowSimulation.Renders.ChartRenders;

public interface IChartRender
{
	public void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings);

	public void UpdateChart(object parameters);

	public void UpdateEnvironment(object parameters);

	public void ShowChartLegend(LegendStyle? legendStyle);

	public void SetChartAreaAxisTitle(bool isHidden = false);

	public void SetMarkerImage(List<double> carsLength);

	public void AddSeries(int index);
}