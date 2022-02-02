using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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
        MethodHandler hadler = new MethodHandler();

     //   Bitmap speed_bmp, distance_bmp;
     //   Graphics speed_g, distance_g;
     //   EnvironmentRendering environmentSpeed, environmentDistance;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void startToolStripButton_Click(object sender, EventArgs e)
        {
            List<string> errors;
            modelParametersBinding.EndEdit();
            var modelParameters = ModelParametersMapper.MapModel(modelParametersBinding.DataSource, out errors);

           
            parametersPanel.Hide();
            hadler.AbortExecution();
            hadler.Execute(
                new ChartsRenderingModel
                {
                    SpeedChart = speedChart,
                    DistanceChart = distanceChart,
                    CarsMovementChart = carsMovementChart,
                    ModelParameters = modelParameters,
                });

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

        private void stopButton_Click(object sender, EventArgs e)
        {
            hadler.AbortExecution();
        }
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            hadler.AbortExecution();
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
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("En");
            languagesSwitcherButton.Image = Properties.Resources.united_kingdom;
            LocalizationHelper.Translate();
        }

        private void RussianMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("Ru");
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
                StartToolStripButton = startToolStripButton
            });
            LocalizationHelper.Translate();

            carsMovementContainer.SplitterDistance = carsMovementContainer.Size.Height / 2;
            chartsContainer.SplitterDistance = chartsContainer.Size.Width / 2;

            List<string> errors;
            modelParametersBinding.EndEdit();
            var modelParameters = ModelParametersMapper.MapModel(modelParametersBinding.DataSource, out errors);
            RenderingHelper.InitialRenderCharts(new ChartsRenderingModel
            {
                SpeedChart = speedChart,
                DistanceChart = distanceChart,
                CarsMovementChart = carsMovementChart,
                ModelParameters = modelParameters,
            });
        }

        private void HideLegendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            carsMovementChart.Legends.Clear();
        }
    }
}
