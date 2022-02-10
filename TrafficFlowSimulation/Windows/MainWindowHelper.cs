using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TrafficFlowSimulation.Сonstants;

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

		public static IdenticalCars IsAllCarsIdentical(ComboBox comboBox)
		{
			return comboBox.SelectedIndex switch
			{
				0 => IdenticalCars.Yes,
				1 => IdenticalCars.No,
				_ => IdenticalCars.No
			};
		}

		public static void HideMultipleField(Control root)
		{
			var allControls = GetAllControls(root);
			var multipleTextBoxes = allControls
				.OfType<TextBox>()
				.Where(x => x.Tag != null && x.Tag.ToString() == "MultipleField")
				.ToList();
			multipleTextBoxes.ForEach(x => x.Hide());

			var singleTextBoxes = allControls
				.OfType<TextBox>()
				.Where(x => x.Tag != null && x.Tag.ToString() == "SingleField")
				.ToList();

			singleTextBoxes.ForEach(x => x.Enabled = true);

			var checkBoxes = allControls
				.OfType<CheckBox>()
				.Where(x => x.Tag != null && x.Tag.ToString() == "MultipleField")
				.ToList();

			checkBoxes.ForEach(x => x.Hide());
		}

		public static void ShowMultipleField(Control root)
		{
			var allControls = GetAllControls(root);
			var multipleTextBoxes = allControls
				.OfType<TextBox>()
				.Where(x => x.Tag != null && x.Tag.ToString() == "MultipleField")
				.ToList();
			multipleTextBoxes.ForEach(x => x.Show());

			var singleTextBoxes = allControls
				.OfType<TextBox>()
				.Where(x => x.Tag != null && x.Tag.ToString() == "SingleField")
				.ToList();

			singleTextBoxes.ForEach(x => x.Enabled = false);

			var checkBoxes = allControls
				.OfType<CheckBox>()
				.Where(x => x.Tag != null && x.Tag.ToString() == "MultipleField")
				.ToList();

			checkBoxes.ForEach(x => x.Show());
		}

		private static IEnumerable<Control> GetAllControls(Control root)
		{
			var stack = new Stack<Control>();
			stack.Push(root);

			while (stack.Any())
			{
				var next = stack.Pop();
				foreach (Control child in next.Controls)
					stack.Push(child);

				yield return next;
			}
		}
	}
}