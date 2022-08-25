using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using Localization;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Models;
using TrafficFlowSimulation.Properties.LocalizationResources;

namespace TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.StartAndStopMovement;

public class StartAndStopMovementDistanceChartRender : ChartsRender
{
	protected override SeriesChartType _seriesChartType => SeriesChartType.Spline;

	protected override string _seriesName => "DistanceSeries";

	protected override string _chartAreaName => "DistanceChartArea";

	private readonly ChartAreaModel _chartAreaModel = new()
	{
		AxisXMinimum = 0,
		AxisXMaximum = 60,
		AxisYMinimum = 0,
		AxisYMaximum = 0,
	};

	public StartAndStopMovementDistanceChartRender(Chart chart) : base(chart)
	{
	}
	
	public override void RenderChart(ModelParameters modelParameters)
	{
		base.RenderChart(modelParameters);

		foreach (var series in _chart.Series.Where(x => x.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));
			_chart.Series[i].Points.AddXY(0, modelParameters.lambda[i]);

			_chart.Series[i].LegendText = GetDistanceChartLegendText(modelParameters.lambda[i]);
		}
	}

	public override void UpdateChart(List<double> t = null!, List<double> x = null!, List<double> y = null!)
	{
		foreach (var series in _chart.Series.Where(series => series.Name.Contains(_seriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(_seriesName, ""));
			_chart.Series[i].Points.AddXY(t.Single(), x[i]);

			_chart.Series[i].LegendText = GetDistanceChartLegendText(x[i]);
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
				_chart.ChartAreas[0].AxisX.Title = LocalizationHelper.Get<MenuResources>().TimeAxisTitleText;
				_chart.ChartAreas[0].AxisY.Title = LocalizationHelper.Get<MenuResources>().DistanceAxisTitleText;
			}
		}
	}

	protected override ChartArea CreateChartArea(ModelParameters modelParameters)
	{
		return new ChartArea
		{
			Name = _chartAreaName,
			AxisX = new Axis
			{
				Minimum = _chartAreaModel.AxisXMinimum,
				Maximum = _chartAreaModel.AxisXMaximum,
				Title = LocalizationHelper.Get<MenuResources>().TimeAxisTitleText,
				TitleFont = new Font("Microsoft Sans Serif", 10F),
				TitleAlignment = StringAlignment.Far
			},
			AxisY = new Axis
			{
				Minimum = _chartAreaModel.AxisYMinimum,
				Maximum = modelParameters.L + 100,
				Title = LocalizationHelper.Get<MenuResources>().DistanceAxisTitleText,
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
			Title = LocalizationHelper.Get<MenuResources>().DistanceChartLegendTitleText,
			TitleFont = new Font("Microsoft Sans Serif", 10F),
			LegendStyle = legendStyle,
			Font = new Font("Microsoft Sans Serif", 10F),
		};
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters)
	{
		return new Series[] { };
	}

	private static string GetDistanceChartLegendText(double position)
	{
		return string.Format(
			LocalizationHelper.Get<MenuResources>().DistanceChartLegendText,
			Math.Round(position, 2).ToString());
	}
}