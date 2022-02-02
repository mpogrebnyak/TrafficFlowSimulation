using System;
using System.Collections.Generic;
using System.Linq;

namespace Localization
{
	public class LoadedResourcesBuilder
	{
		private readonly IDictionary<string, IDictionary<string, string>> _locale2Values;

		public IList<ResourceMetadata> Metadata { get; }

		public LoadedResourcesBuilder()
		{
			_locale2Values = new Dictionary<string, IDictionary<string, string>>(StringComparer.Ordinal);
			Metadata = new List<ResourceMetadata>();
		}
		public LoadedResourcesBuilder AppendValue(string locale, string key, string value)
		{
			IDictionary<string, string> values;
			if (_locale2Values.TryGetValue(locale, out values) == false)
				_locale2Values[locale] = values = new Dictionary<string, string>(StringComparer.Ordinal);

			values[key] = value;
			return this;
		}
		
		public LoadedResources ToLoadedResources()
		{
			return new LoadedResources
			{
				Locales = _locale2Values.Keys.ToArray(),
				Locale2Values = _locale2Values
			};
		}
	}
}
