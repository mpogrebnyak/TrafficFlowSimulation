namespace Settings.Converters
{
	public class ClassConverter: ISettingsConverter
	{
		public object ToObject(string value, object defaultValue, Type type)
		{
			return ConvertHelper.ConvertTo(type, value, defaultValue);
		}

		public string ToString(object value)
		{
			if (value == null)
				return null;

			return ConvertHelper.ConvertTo(typeof(string), value, string.Empty) as string;
		}
	}
}
