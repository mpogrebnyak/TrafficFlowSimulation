using System;
using System.Globalization;

namespace Settings.Converters
{
	public static class ConvertHelper
	{
		public static bool ParseToBoolean(string value, bool defaultValue)
		{
			if(string.IsNullOrEmpty(value))
				return defaultValue;

			switch (value.ToLower())
			{
				case "true":
				case "yes":
				case "on":
					return true;
				case "false":
				case "no":
				case "off":
					return false;
			}

			int result;
			if(int.TryParse(value, NumberStyles.Integer, CultureInfo.CurrentCulture, out result))
			{
				switch (result)
				{
					case 1:
						return true;
					case 0:
						return false;
				}
			}

			return defaultValue;
		}

		public static object ConvertTo(Type targetType, object value, object defaultValue)
		{
			if(targetType.IsAssignableFrom(value.GetType())) return value;

			if(targetType == typeof(bool))
				return ParseToBoolean(value.ToString(), (bool) (defaultValue ?? default(bool)));

			if(targetType == typeof(Type))
				return Type.GetType(value.ToString(), true, false);

			if(targetType.IsEnum) return Enum.Parse(targetType, value.ToString());

			if(targetType == typeof(Guid)) return new Guid(value.ToString());

			Type nullableType = Nullable.GetUnderlyingType(targetType);
			if(nullableType != null)
			{
				Type underlyingType = nullableType.UnderlyingSystemType;

				if(underlyingType == typeof(bool))
					return ParseToBoolean(value.ToString(), (bool) ((object) (defaultValue) ?? (object) default(bool)));

				if(nullableType.IsEnum) return Enum.Parse(underlyingType, value.ToString());
			}

			return null;
		}
	}
}
