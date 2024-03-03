using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.EvaluationHandlers;
using ChartRendering.Helpers;
using ChartRendering.Properties;
using Common.Errors;
using Common.Modularity;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.Handlers;
using TrafficFlowSimulation.Helpers;

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

			var mainWindowConfiguration = new MainWindowConfiguration(this);

			mainWindowConfiguration.Initialize();

			ServiceLocator.Current.GetInstance<MainWindowHelper>().InitializeInterface();
			ServiceLocator.Current.GetInstance<IErrorManager>().ErrorEventHandler += HandleError;
		}

		private void StartToolStripButton_Click(object sender, EventArgs e)
		{
			var windowHelper = ServiceLocator.Current.GetInstance<MainWindowHelper>();
			var currentDrivingMode = ModesHelper.GetCurrentDrivingMode();
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentDrivingMode).AbortExecution();

			if (windowHelper.IsParametersValid() == false)
			{
				ParametersPanel.Show();
				return;
			}
			ParametersPanel.Hide();

			var modelParameters = windowHelper.CollectParametersFromBindingSource();
			var modeSettings = windowHelper.CollectModeSettingsFromBindingSource(modelParameters);
			ServiceLocator.Current.GetInstance<ChartRenderingHandler>(ModesHelper.DrivingModeType).RenderCharts(modelParameters, modeSettings);
			windowHelper.ResizeAllChart();

			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentDrivingMode).Execute(
				modelParameters,
				modeSettings,
				windowHelper.ChartEventHandler);
		}

		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			var currentDrivingMode = ModesHelper.GetCurrentDrivingMode();
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentDrivingMode).AbortExecution();
		}

		private void StopToolStripButton_Click(object sender, EventArgs e)
		{
			var currentDrivingMode = ModesHelper.GetCurrentDrivingMode();
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentDrivingMode).StopExecution();
		}

		private void ContinueToolStripButton_Click(object sender, EventArgs e)
		{
			var currentDrivingMode = ModesHelper.GetCurrentDrivingMode();
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentDrivingMode).StartExecution();
		}

		private void SubmitButton_Click(object sender, EventArgs e)
		{
			RenderCharts();
		}

		private void MainWindow_SizeChanged(object sender, EventArgs e)
		{
			if (ServiceLocator.Current.GetInstance<IServiceRegistrator>().IsRegistered<ChartRenderingHandler>(ModesHelper.DrivingModeType))
			{
				ServiceLocator.Current.GetInstance<ChartRenderingHandler>(ModesHelper.DrivingModeType).SetMarkerImage();
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
			var settings = SettingsHelper.Get<ChartRenderingSettings>();
			settings.IsTrafficCapacityAvailable = EstimateTrafficCapacityCheckBox.Checked;
			SettingsHelper.Set(settings);

			var currentDrivingMode = ModesHelper.GetCurrentDrivingMode();
			var isExecuted = ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentDrivingMode).IsExecuted();
			if (!isExecuted)
				RenderCharts();
		}

		private void RenderCharts()
		{
			var modelParameters = ServiceLocator.Current.GetInstance<MainWindowHelper>().CollectParametersFromBindingSource();
			var modeSettings = ServiceLocator.Current.GetInstance<MainWindowHelper>().CollectModeSettingsFromBindingSource(modelParameters);

			ServiceLocator.Current.GetInstance<ChartRenderingHandler>(ModesHelper.DrivingModeType).RenderCharts(modelParameters, modeSettings);
			ServiceLocator.Current.GetInstance<MainWindowHelper>().ResizeAllChart();
		}

		private void HandleError(object sender, ErrorEventArgs errorEventArgs)
		{
			ServiceLocator.Current.GetInstance<MainWindowHelper>().ShowError(sender.ToString(),errorEventArgs.GetException());
		}

		private void Chart_Resize(object sender, EventArgs e)
		{
			if (ServiceLocator.Current.GetInstance<IServiceRegistrator>().IsRegistered<ChartRenderingHandler>(ModesHelper.DrivingModeType))
			{
				ServiceLocator.Current.GetInstance<ChartRenderingHandler>(ModesHelper.DrivingModeType).SetMarkerImage();
				ServiceLocator.Current.GetInstance<MainWindowHelper>().ResizeChart((Chart) sender);
			}
		}

		private void CreateRandomFlowButton_Click(object sender, EventArgs e)
		{
			ServiceLocator.Current.GetInstance<MainWindowHelper>().CreateRandomFlow();
			RenderCharts();
		}
	}
}
