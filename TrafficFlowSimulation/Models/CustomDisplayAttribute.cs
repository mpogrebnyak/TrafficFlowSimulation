using System;

namespace TrafficFlowSimulation.Models;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
public class CustomDisplayAttribute : Attribute
{
	public int Order { get; }

	public bool IsMultiple { get; }

	public bool IsHidden { get; }

	public Type? EnumType { get; }

	public CustomDisplayAttribute(int order,  bool isMultiple = false, bool isHidden = false, Type? enumType = null)
	{
		Order = order;
		IsMultiple = isMultiple;
		IsHidden = isHidden;
		EnumType = enumType;
	}
}