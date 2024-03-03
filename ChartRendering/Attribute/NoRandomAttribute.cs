using System;

namespace ChartRendering.Attribute;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
public class NoRandomAttribute : System.Attribute
{
}