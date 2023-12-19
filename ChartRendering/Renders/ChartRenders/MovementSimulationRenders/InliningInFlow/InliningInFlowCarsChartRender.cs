using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.ChartRenderModels;
using ChartRendering.Models;
using ChartRendering.Properties;
using EvaluationKernel.Models;
using Localization;

namespace ChartRendering.Renders.ChartRenders.MovementSimulationRenders.InliningInFlow;

public class InliningInFlowCarsChartRender : InliningInFlowChartRender
{
	protected override SeriesChartType SeriesChartType => SeriesChartType.Point;

	protected override string SeriesName => "CarsMovementSeries";

	protected override string ChartAreaName => "CarsMovementChartArea";

	public InliningInFlowCarsChartRender(Chart chart) : base(chart)
	{
	}

	public override void RenderChart(ModelParameters modelParameters, BaseSettingsModels modeSettings)
	{
		base.RenderChart(modelParameters, modeSettings);

		Chart.Legends.Clear();

		foreach (var series in Chart.Series.Where(x => x.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			if (i < modelParameters.n)
			{
				var showLegend = false;
			//	if (modelParameters.lambda[i] > _chartAreaModel.AxisXMinimum && modelParameters.lambda[i] < _chartAreaModel.AxisXMaximum)
				{
					series.Points.AddXY(modelParameters.lambda[i], Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 2);
					showLegend = true;
				}

				UpdateLegend(i, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
				UpdateLabel(i, showLegend, modelParameters.Vn[i], modelParameters.lambda[i]);
			}
		}

		var inliningCar = Chart.Series.First(series => series.Name.Contains(SeriesName + modelParameters.n));
		inliningCar.Points.AddXY(0, Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 10);

		SetMarkerImage(modelParameters.lCar);
	}

	public override void UpdateChart(CoordinatesArgs coordinates)
	{
		foreach (var series in Chart.Series.Where(series => series.Name.Contains(SeriesName)))
		{
			var i = Convert.ToInt32(series.Name.Replace(SeriesName, ""));

			if (i < coordinates.X.Count)
			{
				var showLegend = false;
				if(series.Points.Any())
					series.Points.RemoveAt(0);

			//	if (coordinates.x[i] > _chartAreaModel.AxisXMinimum && coordinates.x[i] < _chartAreaModel.AxisXMaximum)
				{
					var yValue = series.Tag != null && series.Tag.ToString() == _inliningTag
						? CalculateWay(coordinates.X[i])
						: Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 2;
					series.Points.AddXY(coordinates.X[i], yValue);
					showLegend = true;
				}

				UpdateLegend(i, showLegend, coordinates.Y[i], coordinates.X[i]);
				UpdateLabel(i, showLegend, coordinates.Y[i], coordinates.X[i]);
			}
		}
	}

	public override void UpdateEnvironment(object parameters)
	{
		//var environmentModel = (EnvironmentModel) parameters;
		//var trafficLine = _chart.Series.First(series => series.Name.Contains("StartLine"));
		//trafficLine.Color = environmentModel.IsGreenLight ? Color.Green : Color.Red;
		//trafficLine.Label = environmentModel.IsGreenLight 
		//	? Math.Round(environmentModel.GreenTime, 2).ToString()
		//	: Math.Round(environmentModel.RedTime, 2).ToString();
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
		/*var chartArea = new ChartArea
		{
			Name = _chartAreaName,
			AxisX = new Axis
			{
				Minimum = _chartAreaModel.AxisXMinimum,
				Maximum = _chartAreaModel.AxisXMaximum,
				ScaleView = new AxisScaleView
				{
					//Zoomable = true,
					SizeType = DateTimeIntervalType.Number,
					MinSize = 30
				},
				Interval = _chartAreaModel.AxisXInterval,
				ScrollBar = new AxisScrollBar
				{
					ButtonStyle = ScrollBarButtonStyles.SmallScroll,
					IsPositionedInside = true,
					BackColor = Color.White,
					ButtonColor = Color.FromArgb(249, 246, 247)
				},
				IsStartedFromZero = true,
				Title = LocalizationHelper.Get<ChartRenderingResources>().DistanceAxisTitleText,
				TitleFont = new Font("Microsoft Sans Serif", 10F),
				TitleAlignment = StringAlignment.Far
			},
			AxisY = new Axis
			{
				Minimum = _chartAreaModel.AxisYMinimum,
				Maximum = _chartAreaModel.AxisYMaximum,
				Interval = _chartAreaModel.AxisYInterval,
				LabelStyle = new LabelStyle
				{
					Enabled = false
				}
			}
		};

		//chartArea.AxisX.ScaleView.Zoom(_chartAreaModel.AxisXMinimum,_chartAreaModel.AxisXMinimum + _chartAreaModel.ZoomShift);

		return chartArea;*/
		return new ChartArea();
	}

	protected override Legend CreateLegend(LegendStyle legendStyle)
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
		var lineSeries = new Series
		{
			Name = "line",
			ChartType = SeriesChartType.Line,
			ChartArea = ChartAreaName,
			BorderWidth = 1,
			Color = Color.Black,
			IsVisibleInLegend = false
		};
		//lineSeries.Points.Add(new DataPoint(_chartAreaModel.AxisXMinimum, 0));
		//lineSeries.Points.Add(new DataPoint(_chartAreaModel.AxisXMaximum, 0));
		
		var startLineSeries = new Series
		{
			Name = "StartLine",
			ChartType = SeriesChartType.Line,
			ChartArea = ChartAreaName,
			BorderWidth = 2,
			Color = Color.Red,
			IsVisibleInLegend = false
		};
		startLineSeries.Points.Add(new DataPoint(0, 1));
		startLineSeries.Points.Add(new DataPoint(0, 0));

		return new Series[]
		{
			lineSeries,
			startLineSeries,
		};
	}


	protected override string GetLegendText(params double[] values)
	{
		var sb = new StringBuilder();

		sb.Append(LocalizationHelper.Get<ChartRenderingResources>().SpeedText + " ");
		sb.Append(Math.Round(values[0], 2));
		sb.Append("\n");
		sb.Append(LocalizationHelper.Get<ChartRenderingResources>().DistanceText + " ");
		sb.Append(Math.Round(values[1], 2));
		return sb.ToString();
	}

	private double CalculateWay(double x)
	{
		var mainRoad = Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 2;
		var road = Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 10 + x / 25;
		return mainRoad > road
			? road
			: mainRoad;
	}
}