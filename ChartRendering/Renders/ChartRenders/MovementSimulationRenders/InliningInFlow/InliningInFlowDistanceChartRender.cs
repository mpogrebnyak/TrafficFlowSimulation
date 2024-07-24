using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Constants;
using ChartRendering.Helpers;
using ChartRendering.Models;
using ChartRendering.Properties;
using EvaluationKernel.Models;
using Localization;
using Microsoft.Practices.ObjectBuilder2;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.InliningInFlow;

public class InliningInFlowDistanceChartRender : DistanceChartRender
{
	public InliningInFlowDistanceChartRender(Chart chart) : base(chart)
	{
	}
	
	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		Chart.Palette = ChartColorPalette.None;
		Chart.Legends.Clear();

		foreach (var series in Chart.Series.Where(x => x.Name.Contains(SeriesName)))
		{
			series.Color = CustomColors.Blue;
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));
			var chartArea = GetChartArea();

			if (i < modelParameters.n)
			{
				var showLegend = false;
				if (modelParameters.lambda[i] > chartArea.AxisX.Minimum && modelParameters.lambda[i] < chartArea.AxisX.Maximum)
				{
					GetSeries(i).Points.AddXY(modelParameters.lambda[i], Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 2);
					showLegend = true;
				}

				UpdateLegend(i, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
				UpdateLabel(i, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
			}
		}

		var inliningCar = new Series
		{
			Name = SeriesName + modelParameters.n,
			ChartType = SeriesChartType,
			ChartArea = ChartAreaName,
			BorderWidth = 2,
			Color = CustomColors.Red,
		};
		inliningCar.Points.AddXY(0, Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 10);
		Chart.Series.Add(inliningCar);
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
		foreach (var series in Chart.Series.Where(series => series.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			if (i < coordinates.X.Count)
			{
				GetSeries(i).Points.AddXY(coordinates.T, coordinates.X[i]);
				UpdateLegend(i, true, coordinates.X[i]);
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
		var model = new ChartAreaCreationModel
		{
			Name = ChartAreaName,
			AxisX = new Axis
			{
				Minimum = 0,
				Maximum = 60,
				Title = LocalizationHelper.Get<ChartRenderingResources>().TimeAxisTitleText,
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = 100,
				Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceAxisTitleText,
			}
		};
		var chartArea = ChartAreaRendersHelper.CreateChartArea(model);

		return chartArea;
	}

	protected override Legend CreateLegend(LegendStyle legendStyle, ModelParameters? modelParameters = null, BaseSettingsModels modeSettings = null)
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

	public override void AddSeries(ModelParameters modelParameters, int index)
	{
		var seriesToRemove = Chart.Series.Single(x => x.Color == CustomColors.Red);
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
				Color = CustomColors.Red
			}
		);
	}
}