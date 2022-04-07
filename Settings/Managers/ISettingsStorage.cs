using Settings.Metadata.Models;

namespace Settings.Managers;

public interface ISettingsStorage
{
	/// <summary>
	/// Сохранить значение настройки в Storage.
	/// </summary>
	void Set(IList<SettingsKeyValuePair> pairs);

	/// <summary>
	/// Получить настройку для указанного <paramref name="settingsKey"/>.
	/// </summary>
	SettingsValue Get(SettingsKey settingsKey);

	/// <summary>
	/// Удалить настройку из Storage.
	/// </summary>
	void Delete(IList<SettingsKey> keys);
}