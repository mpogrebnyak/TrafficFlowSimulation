using System;
using System.Collections.Generic;
using EvaluationKernel.Models;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using Settings;
using TrafficFlowSimulation.Helpers;

namespace TrafficFlowSimulation.Commands.Rendering
{
	public class SingleLaneTraffic : ChartsRender
	{
		protected override string ChartName => "Car";
		protected override string ChartAreaName => "CarsMovementChartArea";

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
				Chart.Series[i].LegendText = LocalizationHelper.GetCarsMovementChartLegendText(0, ModelParameters.lambda[i]);
				Chart.Series[i].Label = LocalizationHelper.GetCarsMovementChartLegendText(0, ModelParameters.lambda[i]);
			}
		}

		protected override Series[] CreateEnvironment()
		{
			var srartLineSeries = new Series
			{
				Name = "SrartLine",
				ChartType = SeriesChartType.Line,
				ChartArea = ChartAreaName,
				BorderWidth = 1,
				Color = Color.Red,
				IsVisibleInLegend = false
			};
			srartLineSeries.Points.Add(new DataPoint(0, 0));
			srartLineSeries.Points.Add(new DataPoint(0, 1));
			
			var endLineSeries = new Series
			{
				Name = "EndLine",
				ChartType = SeriesChartType.Line,
				ChartArea = ChartAreaName,
				BorderWidth = 1,
				Color = Color.Red,
				IsVisibleInLegend = false
			};
			endLineSeries.Points.Add(new DataPoint(ModelParameters.L, 0));
			endLineSeries.Points.Add(new DataPoint(ModelParameters.L, 1));

			return new[]
			{
				srartLineSeries,
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
					Minimum = -10,
					Maximum = ModelParameters.L,
					ScaleView = new AxisScaleView
					{
						Zoomable = true,
						SizeType = DateTimeIntervalType.Number,
						Size = 10
					},
					Interval = 20,
					ScrollBar = new AxisScrollBar
					{
						ButtonStyle = ScrollBarButtonStyles.SmallScroll,
						IsPositionedInside = true,
						BackColor = Color.White, //Color.FromArgb(249, 246, 247),
						ButtonColor = Color.FromArgb(249, 246, 247) //Color.FromArgb(255, 232, 214)
					},
					IsStartedFromZero = true,


				},
				AxisY = new Axis
				{
					Minimum = 0,
					Maximum = 1,
					Interval = 1
				}

			};

			chartArea.AxisX.ScaleView.Zoom(-10, 40);

			return chartArea;

		}
		protected override Legend CreateLegend()
		{
			return new Legend
			{
				Name = "Legend",
				Title = "Положения и скорости автомобилей",
				AutoFitMinFontSize = 100,
				LegendStyle = LegendStyle.Table,
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
				
				Chart.Series[i].LegendText = LocalizationHelper.GetCarsMovementChartLegendText(y[i], x[i]);
				Chart.Series[i].Label = LocalizationHelper.GetCarsMovementChartLegendText(y[i], x[i]);
			}
		}
	}
}
