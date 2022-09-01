using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common;
using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Handlers.EvaluationHandlers;
using TrafficFlowSimulation.Renders.ChartRenders;
using TrafficFlowSimulation.Renders.ChartRenders.ParametersSelectionRenders;
using TrafficFlowSimulation.Windows.Helpers;

namespace TrafficFlowSimulation.Windows
{
	public partial class ParametersSelectionWindow : Form
	{
		public ParametersSelectionWindow()
		{
			
			InitializeComponent();
			var ee = ParametersSelectionStripDropDownButton.DropDownItems;
			CustomInitializeComponent();
			//parametersPanel.Hide();

			//ServiceLocator.Current.GetInstance<IChartRender>(ParametersSelectionChart.Name+ ParametersSelectionMode.InliningDistance).RenderChart(null);
		}

		private void CustomInitializeComponent()
		{
			ControlMenuStrip.Renderer = new ControlToolStripCustomRender();

			var parametersSelectionConfiguration = new ParametersSelectionWindowConfiguration(ParametersSelectionChart,
				ParametersErrorProvider,
				Controls);

			parametersSelectionConfiguration.Initialize();

			ServiceLocator.Current.GetInstance<ParametersSelectionWindowHelper>().InitializeInterface();
		}

		private void SlamPanel_MouseClick(object sender, MouseEventArgs e)
		{
			if (parametersPanel.Visible)
				parametersPanel.Hide();
			else
				parametersPanel.Show();
		}

		private void SelectParametersToolStripButton_Click(object sender, EventArgs e)
		{
			var modelParameters = ServiceLocator.Current.GetInstance<ParametersSelectionWindowHelper>().CollectParametersFromBindingSource();
			var modeSettings = ServiceLocator.Current.GetInstance<ParametersSelectionWindowHelper>().CollectModeSettingsFromBindingSource(modelParameters);

			ServiceLocator.Current.GetInstance<ParametersSelectionRenderingHandler>().RenderCharts(modelParameters);
			ServiceLocator.Current.GetInstance<IEvaluationHandler>(ParametersSelectionMode.InliningDistance.ToString()).Execute(
				this,
				modelParameters,
				modeSettings);
		}

        private void ParametersSelectionWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
	        
        }
    }
}
