using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ChartRendering.Helpers;

public static class ChartRenderModelHelper
{
	private const char Separator = ':';

	private const char ElementsSeparator = ' ';

	public static Dictionary<int, double> ParseMultipleValues(string str)
	{
		var dictionary = new Dictionary<int, double>();

		if (!string.IsNullOrEmpty(str))
		{
			var elements = str
				.Trim()
				.Split(ElementsSeparator)
				.ToList();

			foreach (var element in elements)
			{
				var value = element.Split(Separator);
				dictionary.Add(Convert.ToInt32(value[0], CultureInfo.InvariantCulture) - 1, Convert.ToDouble(value[1]));
			}
		}

		return dictionary;
	}
}