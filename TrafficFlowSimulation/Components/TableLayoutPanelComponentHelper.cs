using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ChartRendering.ChartRenderModels;
using ChartRendering.Constants;
using Localization.Localization;

namespace TrafficFlowSimulation.Components;

public class TableLayoutPanelComponentHelper
{
	private static string _multipleTag;

	public TableLayoutPanelComponentHelper(string multipleTag)
	{
		_multipleTag = multipleTag;
	}

	public EventHandler GetComboBoxSelectedIndexChangedEvent(Type enumType)
	{
		if (enumType == typeof(IdenticalCars))
		{
			return IdenticalCarsComboBox_SelectedIndexChanged;
		}

		return null;
	} 

	private void IdenticalCarsComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		var comboBox = sender as ComboBox;
		if (comboBox == null) return;

		var tableLayoutPanel = comboBox.Parent as TableLayoutPanel;
		if (tableLayoutPanel == null) return;

		var controls = tableLayoutPanel.Controls;

		var multipleControls = controls
			.OfType<Control>()
			.Where(x => x.Tag != null && x.Tag.Equals(_multipleTag))
			.ToList();

		var comboboxItem = (EnumItem)comboBox.SelectedItem;
		if (comboboxItem.Value.Equals(IdenticalCars.Yes))
			multipleControls.ForEach(x => x.Hide());
		else
			multipleControls.ForEach(x => x.Show());
	}

	public void ComboBoxDrawItemEvent(object sender, DrawItemEventArgs e)
	{
		var comboBox = sender as ComboBox;

		e.Graphics.FillRectangle(
			(e.State & DrawItemState.Selected) == DrawItemState.Selected
				? new SolidBrush(Color.LightGray)
				: new SolidBrush(SystemColors.Window), e.Bounds);

		if (e.Index != -1 && comboBox != null)
			e.Graphics.DrawString(comboBox.Items[e.Index].ToString(),
				e.Font,
				new SolidBrush(Color.Black),
				new Point(e.Bounds.X, e.Bounds.Y));
	}

	public BindingSource CreateBindingSource(IModel model)
	{
		var bs = new BindingSource();
		((System.ComponentModel.ISupportInitialize)bs).BeginInit();
		bs.DataSource = model.GetType();
		((System.ComponentModel.ISupportInitialize)bs).EndInit();

		bs.DataSource = model.GetDefault();

		return bs;
	}

	public void TextBoxEnter(object sender, EventArgs e, string placeholderText)
	{
		var textBox = sender as TextBox;
		if (textBox == null) return;

		if (textBox.Text == placeholderText)
		{
			textBox.Text = "";
			textBox.ForeColor = SystemColors.WindowText;
		}
	}

	public void TextBoxLeave(object sender, EventArgs e, string placeholderText)
	{
		var textBox = sender as TextBox;
		if (textBox == null) return;

		if (string.IsNullOrWhiteSpace(textBox.Text))
		{
			textBox.Text = placeholderText;
			textBox.ForeColor = SystemColors.GrayText;
		}
	}
}