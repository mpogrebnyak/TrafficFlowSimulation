using Localization;
using System;
using System.Globalization;
using System.Windows.Forms;
using ChartRendering;
using ChartRendering.Renders;
using Common;
using Common.Errors;
using Common.Modularity;
using Localization.Localization;
using Settings;
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
			var bootstrapper = new Bootstrapper();
			bootstrapper.Start();

			SetSettings();
			Registration();

			var chartRenderingModule = new ChartRenderingModule(); 
			chartRenderingModule.Initialize();

			CarsRenderingHelper.CreatePaintedCars();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainWindow());
		}

		private static void Registration()
		{
			CommonHelper.ServiceRegistration.RegisterInstance<IErrorManager>(() => new ErrorManager(), skipIfAlreadyRegistered: false);

			CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("Ru");

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

		/*	var settings = SettingsHelper.Get<ChartRenderingSettings>();
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
			SettingsHelper.Set<ChartRendering.Properties.ChartRenderingSettings>(settings);*/
		}
	}
}
