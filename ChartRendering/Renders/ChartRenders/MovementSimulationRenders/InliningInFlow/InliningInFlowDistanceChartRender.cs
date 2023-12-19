using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Models;
using ChartRendering.Properties;
using EvaluationKernel.Models;
using Localization;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.InliningInFlow;

public class InliningInFlowDistanceChartRender : InliningInFlowChartRender
{
	protected override SeriesChartType SeriesChartType => SeriesChartType.Spline;

	protected override string SeriesName => "DistanceSeries";

	protected override string ChartAreaName => "DistanceChartArea";

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

		foreach (var series in Chart.Series.Where(x => x.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			if (i == 0)
				Chart.Series[i].Points.AddXY(0, modelParameters.lambda[i]);

			var lambda = i < modelParameters.lambda.Count
				? modelParameters.lambda[i]
				: 0;

			UpdateLegend(i, true, lambda);
		}
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
		foreach (var series in Chart.Series.Where(series => series.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			if (i < coordinates.X.Count)
			{
				var showLegend = false;
				if (coordinates.X[i] > CommonChartAreaParameters.BeginOfRoad && coordinates.X[i] < CommonChartAreaParameters.EndOfRoad)
				{
					Chart.Series[i].Points.AddXY(coordinates.T, coordinates.X[i]);
					showLegend = true;
				}

				UpdateLegend(i, showLegend, coordinates.X[i]);
			}
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
		return new ChartArea
		{
			Name = ChartAreaName,
			AxisX = new Axis
			{
				//Minimum = _chartAreaModel.AxisXMinimum,
				//Maximum = _chartAreaModel.AxisXMaximum,
				Title = LocalizationHelper.Get<ChartRenderingResources>().TimeAxisTitleText,
				TitleFont = new Font("Microsoft Sans Serif", 10F),
			},
			AxisY = new Axis
			{
				//Minimum = _chartAreaModel.AxisYMinimum,
				//Maximum = _chartAreaModel.AxisYMaximum,
				Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceAxisTitleText,
				TitleFont = new Font("Microsoft Sans Serif", 10F),
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