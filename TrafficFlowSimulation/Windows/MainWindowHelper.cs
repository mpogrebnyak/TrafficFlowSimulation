using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TrafficFlowSimulation.Windows
{
	public static class MainWindowHelper
	{
		public static Chart GetChartFromContextMenu(object o)
		{
			var owner = (o as ToolStripMenuItem).Owner;

			if ((owner as ToolStripDropDownMenu).OwnerItem != null)
			{
				owner = ((owner as ToolStripDropDownMenu).OwnerItem as ToolStripMenuItem).Owner;
			}
			
			return (owner as ContextMenuStrip).SourceControl as Chart;
		}
	}
}