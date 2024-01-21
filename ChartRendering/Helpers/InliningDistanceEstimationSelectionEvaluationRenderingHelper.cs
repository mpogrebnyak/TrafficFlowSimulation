using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ChartRendering.Constants;
using ChartRendering.Properties;
using Localization;

namespace ChartRendering.Helpers;

public static class InliningDistanceEstimationSelectionEvaluationRenderingHelper
{
	private static readonly Dictionary<Color, ColorValue> ColorIntensity = GetColorIntensityDictionary();

	public static Dictionary<Color, ColorValue> GetColorIntensity()
	{
		return ColorIntensity;
	}

	public static string GetColor(double intensityInPercentage)
	{
		var colorIntensity = ColorIntensity;

		if (intensityInPercentage <= 0)
		{
			return colorIntensity.Single(x => x.Value.IntValue == (int) intensityInPercentage).Key.Name;
		}

		var color = colorIntensity.FirstOrDefault(x => intensityInPercentage <= x.Value.IntValue);

		return color.Key != Color.Empty
			? color.Key.Name
			: colorIntensity.Single(x => x.Value.IntValue == -1).Key.Name;
	}

	private static Dictionary<Color, ColorValue> GetColorIntensityDictionary()
	{
		return new Dictionary<Color, ColorValue>
			{
				{
					CustomColors.BrightRed,
					new ColorValue
					{
						IntValue = -1,
						DisplayOrder = 6,
						DisplayValue = LocalizationHelper.Get<ChartRenderingResources>().CrashTitle
					}
				},
				{
					CustomColors.Green,
					new ColorValue
					{
						IntValue = 0,
						DisplayOrder = 1,
						DisplayValue = "0"
					}
				},
				{
					CustomColors.LightGreen,
					new ColorValue
					{
						IntValue = 25,
						DisplayOrder = 2,
						DisplayValue = "≤25"
					}
				},
				{
					CustomColors.Yellow,
					new ColorValue
					{
						IntValue = 50,
						DisplayOrder = 3,
						DisplayValue = "≤50"
					}
				},
				{
					CustomColors.Orange,
					new ColorValue
					{
						IntValue = 75,
						DisplayOrder = 4,
						DisplayValue = "≤75"
					}
				},
				{
					CustomColors.LightRed,
					new ColorValue
					{
						IntValue = 100,
						DisplayOrder = 5,
						DisplayValue = "≤100"
					}
				}
			}
			.OrderBy(x => x.Value.DisplayOrder)
			.ToDictionary(x => x.Key, x => x.Value);
	}

	public class ColorValue
	{
		public int IntValue;

		public int DisplayOrder;

		public string DisplayValue;
	}
}