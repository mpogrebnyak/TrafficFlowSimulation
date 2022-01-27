using System.Windows.Forms;

namespace TrafficFlowSimulation.Models
{
    public class LocalizationComponentsModel
    {
        public BindingSource LocalizationBinding { get; set; }
        public ToolStripDropDownButton LanguagesSwitcherButton { get; set; }
        public ToolStripButton StartToolStripButton { get; set; }
    }
}