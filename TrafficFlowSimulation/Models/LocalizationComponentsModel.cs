using System.Windows.Forms;
using TrafficFlowSimulation.Windows.CustomControls;

namespace TrafficFlowSimulation.Models
{
	public class LocalizationComponentsModel
	{
		public AllChartsModel AllCharts { get; set; }

		public BindingSource LocalizationBinding { get; set; }

		public ErrorProvider ParametersErrorProvider { get; set; }

		public ToolStripDropDownButton LanguagesSwitcherButton { get; set; }

		public ToolStripButton StartToolStripButton { get; set; }

		public ToolStripButton StopToolStripButton { get; set; }

		public ToolStripButton ContinueToolStripButton { get; set; }

		public ToolStripLabel DrivingModeStripLabel { get; set; }
	}
}