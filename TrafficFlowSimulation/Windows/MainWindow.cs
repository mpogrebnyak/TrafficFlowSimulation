﻿using System;
using System.Windows.Forms;
using Common.Modularity;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.Handlers.EvaluationHandlers;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Renders.ChartRenders.MovementSimulationRenders;
using TrafficFlowSimulation.Windows.Helpers;
using TrafficFlowSimulation.Windows.Models;

namespace TrafficFlowSimulation.Windows
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
			CustomInitializeComponent();

			//TODO: доделать возможность импорта и экспорта параметров
			SaveButton.Enabled = false;
			SaveButton.Hide();
			LoadButton.Enabled = false;
			LoadButton.Hide();
		}

		private void CustomInitializeComponent()
		{
			ParametersPanel.Hide();
			ChartsSplitContainer.Panel2Collapsed = true;
			ChartsSplitContainer.Panel2.Hide();

			CarsMovementSplitContainer.SplitterDistance = CarsMovementSplitContainer.Size.Height / 2;
			SpeedAndDistanceSplitContainer.SplitterDistance = ChartsSplitContainer.Size.Width / 2;

			ControlMenuStrip.Renderer = new ControlToolStripCustomRender();

			var allCharts = new AllChartsModel
			{
				SpeedChart = SpeedChart,
				DistanceChart = DistanceChart,
				SpeedFromDistanceChart = SpeedFromDistanceChart,
				CarsMovementChart = CarsMovementChart
			};

			var localizationComponents = new LocalizationComponentsModel
			{
				AllCharts = allCharts,
				ParametersErrorProvider = ParametersErrorProvider,
				LanguagesSwitcherButton = LanguagesSwitcherButton,
				StartToolStripButton = StartToolStripButton,
				StopToolStripButton = StopToolStripButton,
				ContinueToolStripButton = ContinueToolStripButton,
				DrivingModeStripLabel = DrivingModeStripLabel,
				MovementParametersGroupBox = MovementParametersGroupBox,
				BasicParametersGroupBox = BasicParametersGroupBox,
				AdditionalParametersGroupBox = AdditionalParametersGroupBox,
				InitialConditionsGroupBox = InitialConditionsGroupBox,
				ModeSettingsGroupBox = ModeSettingsGroupBox,
				ControlsGroupBox = ControlsGroupBox,
				DrivingModeStripDropDownButton = DrivingModeStripDropDownButton,
				SubmitButton = SubmitButton,
				ParametersSelectionToolStripButton = ParametersSelectionToolStripButton
			};

			var mainWindowConfiguration = new MainWindowConfiguration(localizationComponents,
				allCharts,
				ParametersErrorProvider,
				Controls);

			mainWindowConfiguration.Initialize();

			ServiceLocator.Current.GetInstance<MainWindowHelper>().InitializeInterface();
		}

		private void StartToolStripButton_Click(object sender, EventArgs e)
		{
			ParametersPanel.Hide();

			var modelParameters = ServiceLocator.Current.GetInstance<MainWindowHelper>().CollectParametersFromBindingSource();
			var modeSettings = ServiceLocator.Current.GetInstance<MainWindowHelper>().CollectModeSettingsFromBindingSource(modelParameters);

			ServiceLocator.Current.GetInstance<RenderingHandler>().RenderCharts(modelParameters, modeSettings);

			var currentDrivingMode = SettingsHelper.Get<Properties.Settings>().CurrentDrivingMode;
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentDrivingMode.ToString()).AbortExecution();
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentDrivingMode.ToString()).Execute(
				this,
				modelParameters,
				modeSettings);
		}

		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			var currentDrivingMode = SettingsHelper.Get<Properties.Settings>().CurrentDrivingMode;
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentDrivingMode.ToString()).AbortExecution();
		}

		private void StopToolStripButton_Click(object sender, EventArgs e)
		{
			var currentDrivingMode = SettingsHelper.Get<Properties.Settings>().CurrentDrivingMode;
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentDrivingMode.ToString()).StopExecution();
		}

		private void ContinueToolStripButton_Click(object sender, EventArgs e)
		{
			var currentDrivingMode = SettingsHelper.Get<Properties.Settings>().CurrentDrivingMode;
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentDrivingMode.ToString()).StartExecution();
		}

		private void SubmitButton_Click(object sender, EventArgs e)
		{
			RenderCharts();
		}

		private void MainWindow_SizeChanged(object sender, EventArgs e)
		{
			if (ServiceLocator.Current.GetInstance<IServiceRegistrator>().IsRegistered<RenderingHandler>())
			{
				var modelParameters = ServiceLocator.Current.GetInstance<MainWindowHelper>().CollectParametersFromBindingSource();
				ServiceLocator.Current.GetInstance<RenderingHandler>().SetMarkerImage(modelParameters.lCar);
			}
		}

		private void MainWindow_Shown(object sender, EventArgs e)
		{
			RenderCharts();
		}

		private void ParametersSelectionToolStripButton_Click(object sender, EventArgs e)
		{
			var parametersSelectionWindow = new ParametersSelectionWindow();
			parametersSelectionWindow.ShowDialog();
		}

		private void EstimateTrafficCapacityCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			var settings = SettingsHelper.Get<Properties.Settings>();
			settings.IsTrafficCapacityAvailable = EstimateTrafficCapacityCheckBox.Checked;
			SettingsHelper.Set(settings);

			RenderCharts();
		}

		private static void RenderCharts()
		{
			var modelParameters = ServiceLocator.Current.GetInstance<MainWindowHelper>().CollectParametersFromBindingSource();
			var modeSettings = ServiceLocator.Current.GetInstance<MainWindowHelper>().CollectModeSettingsFromBindingSource(modelParameters);

			ServiceLocator.Current.GetInstance<RenderingHandler>().RenderCharts(modelParameters, modeSettings);
		}
	}
}
