using System.Collections.Generic;
using System.Globalization;

namespace Localization
{
	public class ResourceManager: IResourceManager
	{
		private readonly IList<IResourceProvider> _resourceProviders = new List<IResourceProvider>();

		public void Register(object provider)
		{
			if (provider is IResourceProvider resourceProvider)
			{
				_resourceProviders.Add(resourceProvider);
			}
		}
		public string GetValue(string locale, string key)
		{
			IResourceProvider source;
			return GetValue(locale, key, out source);
		}

		public string GetValue(string locale, string key, out IResourceProvider source)
		{
			foreach (var provider in _resourceProviders)
			{
				var value = provider.GetValue(CultureInfo.GetCultureInfo(locale).Name, key);
				if (value != null)
				{
					source = provider;
					return value;
				}
			}

			source = null;
			return null;
		}
	}
}
