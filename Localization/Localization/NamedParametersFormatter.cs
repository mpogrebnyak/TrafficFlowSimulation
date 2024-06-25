using System.Globalization;
using System.Text.RegularExpressions;

namespace Localization.Localization;

public static class NamedParametersFormatter
{
	private static readonly Regex FormatRegex = new Regex(@"(((?<!{){((@?)([\w]+)(:([^}]+))?)})|({{)|(}}))");

	
	public static string Format(string formatString, IDictionary<string, object> parameters)
	{
		if (formatString == null) return null;
		return FormatRegex.Replace(formatString, match =>
		{
			if (match.Groups[1].Value == "{{") return "{";
			if (match.Groups[1].Value == "}}") return "}";

			var needEncode = match.Groups[4].Value == "@";
			var paramName = match.Groups[5].Value;
			var paramFormat = match.Groups[7].Value;

			object value;
			if (!parameters.TryGetValue(paramName, out value))
			{
				return string.Empty;
			}

			if (string.IsNullOrEmpty(paramFormat))
			{
				if (value == null)
					return string.Empty;

				return value.ToString();
			}

			return ((IFormattable)value).ToString(paramFormat, CultureInfo.CurrentUICulture);
		});
	}
}