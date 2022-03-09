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

		public ComboBox AutoScrollComboBox { get; set; }

		public ComboBox IdenticalCarsComboBox { get; set; }
	}
}