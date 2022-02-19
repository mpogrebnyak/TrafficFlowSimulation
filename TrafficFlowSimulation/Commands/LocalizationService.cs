using System.Drawing;
using System.Linq;
using Localization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Properties;
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
			AllChartsTranslateLegend(lc.AllCharts);

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

		private static void AllChartsTranslateLegend(AllChartsModel allCharts)
		{
			TranslateLegend(allCharts.DistanceChart);
			TranslateLegend(allCharts.SpeedChart);
			TranslateLegend(allCharts.CarsMovementChart);
		}

		private static void TranslateLegend(Chart chart)
		{
			if (chart.Legends.Any())
				RenderingHelper.ShowLegend(chart.Text, chart.Legends[0].LegendStyle);
			else
				RenderingHelper.ShowLegend(chart.Text, LegendDisplayOptions.None);
		}
	}
}