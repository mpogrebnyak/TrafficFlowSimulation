using System;
using System.Linq;

namespace Settings.Converters
{
	public class ClassConverter: ISettingsConverter
	{
		public object ToObject(string value, object defaultValue, Type type)
		{
			return ConvertHelper.ConvertTo(type, value, defaultValue);
		}
	}
}
