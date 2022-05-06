using Settings;
using System.Collections.Generic;
using System.Drawing;
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

		public static void HideMultipleField(Control root)
		{
			var allControls = GetAllControls(root);
			var multipleTextBoxes = allControls
				.OfType<TextBox>()
				.Where(x => x.Tag != null && x.Tag.ToString() == "MultipleField")
				.ToList();
			multipleTextBoxes.ForEach(x => x.Hide());

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

			var checkBoxes = allControls
				.OfType<CheckBox>()
				.Where(x => x.Tag != null && x.Tag.ToString() == "MultipleField")
				.ToList();

			checkBoxes.ForEach(x => x.Show());
		}

		public static void PaintCellPaint(object control, TableLayoutCellPaintEventArgs e)
        {
			var tableLayoutPanel = control as TableLayoutPanel;
			var childControl = tableLayoutPanel.GetControlFromPosition(e.Column, e.Row);
			if (childControl != null && childControl.Tag != null && childControl.Tag == "MultipleField")
			{
				var topLeft = new Point(e.CellBounds.Left, e.CellBounds.Bottom);
				var topRight = new Point(e.CellBounds.Right, e.CellBounds.Bottom);
				var pen = new Pen(Color.FromArgb(255, 151, 29), 0.1f);

				e.Graphics.DrawLine(pen, topLeft, topRight);
			}
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

		public static void DrawColoredItems(ComboBox comboBox, DrawItemEventArgs e)
		{
			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
			{
				e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), e.Bounds);
			}
			else
			{
				e.Graphics.FillRectangle(new SolidBrush(SystemColors.Window), e.Bounds);
			}

			if (e.Index != -1)
				e.Graphics.DrawString(comboBox.Items[e.Index].ToString(),
					e.Font,
					new SolidBrush(Color.Black),
					new Point(e.Bounds.X, e.Bounds.Y));
		}

		public static void ShowCurrentModeSettingsFields(Control root)
		{
			var postfix = "_msf"; //modeSettingsField

			var modeSettingsFields = GetAllControls(root)
				.Where(x => x.Tag != null && x.Tag.ToString().Contains(postfix))
				.ToList();

			var currentDrivingMode = SettingsHelper.Get<Properties.Settings>().CurrentDrivingMode;

			var fieldsForShow = modeSettingsFields
				.Where(x => x.Tag.ToString().Contains(currentDrivingMode.ToString()))
				.ToList();

			var fieldsForHide = modeSettingsFields
				.Except(fieldsForShow)
				.ToList();

			fieldsForShow.ForEach(x => x.Show());
			fieldsForHide.ForEach(x => x.Hide());
		}
	}
}