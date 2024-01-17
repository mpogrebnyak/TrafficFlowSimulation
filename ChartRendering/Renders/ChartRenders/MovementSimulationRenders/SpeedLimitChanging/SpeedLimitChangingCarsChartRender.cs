using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Helpers;
using ChartRendering.Models;
using EvaluationKernel.Models;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.SpeedLimitChanging;

public class SpeedLimitChangingCarsChartRender : CarsChartRender
{
	public SpeedLimitChangingCarsChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		Chart.Legends.Clear();

		var segment = RenderingHelper.GetSegmentBeginningList((SpeedLimitChangingModeSettingsModel)modeSettings);

		foreach (var series in Chart.Series.Where(x => x.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			var showLegend = false;
			if (modelParameters.lambda[i] > segment.First() - 100 && modelParameters.lambda[i] < segment.Last() + 100)
			{
				GetSeries(i).Points.AddXY(modelParameters.lambda[i], Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 2);
				showLegend = true;
			}

			UpdateLegend(i, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
			UpdateLabel(i, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
		}

		SetMarkerImage(modelParameters.lCar);
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
		foreach (var series in Chart.Series.Where(series => series.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			var showLegend = false;
			if (GetSeries(i).Points.Any())
				GetSeries(i).Points.RemoveAt(0);

			if (coordinates.X[i] > GetChartArea().AxisX.Minimum)
			{
				GetSeries(i).Points.AddXY(coordinates.X[i], Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 2);
				showLegend = true;
			}

			UpdateLegend(i, showLegend, coordinates.Y[i], coordinates.X[i]);
			UpdateLabel(i, showLegend, coordinates.Y[i], coordinates.X[i]);
		}
		UpdateChartEnvironment(coordinates.X, coordinates.T);
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var segment = RenderingHelper.GetSegmentBeginningList((SpeedLimitChangingModeSettingsModel)modeSettings);

		var model = new ChartAreaCreationModel
		{
			Name = ChartAreaName,
			AxisX = new Axis
			{
				Minimum = segment.First() - 100,
				Maximum = segment.Last() + 100
			},
			IsZoomAvailable = true
		};
		var chartArea = ChartAreaRendersHelper.CreateChartArea(model);

		return chartArea;
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var settings = (SpeedLimitChangingModeSettingsModel)modeSettings;

		var segmentSpeeds = new SortedDictionary<int, SegmentModel>();
		settings.MapTo(segmentSpeeds);

		var series = new List<Series>();
		foreach (var segment in segmentSpeeds)
		{ 
			if (segment.Value.SegmentBeginning < GetChartArea().AxisX.Minimum || segment.Value.SegmentBeginning > GetChartArea().AxisX.Maximum)
			{
				continue;
			}

			var segmentSeries = new Series
			{
				Name = "SegmentBegin" + segment.Key,
				ChartType = SeriesChartType.Line,
				ChartArea = ChartAreaName,
				BorderWidth = 2,
				Color = Color.Blue,
				IsVisibleInLegend = false
			};
			segmentSeries.Points.Add(new DataPoint(segment.Value.SegmentBeginning, 0));
			segmentSeries.Points.Add(new DataPoint(segment.Value.SegmentBeginning, 1));

			series.Add(segmentSeries);
		}

		return series.ToArray();
	}
}