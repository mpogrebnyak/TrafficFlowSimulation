﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using Localization;
using TrafficFlowSimulation.Properties;

namespace TrafficFlowSimulation.Rendering.Renders
{
	public class SpeedChartRender : ChartsRender
	{
		public override string ChartText => "Speed";
		protected override string ChartName => "Speed";
		protected override string ChartAreaName => "SpeedChartArea";

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
					Minimum = 0,
					Maximum = 20,
				},
				AxisY = new Axis
				{
					Minimum = 0,
					Maximum = 20
				}
			};
		}

		protected override Legend CreateLegend(LegendStyle legendStyle)
		{
			return new Legend
			{
				Name = "Legend",
				Title = "Cкорости автомобилей",
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
				Chart.Series[i].Points.AddXY(t.Single(), y[i]);

				Chart.Series[i].LegendText = GetSpeedChartLegendText(y[i]);
			}
		}

		private static string GetSpeedChartLegendText(double speed)
		{
			return string.Format(
				LocalizationHelper.Get<MenuResources>().SpeedChartLegendText,
				Math.Round(speed, 2).ToString());
		}
	}
}