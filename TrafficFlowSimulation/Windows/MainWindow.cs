using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using EvaluationKernel.Models;
using Localization;
using TrafficFlowSimulation.Commands;
using TrafficFlowSimulation.Models;
using TrafficFlowSimulation.Resources;

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
            Initialize();
        }

        private void startToolStripButton_Click(object sender, EventArgs e)
        {
            ModelParameters modelParameters = new ModelParameters
            {
                n = Int32.Parse(field_n.Text),
                tau = 1,
                Vmax = 16.7,
                Vmin = 0,
                lambda = new double[] {0, -5, -10, -15, -20, -25, -30, -35, -40, -45, -50},
                a = 4,
                q = 3,
                L = 100,
                g = 9.8,
                mu = 0.6,
                k = 1,
                l = 3,
                p = 0.5,
                s = 20
            };

            parametersPanel.Hide();
            hadler.AbortExecution();
            hadler.Execute(
                new ChartsRenderingModel
                {
                    SpeedChart = speedChart,
                    DistanceChart = distanceChart,
                    ModelParameters = modelParameters,
                });

        }

         private void MainWindow_Load(object sender, EventArgs e)
        {
            modelParametersBinding.DataSource = new ModelParameters()
            {
                n = 5,
            };
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
            LocalizationSettingManager.SetLocale(Locales.en);
            languagesSwitcherButton.Image = Properties.Resources.united_kingdom;
            LocalizationHelper.Translate();
        }

        private void RussianMenuItem_Click(object sender, EventArgs e)
        {
            LocalizationSettingManager.SetLocale(Locales.ru);
            languagesSwitcherButton.Image = Properties.Resources.russia;
            LocalizationHelper.Translate();
        }

        private void Initialize()
        {
            LocalizationHelper.InitializeResource(new LocalizationComponentsModel
            {
                LocalizationBinding = localizationBinding,
                LanguagesSwitcherButton = languagesSwitcherButton,
                StartToolStripButton = startToolStripButton
            });
            LocalizationHelper.Translate();

            splitContainer2.SplitterDistance = splitContainer2.Size.Width / 2;
        }
    }
}
