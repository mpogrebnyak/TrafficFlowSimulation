using Settings.Metadata;

namespace Settings.Managers
{
	public static class SettingsManagerExtensions
	{
		/// <summary>
		/// Получить класс настроек для уровня приложения.
		/// </summary>
		/// <typeparam name="TSettings">Тип класса настройки</typeparam>
		/// <param name="manager">Интерфейс расширения <see cref="ISettingsManager"/></param>
		/// <returns>Экземпляр класса настройки</returns>
		public static TSettings Get<TSettings>(this ISettingsManager manager) where TSettings : new()
		{
			return (TSettings)manager.Get(typeof(TSettings));
		}
	}
}