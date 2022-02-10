using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using Localization;
using Settings;
using TrafficFlowSimulation.Properties;
using TrafficFlowSimulation.Rendering.Models;

namespace TrafficFlowSimulation.Rendering.Renders
{
	public class SingleLaneTraffic : ChartsRender
	{
		public override string ChartText => "Car";
		protected override string ChartName => "Car";
		protected override string ChartAreaName => "CarsMovementChartArea";

		private readonly ChartAreaModel _chartAreaModel = new()
		{
			AxisXMinimum = -30,
			AxisXMaximum = 10,
			AxisXInterval = 10,
			AxisYMinimum = 0,
			AxisYMaximum = 1,
			AxisYInterval = 1,
			ZoomShift = 48
		};

		public SingleLaneTraffic(ModelParameters modelParameters, Chart chart) : base(modelParameters, chart)
		{
		}

		public override void Render(SeriesChartType chartType)
		{
			base.Render(chartType);

			Chart.ApplyPaletteColors();

			var carsFolder = SettingsHelper.Get<Properties.Settings>().PaintedCarsFolder;
			foreach (var series in Chart.Series.Where(x => x.Name.Contains(ChartName)))
			{
				var i = Convert.ToInt32(series.Name.Replace(ChartName, ""));
				Chart.Series[i].MarkerImage = carsFolder + "\\" + Chart.Series[i].Color.Name + ".png";
				Chart.Series[i].Points.AddXY(ModelParameters.lambda[i], Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 2);
				Chart.Series[i].LegendText = GetCarsMovementChartLegendText(0, ModelParameters.lambda[i]);
				Chart.Series[i].Label = GetCarsMovementChartLegendText(0, ModelParameters.lambda[i]);
			}
		}

		protected override Series[] CreateEnvironment()
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
			startLineSeries.Points.Add(new DataPoint(0, 0));
			startLineSeries.Points.Add(new DataPoint(0, 1));
			
			var endLineSeries = new Series
			{
				Name = "EndLine",
				ChartType = SeriesChartType.Line,
				ChartArea = ChartAreaName,
				BorderWidth = 2,
				Color = Color.Red,
				IsVisibleInLegend = false
			};
			endLineSeries.Points.Add(new DataPoint(ModelParameters.L, 0));
			endLineSeries.Points.Add(new DataPoint(ModelParameters.L, 1));

			return new[]
			{
				startLineSeries,
				endLineSeries
			};
		}

		protected override ChartArea CreateChartArea()
		{
			var chartArea = new ChartArea
			{
				Name = ChartAreaName,
				AxisX = new Axis
				{
					Minimum = _chartAreaModel.AxisXMinimum,
					Maximum = _chartAreaModel.AxisXMaximum + ModelParameters.L,
					ScaleView = new AxisScaleView
					{
						Zoomable = true,
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
					IsStartedFromZero = true
				},
				AxisY = new Axis
				{
					Minimum = _chartAreaModel.AxisYMinimum,
					Maximum = _chartAreaModel.AxisYMaximum,
					Interval = _chartAreaModel.AxisYInterval
				}
			};

			chartArea.AxisX.ScaleView.Zoom(_chartAreaModel.AxisXMinimum,_chartAreaModel.AxisXMinimum + _chartAreaModel.ZoomShift);

			return chartArea;
		}

		protected override Legend CreateLegend(LegendStyle legendStyle)
		{
			return new Legend
			{
				Name = "Legend",
				Title = "Положения и скорости автомобилей",
				AutoFitMinFontSize = 100,
				LegendStyle = legendStyle,
				Font = new Font("Microsoft Sans Serif", 10F),
			};
		}

		public override void Update(List<double> t = null!, List<double> x = null!, List<double> y = null!)
		{
			foreach (var series in Chart.Series.Where(series => series.Name.Contains(ChartName)))
			{
				var i = Convert.ToInt32(series.Name.Replace(ChartName, ""));
				Chart.Series[i].Points.RemoveAt(0);
				Chart.Series[i].Points.AddXY(x[i], Chart.ChartAreas[ChartAreaName].AxisY.Maximum / 2);
				
				Chart.Series[i].LegendText = GetCarsMovementChartLegendText(y[i], x[i]);
				Chart.Series[i].Label = GetCarsMovementChartLegendText(y[i], x[i]);
			}
		}

		private string GetCarsMovementChartLegendText(double speed, double position)
		{
			return string.Format(
				LocalizationHelper.Get<MenuResources>().CarsMovementChartLegendText,
				Math.Round(speed, 2).ToString(),
				Math.Round(position, 2).ToString());
		}
	}
}
