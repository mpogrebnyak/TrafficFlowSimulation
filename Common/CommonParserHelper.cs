using System.Globalization;

namespace Common;

public static class CommonParserHelper
{
	private const char Separator = ':';

	private const char ElementsSeparator = ' ';

	public static Dictionary<int, double> ParseMultipleValues(string str)
	{
		var dictionary = new Dictionary<int, double>();

		if (!string.IsNullOrEmpty(str))
		{
			var elements = str
				.Trim()
				.Split(ElementsSeparator)
				.ToList();

			foreach (var value in elements.Select(element => element.Split(Separator)))
			{
				dictionary.Add(Convert.ToInt32(value[0], CultureInfo.InvariantCulture), Convert.ToDouble(value[1]));
			}
		}

		return dictionary;
	}
}