using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using EvaluationKernel.Models;
using Settings;
using TrafficFlowSimulation.Commands;
using TrafficFlowSimulation.Commands.Rendering;
using TrafficFlowSimulation.Helpers;
using TrafficFlowSimulation.Models;

namespace TrafficFlowSimulation.Windows
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
			SettingsHelper.InitializeSettings();
			CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("Ru");
		}

		private void startToolStripButton_Click(object sender, EventArgs e)
		{
			List<string> errors;
			ModelParametersBinding.EndEdit();
			var modelParameters = ModelParametersMapper.MapModel(ModelParametersBinding.DataSource, out errors);

			parametersPanel.Hide();
			EvaluationHandler.AbortExecution();
			EvaluationHandler.Execute(
				new AllChartsModel
				{
					SpeedChart = speedChart,
					DistanceChart = distanceChart,
					CarsMovementChart = carsMovementChart,
					},
					modelParameters
				);

		}

		 private void MainWindow_Load(object sender, EventArgs e)
		{
			ModelParametersBinding.DataSource = new ModelParameters()
			{
				n = 100,
				Vmax = 16.7,
				a = 4,
				q = 3
			};

			CarsRenderingHelper.CreatePaintedCars();
			Initialize();
		}

		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			EvaluationHandler.AbortExecution();
		}

		private void slam_Panel_MouseClick(object sender, MouseEventArgs e)
		{
			if (parametersPanel.Visible)
				parametersPanel.Hide();
			else
				parametersPanel.Show();
		}

		private void EnglishMenuItem_Click(object sender, EventArgs e)
		{
			CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("En");
			languagesSwitcherButton.Image = Properties.Resources.united_kingdom;
			LocalizationHelper.Translate();
		}

		private void RussianMenuItem_Click(object sender, EventArgs e)
		{
			CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("Ru");
			languagesSwitcherButton.Image = Properties.Resources.russia;
			LocalizationHelper.Translate();
		}

		private void Initialize()
		{
			LocalizationHelper.InitializeResource(new LocalizationComponentsModel
			{
				LocalizationBinding = LocalizationBinding,
				ParametersErrorProvider = ParametersErrorProvider,
				LanguagesSwitcherButton = languagesSwitcherButton,
				StartToolStripButton = StartToolStripButton
			});
			//LocalizationHelper.Translate();

			carsMovementContainer.SplitterDistance = carsMovementContainer.Size.Height / 2;
			chartsContainer.SplitterDistance = chartsContainer.Size.Width / 2;
			parametersPanel.AutoScroll = true;
			parametersPanel.VerticalScroll.Enabled = true;
			parametersPanel.VerticalScroll.Value = parametersPanel.VerticalScroll.Maximum/10;

			List<string> errors;
			ModelParametersBinding.EndEdit();
			var modelParameters = ModelParametersMapper.MapModel(ModelParametersBinding.DataSource, out errors);
			RenderingHelper.CreateCharts(new AllChartsModel
				{
					SpeedChart = speedChart,
					DistanceChart = distanceChart,
					CarsMovementChart = carsMovementChart
				},
				modelParameters);

			comboBox1.SelectedIndex = 0;
		}

		private void HideLegendToolStripMenuItem_Click(object sender, EventArgs e)
		{
			carsMovementChart.Legends.Clear();
		}

        private void StopToolStripButton_Click(object sender, EventArgs e)
        {
			EvaluationHandler.AbortExecution();
		}

		private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RenderingHelper.SaveChart(carsMovementChart);
		}
	}
}
