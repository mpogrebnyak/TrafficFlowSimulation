using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Caching;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Constants;
using ChartRendering.Helpers;
using ChartRendering.Models;
using ChartRendering.Properties;
using EvaluationKernel.Models;
using Localization;
using Settings;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders;

public abstract class CarsChartRender : ChartsRender
{
	protected override SeriesChartType SeriesChartType => SeriesChartType.Point;

	protected override string SeriesName => "CarsMovementSeries";

	protected override string ChartAreaName => "CarsMovementChartArea";

	private readonly MemoryCache _cache = MemoryCache.Default;

	protected CarsChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		// ReSharper disable once ConstantConditionalAccessQualifier
		UpdateScale(null, (AutoScroll?) modeSettings.Scroll?.Value, modeSettings.ScrollFor);
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

	protected override void RenderChartEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChartEnvironment(modelParameters, modeSettings);

		RenderTrafficCapacity(modelParameters, modeSettings);
	}

	protected virtual void RenderTrafficCapacity(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		TrafficCapacityHelper.RenderTrafficCapacity(Chart.Series, ChartAreaName);
	}

	protected void UpdateChartEnvironment(List<double> values, double t)
	{
		TrafficCapacityHelper.UpdateTrafficCapacity(Chart.Series, values, t);
	}

	public override void SetMarkerImage(object? parameters = null)
	{
		if (parameters != null)
			_cache.Set(new CacheItem("length", parameters), new CacheItemPolicy());

		if(_cache.Get("length") is not List<double> length)
			return;

		var path = SettingsHelper.Get<ChartRenderingSettings>().PaintedCarsFolder;
		Chart.Update();
		Chart.ApplyPaletteColors();
		foreach (var series in Chart.Series.Where(x => x.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			var lengthOfSingleSegmentXPixels =
				(float) Chart.ChartAreas[0].AxisX.ValueToPixelPosition(1) - (float) Chart.ChartAreas[0].AxisX.ValueToPixelPosition(0);
			var lengthOfSingleSegmentYPixels =
				(float) Chart.ChartAreas[0].AxisY.ValueToPixelPosition(0) - (float) Chart.ChartAreas[0].AxisY.ValueToPixelPosition(1);

			var bitmapName = GetBitmapName((int) length[i]);
			var bmp = new Bitmap(path + "\\" + ColorPalette + "\\" + bitmapName + "_" + series.Color.Name + ".png");
			var newBitmap = new Bitmap(bmp, 
				(int)lengthOfSingleSegmentXPixels * 2 * (int)length[i], 
				(int)lengthOfSingleSegmentYPixels / 5);

			if (Chart.Images.Any(x => x.Name == "MarkerImage" + i))
				Chart.Images["MarkerImage" + i] = new NamedImage("MarkerImage" + i, newBitmap);
			else
				Chart.Images.Add(new NamedImage("MarkerImage" + i, newBitmap));

			series.MarkerImage = "MarkerImage" + i;
		}
	}

	public override void UpdateScale(CoordinatesArgs? coordinates = null, AutoScroll? scroll = null, int? scrollFor = null)
	{
		if (scroll != null)
			_cache.Set(new CacheItem("Scroll", scroll), new CacheItemPolicy());

		if (scrollFor != null)
			_cache.Set(new CacheItem("ScrollFor", scrollFor), new CacheItemPolicy());

		if (coordinates == null)
			return;

		if (_cache.Get("Scroll") is not AutoScroll cashScroll || _cache.Get("ScrollFor") is not int cashScrollFor)
			return;

		if (cashScroll == AutoScroll.No)
			return;

		var x = coordinates.X;
		var scaleView = Chart.ChartAreas[0].AxisX.ScaleView;
		scaleView.Scroll(Math.Round(x[cashScrollFor]) - 25);
	}

	private string GetBitmapName(int length)
	{
		foreach (var bitmapResources in CarsRenderingHelper.BitmapResources)
		{
			if (length <= bitmapResources.Key.Value)
			{
				return bitmapResources.Key.Name;
			}
		}

		return CarsRenderingHelper.BitmapResources.First().Key.Name;
	}
}