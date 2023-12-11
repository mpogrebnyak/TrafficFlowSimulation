using Localization;
using System;
using System.Globalization;
using System.Windows.Forms;
using Common;
using Common.Errors;
using Common.Modularity;
using Localization.Localization;
using Settings;
using TrafficFlowSimulation.Constants.Modes;
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
			CommonHelper.ServiceRegistrator.RegisterInstance<IErrorManager>(() => new ErrorManager());

			CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("Ru");

			var chartResourcesProvider = new ResourceProvider(typeof(ChartResources));
			LocalizationHelper.Register(chartResourcesProvider);

			var contextMenuResourcesProvider = new ResourceProvider(typeof(ContextMenuResources));
			LocalizationHelper.Register(contextMenuResourcesProvider);

			var mainWindowMenuResourcesProvider = new ResourceProvider(typeof(MainWindowResources));
			LocalizationHelper.Register(mainWindowMenuResourcesProvider);

			var parametersSelectionWindowResourcesProvider = new ResourceProvider(typeof(ParametersSelectionWindowResources));
			LocalizationHelper.Register(parametersSelectionWindowResourcesProvider);
		}

		private static void SetSettings()
		{
			SettingsHelper.InitializeSettings();

			var settings = SettingsHelper.Get<Properties.Settings>();
			settings.CurrentDrivingMode = DrivingMode.StartAndStopMovement;
			settings.CurrentParametersSelectionMode = ParametersSelectionMode.InliningDistanceEstimation;
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
