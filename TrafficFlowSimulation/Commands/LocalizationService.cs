using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Localization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Localization.Localization;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Properties.TranslationResources;
using TrafficFlowSimulation.Rendering;
using TrafficFlowSimulation.Windows;
using TrafficFlowSimulation.Сonstants;
using TrafficFlowSimulation.Windows.CustomControls;

namespace TrafficFlowSimulation.Commands
{
	public static class LocalizationService
	{
		public static void Translate(LocalizationComponentsModel lc)
		{
			lc.ParametersErrorProvider.UpdateBinding();
			lc.LanguagesSwitcherButton.Text = LocalizationHelper.Get<MenuResources>().LanguagesSwitcheButtomTitle;
			lc.StartToolStripButton.Text = LocalizationHelper.Get<MenuResources>().StartButtonTitle;
			lc.StopToolStripButton.Text = LocalizationHelper.Get<MenuResources>().StopButtonTitle;
			lc.ContinueToolStripButton.Text = LocalizationHelper.Get<MenuResources>().ContinueButtonTitle;
			lc.DrivingModeStripLabel.Text = LocalizationHelper.Get<MenuResources>().DrivingModeLabel;

			TranslateCombobox(lc.AutoScrollComboBox, typeof(AutoScroll));
			TranslateCombobox(lc.IdenticalCarsComboBox, typeof(IdenticalCars));
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
				SmoothnessCoefficientLabel = LocalizationHelper.Get<ParametersResources>().SmoothnessCoefficientLabel,
				InfluenceDistanceLabel = LocalizationHelper.Get<ParametersResources>().InfluenceDistanceLabel,
			};
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

		private static void TranslateCombobox(ComboBox comboBox, Type enumType)
		{
			var selectedItem = comboBox.SelectedItem;
			var elements = new List<ComboboxItem>();

			if (enumType == typeof(AutoScroll))
			{
				elements = (from AutoScroll e in Enum.GetValues(typeof(AutoScroll))
					select new ComboboxItem
					{
						Text = e.GetDescription(),
						Value = e
					}).ToList();
			}

			if (enumType == typeof(IdenticalCars))
			{
				elements = (from IdenticalCars e in Enum.GetValues(typeof(IdenticalCars))
					select new ComboboxItem
					{
						Text = e.GetDescription(),
						Value = e
					}).ToList();
			}

			comboBox.DataSource = elements;
			comboBox.SelectedItem = selectedItem ?? 0;
		}
	}
}