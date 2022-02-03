using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Commands;
using TrafficFlowSimulation.Commands.Rendering;
using TrafficFlowSimulation.Models;

namespace TrafficFlowSimulation.Windows
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("Ru");
			InitializeComponent();
		}

		private void startToolStripButton_Click(object sender, EventArgs e)
		{
			List<string> errors;
			modelParametersBinding.EndEdit();
			var modelParameters = ModelParametersMapper.MapModel(modelParametersBinding.DataSource, out errors);

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
			modelParametersBinding.DataSource = new ModelParameters()
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
				LocalizationBinding = localizationBinding,
				ParametersErrorProvider = parametersErrorProvider,
				LanguagesSwitcherButton = languagesSwitcherButton,
				StartToolStripButton = StartToolStripButton
			});
			LocalizationHelper.Translate();

			carsMovementContainer.SplitterDistance = carsMovementContainer.Size.Height / 2;
			chartsContainer.SplitterDistance = chartsContainer.Size.Width / 2;

			List<string> errors;
			modelParametersBinding.EndEdit();
			var modelParameters = ModelParametersMapper.MapModel(modelParametersBinding.DataSource, out errors);
			RenderingHelper.CreateCharts(new AllChartsModel
				{
					SpeedChart = speedChart,
					DistanceChart = distanceChart,
					CarsMovementChart = carsMovementChart
				},
				modelParameters);
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
			using (SaveFileDialog sfd = new SaveFileDialog())
			{
				sfd.Title = "Сохранить изображение как ...";
				sfd.Filter = "*.bmp|*.bmp;|*.png|*.png;|*.jpg|*.jpg";
				sfd.AddExtension = true;
				sfd.FileName = "graphicImage";
				if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					switch (sfd.FilterIndex)
					{
						case 1: carsMovementChart.SaveImage(sfd.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Bmp); break;
						case 2: carsMovementChart.SaveImage(sfd.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); break;
						case 3: carsMovementChart.SaveImage(sfd.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg); break;
					}
				}
			}
		}
	}
}
