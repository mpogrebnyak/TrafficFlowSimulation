using System;
using System.Windows.Forms;
using Microsoft.Practices.ServiceLocation;
using Settings;
using TrafficFlowSimulation.Handlers.EvaluationHandlers;
using TrafficFlowSimulation.Handlers.EvaluationHandlers.ParametersSelectionEvaluationHandlers.Helpers;
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

			ServiceLocator.Current.GetInstance<ParametersSelectionRenderingHandler>().RenderCharts(modelParameters, modeSettings);

			var currentParametersSelectionMode = SettingsHelper.Get<Properties.Settings>().CurrentParametersSelectionMode;
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentParametersSelectionMode.ToString()).AbortExecution();
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentParametersSelectionMode.ToString()).Execute(
				this,
				modelParameters,
				modeSettings);
		}

		private void ParametersSelectionWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			var currentParametersSelectionMode = SettingsHelper.Get<Properties.Settings>().CurrentParametersSelectionMode;
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentParametersSelectionMode.ToString()).AbortExecution();
		}

		private void ParametersSelectionWindowHelper_Shown(object sender, EventArgs e)
		{
			var modelParameters = ServiceLocator.Current.GetInstance<ParametersSelectionWindowHelper>().CollectParametersFromBindingSource();
			var modeSettings = ServiceLocator.Current.GetInstance<ParametersSelectionWindowHelper>().CollectModeSettingsFromBindingSource(modelParameters);

			ServiceLocator.Current.GetInstance<ParametersSelectionRenderingHandler>().RenderCharts(modelParameters, modeSettings);
		}

		private void ImportPointsButton_Click(object sender, EventArgs e)
		{
			var currentParametersSelectionMode = SettingsHelper.Get<Properties.Settings>().CurrentParametersSelectionMode;
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentParametersSelectionMode.ToString()).AbortExecution();

			var filePath = ServiceLocator.Current.GetInstance<ParametersSelectionWindowHelper>().GetFilePathFromFileDialog();

			if(filePath == null)
				return;

			var points = SerializerPointsHelper.DeserializePoints(filePath, out var modelParameters, out var modeSettings);

			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentParametersSelectionMode.ToString()).ExecutePreCalculated(this, modelParameters, modeSettings, points);
		}
	}
}
