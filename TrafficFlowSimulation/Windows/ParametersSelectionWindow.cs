using System;
using System.Windows.Forms;
using ChartRendering.EvaluationHandlers;
using ChartRendering.Helpers;
using Microsoft.Practices.ServiceLocation;
using Modes;
using TrafficFlowSimulation.Handlers;
using TrafficFlowSimulation.Helpers;
using TrafficFlowSimulation.Windows.Components;

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

			var parametersSelectionConfiguration = new ParametersSelectionWindowConfiguration(this);
			parametersSelectionConfiguration.Initialize();

			ServiceLocator.Current.GetInstance<ParametersSelectionWindowHelper>().InitializeInterface();
		}

		private void SelectParametersToolStripButton_Click(object sender, EventArgs e)
		{
			var modelParameters = ServiceLocator.Current.GetInstance<ParametersSelectionWindowHelper>().CollectParametersFromBindingSource();
			var modeSettings = ServiceLocator.Current.GetInstance<ParametersSelectionWindowHelper>().CollectModeSettingsFromBindingSource(modelParameters);

			ServiceLocator.Current.GetInstance<ChartRenderingHandler>(ModesHelper.ParametersSelectionModeType).RenderCharts(modelParameters, modeSettings);

			var currentParametersSelectionMode = ModesHelper.GetCurrentParametersSelectionMode();
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentParametersSelectionMode).AbortExecution();

			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentParametersSelectionMode)
				.Execute(
					modelParameters,
					modeSettings,
					FormUpdateHandler.GetEvent());
		}

		private void ParametersSelectionWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			var currentParametersSelectionMode = ModesHelper.GetCurrentParametersSelectionMode();
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentParametersSelectionMode).AbortExecution();
		}

		private void ParametersSelectionWindowHelper_Shown(object sender, EventArgs e)
		{
			var modelParameters = ServiceLocator.Current.GetInstance<ParametersSelectionWindowHelper>().CollectParametersFromBindingSource();
			var modeSettings = ServiceLocator.Current.GetInstance<ParametersSelectionWindowHelper>().CollectModeSettingsFromBindingSource(modelParameters);

			ServiceLocator.Current.GetInstance<ChartRenderingHandler>(ModesHelper.ParametersSelectionModeType).RenderCharts(modelParameters, modeSettings);
		}

		private void ImportPointsButton_Click(object sender, EventArgs e)
		{
			var currentParametersSelectionMode = ModesHelper.GetCurrentParametersSelectionMode();
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentParametersSelectionMode).AbortExecution();

			var filePath = ServiceLocator.Current.GetInstance<ParametersSelectionWindowHelper>().GetFilePathFromFileDialog();

			if(filePath == null)
				return;

			var serializerPointsModel = SerializerPointsHelper.DeserializePoints(filePath);

			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentParametersSelectionMode).ExecutePreCalculated(serializerPointsModel.ModelParameters, serializerPointsModel.ModeSettings, serializerPointsModel.CoordinatesModel);
		}
	}
}
