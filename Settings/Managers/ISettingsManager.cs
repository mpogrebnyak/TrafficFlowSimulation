namespace Settings.Managers
{
	public interface ISettingsManager
	{
		/// <summary>
		/// Получить класс настроек.
		/// </summary>
		/// <param name="settingType">Тип класса настройки</param>
		object Get(Type settingType);

		/// <summary>
		/// Сохранить класс настроек.
		/// </summary>
		/// <param name="settingType">Тип класса настройки</param>
		void Set(Type settingType, object instance);
	}
}