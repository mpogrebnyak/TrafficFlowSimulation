using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Helpers;
using ChartRendering.Models;
using EvaluationKernel.Models;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.StartAndStopMovement;

public class StartAndStopMovementCarsChartRender : CarsChartRender
{
	public StartAndStopMovementCarsChartRender(Chart chart) : base(chart)
	{
	}
	
	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		_chart.Legends.Clear();

		foreach (var series in _chart.Series.Where(x => x.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));
			var chartArea = GetChartArea(_chartAreaName);

			var showLegend = false;
			if (modelParameters.lambda[i] > chartArea.AxisX.Minimum && modelParameters.lambda[i] < chartArea.AxisX.Maximum)
			{
				_chart.Series[i].Points.AddXY(modelParameters.lambda[i], _chart.ChartAreas[_chartAreaName].AxisY.Maximum / 2);
				showLegend = true;
			}

			UpdateLegend(i, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
			UpdateLabel(i, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
		}

		SetMarkerImage(modelParameters.lCar);

		//var x = cm.x;
		//var scaleView = _chart.ChartAreas[0].AxisX.ScaleView;
		//scaleView.Scroll(Math.Round(x[modeSettings.ScrollFor]) - 25);
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
		foreach (var series in _chart.Series.Where(series => series.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));

			var showLegend = false;
			if(_chart.Series[i].Points.Any())
				_chart.Series[i].Points.RemoveAt(0);
			if (coordinates.x[i] > GetChartArea(_chartAreaName).AxisX.Minimum)
			{
				_chart.Series[i].Points.AddXY(coordinates.x[i], _chart.ChartAreas[_chartAreaName].AxisY.Maximum / 2);
				showLegend = true;
			}

			UpdateLegend(i, showLegend, coordinates.y[i], coordinates.x[i]);
			UpdateLabel(i, showLegend, coordinates.y[i], coordinates.x[i]);
		}
		UpdateChartEnvironment(coordinates.x, coordinates.t);
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var model = new ChartAreaCreationModel
		{
			Name = _chartAreaName,
			AxisX = new Axis
			{
				Minimum = -30,
				Maximum = modelParameters.L + 100,
				ScaleView = ChartAreaRendersHelper.GetScaleView,
				ScrollBar = ChartAreaRendersHelper.GetScrollBar
			}
		};
		var chartArea = ChartAreaRendersHelper.CreateChartArea(model);

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
}