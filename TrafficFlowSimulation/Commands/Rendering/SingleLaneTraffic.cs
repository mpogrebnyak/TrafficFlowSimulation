using EvaluationKernel.Models;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace TrafficFlowSimulation.Commands.Rendering
{
	public class SingleLaneTraffic : ChartsRender
	{
		protected override string ChartName => "Car";

		public SingleLaneTraffic(ModelParameters modelParameters, Chart chart) : base(modelParameters, chart)
		{
		}

		public override void Render(SeriesChartType chartType)
		{
			base.Render(chartType);

			Chart.ApplyPaletteColors();

			var carsFolder = Resources.Settings.PaintedCarsFolder;
			var count = 0;
			foreach (var series in Chart.Series)
			{
				var name = series.Name;
				if (name.Contains(ChartName))
				{
					Chart.Series[name].MarkerImage = carsFolder + "\\" + Chart.Series[name].Color.Name + ".png";
					Chart.Series[name].Points.AddXY(ModelParameters.lambda[count], 4);
					Chart.Series[name].LegendText = LocalizationHelper.GetLegendText(0, Chart.Series[name].Points[0].XValue);
					Chart.Series[name].Label = LocalizationHelper.GetLegendText(0, Chart.Series[name].Points[0].XValue);
					count++;
				}
			}
		}

		protected override Series[] CreateEnvironment()
		{
			var srartLineSeries = new Series
			{
				Name = "SrartLine",
				ChartType = SeriesChartType.Line,
				ChartArea = "carsMovementChartArea", //chartArea.Name,
				BorderWidth = 1,
				Color = Color.Red,
				IsVisibleInLegend = false
			};
			srartLineSeries.Points.Add(new DataPoint(0, 0));
			srartLineSeries.Points.Add(new DataPoint(0, 8));
			
			var endLineSeries = new Series
			{
				Name = "EndLine",
				ChartType = SeriesChartType.Line,
				ChartArea = "carsMovementChartArea", //chartArea.Name,
				BorderWidth = 1,
				Color = Color.Red,
				IsVisibleInLegend = false
			};
			endLineSeries.Points.Add(new DataPoint(ModelParameters.L, 0));
			endLineSeries.Points.Add(new DataPoint(ModelParameters.L, 8));

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
				Name = "carsMovementChartArea",
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
					Maximum = 8,
					Interval = 8
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
	}
}
