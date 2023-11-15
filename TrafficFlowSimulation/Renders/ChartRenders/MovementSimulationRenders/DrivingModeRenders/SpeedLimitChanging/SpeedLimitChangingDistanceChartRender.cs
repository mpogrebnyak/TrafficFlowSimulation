using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using Localization;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Models.SettingsModels;
using TrafficFlowSimulation.Properties.LocalizationResources;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.Models;

namespace TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.SpeedLimitChanging;

public class SpeedLimitChangingDistanceChartRender : DistanceChartRender
{
	public SpeedLimitChangingDistanceChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		foreach (var series in _chart.Series.Where(x => x.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));
			_chart.Series[i].Points.AddXY(0, modelParameters.lambda[i]);

			UpdateLegend(i, true, modelParameters.lambda[i]);
		}
	}

	public override void UpdateChart(object parameters)
	{
		var cm = (CoordinatesModel) parameters;

		foreach (var series in _chart.Series.Where(series => series.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));
			_chart.Series[i].Points.AddXY(cm.t, cm.x[i]);

			UpdateLegend(i, true, cm.x[i]);
		}
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		return new ChartArea
		{
			Name = _chartAreaName,
			AxisX = new Axis
			{
				Minimum = ChartAreaModel.AxisXMinimum,
				Maximum = ChartAreaModel.AxisXMaximum,
				Interval = ChartAreaModel.AxisXInterval,
				Title = LocalizationHelper.Get<ChartResources>().TimeAxisTitleText,
				TitleFont = new Font("Microsoft Sans Serif", 10F),
				TitleAlignment = StringAlignment.Far
			},
			AxisY = new Axis
			{
				Minimum = ChartAreaModel.AxisYMinimum,
				Maximum = ChartAreaModel.AxisYMaximum + modelParameters.L + 100,
				Title = LocalizationHelper.Get<ChartResources>().DistanceAxisTitleText,
				TitleFont = new Font("Microsoft Sans Serif", 10F),
				TitleAlignment = StringAlignment.Far
			}
		};
	}
	
	protected override Series[] CreateEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var settings = (SpeedLimitChangingModeSettingsModel)modeSettings;

		var segmentBeginSeries = new Series
		{
			Name = "SegmentBegin",
			ChartType = SeriesChartType.Line,
			ChartArea = _chartAreaName,
			BorderWidth = 2,
			Color = Color.Blue,
			IsVisibleInLegend = false
		};
		segmentBeginSeries.Points.Add(new DataPoint(ChartAreaModel.AxisXMinimum,settings.SegmentBeginning));
		segmentBeginSeries.Points.Add(new DataPoint(ChartAreaModel.AxisXMaximum, settings.SegmentBeginning));

		var segmentEndSeries = new Series
		{
			Name = "SegmentEnd",
			ChartType = SeriesChartType.Line,
			ChartArea = _chartAreaName,
			BorderWidth = 2,
			Color = Color.Blue,
			IsVisibleInLegend = false
		};
		segmentEndSeries.Points.Add(new DataPoint(ChartAreaModel.AxisXMinimum, settings.SegmentEnding));
		segmentEndSeries.Points.Add(new DataPoint(ChartAreaModel.AxisXMaximum, settings.SegmentEnding));

		return new[]
		{
			segmentBeginSeries,
			segmentEndSeries
		};
	}
}