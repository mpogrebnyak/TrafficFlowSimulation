using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using Settings;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Models;

namespace TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Renders;

public abstract class ChartsRender : IChartRender
{
	protected virtual SeriesChartType _seriesChartType => SeriesChartType.Spline;

	protected virtual string _seriesName => "Series";

	protected virtual string _chartAreaName => "ChartArea";

	protected virtual string _colorPalette => ChartColorPalette.BrightPastel.ToString();

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

	public virtual void AddSeries(int index) { }

	public abstract void SetChartAreaAxisTitle(bool isHidden = false);

	public virtual void SetMarkerImage()
	{
		var path = SettingsHelper.Get<Properties.Settings>().PaintedCarsFolder;
		_chart.Update();
		_chart.ApplyPaletteColors();
		foreach (var series in _chart.Series.Where(x => x.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));

			float lengthOfSingleSegmentXPixels;
			float lengthOfSingleSegmentYPixels;
			try
			{
				lengthOfSingleSegmentXPixels =
					(float) _chart.ChartAreas[0].AxisX.ValueToPixelPosition(1) - (float) _chart.ChartAreas[0].AxisX.ValueToPixelPosition(0);
				lengthOfSingleSegmentYPixels =
					(float) _chart.ChartAreas[0].AxisY.ValueToPixelPosition(0) - (float) _chart.ChartAreas[0].AxisY.ValueToPixelPosition(1);
			}
			catch (NullReferenceException e)
			{
				return;
			}

			var carLength = SettingsHelper.Get<Properties.Settings>().CarLength;

			var bmp = new Bitmap(path + "\\" + _colorPalette + "\\" + series.Color.Name + ".png");
			var newBitmap = new Bitmap(bmp, 
				(int)lengthOfSingleSegmentXPixels * 2 * carLength, 
				(int)lengthOfSingleSegmentYPixels / 5);

			if (_chart.Images.Any(x => x.Name == "MarkerImage" + i))
				_chart.Images["MarkerImage" + i] = new NamedImage("MarkerImage" + i, newBitmap);
			else
				_chart.Images.Add(new NamedImage("MarkerImage" + i, newBitmap));

			series.MarkerImage = "MarkerImage" + i;
		}
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