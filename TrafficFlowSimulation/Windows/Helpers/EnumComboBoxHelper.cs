using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Localization.Localization;
using TrafficFlowSimulation.Windows.CustomControls;

namespace TrafficFlowSimulation.Windows.Helpers;

public static class EnumComboBoxHelper
{
	public static List<ComboBoxItem> GetEnumComboBoxItems(Type enumType)
	{
		var elements = Enum.GetValues(enumType).Cast<Enum>()
			.Select( x =>
				new ComboBoxItem
				{
					Text = x.GetDescription(),
					Value = x
				}
			).ToList();

		return elements;
	}

	public static void LocalizeEnumComboBoxItems(List<ComboBox> comboBoxesList)
	{
		foreach (var comboBox in comboBoxesList)
		{
			var type = Type.GetType(comboBox.Tag.ToString());

			foreach (Enum value in Enum.GetValues(type))
				comboBox.Items.Cast<ComboBoxItem>().SingleOrDefault(x => x.Value.Equals(value))!.Text = value.GetDescription();
		}
	}
}