﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders.Models;
using EvaluationKernel.Models;
using Localization;
using TrafficFlowSimulation.Properties.LocalizationResources;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.InliningInFlow;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.Models;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.InliningInFlow;

public class InliningInFlowSpeedChartRender : InliningInFlowChartRender
{
	protected override SeriesChartType _seriesChartType => SeriesChartType.Spline;

	protected override string _seriesName => "SpeedSeries";

	protected override string _chartAreaName => "SpeedChartArea";

	private readonly ChartAreaModel _chartAreaModel = new()
	{
		AxisXMinimum = 0,
		AxisXMaximum = 60,
		AxisYMinimum = 0,
		ZoomShift = 40
	};

	public InliningInFlowSpeedChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		foreach (var series in _chart.Series.Where(x => x.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));

			if (i == 0) 
				_chart.Series[i].Points.AddXY(0, 0);

			UpdateLegend(i, true, 0);
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
					_chart.Series[i].Points.AddXY(cm.t, cm.y[i]);
					showLegend = true;
				}

				UpdateLegend(i, showLegend, cm.y[i]);
			}
		}
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
				Title = LocalizationHelper.Get<ChartResources>().TimeAxisTitleText,
				TitleFont = new Font("Microsoft Sans Serif", 10F),
				TitleAlignment = StringAlignment.Far,
				/*
				ScaleView = new AxisScaleView
				{
					Zoomable = true,
					SizeType = DateTimeIntervalType.Number,
					MinSize = 30
				},
				*/
				Interval = _chartAreaModel.AxisXInterval,
				ScrollBar = new AxisScrollBar
				{
					ButtonStyle = ScrollBarButtonStyles.SmallScroll,
					IsPositionedInside = true,
					BackColor = Color.White,
					ButtonColor = Color.FromArgb(249, 246, 247)
				}
			},
			AxisY = new Axis
			{
				Minimum = _chartAreaModel.AxisYMinimum,
				Maximum = RenderingHelper.CalculateMaxSpeed(modelParameters.Vmax),
				Title = LocalizationHelper.Get<ChartResources>().SpeedAxisTitleText,
				TitleFont = new Font("Microsoft Sans Serif", 10F),
				TitleAlignment = StringAlignment.Far
			}
		};

		//chartArea.AxisX.ScaleView.Zoom(_chartAreaModel.AxisXMinimum,_chartAreaModel.AxisXMinimum + _chartAreaModel.ZoomShift);

		return chartArea;
	}

	protected override Legend CreateLegend(LegendStyle legendStyle)
	{
		return new Legend
		{
			Name = "Legend",
			Title = LocalizationHelper.Get<ChartResources>().SpeedChartLegendTitleText,
			TitleFont = new Font("Microsoft Sans Serif", 10F),
			LegendStyle = legendStyle,
			Font = new Font("Microsoft Sans Serif", 10F),
		};
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
				_chart.ChartAreas[0].AxisY.Title = LocalizationHelper.Get<ChartResources>().SpeedAxisTitleText;
			}
		}
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		return new Series[] { };
	}
}