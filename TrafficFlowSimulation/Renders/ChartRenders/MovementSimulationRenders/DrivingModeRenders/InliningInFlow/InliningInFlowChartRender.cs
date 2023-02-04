using System;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.ServiceLocation;
using TrafficFlowSimulation.Constants;

namespace TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders.DrivingModeRenders.InliningInFlow;

public abstract class InliningInFlowChartRender : ChartsRender
{
	protected readonly string _inliningTag = "InliningCar";

	protected override string _colorPalette => "RedAndBlue";

	protected InliningInFlowChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters)
	{
		base.RenderChart(modelParameters);

		_chart.Palette = ChartColorPalette.None;

		foreach (var series in _chart.Series.Where(series => series.Name.Contains(_seriesName)))
		{
			series.Color = CustomColors.Blue;
		}

		_chart.Series.Add(new Series
		{
			Name = _seriesName + modelParameters.n,
			ChartType = _seriesChartType,
			ChartArea = _chartAreaName,
			BorderWidth = 2,
			Color = CustomColors.Red,
			Tag = _inliningTag
		});
	}

	public override void AddSeries(int index)
	{
		var seriesToRemove = _chart.Series.Single(x => x.Tag != null && x.Tag.ToString() == _inliningTag);
		_chart.Series.Remove(seriesToRemove);

		var i = _chart.Series.Count(x => x.Name.Contains(_seriesName));
		_chart.Series
			.Where(x => x.Name.Contains(_seriesName))
			.Where(x => Convert.ToInt32(x.Name.Replace(_seriesName, "")) >= index)
			.Reverse()
			.ForEach(x => x.Name = _seriesName + i--);

		_chart.Series.Insert(index,
			new Series
			{
				Name = _seriesName + index,
				ChartType = _seriesChartType,
				ChartArea = _chartAreaName,
				BorderWidth = 2,
				Color = CustomColors.Red,
				Tag = _inliningTag
			}
		);

		ServiceLocator.Current.GetInstance<RenderingHandler>().SetMarkerImage();
	}

	protected static class CommonChartAreaParameters
	{
		public static double BeginOfRoad = -30;

		public static double EndOfRoad = 20;
	}
}