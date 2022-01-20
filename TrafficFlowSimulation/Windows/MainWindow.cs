using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using EvaluationKernel;
using EvaluationKernel.Models;
using TrafficFlowSimulation.Commands;

namespace TrafficFlowSimulation.Windows
{
    public partial class MainWindow : Form
    {
        Bitmap speed_bmp, distance_bmp;
        Graphics speed_g, distance_g;

        EnvironmentRendering environmentSpeed, environmentDistance;

        Thread th;

        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {

            Point zeroPoint = new Point(25, 25);

            environmentSpeed = new EnvironmentRendering
                (new RenderingParameters
                {
                    ZeroPoint = zeroPoint,
                    MaxWidth = speedPictureBox.Width,
                    MaxHeight = speedPictureBox.Height,
                    ZoomX = 20,
                    ZoomY = 20,
                    StepX = 5,
                    StepY = 5
                });

            environmentDistance = new EnvironmentRendering
                (new RenderingParameters
                {
                    ZeroPoint = zeroPoint,
                    MaxWidth = distancePictureBox.Width,
                    MaxHeight = distancePictureBox.Height,
                    ZoomX = 20,
                    ZoomY = 2,
                    StepX = 5,
                    StepY = 100
                });

            speed_bmp = new Bitmap(speedPictureBox.Width, speedPictureBox.Height);
            speed_g = Graphics.FromImage(speed_bmp);
            //speed_g.TranslateTransform(0, speedPictureBox.Height);
            //speed_g.ScaleTransform(1, -1);
            environmentSpeed.InitializeGraph(speed_g);
            speedPictureBox.Image = speed_bmp;

            distance_bmp = new Bitmap(distancePictureBox.Width, distancePictureBox.Height);
            distance_g = Graphics.FromImage(distance_bmp);
            //distance_g.TranslateTransform(0, distancePictureBox.Height);
            //distance_g.ScaleTransform(1, -1);
            environmentDistance.InitializeGraph(distance_g);
            distancePictureBox.Image = distance_bmp;
        }

        void Method(object modelParameters)
        {
            var m = (ModelParameters)modelParameters;
            var r = new RungeKuttaMethod(m);
            var n = m.n;
            var pens = RenderingHelper.GetPens(n);

            double tp;
            var xp = new double[n];
            var yp = new double[n];
            var t = r.T.Last();
            var x = new double[n];
            var y = new double[5];
            for (int i = 0; i < n; i++)
            {
                x[i] = r.X(i).Last();
                y[i] = r.Y(i).Last();
            }

            while (true)
            {
                tp = t;
                for (int i = 0; i < n; i++)
                {
                    xp[i] = x[i];
                    yp[i] = y[i];
                }
                r.Solve();
                t = r.T.Last();
                for (int i = 0; i < n; i++)
                {
                    x[i] = r.X(i).Last();
                    y[i] = r.Y(i).Last();
                }
                for (int i = 0; i < n; i++)
                {
                    environmentSpeed.DrawLine(speed_g, pens[i],
                        new PointF((float)tp, (float)yp[i]),
                        new PointF((float)t, (float)y[i]));
                    environmentDistance.DrawLine(distance_g, pens[i],
                        new PointF((float)tp, (float)xp[i]),
                        new PointF((float)t, (float)x[i]));
                }

                Invoke(new MethodInvoker(() =>
                {
                    distancePictureBox.Refresh();
                    speedPictureBox.Refresh();
                }));
            }
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            ModelParameters modelParameters = new ModelParameters
            {
                n = 5,
                tau = 1,
                Vmax = 16.7,
                Vmin = 0,
                lambda = new double[] {0, -5, -10, -15, -20},
                a = 4,
                q = 3,
                L = 200,
                g = 9.8,
                mu = 0.6,
                k = 1,
                l = 3,
                p = 0.5,
                s = 20
            };

            th = new Thread(Method);
            th.Start(modelParameters);
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
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if(th != null)
                th.Abort();
        }
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (th != null)
                th.Abort();
        }
    }
}
