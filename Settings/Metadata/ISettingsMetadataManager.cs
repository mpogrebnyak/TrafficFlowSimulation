using System;
using Settings.Metadata.Models;

namespace Settings.Metadata
{
	/// <summary>
	/// Интерфейс работы с метаданными.
	/// </summary>
	public interface ISettingsMetadataManager
	{
		/// <summary>
		/// Получить метаданные, как с учетом зарегистрированных метаданных, так и произвольных метаданных.
		/// </summary>
		/// <param name="settingType">Тип класса настройки</param>
		EntitySettingsMetadata GetMetadata(Type settingType);
	}
}