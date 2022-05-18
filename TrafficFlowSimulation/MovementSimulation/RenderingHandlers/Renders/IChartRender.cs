using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Models;

namespace TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Renders;

public interface IChartRender
{
	public void RenderChart(ModelParameters modelParameters);

	public void UpdateChart(List<double> p1 = null!, List<double> p2 = null!, List<double> p3 = null!);

	public void UpdateEnvironment(EnvironmentParametersModel parameters);

	public void ShowChartLegend(LegendStyle? legendStyle);

	public void SetChartAreaAxisTitle(bool isHidden = false);

	public void SetMarkerImage(string path);
}