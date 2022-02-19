using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using Localization;
using TrafficFlowSimulation.Properties.TranslationResources;
using TrafficFlowSimulation.Rendering.Models;

namespace TrafficFlowSimulation.Rendering.Renders
{
	public class SpeedChartRender : ChartsRender
	{
		public override string ChartText => "Speed";
		protected override string ChartName => "Speed";
		protected override string ChartAreaName => "SpeedChartArea";

		private readonly ChartAreaModel _chartAreaModel = new()
		{
			AxisXMinimum = 0,
			AxisXMaximum = 0,
			//AxisXInterval = 10,
			AxisYMinimum = 0,
			AxisYMaximum = 0,
			//AxisYInterval = 1,
			//ZoomShift = 48
		};

		public SpeedChartRender(ModelParameters modelParameters, Chart chart) : base(modelParameters, chart)
		{
		}

		public override void Render(SeriesChartType chartType)
		{
			base.Render(chartType);

			foreach (var series in Chart.Series.Where(x => x.Name.Contains(ChartName)))
			{
				var i = Convert.ToInt32(series.Name.Replace(ChartName, ""));
				Chart.Series[i].Points.AddXY(0, 0);

				Chart.Series[i].LegendText = GetSpeedChartLegendText(0);
			}
		}

		protected override ChartArea CreateChartArea()
		{
			return new ChartArea
			{
				Name = ChartAreaName,
				AxisX = new Axis
				{
					Minimum = _chartAreaModel.AxisXMinimum,
					Maximum = 20,
					Title = LocalizationHelper.Get<MenuResources>().TimeAxisTitleText,
					TitleFont = new Font("Microsoft Sans Serif", 10F),
					TitleAlignment = StringAlignment.Far
				},
				AxisY = new Axis
				{
					Minimum = _chartAreaModel.AxisYMinimum,
					Maximum = MaxSpeedRound(),
					Title = LocalizationHelper.Get<MenuResources>().SpeedAxisTitleText,
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
				Title = LocalizationHelper.Get<MenuResources>().SpeedChartLegendTitleText,
				TitleFont = new Font("Microsoft Sans Serif", 10F),
				LegendStyle = legendStyle,
				Font = new Font("Microsoft Sans Serif", 10F),
			};
		}

		public override void Update(List<double> t = null!, List<double> x = null!, List<double> y = null!)
		{
			foreach (var series in Chart.Series.Where(series => series.Name.Contains(ChartName)))
			{
				var i = Convert.ToInt32(series.Name.Replace(ChartName, ""));
				Chart.Series[i].Points.AddXY(t.Single(), y[i]);

				Chart.Series[i].LegendText = GetSpeedChartLegendText(y[i]);
			}
		}

		public void SetChartAreaAxisTitle(bool isHidden = false)
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
					Chart.ChartAreas[0].AxisX.Title = LocalizationHelper.Get<MenuResources>().TimeAxisTitleText;
					Chart.ChartAreas[0].AxisY.Title = LocalizationHelper.Get<MenuResources>().SpeedAxisTitleText;
				}
			}
		}

		private static string GetSpeedChartLegendText(double speed)
		{
			return string.Format(
				LocalizationHelper.Get<MenuResources>().SpeedChartLegendText,
				Math.Round(speed, 2).ToString());
		}
		
		private double MaxSpeedRound()
		{
			var round = Math.Round(ModelParameters.Vmax.Max() / 10) * 10;
			return round > ModelParameters.Vmax.Max() ? round : round + 10;
		}
	}
}
