using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Helpers;
using ChartRendering.Models;
using ChartRendering.Properties;
using EvaluationKernel.Models;
using Localization;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.MovementThroughOneTrafficLight;

public class MovementThroughOneTrafficLightCarsChartRender : CarsChartRender
{
	public MovementThroughOneTrafficLightCarsChartRender(Chart chart) : base(chart)
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
			if (modelParameters.lambda[i] > GetChartArea(ChartAreaName).AxisX.Minimum && modelParameters.lambda[i] < GetChartArea(ChartAreaName).AxisX.Maximum)
			{
				Chart.Series[i].Points.AddXY(modelParameters.lambda[i], Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 2);
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
			if(Chart.Series[i].Points.Any())
				Chart.Series[i].Points.RemoveAt(0);
			if (coordinates.X[i] > GetChartArea(ChartAreaName).AxisX.Minimum && coordinates.X[i] < GetChartArea(ChartAreaName).AxisX.Maximum)
			{
				Chart.Series[i].Points.AddXY(coordinates.X[i], Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 2);
				showLegend = true;
			}

			UpdateLegend(i, showLegend, coordinates.Y[i], coordinates.X[i]);
			UpdateLabel(i, showLegend, coordinates.Y[i], coordinates.X[i]);
		}
		UpdateChartEnvironment(coordinates.X, coordinates.T);
	}

	public override void UpdateEnvironment(object parameters)
	{
		var environmentModel = (EnvironmentModel) parameters;
		var trafficLine = Chart.Series.First(series => series.Name.Contains("StartLine"));
		trafficLine.Color = environmentModel.IsGreenLight ? Color.Green : Color.Red;

		var timePoint = Chart.Series.First(series => series.Name.Contains("TimePoint"));
		timePoint.LabelForeColor = environmentModel.IsGreenLight ? Color.Green : Color.Red;
		timePoint.Label = environmentModel.IsGreenLight 
			? Math.Round(environmentModel.GreenTime, 2).ToString()
			: Math.Round(environmentModel.RedTime, 2).ToString();
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		
		var model = new ChartAreaCreationModel
		{
			Name = ChartAreaName,
			AxisX = new Axis
			{
				Minimum = -30,
				Maximum = 20,
				Interval = 10
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
			ChartArea = ChartAreaName,
			BorderWidth = 2,
			Color = Color.Red,
			IsVisibleInLegend = false
		};
		startLineSeries.Points.Add(new DataPoint(0, 1));
		startLineSeries.Points.Add(new DataPoint(0.00001, 0));

		var timePointSeries = new Series
		{
			Name = "TimePoint",
			ChartType = SeriesChartType.Point,
			ChartArea = ChartAreaName,
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

		sb.Append(LocalizationHelper.Get<ChartRenderingResources>().SpeedText + " ");
		sb.Append(Math.Round(values[0], 2));
		sb.Append("\n");
		sb.Append(LocalizationHelper.Get<ChartRenderingResources>().DistanceText + " ");
		sb.Append(Math.Round(values[1], 2));
		return sb.ToString();
	}
}