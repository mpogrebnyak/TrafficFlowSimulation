using System;
using System.Windows.Forms;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Handlers.EvaluationHandlers;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders;
using TrafficFlowSimulation.Windows.Components;
using TrafficFlowSimulation.Windows.Helpers;

namespace TrafficFlowSimulation.Windows
{
	public partial class ParametersSelectionWindow : Form
	{
		public ParametersSelectionWindow()
		{
			InitializeComponent();
			CustomInitializeComponent();
		}

		private void CustomInitializeComponent()
		{
			var slamPanelComponent = new SlamPanelComponent(Controls);
			slamPanelComponent.Initialize();

			ControlMenuStrip.Renderer = new ControlToolStripCustomRender();

			ParametersPanel.Hide();

			var parametersSelectionConfiguration = new ParametersSelectionWindowConfiguration(ParametersSelectionChart,
				ParametersErrorProvider,
				Controls);
			parametersSelectionConfiguration.Initialize();

			ServiceLocator.Current.GetInstance<ParametersSelectionWindowHelper>().InitializeInterface();
		}

		private void SelectParametersToolStripButton_Click(object sender, EventArgs e)
		{
			var modelParameters = ServiceLocator.Current.GetInstance<ParametersSelectionWindowHelper>().CollectParametersFromBindingSource();
			var modeSettings = ServiceLocator.Current.GetInstance<ParametersSelectionWindowHelper>().CollectModeSettingsFromBindingSource(modelParameters);

			ServiceLocator.Current.GetInstance<ParametersSelectionRenderingHandler>().RenderCharts(modelParameters);
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(ParametersSelectionMode.InliningDistanceEstimation.ToString()).Execute(
				this,
				modelParameters,
				modeSettings);
		}

		private void ParametersSelectionWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			var currentParametersSelectionMode = SettingsHelper.Get<Properties.Settings>().CurrentParametersSelectionMode;
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentParametersSelectionMode.ToString()).AbortExecution();
		}

		private void MainWindow_Shown(object sender, EventArgs e)
		{
			var modelParameters = ServiceLocator.Current.GetInstance<MainWindowHelper>().CollectParametersFromBindingSource();
			ServiceLocator.Current.GetInstance<MainWindowHelper>().CollectModeSettingsFromBindingSource(modelParameters);

			ServiceLocator.Current.GetInstance<ParametersSelectionRenderingHandler>().RenderCharts(modelParameters);
		}
	}
}
