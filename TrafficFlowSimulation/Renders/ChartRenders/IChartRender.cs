using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.Models;

namespace TrafficFlowSimulation.Renders.ChartRenders;

public interface IChartRender
{
	public void RenderChart(ModelParameters modelParameters);

	public void UpdateChart(object parameters);

	public void UpdateEnvironment(object parameters);

	public void ShowChartLegend(LegendStyle? legendStyle);

	public void SetChartAreaAxisTitle(bool isHidden = false);

	public void SetMarkerImage();

	public void AddSeries(int index);
}