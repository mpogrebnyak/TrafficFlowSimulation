using System.Drawing;

namespace TrafficFlowSimulation.Commands
{
    public static class RenderingHelper
    {
        public static Pen[] GetPens(int n)
        {
            Pen[] pens = new Pen[5];
            pens[0] = new Pen(Color.Purple, 3);
            pens[1] = new Pen(Color.Red, 2);
            pens[2] = new Pen(Color.Green, 2);
            pens[3] = new Pen(Color.Blue, 2);
            pens[4] = new Pen(Color.Chocolate, 2);
            return pens;
        }
    }
}
