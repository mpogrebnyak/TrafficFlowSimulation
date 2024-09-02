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

public class InliningInFlowCarsChartRender : CarsChartRender
{
	protected override string ColorPalette => "RedAndBlue";

	private int _n1;

	private int _n2;

	public InliningInFlowCarsChartRender(Chart chart) : base(chart)
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
			if (modelParameters.lambda[i] > GetChartArea().AxisX.Minimum && modelParameters.lambda[i] < GetChartArea().AxisX.Maximum)
			{
				if (i < _n1) 
					series.Points.AddXY(modelParameters.lambda[i], 3 * Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 4);
				else
					series.Points.AddXY(modelParameters.lambda[i], Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 4);

				showLegend = true;
			}

			UpdateLegend(series, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
			UpdateLabel(series, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
		}

		SetMarkerImage(modelParameters.lCar);
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
		foreach (var series in Chart.Series.Where(series => series.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			var showLegend = false;
			if (series.Points.Any())
				series.Points.RemoveAt(0);
			if (coordinates.X[i] > GetChartArea().AxisX.Minimum)
			{
				if (i < _n1)
					series.Points.AddXY(coordinates.X[i], 3 * Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 4);
				else
					series.Points.AddXY(coordinates.X[i], Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 4);

				showLegend = true;
			}

			UpdateLegend(series, showLegend, coordinates.Y[i], coordinates.X[i]);
			UpdateLabel(series, showLegend, coordinates.Y[i], coordinates.X[i]);
		}

		UpdateChartEnvironment(coordinates.X, coordinates.T);
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
				Minimum = -30,
				Maximum = 500
			},
			IsZoomAvailable = true
		};
		var chartArea = ChartAreaRendersHelper.CreateChartArea(model);

		return chartArea;
	}

	protected override Legend CreateLegend(LegendStyle legendStyle, ModelParameters? modelParameters = null, BaseSettingsModels modeSettings = null)
	{
		return new Legend
		{
			Name = "Legend",
			Title = LocalizationHelper.Get<ChartRenderingResources>().CarsMovementChartLegendTitleText,
			TitleFont = new Font("Microsoft Sans Serif", 10F),
			LegendStyle = legendStyle,
			Font = new Font("Microsoft Sans Serif", 10F)
		};
	}

	protected override Series[] CreateEnvironment(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		var startLineSeries = new Series
		{
			Name = "StartLine",
			ChartType = SeriesChartType.Line,
			ChartArea = ChartAreaName,
			BorderWidth = 2,
			Color = Color.Red,
			IsVisibleInLegend = false
		};
		startLineSeries.Points.Add(new DataPoint(0.001, 1));
		startLineSeries.Points.Add(new DataPoint(0.001, 0));

		return new[]
		{
			startLineSeries
		};
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