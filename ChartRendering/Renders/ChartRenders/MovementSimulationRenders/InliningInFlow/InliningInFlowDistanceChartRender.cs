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
using Settings;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.InliningInFlow;

public class InliningInFlowDistanceChartRender : DistanceChartRender
{
	protected override string ColorPalette => "RedAndBlue";

	protected override bool IsTimeAutomaticallyIncrease => false;

	public InliningInFlowDistanceChartRender(Chart chart) : base(chart)
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
				series.Points.AddXY(0, modelParameters.lambda[i]);

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
			if (coordinates.X[i] > GetChartArea().AxisY.Minimum)
			{
				series.Points.AddXY(coordinates.T, coordinates.X[i]);
				showLegend = true;
			}

			UpdateLegend(series, showLegend, coordinates.X[i]);
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
				Chart.ChartAreas[0].AxisY.Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceAxisTitleText;
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
				Minimum = 0,
				Maximum = 60,
				Interval = 60 / 5.0,
				Title = LocalizationHelper.Get<ChartRenderingResources>().TimeAxisTitleText,
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = 515,
				Interval = 515 / 5.0,
				Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceAxisTitleText,
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
			Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceChartLegendTitleText,
			TitleFont = new Font("Microsoft Sans Serif", 10F),
			LegendStyle = legendStyle,
			Font = new Font("Microsoft Sans Serif", 10F),
		};
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		return new Series[] { };
	}

	public override void AddSeries(ModelParameters modelParameters, int indexFrom, int indexTo)
	{
		RenderingHelper.AddSeries(Chart, SeriesName, indexFrom, indexTo, 1);
	}

	protected override void CreateAxisSignature()
	{
		var chartArea = GetChartArea();
		chartArea.AxisX.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(chartArea.AxisX.Maximum, LocalizationHelper.Get<ChartRenderingResources>().TWithMeasurements));
		chartArea.AxisY.CustomLabels.Add(ChartAreaRendersHelper.CreateCustomLabel(chartArea.AxisY.Maximum, LocalizationHelper.Get<ChartRenderingResources>().XWithMeasurements));
	}
}