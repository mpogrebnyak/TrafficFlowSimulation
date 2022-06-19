using System.Collections.Generic;

namespace Localization.Localization
{
	public class LoadedResources
	{
		public string[] Locales { get; set; }
	
		public IDictionary<string, IDictionary<string, string>> LocaleToValues { get; set; }

		public string GetValue(string locale, string key)
		{
			IDictionary<string, string> values;
			if (LocaleToValues.TryGetValue(locale, out values))
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
