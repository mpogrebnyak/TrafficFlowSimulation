﻿using System;
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
using Settings;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.InliningInFlow;

public class InliningInFlowSpeedChartRender : SpeedChartRender
{
	protected override string ColorPalette => "RedAndBlue";

	protected override bool IsTimeAutomaticallyIncrease => false;

	public InliningInFlowSpeedChartRender(Chart chart) : base(chart)
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

			if (settings.ChangeFirstInliningInFlowCarColor && i == modelParameters.n1 + settings.Number)
				Chart.Series.Last().Color = CustomColors.DarkGreen;
		}

		foreach (var series in Chart.Series.Where(x => x.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			var showLegend = false;
			if (i == 0)
				series.Points.AddXY(0, modelParameters.Vn[i]);

			UpdateLegend(series, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
			UpdateLabel(series, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
		}
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
		base.UpdateChart(coordinates);

		var chartViewMode = SettingsHelper.Get<ChartRenderingSettings>().ChartViewMode;

		foreach (var series in Chart.Series.Where(series => series.Name.Contains(SeriesName)))
		{
			RenderingHelper.EnableSeries(series, chartViewMode, (int)series.Tag);

			if (int.TryParse(series.Name.Replace(SeriesName, ""), out _) == false)
				continue;

			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			var showLegend = false;
			if (i < coordinates.X.Count)
			{
				series.Points.AddXY(coordinates.T, coordinates.Y[i]);
				showLegend = true;
			}

			UpdateLegend(series, showLegend, coordinates.X[i]);
		}
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var model = new ChartAreaCreationModel
		{
			Name = ChartAreaName,
			AxisX = new Axis
			{
				Minimum = 0,
				Maximum = 60,
				Interval = 60 / 5.0,
				Title = LocalizationHelper.Get<ChartRenderingResources>().TimeAxisTitleText,
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = RenderingHelper.CalculateMaxSpeed(modelParameters.Vmax),
				Interval = RenderingHelper.CalculateMaxSpeed(modelParameters.Vmax) / 5.0,
				Title = LocalizationHelper.Get<ChartRenderingResources>().SpeedAxisTitleText,
			}
		};
		var chartArea = ChartAreaRendersHelper.CreateChartArea(model);

		return chartArea;
	}

	protected override Legend CreateLegend(LegendStyle legendStyle, ModelParameters? modelParameters = null, BaseSettingsModels modeSettings = null)
	{
		return new Legend
		{
			Name = "Legend",
			Title = LocalizationHelper.Get<ChartRenderingResources>().SpeedChartLegendTitleText,
			TitleFont = new Font("Microsoft Sans Serif", 10F),
			LegendStyle = legendStyle,
			Font = new Font("Microsoft Sans Serif", 10F),
		};
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
				Chart.ChartAreas[0].AxisY.Title = LocalizationHelper.Get<ChartRenderingResources>().SpeedAxisTitleText;
			}
		}
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		return new Series[] { };
	}

	public override void UpdateEnvironment(object parameters)
	{
		var calculateMinimumSpeedValue = SettingsHelper.Get<ChartRenderingSettings>().CalculateMinimumSpeedValue;
		if(calculateMinimumSpeedValue == false)
			return;

		var environmentModels = (InliningInFlowEnvironmentArgs) parameters;

		var minSpeedValueSeries = Chart.Series.FirstOrDefault(series => series.Name == "MinSpeedValue");
		if(minSpeedValueSeries != null)
		{
			if (minSpeedValueSeries.Points.First().YValues.First() < environmentModels.MinSpeedValue)
				return;

			Chart.Series.Remove(minSpeedValueSeries);
		}

		var series = new Series
		{
			Name = "MinSpeedValue",
			ChartType = SeriesChartType.Line,
			ChartArea = ChartAreaName,
			BorderWidth = 2,
			Color = CustomColors.Red,
			IsVisibleInLegend = false,
			BorderDashStyle = ChartDashStyle.Dash
		};

		var customLabel = ChartAreaRendersHelper.CreateCustomLabel(Math.Round(environmentModels.MinSpeedValue, 2));
		Chart.ChartAreas.First().AxisY.CustomLabels.Add(customLabel);
		ChartAreaRendersHelper.CreateCustomLabels(Chart.ChartAreas.First().AxisY);
		series.Points.Add(new DataPoint(GetChartArea().AxisX.Minimum, environmentModels.MinSpeedValue));

		// необходимо для красивой отрисовки без начала движения
		series.Points.Add(new DataPoint(20, environmentModels.MinSpeedValue));
		series.Points.Add(new DataPoint(40, environmentModels.MinSpeedValue));

		var maximumTime = SettingsHelper.Get<ChartRenderingSettings>().MaximumTimeForAutomaticIncrease;
		for (var i = 1; i <= maximumTime; i++)
		{
			series.Points.Add(new DataPoint(GetChartArea().AxisX.Maximum * i, environmentModels.MinSpeedValue));
		}

		Chart.Series.Add(series);
	}

	public override void AddSeries(ModelParameters modelParameters, int indexFrom, int indexTo)
	{
		RenderingHelper.AddSeries(Chart, SeriesName, indexFrom, indexTo, 1);
	}

	protected override void CreateAxisSignature()
	{
		var chartArea = GetChartArea();
		chartArea.AxisX.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(chartArea.AxisX.Maximum, LocalizationHelper.Get<ChartRenderingResources>().TWithMeasurements));
		chartArea.AxisY.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(chartArea.AxisY.Maximum, LocalizationHelper.Get<ChartRenderingResources>().DotXWithMeasurements));
	}
}