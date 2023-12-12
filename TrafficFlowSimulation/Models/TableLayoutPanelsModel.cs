using System.Windows.Forms;

namespace TrafficFlowSimulation.Windows.Models;

public class TableLayoutPanelsModel
{
	public TableLayoutPanel BasicParametersTableLayoutPanel { get; set; }

	public TableLayoutPanel AdditionalParametersTableLayoutPanel { get; set; }

	public TableLayoutPanel InitialConditionsTableLayoutPanel { get; set; }

	public TableLayoutPanel SettingsTableLayoutPanel { get; set; }
}