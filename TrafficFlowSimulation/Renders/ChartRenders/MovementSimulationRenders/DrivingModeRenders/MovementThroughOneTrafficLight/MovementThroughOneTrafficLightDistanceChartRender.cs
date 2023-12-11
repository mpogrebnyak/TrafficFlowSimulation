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

namespace TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.MovementThroughOneTrafficLight;

public class MovementThroughOneTrafficLightDistanceChartRender : DistanceChartRender
{
	private readonly ChartAreaModel _chartAreaModel = new()
	{
		AxisXMinimum = 0,
		AxisXMaximum = 60,
		AxisXInterval = 10,
		AxisYMinimum = CommonChartAreaParameters.BeginOfRoad,
		AxisYMaximum = CommonChartAreaParameters.EndOfRoad,
		AxisYInterval = 1,
		//ZoomShift = 48
	};

	public MovementThroughOneTrafficLightDistanceChartRender(Chart chart) : base(chart)
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

			UpdateLegend(i, true, modelParameters.lambda[i]);
		}
	}

	public override void UpdateChart(object parameters)
	{
		var cm = (CoordinatesModel) parameters;

		foreach (var series in _chart.Series.Where(series => series.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));

			var showLegend = false;
			if (cm.x[i] > _chartAreaModel.AxisYMinimum && cm.x[i] < _chartAreaModel.AxisYMaximum)
			{
				_chart.Series[i].Points.AddXY(cm.t, cm.x[i]);
				showLegend = true;
			}

			UpdateLegend(i, showLegend, cm.x[i]);
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
				//Maximum = modelParameters.L + 100,
				Title = LocalizationHelper.Get<ChartResources>().DistanceAxisTitleText,
				TitleFont = new Font("Microsoft Sans Serif", 10F),
				TitleAlignment = StringAlignment.Far
			}
		};
	}
}