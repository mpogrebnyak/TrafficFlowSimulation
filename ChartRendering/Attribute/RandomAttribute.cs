using System;

namespace ChartRendering.Attribute;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
public class RandomAttribute : System.Attribute
{
	public double Minimum { get; }
	public double Maximum { get; }
	public bool NoRandomGeneration { get; }

	public RandomAttribute(double minimum = 0, double maximum = 0, bool noRandomGeneration = false)
	{
		Minimum = minimum;
		Maximum = maximum;
		NoRandomGeneration = noRandomGeneration;
	}
}