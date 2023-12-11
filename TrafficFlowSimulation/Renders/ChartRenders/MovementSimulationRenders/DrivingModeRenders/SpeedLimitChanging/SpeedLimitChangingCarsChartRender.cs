using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Models.ChartRenderModels;
using TrafficFlowSimulation.Models.ChartRenderModels.SettingsModels;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.Models;

namespace TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.SpeedLimitChanging;

public class SpeedLimitChangingCarsChartRender : CarsChartRender
{
	public SpeedLimitChangingCarsChartRender(Chart chart) : base(chart)
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
			if (modelParameters.lambda[i] > ChartAreaModel.AxisXMinimum && modelParameters.lambda[i] < ChartAreaModel.AxisXMaximum)
			{
				_chart.Series[i].Points.AddXY(modelParameters.lambda[i], _chart.ChartAreas[_chartAreaName].AxisY.Maximum / 2);
				showLegend = true;
			}

			UpdateLegend(i, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
			UpdateLabel(i, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
		}

		SetMarkerImage(modelParameters.lCar);
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
			if (cm.x[i] > ChartAreaModel.AxisXMinimum)
			{
				_chart.Series[i].Points.AddXY(cm.x[i], _chart.ChartAreas[_chartAreaName].AxisY.Maximum / 2);
				showLegend = true;
			}

			UpdateLegend(i, showLegend, cm.y[i], cm.x[i]);
			UpdateLabel(i, showLegend, cm.y[i], cm.x[i]);
		}
		UpdateChartEnvironment(cm.x, cm.t);
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var chartArea = new ChartArea
		{
			Name = _chartAreaName,
			AxisX = new Axis
			{
				Minimum = ChartAreaModel.AxisXMinimum,
				Maximum = ChartAreaModel.AxisXMaximum + modelParameters.L,
				ScaleView = new AxisScaleView
				{
					Zoomable = true,
					SizeType = DateTimeIntervalType.Number,
					MinSize = 30
				},
				Interval = ChartAreaModel.AxisXInterval,
				ScrollBar = new AxisScrollBar
				{
					ButtonStyle = ScrollBarButtonStyles.SmallScroll,
					IsPositionedInside = true,
					BackColor = Color.White,
					ButtonColor = Color.FromArgb(249, 246, 247)
				},
				IsStartedFromZero = true,
				//Title = LocalizationHelper.Get<ChartResources>().DistanceAxisTitleText,
				//TitleFont = new Font("Microsoft Sans Serif", 10F),
				//TitleAlignment = StringAlignment.Far
			},
			AxisY = new Axis
			{
				Minimum = ChartAreaModel.AxisYMinimum,
				Maximum = ChartAreaModel.AxisYMaximum,
				Interval = ChartAreaModel.AxisYInterval,
				LabelStyle = new LabelStyle
				{
					Enabled = false
				}
			}
		};

		chartArea.AxisX.ScaleView.Zoom(ChartAreaModel.AxisXMinimum,ChartAreaModel.AxisXMinimum + ChartAreaModel.ZoomShift);

		return chartArea;
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var settings = (SpeedLimitChangingModeSettingsModel)modeSettings;

/*		var startLineSeries = new Series
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
		
		var segmentBeginSeries = new Series
		{
			Name = "SegmentBegin",
			ChartType = SeriesChartType.Line,
			ChartArea = _chartAreaName,
			BorderWidth = 2,
			Color = Color.Blue,
			IsVisibleInLegend = false
		};
		segmentBeginSeries.Points.Add(new DataPoint(settings.SegmentBeginning, 0));
		segmentBeginSeries.Points.Add(new DataPoint(settings.SegmentBeginning, 1));

		var segmentEndSeries = new Series
		{
			Name = "SegmentEnd",
			ChartType = SeriesChartType.Line,
			ChartArea = _chartAreaName,
			BorderWidth = 2,
			Color = Color.Blue,
			IsVisibleInLegend = false
		};
		segmentEndSeries.Points.Add(new DataPoint(settings.SegmentEnding, 0));
		segmentEndSeries.Points.Add(new DataPoint(settings.SegmentEnding, 1));

		return new[]
		{
			startLineSeries,
			endLineSeries,
			segmentBeginSeries,
			segmentEndSeries
		};*/
		return new Series[]
		{
			
		} ;
	}
}