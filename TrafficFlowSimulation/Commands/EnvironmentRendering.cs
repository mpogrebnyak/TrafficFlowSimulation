using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrafficFlowSimulation.Commands
{
    public class RenderingParameters
    {
        public Point ZeroPoint { get; set; }
        public float ZoomX { get; set; }
        public float ZoomY { get; set; }
        public int StepX { get; set; }
        public int StepY { get; set; }
        public int MaxWidth { get; set; }
        public int MaxHeight { get; set; }
    }

    public class EnvironmentRendering
    {
        RenderingParameters _r;

        public EnvironmentRendering(RenderingParameters renderingParameters)
        {
            _r = renderingParameters;
        }
        public void InitializeGraph(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 2);

            g.DrawLine(pen, 0, _r.MaxHeight - _r.ZeroPoint.Y, _r.MaxWidth, _r.MaxHeight - _r.ZeroPoint.Y);
            g.DrawLine(pen, _r.ZeroPoint.X, _r.MaxHeight, _r.ZeroPoint.X, 0);

            pen = new Pen(Color.Black, 1);
            for (int step = 0; step < _r.MaxHeight / _r.ZoomY; step += _r.StepY)
            {
                g.DrawLine(pen, _r.ZeroPoint.X, _r.MaxHeight - _r.ZeroPoint.Y - step * _r.ZoomY, _r.MaxWidth, _r.MaxHeight - _r.ZeroPoint.Y - step * _r.ZoomY);

                if (step != 0)
                    CreateLabel(g, step,
                        new PointF(
                            _r.ZeroPoint.X - 26,
                            _r.MaxHeight - _r.ZeroPoint.Y - step * _r.ZoomY - 8
                            ));
            }

            for (int step = 0; step < _r.MaxWidth / _r.ZoomX; step += _r.StepX)
            {
                g.DrawLine(pen, _r.ZeroPoint.X + step * _r.ZoomX, _r.MaxHeight - _r.ZeroPoint.Y, _r.ZeroPoint.X + step * _r.ZoomX, 0);

                CreateLabel(g, step,
                    new PointF(
                        _r.ZeroPoint.X + step * _r.ZoomX - (step != 0 ? 8 : 0),
                        _r.MaxHeight - _r.ZeroPoint.Y
                        ));
            }
        }

        private void CreateLabel(Graphics g, int label, PointF locationPoint)
        {
            var drawString = label.ToString();
            Font drawFont = new Font("Arial", 10);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            StringFormat drawFormat = new StringFormat();

            g.DrawString(drawString, drawFont, drawBrush, locationPoint, drawFormat);
        }

        public void DrawLine(Graphics g, Pen p, PointF point1, PointF point2)
        {
            g.DrawLine(p,
                _r.ZeroPoint.X + point1.X * _r.ZoomX,
                _r.MaxHeight - _r.ZeroPoint.Y - point1.Y * _r.ZoomY,
                _r.ZeroPoint.X + point2.X * _r.ZoomX,
                _r.MaxHeight - _r.ZeroPoint.Y - point2.Y * _r.ZoomY);
        }
       // g.DrawEllipse(p, _r.ZeroPoint.X + point1.X* _r.ZoomX, _r.MaxHeight - _r.ZeroPoint.Y - point1.Y* _r.ZoomY, 1, 1);


        // public void CreateCa

    }
}
