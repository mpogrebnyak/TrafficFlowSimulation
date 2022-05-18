using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Models;

namespace TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Renders;

public abstract class ChartsRender : IChartRender
{
	protected virtual SeriesChartType _seriesChartType => SeriesChartType.Spline;

	protected virtual string _seriesName => "Series";

	protected virtual string _chartAreaName => "ChartArea";

	protected Chart _chart;

	public ChartsRender(Chart chart)
	{
		_chart = chart;
	}

	public virtual void RenderChart(ModelParameters modelParameters)
	{
		FullClearChart();

		var chartArea = CreateChartArea(modelParameters);
		_chart.ChartAreas.Add(chartArea);

		_chart.Legends.Add(CreateLegend(LegendStyle.Column));

		for (int i = 0; i < modelParameters.n; i++)
		{
			_chart.Series.Add(new Series
			{
				Name = _seriesName + i,
				ChartType = _seriesChartType,
				ChartArea = chartArea.Name,
				BorderWidth = 2
			});
		}

		var environmentSeries = CreateEnvironment(modelParameters);
		foreach (var series in environmentSeries)
		{
			_chart.Series.Add(series);
		}
	}

	public abstract void UpdateChart(List<double> p1 = null!, List<double> p2 = null!, List<double> p3 = null!);

	public virtual void UpdateEnvironment(EnvironmentParametersModel parameters) { }

	public abstract void SetChartAreaAxisTitle(bool isHidden = false);

	public virtual void SetMarkerImage(string path) { }

	public void DeleteMarkerImage()
	{
		foreach (var series in _chart.Series.Where(x => x.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));
			_chart.Series[i].MarkerImage = null;
			_chart.Series[i].MarkerStyle = MarkerStyle.Circle;
			var q = _chart.Series[i].CustomProperties;
		}
		_chart.Images.Clear();
		_chart.Update();
	}

	public virtual void ShowChartLegend(LegendStyle? legendStyle)
	{
		_chart.Legends.Clear();

		if (legendStyle.HasValue)
		{
			_chart.Legends.Add(CreateLegend(legendStyle.Value));
		}
	}

	protected void UpdateLegend(int i, bool showLegend, params double[] values)
	{
		if (showLegend)
		{
			_chart.Series[i].LegendText = GetLegendText(values);
			_chart.Series[i].IsVisibleInLegend = true;
		}
		else
		{
			_chart.Series[i].IsVisibleInLegend = false;
		}
	}

	protected void UpdateLabel(int i, bool showLabel, params double[] values)
	{
		if (showLabel)
		{
			_chart.Series[i].Label = GetLegendText(values);
		}
		else
		{
			_chart.Series[i].Label = string.Empty;
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

	protected abstract ChartArea CreateChartArea(ModelParameters modelParameters);

	protected abstract Legend CreateLegend(LegendStyle legendStyle);

	protected abstract Series[] CreateEnvironment(ModelParameters modelParameters);
	

	private void FullClearChart()
	{
		_chart.Series.Clear();
		_chart.ChartAreas.Clear();
		_chart.Legends.Clear();
	}
}