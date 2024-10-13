using System;
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
			var noRandom = property.GetCustomAttribute<RandomAttribute>();
			if (noRandom is {NoRandomGeneration: true})
			{
				continue;
			}

			if (property.Name.EndsWith("_multiple"))
			{
				var singlePropertyName = property.Name.Replace("_multiple", "");
				var singleProperty = type.GetProperty(singlePropertyName);
				if (singleProperty != null)
				{
					var range = singleProperty.GetCustomAttribute<RandomAttribute>();

					if (range != null)
					{
						var minValue = Convert.ChangeType(range.Minimum, singleProperty.PropertyType);
						var maxValue = Convert.ChangeType(range.Maximum, singleProperty.PropertyType);

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

				var range = property.GetCustomAttribute<RandomAttribute>();

				if (range != null)
				{
					var minValue = Convert.ChangeType(range.Minimum, property.PropertyType);
					var maxValue = Convert.ChangeType(range.Maximum, property.PropertyType);

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

	public static double GenerateDoubleRandomValue(double minValue, double maxValue)
	{
		var randomDouble = Random.NextDouble() * (maxValue - minValue) + minValue;
		return Math.Round(randomDouble, 2);
	}
}