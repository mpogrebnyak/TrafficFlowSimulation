using System;

namespace Settings.Metadata.Models
{
	public abstract class SettingsMetadata
	{
		/// <summary>
		/// Полный ключ до данной настройки.
		/// </summary>
		public SettingsPathKey SettingsKey { get; set; }

		/// <summary>
		/// Тип свойства.
		/// </summary>
		public Type Type { get; set; }

		/// <summary>
		/// Имя проперти.
		/// </summary>
		public string PropertyName { get; set; }
	}
}