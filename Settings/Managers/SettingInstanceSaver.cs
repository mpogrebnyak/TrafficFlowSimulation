using Settings.Converters;
using Settings.Metadata.Models;

namespace Settings.Managers;

public class SettingInstanceSaver
{
	private readonly SettingsGroupMetadata _metadata;
	private readonly ISettingsStorage _storage;
	private readonly List<SettingsKeyValuePair> _savingKeys = new List<SettingsKeyValuePair>();

	public SettingInstanceSaver(SettingsGroupMetadata metadata, ISettingsStorage storage)
	{
		_metadata = metadata;
		_storage = storage;
	}

	/// <summary>
	/// Сохранить экземпляр класса настроек.
	/// </summary>
	/// <param name="instance">Фактический объект с полями</param>
	/// <param name="buildInfo">Набор ключей, которые фактически будут сохранены с учетом дополнительных свойств скрытия и заблокировать</param>
	public void Save(object instance, IList<SettingsPathKey> buildInfo)
	{
		// очистим набор ключи для сохранения
		_savingKeys.Clear();

		FindKeysAndValues(instance, _metadata, buildInfo);
		// сохраняем набор ключей и значений в хранилище
		_storage.Set(_savingKeys);
	}

	/// <summary>
	/// Сохранить экземпляр класса настроек с флагами скрыть и заблокировать с значениями "по умолчанию".
	/// </summary>
	/// <param name="instance">Фактический объект с полями</param>
	public void Save(object instance)
	{
		var items = _metadata.GetAllChildMetadata().OfType<SettingsItemMetadata>();
		var buildInfo = items.Select(x => x.SettingsKey).ToList();

		Save(instance, buildInfo);
	}

	private void FindKeysAndValues(object instance, SettingsGroupMetadata groupMetadata,
		IList<SettingsPathKey> buildInfo)
	{
		var itemMetadatas = groupMetadata.Children.OfType<SettingsItemMetadata>();

		foreach (var itemMetadata in itemMetadatas)
		{
			if (!buildInfo.Contains(itemMetadata.SettingsKey))
				continue;

			var settingsKey = new SettingsKey
			{
				Name = itemMetadata.SettingsKey.PluralKey
			};

			var settingsConverterFactory = new SettingsConverterFactory();
			var converter = settingsConverterFactory.GetConverter(itemMetadata);

			var propValue = instance.GetType().GetProperty(itemMetadata.PropertyName).GetValue(instance, null);
			var settingsValue = new SettingsValue
			{
				Value = converter.ToString(propValue)
			};

			_savingKeys.Add(new SettingsKeyValuePair(settingsKey, settingsValue));
		}

		var groupMetadatas = groupMetadata.Children.OfType<SettingsGroupMetadata>();
		foreach (var itemMetadata in groupMetadatas)
		{
			var newInstance = instance.GetType().GetProperty(itemMetadata.PropertyName).GetValue(instance, null);

			FindKeysAndValues(newInstance, itemMetadata, buildInfo);
		}
	}
}