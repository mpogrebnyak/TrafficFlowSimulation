using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Helpers;
using ChartRendering.Models;
using ChartRendering.Properties;
using EvaluationKernel.Models;
using Localization;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.InliningInFlow;

public class InliningInFlowSpeedChartRender : InliningInFlowChartRender
{
	protected override SeriesChartType SeriesChartType => SeriesChartType.Spline;

	protected override string SeriesName => "SpeedSeries";

	protected override string ChartAreaName => "SpeedChartArea";

	/*private readonly ChartAreaModel _chartAreaModel = new()
	{
		AxisXMinimum = 0,
		AxisXMaximum = 60,
		AxisYMinimum = 0,
		ZoomShift = 40
	};*/

	public InliningInFlowSpeedChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		foreach (var series in Chart.Series.Where(x => x.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			if (i == 0) 
				Chart.Series[i].Points.AddXY(0, 0);

			UpdateLegend(i, true, 0);
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
					Chart.Series[i].Points.AddXY(coordinates.T, coordinates.Y[i]);
					showLegend = true;
				}

				UpdateLegend(i, showLegend, coordinates.Y[i]);
			}
		}
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var chartArea = new ChartArea
		{
			Name = ChartAreaName,
			AxisX = new Axis
			{
			//	Minimum = _chartAreaModel.AxisXMinimum,
			//	Maximum = _chartAreaModel.AxisXMaximum,
				Title = LocalizationHelper.Get<ChartRenderingResources>().TimeAxisTitleText,
				TitleFont = new Font("Microsoft Sans Serif", 10F),
				/*
				ScaleView = new AxisScaleView
				{
					Zoomable = true,
					SizeType = DateTimeIntervalType.Number,
					MinSize = 30
				},
				*/
			//	Interval = _chartAreaModel.AxisXInterval,
				ScrollBar = new AxisScrollBar
				{
					ButtonStyle = ScrollBarButtonStyles.SmallScroll,
					IsPositionedInside = true,
					BackColor = Color.White,
					ButtonColor = Color.FromArgb(249, 246, 247)
				}
			},
			AxisY = new Axis
			{
			//	Minimum = _chartAreaModel.AxisYMinimum,
				Maximum = RenderingHelper.CalculateMaxSpeed(modelParameters.Vmax),
				Title = LocalizationHelper.Get<ChartRenderingResources>().SpeedAxisTitleText,
				TitleFont = new Font("Microsoft Sans Serif", 10F),
			}
		};

		//chartArea.AxisX.ScaleView.Zoom(_chartAreaModel.AxisXMinimum,_chartAreaModel.AxisXMinimum + _chartAreaModel.ZoomShift);

		return chartArea;
	}

	protected override Legend CreateLegend(LegendStyle legendStyle)
	{
		return new Legend
		{
			Name = "Legend",
			Title = LocalizationHelper.Get<ChartRenderingResources>().SpeedChartLegendTitleText,
			TitleFont = new Font("Microsoft Sans Serif", 10F),
			LegendStyle = legendStyle,
			Font = new Font("Microsoft Sans Serif", 10F),
		};
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
				Chart.ChartAreas[0].AxisY.Title = LocalizationHelper.Get<ChartRenderingResources>().SpeedAxisTitleText;
			}
		}
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		return new Series[] { };
	}
}