using System;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Constants;
using ChartRendering.Helpers;
using ChartRendering.Models;
using ChartRendering.Properties;
using EvaluationKernel.Models;
using Settings;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.InliningInFlow;

public class InliningInFlowSpeedFromDistanceChartRender : SpeedFromDistanceChartRender
{
	protected override string ColorPalette => "RedAndBlue";

	public InliningInFlowSpeedFromDistanceChartRender(Chart chart) : base(chart)
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
				series.Points.AddXY(modelParameters.lambda[i], modelParameters.Vn[i]);

			UpdateLegend(series, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
		}
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
		var chartViewMode = SettingsHelper.Get<ChartRenderingSettings>().ChartViewMode;

		foreach (var series in Chart.Series.Where(series => series.Name.Contains(SeriesName)))
		{
			RenderingHelper.EnableSeries(series, chartViewMode, (int)series.Tag);

			if (int.TryParse(series.Name.Replace(SeriesName, ""), out _) == false)
				continue;

			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			var showLegend = false;
			if (coordinates.X[i] > GetChartArea().AxisX.Minimum - 10)
			{
				series.Points.AddXY(coordinates.X[i], coordinates.Y[i]);
				showLegend = true;
			}

			UpdateLegend(series, showLegend, coordinates.X[i]);
		}
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{ 
		var chartArea = base.CreateChartArea(modelParameters, modeSettings);

		chartArea.AxisX.Minimum = 0;
		chartArea.AxisX.Maximum = 515;
		chartArea.AxisX.Interval = 515 / 5.0;

		return chartArea;
	}

	public override void AddSeries(ModelParameters modelParameters, int indexFrom, int indexTo)
	{
		RenderingHelper.AddSeries(Chart, SeriesName, indexFrom, indexTo, 1);
	}
}