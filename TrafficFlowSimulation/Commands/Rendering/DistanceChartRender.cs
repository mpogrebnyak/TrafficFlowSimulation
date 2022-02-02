﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EvaluationKernel.Models;
using System.Windows.Forms.DataVisualization.Charting;

namespace TrafficFlowSimulation.Commands.Rendering
{
	public class DistanceChartRender : ChartsRender
	{
		protected override string ChartName => "Distance";
		protected override string ChartAreaName => "DistanceChartArea";

		public DistanceChartRender(ModelParameters modelParameters, Chart chart) : base(modelParameters, chart)
		{
		}

		public override void Render(SeriesChartType chartType)
		{
			base.Render(chartType);

			foreach (var series in Chart.Series.Where(x => x.Name.Contains(ChartName)))
			{
				var i = Convert.ToInt32(series.Name.Replace(ChartName, ""));
				Chart.Series[i].Points.AddXY(0, ModelParameters.lambda[i]);

				Chart.Series[i].LegendText = LocalizationHelper.GetDistanceChartLegendText(ModelParameters.lambda[i]);
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
					Maximum = 20
				},
				AxisY = new Axis
				{
					Minimum = 0,
					Maximum = ModelParameters.L + 100
				}
			};
		}
		protected override Legend CreateLegend()
		{
			return new Legend
			{
				Name = "Legend",
				Title = "Положение автомобилей",
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
				Chart.Series[i].Points.AddXY(t.Single(), x[i]);

				Chart.Series[i].LegendText = LocalizationHelper.GetDistanceChartLegendText(x[i]);
			}
		}
	}
}
