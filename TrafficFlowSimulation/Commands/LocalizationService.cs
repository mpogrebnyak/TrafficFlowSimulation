using System;
using System.Drawing;
using System.Linq;
using Localization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Properties.TranslationResources;
using TrafficFlowSimulation.Rendering;
using TrafficFlowSimulation.Сonstants;

namespace TrafficFlowSimulation.Commands
{
	public static class LocalizationService
	{
		public static void Translate(LocalizationComponentsModel lc)
		{
			lc.ParametersErrorProvider.UpdateBinding();
			lc.LanguagesSwitcherButton.Text = LocalizationHelper.Get<MenuResources>().LanguagesSwitcheButtomTitle;
			lc.StartToolStripButton.Text = LocalizationHelper.Get<MenuResources>().StartButtonTitle;

			FillAutoScrollComboBox(lc.AutoScrollComboBox);
			AllChartsTranslator(lc.AllCharts);

			lc.LocalizationBinding.DataSource = new ParametersResources
			{
				MovementParametersGroupBoxText = LocalizationHelper.Get<ParametersResources>().MovementParametersGroupBoxText,
				ModeSettingsGroupBoxText = LocalizationHelper.Get<ParametersResources>().ModeSettingsGroupBoxText,
				BasicParametersGroupBoxText = LocalizationHelper.Get<ParametersResources>().BasicParametersGroupBoxText,
				AdditionalParametersGroupBoxText = LocalizationHelper.Get<ParametersResources>().AdditionalParametersGroupBoxText,
				InitialConditionsGroupBoxText = LocalizationHelper.Get<ParametersResources>().InitialConditionsGroupBoxText,
				ControlsGroupBoxText = LocalizationHelper.Get<ParametersResources>().ControlsGroupBoxText,

				VehiclesNumberLabel = LocalizationHelper.Get<ParametersResources>().VehiclesNumberLabel,
				IdenticalCarsLabel = LocalizationHelper.Get<ParametersResources>().IdenticalCarsLabel,
				DriverResponseTimeLabel = LocalizationHelper.Get<ParametersResources>().DriverResponseTimeLabel,
				MaximumSpeedLabel = LocalizationHelper.Get<ParametersResources>().MaximumSpeedLabel,
				AccelerationIntensityLabel = LocalizationHelper.Get<ParametersResources>().AccelerationIntensityLabel,
				DecelerationIntensityLabel = LocalizationHelper.Get<ParametersResources>().DecelerationIntensityLabel,
				SafelyDistanceLabel = LocalizationHelper.Get<ParametersResources>().SafelyDistanceLabel,
			};
		}

		public static ComboBox FillAutoScrollComboBox(ComboBox comboBox)
		{
			var selectedIndex = comboBox.SelectedIndex;
			comboBox.Items.Clear();
			comboBox.Items.Add(LocalizationHelper.Get<MenuResources>().YesTitle);
			comboBox.Items.Add(LocalizationHelper.Get<MenuResources>().NoTitle);
			comboBox.SelectedIndex = selectedIndex == -1 ? 1 : selectedIndex;
			return comboBox;
		}

		private static void AllChartsTranslator(AllChartsModel allCharts)
		{
			TranslateChart(allCharts.DistanceChart);
			TranslateChart(allCharts.SpeedChart);
			TranslateChart(allCharts.CarsMovementChart);
			ShowXAxis(allCharts);
			ShowYAxis(allCharts);
		}

		private static void TranslateChart(Chart chart)
		{
			if (chart.Legends.Any())
				RenderingHelper.ShowLegend(chart.Text, chart.Legends[0].LegendStyle);
			else
				RenderingHelper.ShowLegend(chart.Text, LegendDisplayOptions.None);
		}
		
		private static void ShowXAxis(AllChartsModel allCharts)
		{
			if (allCharts.SpeedChart.ChartAreas.Any() &&
			    !String.IsNullOrEmpty(allCharts.SpeedChart.ChartAreas[0].AxisX.Title))
			{
				allCharts.SpeedChart.ChartAreas[0].AxisX.Title =
					LocalizationHelper.Get<MenuResources>().TimeAxisTitleText;
			}

			if (allCharts.DistanceChart.ChartAreas.Any() &&
			    !String.IsNullOrEmpty(allCharts.DistanceChart.ChartAreas[0].AxisX.Title))
			{
				allCharts.DistanceChart.ChartAreas[0].AxisX.Title =
					LocalizationHelper.Get<MenuResources>().TimeAxisTitleText;
			}

			if (allCharts.CarsMovementChart.ChartAreas.Any() &&
			    !String.IsNullOrEmpty(allCharts.CarsMovementChart.ChartAreas[0].AxisX.Title))
			{
				allCharts.CarsMovementChart.ChartAreas[0].AxisX.Title =
					LocalizationHelper.Get<MenuResources>().DistanceAxisTitleText;
			}
		}

		private static void ShowYAxis(AllChartsModel allCharts)
		{
			if (allCharts.SpeedChart.ChartAreas.Any() &&
			    !String.IsNullOrEmpty(allCharts.SpeedChart.ChartAreas[0].AxisY.Title))
			{
				allCharts.SpeedChart.ChartAreas[0].AxisY.Title =
					LocalizationHelper.Get<MenuResources>().SpeedChartLegendTitleText;
			}

			if (allCharts.DistanceChart.ChartAreas.Any() &&
			    !String.IsNullOrEmpty(allCharts.DistanceChart.ChartAreas[0].AxisY.Title))
			{
				allCharts.DistanceChart.ChartAreas[0].AxisY.Title =
					LocalizationHelper.Get<MenuResources>().DistanceAxisTitleText;
			}
		}
	}
}