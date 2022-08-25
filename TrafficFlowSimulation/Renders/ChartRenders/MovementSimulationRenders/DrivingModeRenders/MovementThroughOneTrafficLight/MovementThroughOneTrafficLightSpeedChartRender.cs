using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using Localization;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Models;
using TrafficFlowSimulation.Properties.LocalizationResources;

namespace TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.MovementThroughOneTrafficLight;

public class MovementThroughOneTrafficLightSpeedChartRender : ChartsRender
{
	protected override SeriesChartType _seriesChartType => SeriesChartType.Spline;

	protected override string _seriesName => "SpeedSeries";

	protected override string _chartAreaName => "SpeedChartArea";

	private readonly ChartAreaModel _chartAreaModel = new()
	{
		AxisXMinimum = 0,
		AxisXMaximum = 60,
		AxisYMinimum = 0,
	//	ZoomShift = 40
	};

	public MovementThroughOneTrafficLightSpeedChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters)
	{
		base.RenderChart(modelParameters);

		foreach (var series in _chart.Series.Where(x => x.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));
			if (i == 0)
				_chart.Series[i].Points.AddXY(0, 0);

			UpdateLegend(i, true, 0);
		}
	}

	public override void UpdateChart(List<double> t = null!, List<double> x = null!, List<double> y = null!)
	{
		foreach (var series in _chart.Series.Where(series => series.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));

			var showLegend = false;
			if (x[i] > CommonChartAreaParameters.BeginOfRoad && x[i] < CommonChartAreaParameters.EndOfRoad)
			{
				_chart.Series[i].Points.AddXY(t.Single(), y[i]);
				showLegend = true;
			}

			UpdateLegend(i, showLegend, y[i]);
		}
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters)
	{
		var chartArea = new ChartArea
		{
			Name = _chartAreaName,
			AxisX = new Axis
			{
				Minimum = _chartAreaModel.AxisXMinimum,
				Maximum = _chartAreaModel.AxisXMaximum,
				Title = LocalizationHelper.Get<MenuResources>().TimeAxisTitleText,
				TitleFont = new Font("Microsoft Sans Serif", 10F),
				TitleAlignment = StringAlignment.Far,
				ScaleView = new AxisScaleView
				{
					Zoomable = true,
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
				}
			},
			AxisY = new Axis
			{
				Minimum = _chartAreaModel.AxisYMinimum,
				Maximum = RenderingHelper.CalculateMaxSpeed(modelParameters.Vmax),
				Title = LocalizationHelper.Get<MenuResources>().SpeedAxisTitleText,
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
			Title = LocalizationHelper.Get<MenuResources>().SpeedChartLegendTitleText,
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
				_chart.ChartAreas[0].AxisX.Title = LocalizationHelper.Get<MenuResources>().TimeAxisTitleText;
				_chart.ChartAreas[0].AxisY.Title = LocalizationHelper.Get<MenuResources>().SpeedAxisTitleText;
			}
		}
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters)
	{
		return new Series[] { };
	}
}