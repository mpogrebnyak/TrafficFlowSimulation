using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Helpers;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders.Models;
using EvaluationKernel.Models;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.SpeedLimitChanging;

public class SpeedLimitChangingCarsChartRender : CarsChartRender
{
	public SpeedLimitChangingCarsChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		_chart.Legends.Clear();

		var segment = GetSegmentList((SpeedLimitChangingModeSettingsModel)modeSettings);

		foreach (var series in _chart.Series.Where(x => x.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));

			var showLegend = false;
			if (modelParameters.lambda[i] > segment.First() - 100 && modelParameters.lambda[i] < segment.Last() + 100)
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
		var segment = GetSegmentList((SpeedLimitChangingModeSettingsModel)modeSettings);

		var model = new ChartAreaCreationModel
		{
			Name = _chartAreaName,
			AxisX = new Axis
			{
				Minimum = segment.First() - 100,
				Maximum = segment.Last() + 100,
				ScaleView = ChartAreaRendersHelper.GetScaleView,
				ScrollBar = ChartAreaRendersHelper.GetScrollBar
			}
		};
		var chartArea = ChartAreaRendersHelper.CreateChartArea(model);

		return chartArea;
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var settings = (SpeedLimitChangingModeSettingsModel)modeSettings;

		var segmentSpeeds = new SortedDictionary<int, SegmentModel>();
		settings.MapTo(segmentSpeeds);

		var series = new List<Series>();
		foreach (var segment in segmentSpeeds)
		{
			var segmentSeries = new Series
			{
				Name = "SegmentBegin" + segment.Key,
				ChartType = SeriesChartType.Line,
				ChartArea = _chartAreaName,
				BorderWidth = 2,
				Color = Color.Blue,
				IsVisibleInLegend = false
			};
			segmentSeries.Points.Add(new DataPoint(segment.Value.SegmentBeginning, 0));
			segmentSeries.Points.Add(new DataPoint(segment.Value.SegmentBeginning, 1));

			series.Add(segmentSeries);
		}

		return series.ToArray();
	}

	private List<double> GetSegmentList(SpeedLimitChangingModeSettingsModel settings)
	{
		var segmentSpeeds = new SortedDictionary<int, SegmentModel>();
		settings.MapTo(segmentSpeeds);

		return segmentSpeeds
			.Where(x => x.Key != 0 && x.Key != settings.SegmentsNumber + 1)
			.Select(x=> x.Value.SegmentBeginning)
			.ToList();;
	}
}