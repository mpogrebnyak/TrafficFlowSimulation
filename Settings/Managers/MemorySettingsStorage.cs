using Settings.Metadata.Models;

namespace Settings.Managers;

public class MemorySettingsStorage : ISettingsStorage
{
	private readonly Dictionary<SettingsKey, SettingsValue> _values;

	public MemorySettingsStorage()
	{
		_values = new Dictionary<SettingsKey, SettingsValue>();
	}

	public void Set(IList<SettingsKeyValuePair> pairs)
	{
		if (pairs == null) throw new ArgumentNullException("pairs");
		if (pairs.Any(x => x == null)) throw new ArgumentOutOfRangeException("pairs", "Cannot use null element in set.");

		foreach (var pair in pairs)
			_values[pair.Key] = pair.Value;
	}

	public void Delete(IList<SettingsKey> keys)
	{
		if (keys == null) throw new ArgumentNullException("keys");
		if (keys.Any(x => x == null)) throw new ArgumentOutOfRangeException("keys", "Cannot use null element in set.");

		var removedKeys = keys.Select(x => new { key = x, wasRemoved = _values.Remove(x) }).Where(x => x.wasRemoved).ToList();
	}

	public SettingsValue Get(SettingsKey settingsKey)
	{
		if (settingsKey == null) throw new ArgumentNullException("settingsKey");

		SettingsValue settingsValue;
		_values.TryGetValue(settingsKey, out settingsValue);

		return settingsValue;
	}
}