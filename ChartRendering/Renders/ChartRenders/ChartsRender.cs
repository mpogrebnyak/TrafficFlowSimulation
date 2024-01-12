using System;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Constants;
using ChartRendering.Models;
using ChartRendering.Properties;
using EvaluationKernel.Models;
using Settings;

namespace ChartRendering.Renders.ChartRenders;

public abstract class ChartsRender : IChartRender
{
	protected virtual SeriesChartType SeriesChartType => SeriesChartType.Spline;

	protected virtual string SeriesName => "Series";

	protected virtual string ChartAreaName => "ChartArea";

	protected virtual string ColorPalette => ChartColorPalette.BrightPastel.ToString();

	protected readonly Chart Chart;

	public static string EnvironmentSeriesTag => "EnvironmentSeries";

	protected virtual bool IsTimeAutomaticallyIncrease => false;

	private int _currentMinute = 1;

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

		for (var i = 0; i < modelParameters.n; i++)
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

		_currentMinute = 1;
	}

	public virtual void UpdateChart(CoordinatesArgs coordinates)
	{
		if (!IsTimeAutomaticallyIncrease)
			return;

		if (!(coordinates.T > 60 * _currentMinute))
			return;

		_currentMinute++;

		var maximumTime = SettingsHelper.Get<ChartRenderingSettings>().MaximumTimeForAutomaticIncrease;
		if (_currentMinute <= maximumTime)
		{
			var chartAreas = Chart.ChartAreas.Single(x => x.Name == ChartAreaName);
			chartAreas.AxisX.Maximum = 60 * _currentMinute;
			Chart.Invalidate();
		}
	}

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

	protected ChartArea GetChartArea()
	{
		return Chart.ChartAreas.Single(x => x.Name == ChartAreaName);
	}
}