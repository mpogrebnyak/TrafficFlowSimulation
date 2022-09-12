using Localization;
using System;
using System.Globalization;
using System.Windows.Forms;
using Common;
using Common.Modularity;
using Localization.Localization;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Handlers;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Properties.LocalizationResources;
using TrafficFlowSimulation.Renders;
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
			var bootstrapper = new Bootstrapper();
			bootstrapper.Start();

			SetSettings();
			Registration();

			var trafficFlowSimulationModule = new TrafficFlowSimulationModule(); 
			trafficFlowSimulationModule.Initialize();

			CarsRenderingHelper.CreatePaintedCars();

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
			settings.CurrentParametersSelectionMode = ParametersSelectionMode.InliningDistance;
			settings.AvailableDrivingModes = 
				new[]
				{
					DrivingMode.StartAndStopMovement,
					DrivingMode.TrafficThroughOneTrafficLight,
					DrivingMode.InliningInFlow,
					DrivingMode.SpeedLimitChanging
				};
			SettingsHelper.Set<Properties.Settings>(settings);
		}
	}
}
