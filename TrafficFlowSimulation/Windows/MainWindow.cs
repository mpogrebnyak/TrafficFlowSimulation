using System;
using System.Drawing;
using System.Windows.Forms;
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
        }

        private void startButton_Click(object sender, EventArgs e)
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
            
            LocalizationSettingManager.SetLocale(Locales.en);
            var provider1 = new ResourceProvider(typeof(ModuleResources));

            var manager = new ResourceManager();
            manager.Register(provider1);
            var builder = new ResourceBuilder(manager);
            var test1 = builder.Get<ModuleResources>();
            
           var ee = builder.Get<ModuleResources>().InvalidHttpMethod;

            textBox1.Text = ee;
            textBox2.Text = builder.Get<ModuleResources>().eeee;
            hadler.AbortExecution();
            hadler.Execute(
                new ChartsRenderingModel
                {
                    SpeedChart = speedChart,
                    DistanceChart = distanceChart,
                    ModelParameters = modelParameters,
                });
        }

        private void slam_Panel_MouseClick(object sender, MouseEventArgs e)
        {
            if (menu_Panel.Visible)
                menu_Panel.Hide();
            else
                menu_Panel.Show();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

            //RenderingHelper.Render(speedChart, 0);
            //RenderingHelper.Render(distanceChart, 0);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            hadler.AbortExecution();
        }
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            hadler.AbortExecution();
        }
    }
}
