using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Caching;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using EvaluationKernel.Models;
using Settings;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders;

public abstract class CarsChartRender : ChartsRender
{
	protected override SeriesChartType _seriesChartType => SeriesChartType.Point;

	protected override string _seriesName => "CarsMovementSeries";

	protected override string _chartAreaName => "CarsMovementChartArea";
	
	private readonly MemoryCache _cache = MemoryCache.Default;

	protected CarsChartRender(Chart chart) : base(chart)
	{
	}

	public override void SetChartAreaAxisTitle(bool isHidden = false)
	{
		if (_chart.ChartAreas.Any())
		{
			if (isHidden)
			{
				_chart.ChartAreas[0].AxisX.Title = string.Empty;
				_chart.ChartAreas[0].AxisY.Title = string.Empty;
			}
			else
			{
				//_chart.ChartAreas[0].AxisX.Title = LocalizationHelper.Get<ChartResources>().TimeAxisTitleText;
			}
		}
	}

	protected override Legend CreateLegend(LegendStyle legendStyle)
	{
		return new Legend
		{
			Name = "Legend",
		//	Title = LocalizationHelper.Get<ChartResources>().CarsMovementChartLegendTitleText,
			TitleFont = new Font("Microsoft Sans Serif", 10F),
			LegendStyle = legendStyle,
			Font = new Font("Microsoft Sans Serif", 10F)
		};
	}

	protected override void RenderChartEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChartEnvironment(modelParameters, modeSettings);

		TrafficCapacityHelper.RenderTrafficCapacity(_chart.Series, _chartAreaName);
	}

	protected void UpdateChartEnvironment(List<double> values, double t)
	{
		TrafficCapacityHelper.UpdateTrafficCapacity(_chart.Series, values, t);
	}

	public override void SetMarkerImage(object? parameters = null)
	{
		if (parameters != null)
			_cache.Add(new CacheItem("length",parameters), new CacheItemPolicy());

		if(_cache.Get("length") is not List<double> length)
			return;

		var path = SettingsHelper.Get<Properties.ChartRenderingSettings>().PaintedCarsFolder;
		_chart.Update();
		_chart.ApplyPaletteColors();
		foreach (var series in _chart.Series.Where(x => x.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));

			var lengthOfSingleSegmentXPixels =
				(float) _chart.ChartAreas[0].AxisX.ValueToPixelPosition(1) - (float) _chart.ChartAreas[0].AxisX.ValueToPixelPosition(0);
			var lengthOfSingleSegmentYPixels =
				(float) _chart.ChartAreas[0].AxisY.ValueToPixelPosition(0) - (float) _chart.ChartAreas[0].AxisY.ValueToPixelPosition(1);

			var bmp = new Bitmap(path + "\\" + _colorPalette + "\\" + series.Color.Name + ".png");
			var newBitmap = new Bitmap(bmp, 
				(int)lengthOfSingleSegmentXPixels * 2 * (int)length[i], 
				(int)lengthOfSingleSegmentYPixels / 5);

			if (_chart.Images.Any(x => x.Name == "MarkerImage" + i))
				_chart.Images["MarkerImage" + i] = new NamedImage("MarkerImage" + i, newBitmap);
			else
				_chart.Images.Add(new NamedImage("MarkerImage" + i, newBitmap));

			series.MarkerImage = "MarkerImage" + i;
		}
	}
	
}