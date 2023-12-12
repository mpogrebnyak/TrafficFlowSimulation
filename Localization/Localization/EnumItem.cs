namespace Localization.Localization;

public class EnumItem
{
	public Enum Value { get; set; }
	public string Text { get; set; }

	public EnumItem()
	{
		Value = null;
		Text = null;
	}

	public EnumItem(Enum value)
	{
		Value = value;
		Text = value.GetDescription();
	}

	public override string ToString()
	{
		return Text;
	}
}