namespace TrafficFlowSimulation.Constants;

public static class Prefixes
{
	public const string TextBoxPrefix = "textBox_";

	public const string LabelPrefix = "label_";

	public const string ComboBoxPrefix = "comboBox_";

	public static string[] All()
	{
		return new []
		{
			LabelPrefix,
			TextBoxPrefix,
			ComboBoxPrefix
		};
	}
}