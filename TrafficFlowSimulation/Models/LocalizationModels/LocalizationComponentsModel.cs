using System.Windows.Forms;
using TrafficFlowSimulation.Windows.Models;

namespace TrafficFlowSimulation.Models
{
	public class LocalizationComponentsModel
	{
		public AllChartsModel AllCharts { get; set; }

		public ErrorProvider ParametersErrorProvider { get; set; }

		public ToolStripDropDownButton LanguagesSwitcherButton { get; set; }

		public ToolStripButton StartToolStripButton { get; set; }

		public ToolStripButton StopToolStripButton { get; set; }

		public ToolStripButton ContinueToolStripButton { get; set; }

		public ToolStripLabel DrivingModeStripLabel { get; set; }

		public ToolStripDropDownButton DrivingModeStripDropDownButton { get; set; }

		public GroupBox MovementParametersGroupBox { get; set; }

		public GroupBox ModeSettingsGroupBox { get; set; }

		public GroupBox AdditionalParametersGroupBox { get; set; }

		public GroupBox BasicParametersGroupBox { get; set; }

		public GroupBox InitialConditionsGroupBox { get; set; }

		public GroupBox ControlsGroupBox { get; set; }

		public Button SubmitButton { get; set; }

		public ToolStripButton ParametersSelectionToolStripButton { get; set; }

		public CheckBox EstimateTrafficCapacityCheckBox { get; set; }
	}
}