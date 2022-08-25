using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel;
using EvaluationKernel.Equations;
using EvaluationKernel.Models;
using Microsoft.Practices.ServiceLocation;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Handlers.EvaluationHandlers;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers;
using TrafficFlowSimulation.MovementSimulation.RenderingHandlers.Renders;
using TrafficFlowSimulation.Windows.Helpers;

namespace TrafficFlowSimulation.Windows
{
	public partial class ParametersEvaluationWindow : Form
	{
		public ParametersEvaluationWindow(ModelParameters modelParameters)
		{
			InitializeComponent();
			CustomInitializeComponent();
			parametersPanel.Hide();

			ServiceLocator.Current.GetInstance<IChartRender>(ParametersSelectionChart.Name+ ParametersSelectionMode.InliningDistance).RenderChart(null);
		}

		private void CustomInitializeComponent()
		{
			var parametersEvaluationConfiguration = new ParametersEvaluationWindowConfiguration(ParametersSelectionChart,
				ParametersErrorProvider,
				Controls);

			parametersEvaluationConfiguration.Initialize();

			ServiceLocator.Current.GetInstance<ParametersSelectionWindowHelper>().InitializeInterface();
		}

		private void SlamPanel_MouseClick(object sender, MouseEventArgs e)
		{
			if (parametersPanel.Visible)
				parametersPanel.Hide();
			else
				parametersPanel.Show();
		}

        private void SelectParametersToolStripButton1_Click(object sender, EventArgs e)
        {
	        var modelParameters = new ModelParameters
	        {
		        n = 2,
		        a = new List<double> {4, 4},
		        q = new List<double> {3, 3},
		        eps = 0,
		        g = 9.8,
		        k = new List<double> {0.5, 0.5},
		        l = new List<double> {5, 5},
		        mu = 0.6,
		        s = new List<double>{20,20},
		        tau = 1,
		        L = 10000,
		        Vmax = new List<double> {16.7,16.7},
		        Vmin = 0,
		        Vn = new List<double> {0, 16.7},
		        lambda = new List<double> {0, -50},
	        };
	        
	        ServiceLocator.Current.GetInstance<IEvaluationHandler>(ParametersSelectionMode.InliningDistance.ToString()).Execute(
		        this,
		        modelParameters,
		        null);
        }
    }
}
