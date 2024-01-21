using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Properties;
using EvaluationKernel.Models;
using Localization;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders;

public abstract class DistanceChartRender : ChartsRender
{
	protected override SeriesChartType SeriesChartType => SeriesChartType.Spline;

	protected override string SeriesName => "DistanceSeries";

	protected override string ChartAreaName => "DistanceChartArea";

	protected override bool IsTimeAutomaticallyIncrease => true;

	protected DistanceChartRender(Chart chart) : base(chart)
	{
	}

	public override void SetChartAreaAxisTitle(bool isHidden = false)
	{
		if (Chart.ChartAreas.Any())
		{
			if (isHidden)
			{
				Chart.ChartAreas[0].AxisX.Title = string.Empty;
				Chart.ChartAreas[0].AxisY.Title = string.Empty;
			}
			else
			{
				Chart.ChartAreas[0].AxisX.Title = LocalizationHelper.Get<ChartRenderingResources>().TimeAxisTitleText;
				Chart.ChartAreas[0].AxisY.Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceAxisTitleText;
			}
		}
	}

	protected override Legend CreateLegend(LegendStyle legendStyle, ModelParameters? modelParameters = null)
	{
		return new Legend
		{
			Name = "Legend",
			Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceChartLegendTitleText,
			TitleFont = new Font("Microsoft Sans Serif", 10F),
			LegendStyle = legendStyle,
			Font = new Font("Microsoft Sans Serif", 10F),
		};
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		return new Series[] { };
	}
}