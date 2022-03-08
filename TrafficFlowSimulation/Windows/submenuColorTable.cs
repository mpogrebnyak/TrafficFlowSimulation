using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficFlowSimulation.Windows
{
    internal class submenuColorTable : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.LightGray; }
        }

        public override Color MenuItemBorder
        {
            get { return Color.Black; }
        }

      //  public override Color ToolStripDropDownBackground
       // {
      //      get { return Color.LightGray; }
      //  }

        public override Color ToolStripContentPanelGradientBegin
        {
            get { return Color.LightGray; }
        }
    }
}