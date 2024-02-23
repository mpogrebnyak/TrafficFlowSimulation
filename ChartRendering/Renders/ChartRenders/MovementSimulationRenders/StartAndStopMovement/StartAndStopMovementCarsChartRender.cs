using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Helpers;
using ChartRendering.Models;
using EvaluationKernel.Models;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.StartAndStopMovement;

public class StartAndStopMovementCarsChartRender : CarsChartRender
{
	public StartAndStopMovementCarsChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		Chart.Legends.Clear();

		foreach (var series in Chart.Series.Where(x => x.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));
			var chartArea = GetChartArea();

			var showLegend = false;
			if (modelParameters.lambda[i] > chartArea.AxisX.Minimum && modelParameters.lambda[i] < chartArea.AxisX.Maximum)
			{
				GetSeries(i).Points.AddXY(modelParameters.lambda[i], Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 2);
				showLegend = true;
			}

			UpdateLegend(i, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
			UpdateLabel(i, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
		}

		SetMarkerImage(modelParameters.lCar);
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
		foreach (var series in Chart.Series.Where(series => series.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			var showLegend = false;
			if (GetSeries(i).Points.Any())
				GetSeries(i).Points.RemoveAt(0);
			if (coordinates.X[i] > GetChartArea().AxisX.Minimum)
			{
				GetSeries(i).Points.AddXY(coordinates.X[i], Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 2);
				showLegend = true;
			}

			UpdateLegend(i, showLegend, coordinates.Y[i], coordinates.X[i]);
			UpdateLabel(i, showLegend, coordinates.Y[i], coordinates.X[i]);
		}
		UpdateChartEnvironment(coordinates.X, coordinates.T);
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var model = new ChartAreaCreationModel
		{
			Name = ChartAreaName,
			AxisX = new Axis
			{
				Minimum = -30,
				Maximum = modelParameters.L + 100
			},
			IsZoomAvailable = true
		};
		var chartArea = ChartAreaRendersHelper.CreateChartArea(model);

		return chartArea;
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var startLineSeries = RenderingHelper.CreateLineSeries("StartLine", Color.Red);
		startLineSeries.Points.Add(new DataPoint(0, 0));
		startLineSeries.Points.Add(new DataPoint(0, 1));

		var endLineSeries = RenderingHelper.CreateLineSeries("EndLine", Color.Red);
		endLineSeries.Points.Add(new DataPoint(modelParameters.L, 0));
		endLineSeries.Points.Add(new DataPoint(modelParameters.L, 1));

		return new[]
		{
			startLineSeries,
			endLineSeries
		};
	}
}