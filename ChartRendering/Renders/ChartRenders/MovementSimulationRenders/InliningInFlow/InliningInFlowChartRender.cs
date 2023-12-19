using System;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Constants;
using EvaluationKernel.Models;
using Microsoft.Practices.ObjectBuilder2;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.InliningInFlow;

public abstract class InliningInFlowChartRender : ChartsRender
{
	protected readonly string _inliningTag = "InliningCar";

	protected override string ColorPalette => "RedAndBlue";

	protected InliningInFlowChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		Chart.Palette = ChartColorPalette.None;

		foreach (var series in Chart.Series.Where(series => series.Name.Contains(SeriesName)))
		{
			series.Color = CustomColors.Blue;
		}

		Chart.Series.Add(new Series
		{
			Name = SeriesName + modelParameters.n,
			ChartType = SeriesChartType,
			ChartArea = ChartAreaName,
			BorderWidth = 2,
			Color = CustomColors.Red,
			Tag = _inliningTag
		});
	}

	public override void AddSeries(int index)
	{
		var seriesToRemove = Chart.Series.Single(x => x.Tag != null && x.Tag.ToString() == _inliningTag);
		Chart.Series.Remove(seriesToRemove);

		var i = Chart.Series.Count(x => x.Name.Contains(SeriesName));
		Chart.Series
			.Where(x => x.Name.Contains(SeriesName))
			.Where(x => Convert.ToInt32(x.Name.Replace(SeriesName, "")) >= index)
			.Reverse()
			.ForEach(x => x.Name = SeriesName + i--);

		Chart.Series.Insert(index,
			new Series
			{
				Name = SeriesName + index,
				ChartType = SeriesChartType,
				ChartArea = ChartAreaName,
				BorderWidth = 2,
				Color = CustomColors.Red,
				Tag = _inliningTag
			}
		);

		// Поправить проставление маркера, возможно добавлять только один маркер по индексу
		// ServiceLocator.Current.GetInstance<RenderingHandler>().SetMarkerImage();
	}

	protected static class CommonChartAreaParameters
	{
		public static double BeginOfRoad = -30;

		public static double EndOfRoad = 20;
	}
}