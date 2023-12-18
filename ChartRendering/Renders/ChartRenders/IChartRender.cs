using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Models;
using EvaluationKernel.Models;

namespace ChartRendering.Renders.ChartRenders;

public interface IChartRender
{
	public void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings);

	public void UpdateChart(CoordinatesArgs coordinates);

	public void UpdateEnvironment(object parameters);

	public void ShowChartLegend(LegendStyle? legendStyle);

	public void SetChartAreaAxisTitle(bool isHidden = false);

	public void SetMarkerImage(object? parameters = null);

	public void AddSeries(int index);
}