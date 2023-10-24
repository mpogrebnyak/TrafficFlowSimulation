using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using Localization;
using Microsoft.Practices.ObjectBuilder2;
using Settings;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Properties.LocalizationResources;

namespace TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders;

public abstract class CarsChartRender : ChartsRender
{
	protected override SeriesChartType _seriesChartType => SeriesChartType.Point;

	protected override string _seriesName => "CarsMovementSeries";

	protected override string _chartAreaName => "CarsMovementChartArea";

	protected CarsChartRender(Chart chart) : base(chart)
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
				_chart.ChartAreas[0].AxisX.Title = LocalizationHelper.Get<ChartResources>().TimeAxisTitleText;
			}
		}
	}

	protected override Legend CreateLegend(LegendStyle legendStyle)
	{
		return new Legend
		{
			Name = "Legend",
			Title = LocalizationHelper.Get<ChartResources>().CarsMovementChartLegendTitleText,
			TitleFont = new Font("Microsoft Sans Serif", 10F),
			LegendStyle = legendStyle,
			Font = new Font("Microsoft Sans Serif", 10F)
		};
	}

	protected override void RenderChartEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChartEnvironment(modelParameters, modeSettings);

		TrafficCapacityHelper.RenderTrafficCapacity(_chart.Series, _chartAreaName);
	}

	protected void UpdateChartEnvironment(List<double> values, double t)
	{
		TrafficCapacityHelper.UpdateTrafficCapacity(_chart.Series, values, t);
	}
}