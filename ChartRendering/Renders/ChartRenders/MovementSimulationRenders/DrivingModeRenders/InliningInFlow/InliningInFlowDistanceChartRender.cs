using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Models;
using ChartRendering.Properties;
using EvaluationKernel.Models;
using Localization;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.InliningInFlow;

public class InliningInFlowDistanceChartRender : InliningInFlowChartRender
{
	protected override SeriesChartType _seriesChartType => SeriesChartType.Spline;

	protected override string _seriesName => "DistanceSeries";

	protected override string _chartAreaName => "DistanceChartArea";

	/*private readonly ChartAreaModel _chartAreaModel = new()
	{
		AxisXMinimum = 0,
		AxisXMaximum = 60,
		AxisXInterval = 10,
		AxisYMinimum = CommonChartAreaParameters.BeginOfRoad,
		AxisYMaximum = CommonChartAreaParameters.EndOfRoad,
		AxisYInterval = 1,
		ZoomShift = 48
	};*/

	public InliningInFlowDistanceChartRender(Chart chart) : base(chart)
	{
	}
	
	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		foreach (var series in _chart.Series.Where(x => x.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));

			if (i == 0)
				_chart.Series[i].Points.AddXY(0, modelParameters.lambda[i]);

			var lambda = i < modelParameters.lambda.Count
				? modelParameters.lambda[i]
				: 0;

			UpdateLegend(i, true, lambda);
		}
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
		foreach (var series in _chart.Series.Where(series => series.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));

			if (i < coordinates.x.Count)
			{
				var showLegend = false;
				if (coordinates.x[i] > CommonChartAreaParameters.BeginOfRoad && coordinates.x[i] < CommonChartAreaParameters.EndOfRoad)
				{
					_chart.Series[i].Points.AddXY(coordinates.t, coordinates.x[i]);
					showLegend = true;
				}

				UpdateLegend(i, showLegend, coordinates.x[i]);
			}
		}
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
				_chart.ChartAreas[0].AxisX.Title = LocalizationHelper.Get<ChartRenderingResources>().TimeAxisTitleText;
				_chart.ChartAreas[0].AxisY.Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceAxisTitleText;
			}
		}
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		return new ChartArea
		{
			Name = _chartAreaName,
			AxisX = new Axis
			{
				//Minimum = _chartAreaModel.AxisXMinimum,
				//Maximum = _chartAreaModel.AxisXMaximum,
				Title = LocalizationHelper.Get<ChartRenderingResources>().TimeAxisTitleText,
				TitleFont = new Font("Microsoft Sans Serif", 10F),
				TitleAlignment = StringAlignment.Far
			},
			AxisY = new Axis
			{
				//Minimum = _chartAreaModel.AxisYMinimum,
				//Maximum = _chartAreaModel.AxisYMaximum,
				Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceAxisTitleText,
				TitleFont = new Font("Microsoft Sans Serif", 10F),
				TitleAlignment = StringAlignment.Far
			}
		};
	}

	protected override Legend CreateLegend(LegendStyle legendStyle)
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
}