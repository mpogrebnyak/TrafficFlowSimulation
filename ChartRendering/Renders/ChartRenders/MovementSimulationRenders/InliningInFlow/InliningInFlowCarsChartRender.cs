using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Constants;
using ChartRendering.Helpers;
using ChartRendering.Models;
using ChartRendering.Properties;
using EvaluationKernel.Models;
using Localization;
using Microsoft.Practices.ObjectBuilder2;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.InliningInFlow;

public class InliningInFlowCarsChartRender : CarsChartRender
{
	public InliningInFlowCarsChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		var settings = (InliningInFlowModeSettingsModel)modeSettings;

		Chart.Palette = ChartColorPalette.None;
		Chart.Legends.Clear();

		foreach (var series in Chart.Series.Where(x => x.Name.Contains(SeriesName)))
		{
			series.Color = CustomColors.Blue;
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));
			var chartArea = GetChartArea();

			if (i < modelParameters.n)
			{
				var showLegend = false;
				if (modelParameters.lambda[i] > chartArea.AxisX.Minimum && modelParameters.lambda[i] < chartArea.AxisX.Maximum)
				{
					GetSeries(i).Points.AddXY(modelParameters.lambda[i], Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 2);
					showLegend = true;
				}

				UpdateLegend(i, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
				UpdateLabel(i, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
			}
		}

		var inliningCar = new Series
		{
			Name = SeriesName + modelParameters.n,
			ChartType = SeriesChartType,
			ChartArea = ChartAreaName,
			BorderWidth = 2,
			Color = CustomColors.Red,
		};
		inliningCar.Points.AddXY(0, Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 10);
		Chart.Series.Add(inliningCar);

		var lCars = new List<double>();
		lCars.AddRange(modelParameters.lCar);
		lCars.Add(settings.l_car);

		SetMarkerImage(lCars);
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
		var chartArea = GetChartArea();
		foreach (var series in Chart.Series.Where(series => series.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			if (i < coordinates.X.Count)
			{
				var showLegend = false;
				if(series.Points.Any())
					series.Points.RemoveAt(0);

				if (coordinates.X[i] > chartArea.AxisX.Minimum && coordinates.X[i] < chartArea.AxisX.Maximum)
				{
					var yValue = series.Color == CustomColors.Red
						? CalculateWay(coordinates.X[i])
						: Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 2;
					series.Points.AddXY(coordinates.X[i], yValue);
					showLegend = true;
				}

				UpdateLegend(i, showLegend, coordinates.Y[i], coordinates.X[i]);
				UpdateLabel(i, showLegend, coordinates.Y[i], coordinates.X[i]);
			}
		}
	}

	public override void SetChartAreaAxisTitle(bool isHidden = false)
	{
		if (Chart.ChartAreas.Any())
		{
			if (isHidden)
			{
				Chart.ChartAreas[0].AxisX.Title = string.Empty;
				Chart.ChartAreas[0].AxisY.Title = string.Empty;
			}
			else
			{
				Chart.ChartAreas[0].AxisX.Title = LocalizationHelper.Get<ChartRenderingResources>().TimeAxisTitleText;
			}
		}
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var model = new ChartAreaCreationModel
		{
			Name = ChartAreaName,
			AxisX = new Axis
			{
				Minimum = -30,
				Maximum = 20
			}
		};
		var chartArea = ChartAreaRendersHelper.CreateChartArea(model);

		return chartArea;
	}

	protected override Legend CreateLegend(LegendStyle legendStyle, ModelParameters? modelParameters = null)
	{
		return new Legend
		{
			Name = "Legend",
			Title = LocalizationHelper.Get<ChartRenderingResources>().CarsMovementChartLegendTitleText,
			TitleFont = new Font("Microsoft Sans Serif", 10F),
			LegendStyle = legendStyle,
			Font = new Font("Microsoft Sans Serif", 10F)
		};
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
		startLineSeries.Points.Add(new DataPoint(0.001, 1));
		startLineSeries.Points.Add(new DataPoint(0.001, 0));

		return new[]
		{
			startLineSeries
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

	private double CalculateWay(double x)
	{
		var mainRoad = Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 2;
		var road = Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 10 + x / 25;
		return mainRoad > road
			? road
			: mainRoad;
	}

	public override void AddSeries(ModelParameters modelParameters, int index)
	{
		var seriesToRemove = Chart.Series.Single(x => x.Color == CustomColors.Red);
		Chart.Series.Remove(seriesToRemove);

		var i = Chart.Series.Count(x => x.Name.Contains(SeriesName));
		Chart.Series
			.Where(x => x.Name.Contains(SeriesName))
			.Where(x => Convert.ToInt32(x.Name.Replace(SeriesName, "")) >= index)
			.Reverse()
			.ForEach(x => x.Name = SeriesName + i--);

		Chart.Series.Insert(index,
			new Series
			{
				Name = SeriesName + index,
				ChartType = SeriesChartType,
				ChartArea = ChartAreaName,
				BorderWidth = 2,
				Color = CustomColors.Red
			}
		);

		SetMarkerImage(modelParameters.lCar);
	}
}