using System;
using System.Threading;
using Localization;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Resources;

namespace TrafficFlowSimulation.Helpers
{
	public static class LocalizationHelper
	{
		private static ResourceBuilder ResourceBuilder;

		private static LocalizationComponentsModel LocalizationComponents;

		public static void InitializeResource(LocalizationComponentsModel lc)
		{
			LocalizationComponents = lc;

			var menuResourcesProvider = new ResourceProvider(typeof(MenuResources));
			var parametersResourcesProvider = new ResourceProvider(typeof(ParametersResources));

			var resourceManager = new ResourceManager(); 
			resourceManager.Register(menuResourcesProvider);
			resourceManager.Register(parametersResourcesProvider);

			ResourceBuilder = new ResourceBuilder(resourceManager);
		}

		public static void Translate()
		{
			var lc = LocalizationComponents;
			lc.ParametersErrorProvider.UpdateBinding();
			lc.LanguagesSwitcherButton.Text = ResourceBuilder.Get<MenuResources>().LanguagesSwitcheButtomTitle;
			lc.StartToolStripButton.Text = ResourceBuilder.Get<MenuResources>().StartButtonTitle;

			lc.LocalizationBinding.DataSource = new ParametersResources
			{
				ParametersTitle = ResourceBuilder.Get<ParametersResources>().ParametersTitle,
				VehiclesNumberLabel = ResourceBuilder.Get<ParametersResources>().VehiclesNumberLabel,
				MaximumSpeedLabel = ResourceBuilder.Get<ParametersResources>().MaximumSpeedLabel,
				AccelerationIntensityLabel = ResourceBuilder.Get<ParametersResources>().AccelerationIntensityLabel,
				DecelerationIntensityLabel = ResourceBuilder.Get<ParametersResources>().DecelerationIntensityLabel
			};
		}

		public static string GetCarsMovementChartLegendText(double speed, double position)
		{
			var currentLocale = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
			var ee = ResourceBuilder.Get<MenuResources>().CarsMovementChartLegendText;
			return string.Format(
					ResourceBuilder.Get<MenuResources>().CarsMovementChartLegendText,
					Math.Round(speed, 2).ToString(),
					Math.Round(position, 2).ToString());
		}

		public static string GetSpeedChartLegendText(double speed)
		{
			return string.Format(
				ResourceBuilder.Get<MenuResources>().SpeedChartLegendText,
				Math.Round(speed, 2).ToString());
		}

		public static string GetDistanceChartLegendText(double position)
		{
			return string.Format(
				ResourceBuilder.Get<MenuResources>().DistanceChartLegendText,
				Math.Round(position, 2).ToString());
		}
	}
}
