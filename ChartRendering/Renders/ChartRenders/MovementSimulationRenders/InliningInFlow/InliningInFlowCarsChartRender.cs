using System;
using System.Drawing;
using System.Linq;
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
	protected override string ColorPalette => "RedAndBlue";

	public InliningInFlowCarsChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var settings = (InliningInFlowModeSettingsModel)modeSettings;

		base.RenderChart(modelParameters, modeSettings);

		Chart.Series.Clear();
		Chart.Legends.Clear();

		for (var i = 0; i < modelParameters.n1; i++)
		{
			Chart.Series.Add(new Series
			{
				Name = SeriesName + i,
				ChartType = SeriesChartType,
				ChartArea = GetChartArea().Name,
				BorderWidth = 2,
				Color = CustomColors.Blue,
				Tag = 1
			});
		}

		for (var i = modelParameters.n1; i < modelParameters.n1 + modelParameters.n2; i++)
		{
			Chart.Series.Add(new Series
			{
				Name = SeriesName + i,
				ChartType = SeriesChartType,
				ChartArea = GetChartArea().Name,
				BorderWidth = 2,
				Color = CustomColors.Red,
				Tag = 2
			});

			if (i == modelParameters.n1 + settings.Number)
				Chart.Series.Last().Color = CustomColors.DarkGreen;
		}

		foreach (var series in Chart.Series.Where(x => x.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			var showLegend = false;
			if (modelParameters.lambda[i] > GetChartArea().AxisX.Minimum && modelParameters.lambda[i] < GetChartArea().AxisX.Maximum)
			{
				if ((int) series.Tag == 1)
					series.Points.AddXY(modelParameters.lambda[i], 3 * Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 4);
				else
					series.Points.AddXY(modelParameters.lambda[i], Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 2);

				showLegend = true;
			}

			UpdateLegend(series, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
			UpdateLabel(series, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
		}

		RenderChartEnvironment(modelParameters, modeSettings);
		SetMarkerImage(modelParameters.lCar);
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
		foreach (var series in Chart.Series.Where(series => series.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			var showLegend = false;
			if (series.Points.Any())
				series.Points.RemoveAt(0);
			if (coordinates.X[i] > GetChartArea().AxisX.Minimum)
			{
				if ((int) series.Tag == 1)
					series.Points.AddXY(coordinates.X[i], 3 * Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 4);
				else
					series.Points.AddXY(coordinates.X[i], Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 2);

				showLegend = true;
			}

			UpdateLegend(series, showLegend, coordinates.Y[i], coordinates.X[i]);
			UpdateLabel(series, showLegend, coordinates.Y[i], coordinates.X[i]);
		}

		UpdateChartEnvironment(coordinates.X, coordinates.T);
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
				Maximum = 500
			},
			IsZoomAvailable = true
		};
		var chartArea = ChartAreaRendersHelper.CreateChartArea(model);

		return chartArea;
	}

	protected override Legend CreateLegend(LegendStyle legendStyle, ModelParameters? modelParameters = null, BaseSettingsModels modeSettings = null)
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
		var settings = (InliningInFlowModeSettingsModel) modeSettings;

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

		var endLineSeries = new Series
		{
			Name = "EndLine",
			ChartType = SeriesChartType.Line,
			ChartArea = ChartAreaName,
			BorderWidth = 2,
			Color = Color.Red,
			IsVisibleInLegend = false
		};
		endLineSeries.Points.Add(new DataPoint(settings.Lenght, 1));
		endLineSeries.Points.Add(new DataPoint(settings.Lenght, 0));

		return new[]
		{
			startLineSeries,
			endLineSeries
		};
	}

	public override void AddSeries(ModelParameters modelParameters, int indexFrom, int indexTo)
	{
		var s = Chart.Series[indexFrom];
		s.Name = SeriesName + "-1";
		s.Tag = 1;

		Chart.Series.RemoveAt(indexFrom);
		Chart.Series.Insert(indexTo, s);

		var i = 0;
		Chart.Series.Where(x => int.TryParse(x.Name.Replace(SeriesName, ""), out _)).ForEach(x => x.Name = "tmp" + x.Name);
		Chart.Series.Where(x => int.TryParse(x.Name.Replace("tmp" + SeriesName, ""), out _)).ForEach(x => x.Name = SeriesName + i++);
	}
}