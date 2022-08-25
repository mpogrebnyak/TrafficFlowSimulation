using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.Models;

namespace TrafficFlowSimulation.Renders.ChartRenders;

public interface IChartRender
{
	public void RenderChart(ModelParameters modelParameters);

	public void UpdateChart(List<double> p1 = null!, List<double> p2 = null!, List<double> p3 = null!);

	public void UpdateEnvironment(EnvironmentParametersModel parameters);

	public void ShowChartLegend(LegendStyle? legendStyle);

	public void SetChartAreaAxisTitle(bool isHidden = false);

	public void SetMarkerImage();

	public void AddSeries(int index);
}