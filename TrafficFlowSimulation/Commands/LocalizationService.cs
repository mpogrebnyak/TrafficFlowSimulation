using Localization;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Properties;

namespace TrafficFlowSimulation.Commands
{
	public static class LocalizationService
	{
		public static void Translate(LocalizationComponentsModel lc)
		{
			lc.ParametersErrorProvider.UpdateBinding();
			lc.LanguagesSwitcherButton.Text = LocalizationHelper.Get<MenuResources>().LanguagesSwitcheButtomTitle;
			lc.StartToolStripButton.Text = LocalizationHelper.Get<MenuResources>().StartButtonTitle;

			lc.LocalizationBinding.DataSource = new ParametersResources
			{
				MovementParametersGroupBoxText = LocalizationHelper.Get<ParametersResources>().MovementParametersGroupBoxText,
				ModeSettingsGroupBoxText = LocalizationHelper.Get<ParametersResources>().ModeSettingsGroupBoxText,
				BasicParametersGroupBoxText = LocalizationHelper.Get<ParametersResources>().BasicParametersGroupBoxText,


				VehiclesNumberLabel = LocalizationHelper.Get<ParametersResources>().VehiclesNumberLabel,
				IdenticalCarsLabel = LocalizationHelper.Get<ParametersResources>().IdenticalCarsLabel,
				DriverResponseTimeLabel = LocalizationHelper.Get<ParametersResources>().DriverResponseTimeLabel,
				MaximumSpeedLabel = LocalizationHelper.Get<ParametersResources>().MaximumSpeedLabel,
				AccelerationIntensityLabel = LocalizationHelper.Get<ParametersResources>().AccelerationIntensityLabel,
				DecelerationIntensityLabel = LocalizationHelper.Get<ParametersResources>().DecelerationIntensityLabel,
				SafelyDistanceLabel = LocalizationHelper.Get<ParametersResources>().SafelyDistanceLabel,
			};
		}
	}
}