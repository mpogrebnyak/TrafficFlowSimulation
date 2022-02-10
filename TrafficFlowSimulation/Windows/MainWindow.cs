using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Commands;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Rendering;
using TrafficFlowSimulation.Сonstants;

namespace TrafficFlowSimulation.Windows
{
	public partial class MainWindow : Form
	{
		private LocalizationComponentsModel _localizationComponents;

		public MainWindow()
		{
			InitializeComponent();
			CustomInitializeComponent();
			InitializeInterface();
			
			parametersPanel.Hide();
		}

		private void CustomInitializeComponent()
		{
			carsMovementContainer.SplitterDistance = carsMovementContainer.Size.Height / 2;
			chartsContainer.SplitterDistance = chartsContainer.Size.Width / 2;
			comboBox1.SelectedIndex = 0;

			_localizationComponents = new LocalizationComponentsModel
			{
				LocalizationBinding = LocalizationBinding,
				ParametersErrorProvider = ParametersErrorProvider,
				LanguagesSwitcherButton = languagesSwitcherButton,
				StartToolStripButton = StartToolStripButton,
				AutoScrollComboBox = AutoScrollComboBox
			};
		}

		private void InitializeInterface()
		{
			LocalizationService.Translate(_localizationComponents);
			
			// избавиться от этого 
			ModelParametersBinding.DataSource = new ModelParameters()
			{
				n = 100,
				Vmax = 16.7,
				a = 4,
				q = 3
			};
			
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

			// перенести в main
			CarsRenderingHelper.CreatePaintedCars();
		}

		private void startToolStripButton_Click(object sender, EventArgs e)
		{
			// сделать нормально
			List<string> errors;
			ModelParametersBinding.EndEdit();
			var modelParameters = ModelParametersMapper.MapModel(ModelParametersBinding.DataSource, out errors);
			var modeSettings = new ModeSettings();
			modeSettings.MapTo(AutoScrollComboBox.SelectedIndex, ScrollForNumericUpDown.Value);

			RenderingHelper.CreateCharts(new AllChartsModel
				{
					SpeedChart = speedChart,
					DistanceChart = distanceChart,
					CarsMovementChart = carsMovementChart
				},
				modelParameters);
			
			parametersPanel.Hide();
			EvaluationHandler.AbortExecution();
			EvaluationHandler.Execute(
				new AllChartsModel
				{
					SpeedChart = speedChart,
					DistanceChart = distanceChart,
					CarsMovementChart = carsMovementChart,
				},
				modelParameters,
				modeSettings
				);
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
			LocalizationService.Translate(_localizationComponents);
		}

		private void RussianMenuItem_Click(object sender, EventArgs e)
		{
			CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("Ru");
			languagesSwitcherButton.Image = Properties.Resources.russia;
			LocalizationService.Translate(_localizationComponents);
		}

		private void StopToolStripButton_Click(object sender, EventArgs e)
		{
			EvaluationHandler.AbortExecution();
		}

		private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var chart = MainWindowHelper.GetChartFromContextMenu(sender);
			RenderingHelper.SaveChart(chart);
		}

		private void HideLegendToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var chart = MainWindowHelper.GetChartFromContextMenu(sender);
			RenderingHelper.ShowLegend(chart.Text, LegendDisplayOptions.None);
		}

		private void ShowFullToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var chart = MainWindowHelper.GetChartFromContextMenu(sender);
			RenderingHelper.ShowLegend(chart.Text, LegendDisplayOptions.Full);
		}

		private void ShowPartiallyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var chart = MainWindowHelper.GetChartFromContextMenu(sender);
			RenderingHelper.ShowLegend(chart.Text, LegendDisplayOptions.Partially);
		}
	}
}
