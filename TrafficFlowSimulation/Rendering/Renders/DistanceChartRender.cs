using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using Localization;
using TrafficFlowSimulation.Properties.TranslationResources;

namespace TrafficFlowSimulation.Rendering.Renders
{
	public class DistanceChartRender : ChartsRender
	{
		public override string ChartText => "Distance";
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

				Chart.Series[i].LegendText = GetDistanceChartLegendText(ModelParameters.lambda[i]);
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
					Title = LocalizationHelper.Get<MenuResources>().TimeAxisTitleText,
					TitleFont = new Font("Microsoft Sans Serif", 10F),
					TitleAlignment = StringAlignment.Far
				},
				AxisY = new Axis
				{
					Minimum = 0,
					Maximum = ModelParameters.L + 100,
					Title = LocalizationHelper.Get<MenuResources>().DistanceAxisTitleText,
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
				Title = LocalizationHelper.Get<MenuResources>().DistanceChartLegendTitleText,
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
				Chart.Series[i].Points.AddXY(t.Single(), x[i]);

				Chart.Series[i].LegendText = GetDistanceChartLegendText(x[i]);
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
					Chart.ChartAreas[0].AxisY.Title = LocalizationHelper.Get<MenuResources>().DistanceAxisTitleText;
				}
			}
		}

		private static string GetDistanceChartLegendText(double position)
		{
			return string.Format(
				LocalizationHelper.Get<MenuResources>().DistanceChartLegendText,
				Math.Round(position, 2).ToString());
		}
	}
}
