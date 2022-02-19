using System.Drawing;
using System.Windows.Forms;

namespace TrafficFlowSimulation.Windows
{
    internal class SubMenuCustomColorTable : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.LightGray; }
        }

        public override Color MenuItemBorder
        {
            get { return Color.Black; }
        }

        public override Color ToolStripContentPanelGradientBegin
        {
            get { return Color.LightGray; }
        }
    }
}