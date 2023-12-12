using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TrafficFlowSimulation.Helpers;

public static class EnumComboBoxHelper
{
	public static void LocalizeEnumComboBoxItems(List<ComboBox> comboBoxesList)
	{
		foreach (var comboBox in comboBoxesList)
		{
			var type = Type.GetType(comboBox.Tag.ToString());

		//	foreach (Enum value in Enum.GetValues(type))
			//	comboBox.Items.Cast<ComboBoxItem>().SingleOrDefault(x => x.Value.Equals(value))!.Text = value.GetDescription();
		}
	}
}