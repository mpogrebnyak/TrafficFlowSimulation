using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Properties;
using ChartRendering.Renders.ChartRenders.MovementSimulationRenders.Models;
using EvaluationKernel.Models;
using Localization;
using TrafficFlowSimulation.Renders.ChartRenders;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.Models;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders;

public class SpeedFromDistanceChartRender : ChartsRender
{
	protected override SeriesChartType _seriesChartType => SeriesChartType.Spline;

	protected override string _seriesName => "SpeedFromDistance";

	protected override string _chartAreaName => "SpeedFromDistance";

	private readonly ChartAreaModel _chartAreaModel = new()
	{
		AxisXMinimum = 0,
		AxisXMaximum = 60,
		AxisYMinimum = 0,
		AxisYMaximum = 0,
	};

	public SpeedFromDistanceChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		foreach (var series in _chart.Series.Where(x => x.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));
			_chart.Series[i].Points.AddXY(0, 0);

			UpdateLegend(i, true, 0);
		}
	}

	public override void UpdateChart(object parameters)
	{
		var cm = (CoordinatesModel) parameters;

		foreach (var series in _chart.Series.Where(series => series.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));
			_chart.Series[i].Points.AddXY(cm.x[i], cm.y[i]);

			UpdateLegend(i, true, cm.y[i]);
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
				_chart.ChartAreas[0].AxisX.Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceAxisTitleText;
				_chart.ChartAreas[0].AxisY.Title = LocalizationHelper.Get<ChartRenderingResources>().SpeedAxisTitleText;
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
				Minimum = _chartAreaModel.AxisXMinimum,
				Maximum = modelParameters.L + 100,
				Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceAxisTitleText,
				TitleFont = new Font("Microsoft Sans Serif", 10F),
				TitleAlignment = StringAlignment.Far
			},
			AxisY = new Axis
			{
				Minimum = _chartAreaModel.AxisYMinimum,
				Maximum = RenderingHelper.CalculateMaxSpeed(modelParameters.Vmax),
				Title = LocalizationHelper.Get<ChartRenderingResources>().SpeedAxisTitleText,
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