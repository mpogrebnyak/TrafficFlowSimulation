using System.ComponentModel;
using Fasterflect;

namespace Localization.Localization;

public class LocalizedDescriptionAttribute : DescriptionAttribute
{
	private List<Type> _registeredTypes = new();
	private static ResourceManager _resourceManager = new();
	private static ResourceBuilder _resourceBuilder;

	private readonly Type _resourceType;
	private readonly string _resourceKey;

	public LocalizedDescriptionAttribute(string resourceKey, Type resourceType)
	{
		if (!_registeredTypes.Contains(resourceType))
		{
			var provider = new ResourceProvider(resourceType);
			_resourceManager.Register(provider);
			_resourceBuilder = new ResourceBuilder(_resourceManager);

			_registeredTypes.Add(resourceType);
		}

		_resourceType = resourceType;
		_resourceKey = resourceKey;
	}

	public override string Description
	{
		get
		{
			var resource = _resourceBuilder.Get(_resourceType);
			var displayName = (string) resource.TryGetPropertyValue(_resourceKey);

			return string.IsNullOrEmpty(displayName)
				? string.Format("[[{0}]]", _resourceKey)
				: displayName;
		}
	}
}