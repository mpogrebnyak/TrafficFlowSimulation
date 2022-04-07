namespace Settings.Converters
{
	public interface ISettingsConverter
	{
		/// <summary>
		/// Десериализовать экземпляр объекта из строки.
		/// </summary>
		/// <param name="value">Строка, в которой содержится сериализованный объект</param>
		/// <param name="defaultValue">Значение по умолчанию, используется если <paramref name="value"/> пустое или null </param>
		object ToObject(string value, object defaultValue, Type type);

		/// <summary>
		/// Сереализовать объект в строку.
		/// </summary>
		/// <param name="value">Значение объекта</param>
		/// <param name="provider">Провайдер (опционально)</param>
		/// <returns>Сериализованный объект</returns>
		string ToString(object value);
	}
}
