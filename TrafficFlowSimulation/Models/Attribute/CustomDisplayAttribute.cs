using System;

namespace TrafficFlowSimulation.Models.Attribute;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
public class CustomDisplayAttribute : System.Attribute
{
	public int Order { get; }

	public bool IsMultiple { get; }

	public bool IsHidden { get; }

	public bool IsReadOnly { get; }

	public Type? EnumType { get; }

	public CustomDisplayAttribute(int order, bool isMultiple = false, bool isHidden = false, bool isReadOnly = false,Type? enumType = null)
	{
		Order = order;
		IsMultiple = isMultiple;
		IsHidden = isHidden;
		IsReadOnly = isReadOnly;
		EnumType = enumType;
	}
}