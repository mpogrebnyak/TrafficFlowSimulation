using Localization;
using System;
using System.Globalization;
using System.Windows.Forms;
using Localization.Localization;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers;
using TrafficFlowSimulation.Properties.LocalizationResources;
using TrafficFlowSimulation.Windows;

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
			var serviceRegistrator = new UnityServiceRegistrator();

			var locator = serviceRegistrator.CreateLocator();
			ServiceLocator.SetLocatorProvider(() => locator);
			
			SetSettings();
			Registration();

			CarsRenderingHelper.CreatePaintedCars();
			var ee = new TrafficFlowSimulationModule(); 
			ee.Initialize();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainWindow());
		}

		private static void Registration()
		{
			CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("Ru");

			var menuResourcesProvider = new ResourceProvider(typeof(MenuResources));
			LocalizationHelper.Register(menuResourcesProvider);
		}

		private static void SetSettings()
		{
			SettingsHelper.InitializeSettings();

			var settings = SettingsHelper.Get<Properties.Settings>();
			settings.CurrentDrivingMode = DrivingMode.StartAndStopMovement;
			settings.AvailableDrivingModes = 
				new[]
				{
					DrivingMode.StartAndStopMovement,
					DrivingMode.TrafficThroughOneTrafficLight,
					DrivingMode.InliningInFlow
				};
			SettingsHelper.Set<Properties.Settings>(settings);
		}
	}
}
