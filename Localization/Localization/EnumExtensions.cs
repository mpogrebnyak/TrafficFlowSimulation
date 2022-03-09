﻿using System.ComponentModel;
using System.Reflection;

namespace Localization.Localization;

public static class EnumExtensions
{
	public static string GetDescription(this Enum enumValue) 
	{
		FieldInfo fi = enumValue.GetType().GetField(enumValue.ToString());
		DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

		if (attributes != null && attributes.Length > 0)
			return attributes[0].Description;

		return enumValue.ToString();
	}
}