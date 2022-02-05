using System;
using Settings.Metadata.Models;

namespace Settings.Metadata
{
	/// <summary>
	/// Построение метаданых настроек на основании типа класса.
	/// </summary>
	public interface ISettingsMetadataBuilder
	{
		SettingsGroupMetadata BuildMetadata(Type settingType);
	}
}