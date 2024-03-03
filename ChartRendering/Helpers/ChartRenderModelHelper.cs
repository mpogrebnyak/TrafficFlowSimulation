﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using ChartRendering.Attribute;

namespace ChartRendering.Helpers;

public static class ChartRenderModelHelper
{
	private static readonly Random Random = new ();

	public static T CreateModelWithRandomValues<T>(T obj, int n) where T : new()
	{
		var type = typeof(T);
		var properties = type.GetProperties();

		foreach (var property in properties)
		{
			var noRandom = property.GetCustomAttribute<NoRandomAttribute>();
			if (noRandom != null)
			{
				continue;
			}

			if (property.Name.EndsWith("_multiple"))
			{
				var singlePropertyName = property.Name.Replace("_multiple", "");
				var singleProperty = type.GetProperty(singlePropertyName);
				if (singleProperty != null)
				{
					var rangeAttribute = singleProperty.GetCustomAttribute<RangeAttribute>();

					if (rangeAttribute != null)
					{
						var minValue = Convert.ChangeType(rangeAttribute.Minimum, singleProperty.PropertyType);
						var maxValue = Convert.ChangeType(rangeAttribute.Maximum, singleProperty.PropertyType);

						var randomValue = string.Empty;
						for (var i = 0; i < n; i++)
						{
							randomValue += i + ":" + GenerateRandomValue(minValue, maxValue) + " ";
						}
						randomValue = randomValue.TrimEnd();

						property.SetValue(obj, randomValue);
					}
				}
			}
			else
			{
				if (properties.Any(x => x.Name == property.Name + "_multiple"))
				{
					continue;
				}

				var rangeAttribute = property.GetCustomAttribute<RangeAttribute>();

				if (rangeAttribute != null)
				{
					var minValue = Convert.ChangeType(rangeAttribute.Minimum, property.PropertyType);
					var maxValue = Convert.ChangeType(rangeAttribute.Maximum, property.PropertyType);

					var randomValue = GenerateRandomValue(minValue, maxValue);
					property.SetValue(obj, randomValue);
				}
			}
		}

		return obj;
	}

	private static object GenerateRandomValue(object minValue, object maxValue)
	{
		if (minValue is int && maxValue is int)
		{
			return Random.Next((int)minValue, (int)maxValue + 1);
		}
		else if (minValue is double && maxValue is double)
		{
			var randomDouble = Random.NextDouble() * ((double)maxValue - (double)minValue) + (double)minValue;
			return Math.Round(randomDouble, 2);
		}
		else
		{
			throw new ArgumentException("Unsupported data type for RangeAttribute.");
		}
	}
}