using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Properties;
using EvaluationKernel.Models;
using Localization;
using TrafficFlowSimulation.Renders.ChartRenders;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.Models;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders;

public abstract class DistanceChartRender : ChartsRender
{
	protected override SeriesChartType _seriesChartType => SeriesChartType.Spline;

	protected override string _seriesName => "DistanceSeries";

	protected override string _chartAreaName => "DistanceChartArea";

	protected readonly ChartAreaModel ChartAreaModel = new()
	{
		AxisXMinimum = 0,
		AxisXMaximum = 60,
		AxisXInterval = 20,
		AxisYMinimum = 0,
		AxisYMaximum = 0,
	};

	protected DistanceChartRender(Chart chart) : base(chart)
	{
	}

	public override void SetChartAreaAxisTitle(bool isHidden = false)
	{
		if (_chart.ChartAreas.Any())
		{
			if (isHidden)
			{
				_chart.ChartAreas[0].AxisX.Title = string.Empty;
				_chart.ChartAreas[0].AxisY.Title = string.Empty;
			}
			else
			{
				_chart.ChartAreas[0].AxisX.Title = LocalizationHelper.Get<ChartRenderingResources>().TimeAxisTitleText;
				_chart.ChartAreas[0].AxisY.Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceAxisTitleText;
			}
		}
	}

	protected override Legend CreateLegend(LegendStyle legendStyle)
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