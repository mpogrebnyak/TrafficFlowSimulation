using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using Localization;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Models;
using TrafficFlowSimulation.Properties.LocalizationResources;

namespace TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.StartAndStopMovement;

public class StartAndStopMovementCarsChartRender : ChartsRender
{
	protected override SeriesChartType _seriesChartType => SeriesChartType.Point;

	protected override string _seriesName => "CarsMovementSeries";

	protected override string _chartAreaName => "CarsMovementChartArea";

	private readonly ChartAreaModel _chartAreaModel = new()
	{
		AxisXMinimum = -30,
		AxisXMaximum = 10,
		AxisXInterval = 10,
		AxisYMinimum = 0,
		AxisYMaximum = 1,
		AxisYInterval = 1,
		ZoomShift = 48
	};

	public StartAndStopMovementCarsChartRender(Chart chart) : base(chart)
	{
	}
	
	public override void RenderChart(ModelParameters modelParameters)
	{
		base.RenderChart(modelParameters);

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

	public override void UpdateChart(List<double> t = null!, List<double> x = null!, List<double> y = null!)
	{
		foreach (var series in _chart.Series.Where(series => series.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));

			var showLegend = false;
			if(_chart.Series[i].Points.Any())
				_chart.Series[i].Points.RemoveAt(0);
			if (x[i] > _chartAreaModel.AxisXMinimum)
			{
				_chart.Series[i].Points.AddXY(x[i], _chart.ChartAreas[_chartAreaName].AxisY.Maximum / 2);
				showLegend = true;
			}

			UpdateLegend(i, showLegend, y[i], x[i]);
			UpdateLabel(i, showLegend, y[i], x[i]);
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
				_chart.ChartAreas[0].AxisX.Title = LocalizationHelper.Get<MenuResources>().TimeAxisTitleText;
			}
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
				Maximum = _chartAreaModel.AxisXMaximum + modelParameters.L,
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
				},
				IsStartedFromZero = true,
				Title = LocalizationHelper.Get<MenuResources>().DistanceAxisTitleText,
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

		chartArea.AxisX.ScaleView.Zoom(_chartAreaModel.AxisXMinimum,_chartAreaModel.AxisXMinimum + _chartAreaModel.ZoomShift);

		return chartArea;
	}

	protected override Legend CreateLegend(LegendStyle legendStyle)
	{
		return new Legend
		{
			Name = "Legend",
			Title = LocalizationHelper.Get<MenuResources>().CarsMovementChartLegendTitleText,
			TitleFont = new Font("Microsoft Sans Serif", 10F),
			LegendStyle = legendStyle,
			Font = new Font("Microsoft Sans Serif", 10F),
		};
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters)
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
		startLineSeries.Points.Add(new DataPoint(0, 0));
		startLineSeries.Points.Add(new DataPoint(0, 1));
			
		var endLineSeries = new Series
		{
			Name = "EndLine",
			ChartType = SeriesChartType.Line,
			ChartArea = _chartAreaName,
			BorderWidth = 2,
			Color = Color.Red,
			IsVisibleInLegend = false
		};
		endLineSeries.Points.Add(new DataPoint(modelParameters.L, 0));
		endLineSeries.Points.Add(new DataPoint(modelParameters.L, 1));

		return new[]
		{
			startLineSeries,
			endLineSeries
		};
	}

	private static string GetCarsMovementChartLegendText(double speed, double position)
	{
		return string.Format(
			LocalizationHelper.Get<MenuResources>().CarsMovementChartLegendText,
			Math.Round(speed, 2).ToString(),
			Math.Round(position, 2).ToString());
	}
}