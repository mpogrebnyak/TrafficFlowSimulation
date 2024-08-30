using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Helpers;
using ChartRendering.Models;
using EvaluationKernel.Models;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.MovementThroughMultipleTrafficLights;

public class MovementThroughMultipleTrafficLightsCarsChartRender : CarsChartRender
{
	public MovementThroughMultipleTrafficLightsCarsChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		Chart.Legends.Clear();

		foreach (var series in Chart.Series.Where(x => x.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			var showLegend = false;
			if (modelParameters.lambda[i] > GetChartArea().AxisX.Minimum && modelParameters.lambda[i] < GetChartArea().AxisX.Maximum)
			{
				series.Points.AddXY(modelParameters.lambda[i], Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 2);
				showLegend = true;
			}

			UpdateLegend(series, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
			UpdateLabel(series, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
		}

		SetMarkerImage(modelParameters.lCar);
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
		foreach (var series in Chart.Series.Where(series => series.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			if(series.Points.Any())
				series.Points.RemoveAt(0);

			var showLegend = false;
			if (coordinates.X[i] > GetChartArea().AxisX.Minimum && coordinates.X[i] < GetChartArea().AxisX.Maximum)
			{
				series.Points.AddXY(coordinates.X[i], Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 2);
				showLegend = true;
			}

			UpdateLegend(series, showLegend, coordinates.Y[i], coordinates.X[i]);
			UpdateLabel(series, showLegend, coordinates.Y[i], coordinates.X[i]);
		}
		UpdateChartEnvironment(coordinates.X, coordinates.T);
	}

	public override void UpdateEnvironment(object parameters)
	{
		var environmentModels = (MultipleTrafficLightsEnvironmentArgs) parameters;

		foreach (var model in environmentModels.TrafficLight.Select((value, i) => new { i, value }))
		{
			var trafficLine = Chart.Series.First(series => series.Name.Contains("TrafficLight" + model.i));
			trafficLine.Color = model.value.IsGreenLight ? Color.Green : Color.Red;

			var timePoint = Chart.Series.First(series => series.Name.Contains("TimePoint" + model.i));
			timePoint.LabelForeColor = model.value.IsGreenLight ? Color.Green : Color.Red;
			timePoint.Label = Math.Round(model.value.Time, 2).ToString();
		}
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var settings = (MovementThroughMultipleTrafficLightsModeSettingsModel) modeSettings;
		var trafficLightsParameters = settings.MapTo();

		var model = new ChartAreaCreationModel
		{
			Name = ChartAreaName,
			AxisX = new Axis
			{
				Minimum = -30,
				Maximum = trafficLightsParameters.TrafficLightsPosition.Last() + 99
			},
			IsZoomAvailable = true
		};
		var chartArea = ChartAreaRendersHelper.CreateChartArea(model);

		return chartArea;
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var settings = (MovementThroughMultipleTrafficLightsModeSettingsModel) modeSettings;
		var trafficLightsParameters = settings.MapTo();

		var environmentSeriesList = new List<Series>();
		for (var i = 0; i < settings.TrafficLightsNumber; i++)
		{
			var startLineSeries = new Series
			{
				Name = "TrafficLight" + i,
				ChartType = SeriesChartType.Line,
				ChartArea = ChartAreaName,
				BorderWidth = 2,
				Color = Color.Red,
				IsVisibleInLegend = false
			};
			startLineSeries.Points.Add(new DataPoint(trafficLightsParameters.TrafficLightsPosition[i], 1));
			startLineSeries.Points.Add(new DataPoint(trafficLightsParameters.TrafficLightsPosition[i], 0));
			environmentSeriesList.Add(startLineSeries);

			var timePointSeries = new Series
			{
				Name = "TimePoint" + i,
				ChartType = SeriesChartType.Point,
				ChartArea = ChartAreaName,
				BorderWidth = 2,
				Color = Color.Transparent,
				IsVisibleInLegend = false,
				Label = "0",
				LabelForeColor = Color.Red,
				Font = new Font("Microsoft Sans Serif", 10F)
			};
			timePointSeries.Points.Add(new DataPoint(trafficLightsParameters.TrafficLightsPosition[i] + 1, 1));
			environmentSeriesList.Add(timePointSeries);
		}

		return environmentSeriesList.ToArray();
	}

	protected override void RenderTrafficCapacity(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var settings = (MovementThroughMultipleTrafficLightsModeSettingsModel) modeSettings;
		var trafficLightsParameters = settings.MapTo();

		var roundTimeList = new List<int>();
		for (var i = 0; i < settings.TrafficLightsNumber; i++)
		{
			roundTimeList.Add((int)(trafficLightsParameters.TrafficLightsGreenTime[i] + trafficLightsParameters.TrafficLightsRedTime[i]));
		}

		TrafficCapacityHelper.RenderTrafficCapacity(Chart.Series, ChartAreaName, roundTimeList);
	}
}