using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;

namespace TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Renders.InliningInFlow;

public abstract class InliningInFlowChartRender : ChartsRender
{
	protected readonly string _inliningTag = "InliningCar";

	protected InliningInFlowChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters)
	{
		base.RenderChart(modelParameters);

		_chart.Series.Add(new Series
		{
			Name = _seriesName + modelParameters.n,
			ChartType = _seriesChartType,
			ChartArea = _chartAreaName,
			BorderWidth = 2,
			Tag = _inliningTag
		});
	}

	protected static class CommonChartAreaParameters
	{
		public static double BeginOfRoad = -20;

		public static double EndOfRoad = 30;
	}
}