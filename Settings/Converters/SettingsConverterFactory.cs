using Settings.Metadata.Models;

namespace Settings.Converters
{
	public class SettingsConverterFactory
	{
		public ISettingsConverter GetConverter(SettingsItemMetadata metadata)
		{
			if (metadata.Type.IsArray)
			{
				return new ArrayConverter();
			}

			return new ClassConverter();
		}
	}
}