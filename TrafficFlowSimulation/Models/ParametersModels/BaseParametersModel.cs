using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EvaluationKernel.Models;

namespace TrafficFlowSimulation.Models.ParametersModels;

public class BaseParametersModel : ValidationModel, IModel
{
	//public virtual void MapTo(ModelParameters mp) { }

	private static readonly char _separator = ':';

	private static readonly char _elementsSeparator = ' ';

	protected static Dictionary<int, double> ParseMultipleValues(string str)
	{
		var dictionary = new Dictionary<int, double>();

		if (!string.IsNullOrEmpty(str))
		{
			var elements = str
				.Trim()
				.Split(_elementsSeparator)
				.ToList();

			foreach (var element in elements)
			{
				var value = element.Split(_separator);
				dictionary.Add(Convert.ToInt32(value[0], CultureInfo.InvariantCulture) - 1, Convert.ToDouble(value[1]));
			}
		}

		return dictionary;
	}
	public virtual object GetDefault()
	{
		return null;
	}
}