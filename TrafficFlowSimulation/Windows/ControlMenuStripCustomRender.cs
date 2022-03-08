using System.Drawing;
using System.Windows.Forms;

namespace TrafficFlowSimulation.Windows
{
    internal class ControlMenuStripCustomRender : ToolStripProfessionalRenderer
    {
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
    {
        if (!e.Item.Selected)
        {
            base.OnRenderButtonBackground(e);
        }
        else
        {
            Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), rectangle);
            e.Graphics.DrawRectangle(Pens.Black, rectangle);
        }
    }
}
}