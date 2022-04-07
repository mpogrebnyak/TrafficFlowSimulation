namespace Settings.Metadata.Models;

/// <summary>
/// Данные для сохранения одной настройки.
/// </summary>
public class SettingsKeyValuePair
{
	private readonly SettingsKey _key;
	private readonly SettingsValue _value;

	public SettingsKeyValuePair(SettingsKey key, SettingsValue value)
	{
		if (key == null) throw new ArgumentNullException("key");
		if (value == null) throw new ArgumentNullException("value");

		_key = key;
		_value = value;
	}

	/// <summary>
	/// Ключ настройки.
	/// </summary>
	public SettingsKey Key
	{
		get { return _key; }
	}

	/// <summary>
	/// Данные настройки.
	/// </summary>
	public SettingsValue Value
	{
		get { return _value; }
	}
}