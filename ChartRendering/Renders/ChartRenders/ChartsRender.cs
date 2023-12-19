using System;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Constants;
using ChartRendering.Models;
using EvaluationKernel.Models;

namespace ChartRendering.Renders.ChartRenders;

public abstract class ChartsRender : IChartRender
{
	protected virtual SeriesChartType SeriesChartType => SeriesChartType.Spline;

	protected virtual string SeriesName => "Series";

	protected virtual string ChartAreaName => "ChartArea";

	protected virtual string ColorPalette => ChartColorPalette.BrightPastel.ToString();

	protected readonly Chart Chart;

	public static string EnvironmentSeriesTag => "EnvironmentSeries";

	protected ChartsRender(Chart chart)
	{
		Chart = chart;
	}

	public virtual void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		FullClearChart();

		var chartArea = CreateChartArea(modelParameters, modeSettings);
		Chart.ChartAreas.Add(chartArea);

		Chart.Legends.Add(CreateLegend(LegendStyle.Column));

		for (int i = 0; i < modelParameters.n; i++)
		{
			Chart.Series.Add(new Series
			{
				Name = SeriesName + i,
				ChartType = SeriesChartType,
				ChartArea = chartArea.Name,
				BorderWidth = 2
			});
		}

		RenderChartEnvironment(modelParameters, modeSettings);
	}

	public abstract void UpdateChart(CoordinatesArgs coordinates);

	public virtual void UpdateEnvironment(object parameters) { } 

	public virtual void AddSeries(int index) { }

	public virtual void UpdateScale(CoordinatesArgs? coordinates = null, AutoScroll? scroll = null, int? scrollFor = null) { }

	public abstract void SetChartAreaAxisTitle(bool isHidden = false);

	public virtual void SetMarkerImage(object? parameters = null)
	{
	}

	public virtual void ShowChartLegend(LegendStyle? legendStyle)
	{
		Chart.Legends.Clear();

		if (legendStyle.HasValue)
		{
			Chart.Legends.Add(CreateLegend(legendStyle.Value));
		}
	}

	protected void UpdateLegend(int i, bool showLegend, params double[] values)
	{
		if (showLegend)
		{
			Chart.Series[i].LegendText = GetLegendText(values);
			Chart.Series[i].IsVisibleInLegend = true;
		}
		else
		{
			Chart.Series[i].IsVisibleInLegend = false;
		}
	}

	protected void UpdateLabel(int i, bool showLabel, params double[] values)
	{
		if (showLabel)
		{
			Chart.Series[i].Label = GetLegendText(values);
		}
		else
		{
			Chart.Series[i].Label = string.Empty;
		}
	}

	protected virtual string GetLegendText(params double[] values)
	{
		var sb = new StringBuilder();
		foreach (var value in values)
		{
			sb.Append(Math.Round(value, 2) + " ");
		}
		return sb.ToString();
	}

	protected virtual void RenderChartEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var environmentSeries = CreateEnvironment(modelParameters, modeSettings);
		foreach (var series in environmentSeries)
		{
			series.Tag = EnvironmentSeriesTag;
			Chart.Series.Add(series);
		}
	}

	protected abstract ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings);

	protected abstract Legend CreateLegend(LegendStyle legendStyle);

	protected abstract Series[] CreateEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings);

	protected void FullClearChart()
	{
		Chart.Series.Clear();
		Chart.ChartAreas.Clear();
		Chart.Legends.Clear();
	}

	protected ChartArea GetChartArea(string name)
	{
		return Chart.ChartAreas.Single(x => x.Name == ChartAreaName);
	}
}