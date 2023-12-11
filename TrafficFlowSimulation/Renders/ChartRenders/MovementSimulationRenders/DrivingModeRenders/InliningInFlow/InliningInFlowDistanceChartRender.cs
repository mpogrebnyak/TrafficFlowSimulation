using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using Localization;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Models.ChartRenderModels;
using TrafficFlowSimulation.Properties.LocalizationResources;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.Models;

namespace TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.InliningInFlow;

public class InliningInFlowDistanceChartRender : InliningInFlowChartRender
{
	protected override SeriesChartType _seriesChartType => SeriesChartType.Spline;

	protected override string _seriesName => "DistanceSeries";

	protected override string _chartAreaName => "DistanceChartArea";

	private readonly ChartAreaModel _chartAreaModel = new()
	{
		AxisXMinimum = 0,
		AxisXMaximum = 60,
		AxisXInterval = 10,
		AxisYMinimum = CommonChartAreaParameters.BeginOfRoad,
		AxisYMaximum = CommonChartAreaParameters.EndOfRoad,
		AxisYInterval = 1,
		ZoomShift = 48
	};

	public InliningInFlowDistanceChartRender(Chart chart) : base(chart)
	{
	}
	
	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		foreach (var series in _chart.Series.Where(x => x.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));

			if (i == 0)
				_chart.Series[i].Points.AddXY(0, modelParameters.lambda[i]);

			var lambda = i < modelParameters.lambda.Count
				? modelParameters.lambda[i]
				: 0;

			UpdateLegend(i, true, lambda);
		}
	}

	public override void UpdateChart(object parameters)
	{
		var cm = (CoordinatesModel) parameters;

		foreach (var series in _chart.Series.Where(series => series.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));

			if (i < cm.x.Count)
			{
				var showLegend = false;
				if (cm.x[i] > CommonChartAreaParameters.BeginOfRoad && cm.x[i] < CommonChartAreaParameters.EndOfRoad)
				{
					_chart.Series[i].Points.AddXY(cm.t, cm.x[i]);
					showLegend = true;
				}

				UpdateLegend(i, showLegend, cm.x[i]);
			}
		}
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
				_chart.ChartAreas[0].AxisY.Title = LocalizationHelper.Get<ChartResources>().DistanceAxisTitleText;
			}
		}
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		return new ChartArea
		{
			Name = _chartAreaName,
			AxisX = new Axis
			{
				Minimum = _chartAreaModel.AxisXMinimum,
				Maximum = _chartAreaModel.AxisXMaximum,
				Title = LocalizationHelper.Get<ChartResources>().TimeAxisTitleText,
				TitleFont = new Font("Microsoft Sans Serif", 10F),
				TitleAlignment = StringAlignment.Far
			},
			AxisY = new Axis
			{
				Minimum = _chartAreaModel.AxisYMinimum,
				Maximum = _chartAreaModel.AxisYMaximum,
				Title = LocalizationHelper.Get<ChartResources>().DistanceAxisTitleText,
				TitleFont = new Font("Microsoft Sans Serif", 10F),
				TitleAlignment = StringAlignment.Far
			}
		};
	}

	protected override Legend CreateLegend(LegendStyle legendStyle)
	{
		return new Legend
		{
			Name = "Legend",
			Title = LocalizationHelper.Get<ChartResources>().DistanceChartLegendTitleText,
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