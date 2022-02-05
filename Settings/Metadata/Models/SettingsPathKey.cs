using System;
using System.Reflection;

namespace Settings.Metadata.Models
{
	/// <summary>
	/// Класс агрегирующий логику построения ключений в настройках (Settings).
	/// </summary>
	public class SettingsPathKey
	{
		protected SettingsPathKey(string pluralKey)
		{
			_pluralKey = pluralKey;
		}

		private readonly string _pluralKey;

		/// <summary>
		/// Полный классификационный ключ до property или экземпляра класса.
		/// </summary>
		public string PluralKey
		{
			get { return _pluralKey; }
		}

		/// <summary>
		/// Получить ключ для класса по которому он может быть получен или сохранен.
		/// </summary>
		public static SettingsPathKey Build(Type t)
		{
			if(t == null)
				throw new ArgumentNullException("t");

			return new SettingsPathKey(t.FullName);
		}

		/// <summary>
		/// Получить ключ для property из класса.
		/// </summary>
		/// <param name="propertyInfo">Информация о property.</param>
		public SettingsPathKey ForProperty(PropertyInfo propertyInfo)
		{
			return ForProperty(propertyInfo.Name);
		}

		/// <summary>
		/// Внутренняя реализация. Получить ключ для property из класса.
		/// </summary>
		/// <param name="propertyName">Имя property в текстовом формате.</param>
		internal SettingsPathKey ForProperty(string propertyName)
		{
			return new SettingsPathKey(string.Format("{0}.{1}", PluralKey, propertyName));
		}
	}
}
