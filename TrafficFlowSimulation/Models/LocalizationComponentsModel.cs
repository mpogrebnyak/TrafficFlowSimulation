using System.Windows.Forms;

namespace TrafficFlowSimulation.Models
{
	public class LocalizationComponentsModel
	{
		public BindingSource LocalizationBinding { get; set; }

		public ErrorProvider ParametersErrorProvider { get; set; }

		public ToolStripDropDownButton LanguagesSwitcherButton { get; set; }

		public ToolStripButton StartToolStripButton { get; set; }

		public ComboBox AutoScrollComboBox { get; set; }
	}
}