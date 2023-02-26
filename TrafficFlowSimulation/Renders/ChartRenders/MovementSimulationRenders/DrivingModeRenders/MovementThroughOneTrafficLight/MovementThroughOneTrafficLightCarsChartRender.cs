﻿using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using Localization;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Properties.LocalizationResources;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.Models;

namespace TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.MovementThroughOneTrafficLight;

public class MovementThroughOneTrafficLightCarsChartRender : CarsChartRender
{
	private readonly ChartAreaModel _chartAreaModel = new()
	{
		AxisXMinimum = CommonChartAreaParameters.BeginOfRoad,
		AxisXMaximum = CommonChartAreaParameters.EndOfRoad,
		AxisXInterval = 10,
		AxisYMinimum = 0,
		AxisYMaximum = 1,
		AxisYInterval = 1,
		ZoomShift = 48
	};

	public MovementThroughOneTrafficLightCarsChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		_chart.Legends.Clear();

		foreach (var series in _chart.Series.Where(x => x.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));

			var showLegend = false;
			if (modelParameters.lambda[i] > _chartAreaModel.AxisXMinimum && modelParameters.lambda[i] < _chartAreaModel.AxisXMaximum)
			{
				_chart.Series[i].Points.AddXY(modelParameters.lambda[i], _chart.ChartAreas[_chartAreaName].AxisY.Maximum / 2);
				showLegend = true;
			}
			
			UpdateLegend(i, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
			UpdateLabel(i, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
		}

		SetMarkerImage();
	}

	public override void UpdateChart(object parameters)
	{
		var cm = (CoordinatesModel) parameters;

		foreach (var series in _chart.Series.Where(series => series.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));

			var showLegend = false;
			if(_chart.Series[i].Points.Any())
				_chart.Series[i].Points.RemoveAt(0);
			if (cm.x[i] > _chartAreaModel.AxisXMinimum && cm.x[i] < _chartAreaModel.AxisXMaximum)
			{
				_chart.Series[i].Points.AddXY(cm.x[i], _chart.ChartAreas[_chartAreaName].AxisY.Maximum / 2);
				showLegend = true;
			}

			UpdateLegend(i, showLegend, cm.y[i], cm.x[i]);
			UpdateLabel(i, showLegend, cm.y[i], cm.x[i]);
		}
	}

	public override void UpdateEnvironment(object parameters)
	{
		var environmentModel = (EnvironmentModel) parameters;
		var trafficLine = _chart.Series.First(series => series.Name.Contains("StartLine"));
		trafficLine.Color = environmentModel.IsGreenLight ? Color.Green : Color.Red;

		var timePoint = _chart.Series.First(series => series.Name.Contains("TimePoint"));
		timePoint.LabelForeColor = environmentModel.IsGreenLight ? Color.Green : Color.Red;
		timePoint.Label = environmentModel.IsGreenLight 
			? Math.Round(environmentModel.GreenTime, 2).ToString()
			: Math.Round(environmentModel.RedTime, 2).ToString();
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var chartArea = new ChartArea
		{
			Name = _chartAreaName,
			AxisX = new Axis
			{
				Minimum = _chartAreaModel.AxisXMinimum,
				Maximum = _chartAreaModel.AxisXMaximum,
				ScaleView = new AxisScaleView
				{
					//Zoomable = true,
					SizeType = DateTimeIntervalType.Number,
					MinSize = 30
				},
				Interval = _chartAreaModel.AxisXInterval,
				ScrollBar = new AxisScrollBar
				{
					ButtonStyle = ScrollBarButtonStyles.SmallScroll,
					IsPositionedInside = true,
					BackColor = Color.White,
					ButtonColor = Color.FromArgb(249, 246, 247)
				},
				IsStartedFromZero = true,
				Title = LocalizationHelper.Get<ChartResources>().DistanceAxisTitleText,
				TitleFont = new Font("Microsoft Sans Serif", 10F),
				TitleAlignment = StringAlignment.Far
			},
			AxisY = new Axis
			{
				Minimum = _chartAreaModel.AxisYMinimum,
				Maximum = _chartAreaModel.AxisYMaximum,
				Interval = _chartAreaModel.AxisYInterval,
				LabelStyle = new LabelStyle
				{
					Enabled = false
				}
			}
		};

		//chartArea.AxisX.ScaleView.Zoom(_chartAreaModel.AxisXMinimum,_chartAreaModel.AxisXMinimum + _chartAreaModel.ZoomShift);

		return chartArea;
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var startLineSeries = new Series
		{
			Name = "StartLine",
			ChartType = SeriesChartType.Line,
			ChartArea = _chartAreaName,
			BorderWidth = 2,
			Color = Color.Red,
			IsVisibleInLegend = false
		};
		startLineSeries.Points.Add(new DataPoint(0, 1));
		startLineSeries.Points.Add(new DataPoint(0.00001, 0));

		var timePointSeries = new Series()
		{
			Name = "TimePoint",
			ChartType = SeriesChartType.Point,
			ChartArea = _chartAreaName,
			BorderWidth = 2,
			Color = Color.Transparent,
			IsVisibleInLegend = false,
			Label = "0",
			LabelForeColor = Color.Red,
			Font = new Font("Microsoft Sans Serif", 10F)
		};
		timePointSeries.Points.Add(new DataPoint(1, 1));

		return new[]
		{
			startLineSeries,
			timePointSeries
		};
	}


	protected override string GetLegendText(params double[] values)
	{
		var sb = new StringBuilder();

		sb.Append(LocalizationHelper.Get<ChartResources>().SpeedText + " ");
		sb.Append(Math.Round(values[0], 2));
		sb.Append("\n");
		sb.Append(LocalizationHelper.Get<ChartResources>().DistanceText + " ");
		sb.Append(Math.Round(values[1], 2));
		return sb.ToString();
	}
}