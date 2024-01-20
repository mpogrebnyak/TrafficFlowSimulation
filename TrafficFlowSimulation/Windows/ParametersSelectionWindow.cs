using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.EvaluationHandlers;
using ChartRendering.Helpers;
using Common.Modularity;
using Microsoft.Practices.ServiceLocation;
using Modes;
using TrafficFlowSimulation.Components;
using TrafficFlowSimulation.Handlers;
using TrafficFlowSimulation.Helpers;

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
			var windowHelper = ServiceLocator.Current.GetInstance<ParametersSelectionWindowHelper>();

			var modelParameters = windowHelper.CollectParametersFromBindingSource();
			var modeSettings = windowHelper.CollectModeSettingsFromBindingSource(modelParameters);

			ServiceLocator.Current.GetInstance<ChartRenderingHandler>(ModesHelper.ParametersSelectionModeType).RenderCharts(modelParameters, modeSettings);
			windowHelper.ResizeAllChart();

			var currentParametersSelectionMode = ModesHelper.GetCurrentParametersSelectionMode();
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentParametersSelectionMode).AbortExecution();

			ServiceLocator.Current.GetInstance<IEvaluationHandler>(currentParametersSelectionMode)
				.Execute(
					modelParameters,
					modeSettings,
					windowHelper.ChartEventHandler);
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
			ServiceLocator.Current.GetInstance<ParametersSelectionWindowHelper>().ResizeAllChart();
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

		private void Chart_Resize(object sender, EventArgs e)
		{
			if (ServiceLocator.Current.GetInstance<IServiceRegistrator>().IsRegistered<ChartRenderingHandler>(ModesHelper.ParametersSelectionModeType))
			{
				ServiceLocator.Current.GetInstance<ParametersSelectionWindowHelper>().ResizeChart((Chart) sender);
			}
		}
	}
}
