using System.Collections.Generic;

namespace Localization
{
	public class LoadedResources
	{
		public string[] Locales { get; set; }
	
		public IDictionary<string, IDictionary<string, string>> Locale2Values { get; set; }

		public string GetValue(string locale, string key)
		{
			IDictionary<string, string> values;
			if (Locale2Values.TryGetValue(locale, out values))
			{
				string value;
				if (values.TryGetValue(key, out value))
				{
					return value;
				}
			}

			return null;
		}
	}
}
