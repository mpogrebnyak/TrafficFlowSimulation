using System.Linq;
using System.Resources;

namespace Localization
{
	public class ResourceMetadata
	{
		public const char NameSeparator = '.';
		public const char EscapeCharacter = '_';

		public static readonly char[] InvalidNameCharacters =
		{
			'!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+', '?', '.', ',', '"', '`', ':', ';', '{', '}', '<', '>', '|', '\'', '/', '\\'
		};

		public static string Normalize(string name)
		{
			if (string.IsNullOrEmpty(name)) return name;

			return InvalidNameCharacters.Aggregate(name,
				(current, invalidNameCharacter) => current.Replace(invalidNameCharacter, EscapeCharacter));
		}


		/// <summary>
		/// Название ресурса (может повторяться, но только для разных родительских секций).
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// "Путь" с учётом иерархии, через точку (например "Parent1.Parent2.Item").
		/// Должен быть обязательно задан и быть уникальным в рамках <see cref="ResourceManager"/>.
		/// </summary>
		public string Key { get; set; }
	}
}
