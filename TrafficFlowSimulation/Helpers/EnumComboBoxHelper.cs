using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Localization.Localization;

namespace TrafficFlowSimulation.Helpers;

public static class EnumComboBoxHelper
{
	public static void LocalizeEnumComboBoxItems(List<ComboBox> comboBoxesList)
	{
		foreach (var comboBox in comboBoxesList)
		{
			var type = Type.GetType(comboBox.Tag.ToString());

			foreach (Enum value in Enum.GetValues(type))
				comboBox.Items.Cast<EnumItem>().SingleOrDefault(x => x.Value.Equals(value))!.Text = value.GetDescription();
		}
	}
}