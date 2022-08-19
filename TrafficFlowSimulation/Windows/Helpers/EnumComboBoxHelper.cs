using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Localization.Localization;
using TrafficFlowSimulation.Models.ParametersModels.Constants;
using TrafficFlowSimulation.Models.SettingsModels.Constants;
using TrafficFlowSimulation.Windows.CustomControls;

namespace TrafficFlowSimulation.Windows.Helpers;

/*
 * При добавлении нового enum в ComboBox, необходимо добавить его обработку по аналогии
*/
public static class EnumComboBoxHelper
{
	public static List<ComboBoxItem> GetEnumComboBoxItems(Type enumType)
	{
		var elements = new List<ComboBoxItem>();

		if (enumType == typeof(AutoScroll))
		{
			elements = (from AutoScroll e in Enum.GetValues(typeof(AutoScroll))
				select new ComboBoxItem
				{
					Text = e.GetDescription(),
					Value = e
				}).ToList();
		}

		if (enumType == typeof(IdenticalCars))
		{
			elements = (from IdenticalCars e in Enum.GetValues(typeof(IdenticalCars))
				select new ComboBoxItem
				{
					Text = e.GetDescription(),
					Value = e
				}).ToList();
		}

		if (enumType == typeof(FirstTrafficLightColor))
		{
			elements = (from FirstTrafficLightColor e in Enum.GetValues(typeof(FirstTrafficLightColor))
				select new ComboBoxItem
				{
					Text = e.GetDescription(),
					Value = e
				}).ToList();
		}

		return elements;
	}

	public static void LocalizeEnumComboBoxItems(List<ComboBox> comboBoxesList)
	{
		foreach (var comboBox in comboBoxesList)
		{
			var type = Type.GetType(comboBox.Tag.ToString());

			if (type == typeof(AutoScroll))
				foreach (AutoScroll value in Enum.GetValues(typeof(AutoScroll)))
					comboBox.Items.Cast<ComboBoxItem>().SingleOrDefault(x => (AutoScroll)x.Value == value)!.Text = value.GetDescription();
			if (type == typeof(IdenticalCars))
				foreach (IdenticalCars value in Enum.GetValues(typeof(IdenticalCars)))
					comboBox.Items.Cast<ComboBoxItem>().SingleOrDefault(x => (IdenticalCars)x.Value == value)!.Text = value.GetDescription();
			if (type == typeof(FirstTrafficLightColor))
				foreach (FirstTrafficLightColor value in Enum.GetValues(typeof(FirstTrafficLightColor)))
					comboBox.Items.Cast<ComboBoxItem>().SingleOrDefault(x => (FirstTrafficLightColor)x.Value == value)!.Text = value.GetDescription();
		}
	}
}