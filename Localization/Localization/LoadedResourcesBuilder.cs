using System;
using System.Collections.Generic;
using System.Linq;

namespace Localization.Localization
{
	public class LoadedResourcesBuilder
	{
		private readonly IDictionary<string, IDictionary<string, string>> _localeToValues;

		public IList<ResourceMetadata> Metadata { get; }

		public LoadedResourcesBuilder()
		{
			_localeToValues = new Dictionary<string, IDictionary<string, string>>(StringComparer.Ordinal);
			Metadata = new List<ResourceMetadata>();
		}
		public LoadedResourcesBuilder AppendValue(string locale, string key, string value)
		{
			IDictionary<string, string> values;
			if (_localeToValues.TryGetValue(locale, out values) == false)
				_localeToValues[locale] = values = new Dictionary<string, string>(StringComparer.Ordinal);

			values[key] = value;
			return this;
		}
		
		public LoadedResources ToLoadedResources()
		{
			return new LoadedResources
			{
				Locales = _localeToValues.Keys.ToArray(),
				LocaleToValues = _localeToValues
			};
		}
	}
}
