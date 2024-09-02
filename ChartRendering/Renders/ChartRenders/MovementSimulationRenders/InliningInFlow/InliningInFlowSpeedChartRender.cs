using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.ChartRenderModels.SettingsModels;
using ChartRendering.Constants;
using ChartRendering.Helpers;
using ChartRendering.Models;
using ChartRendering.Properties;
using EvaluationKernel.Models;
using Localization;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.InliningInFlow;

public class InliningInFlowSpeedChartRender : SpeedChartRender
{
	protected override string ColorPalette => "RedAndBlue";

	private int _n1;

	private int _n2;

	public InliningInFlowSpeedChartRender(Chart chart) : base(chart)
	{
	}
	
	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var settings = (InliningInFlowModeSettingsModel)modeSettings;

		_n1 = modelParameters.n1;
		_n2 = modelParameters.n2;

		base.RenderChart(modelParameters, modeSettings);
		Chart.Series.Clear();
		Chart.Legends.Clear();

		for (var i = 0; i < _n1; i++)
		{
			Chart.Series.Add(new Series
			{
				Name = SeriesName + i,
				ChartType = SeriesChartType,
				ChartArea = GetChartArea().Name,
				BorderWidth = 2,
				Color = CustomColors.Blue
			});
		}

		for (var i = _n1; i < _n1 + _n2; i++)
		{
			Chart.Series.Add(new Series
			{
				Name = SeriesName + i,
				ChartType = SeriesChartType,
				ChartArea = GetChartArea().Name,
				BorderWidth = 2,
				Color = CustomColors.Red
			});

			if (i == modelParameters.n1 + settings.Number)
				Chart.Series.Last().Color = CustomColors.DarkGreen;
		}

		foreach (var series in Chart.Series.Where(x => x.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			var showLegend = false;
			if (i == 0)
				series.Points.AddXY(0, modelParameters.Vn[i]);

			UpdateLegend(series, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
			UpdateLabel(series, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
		}
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
		foreach (var series in Chart.Series.Where(series => series.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			if (i < coordinates.X.Count)
			{
				series.Points.AddXY(coordinates.T, coordinates.Y[i]);
				UpdateLegend(series, true, coordinates.Y[i]);
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
				Maximum = 100,
				Title = LocalizationHelper.Get<ChartRenderingResources>().TimeAxisTitleText,
			},
			AxisY = new Axis
			{
				Minimum = 0,
				Maximum = RenderingHelper.CalculateMaxSpeed(modelParameters.Vmax),
				Title = LocalizationHelper.Get<ChartRenderingResources>().SpeedAxisTitleText,
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

	public override void AddSeries(ModelParameters modelParameters, int indexFrom, int indexTo)
	{
		_n1++;
		_n2--;

		var s = Chart.Series[indexFrom];
		Chart.Series.RemoveAt(indexFrom);
		
		Chart.Series.Insert(indexTo, s);

		foreach (var series in Chart.Series.Select((value, i) => new { i, value }))
		{
			series.value.Name = series.i.ToString();
		}

		foreach (var series in Chart.Series.Select((value, i) => new { i, value }))
		{
			series.value.Name = SeriesName + series.i;
		}
	}
}