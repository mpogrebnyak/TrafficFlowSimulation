using Localization;
using System;
using System.Globalization;
using System.Windows.Forms;
using Localization.Localization;
using Settings;
using TrafficFlowSimulation.Properties.TranslationResources;
using TrafficFlowSimulation.Windows;
using TrafficFlowSimulation.Сonstants;

namespace TrafficFlowSimulation
{

	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			SetSettings();
			Registration();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainWindow());
		}

		private static void Registration()
		{
			CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("Ru");

			var menuResourcesProvider = new ResourceProvider(typeof(MenuResources));
			var parametersResourcesProvider = new ResourceProvider(typeof(ParametersResources));
			LocalizationHelper.Register(menuResourcesProvider);
			LocalizationHelper.Register(parametersResourcesProvider);
		}

		private static void SetSettings()
		{
			SettingsHelper.InitializeSettings();

			var settings = SettingsHelper.Get<Properties.Settings>();
			settings.AvailableDrivingModes = 
				new[]
				{
					DrivingMode.StartAndStopMovement,
					DrivingMode.TrafficThroughTrafficLights
				};
			SettingsHelper.Set<Properties.Settings>(settings);
		}
	}
}
