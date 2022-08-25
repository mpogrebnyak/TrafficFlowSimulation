using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Settings.Metadata.Models;

namespace Settings.Metadata
{
	public class SettingsMetadataBuilder: ISettingsMetadataBuilder
	{
		public SettingsGroupMetadata BuildMetadata(Type settingType)
		{
			var group = new SettingsGroupMetadata { SettingsKey = SettingsPathKey.Build(settingType), Type = settingType };

			return FillGroupMetadata(group, settingType);
		}

		private SettingsGroupMetadata FillGroupMetadata(SettingsGroupMetadata groupMetadata, Type settingType)
		{
			var childrens = new List<SettingsMetadata>();

			foreach (PropertyInfo pi in GetProperties(settingType))
			{
				Type checkingType = pi.PropertyType;

				// Если класс Nullable, то будем анализировать именно внутренний класс.
				if (IsNullableType(checkingType))
				{
					checkingType = checkingType.GetGenericArguments()[0];
				}

				if (IsSimpleType(checkingType))
				{
					childrens.Add(BuildItemMetadata(groupMetadata, pi));
				}
				else if (checkingType.IsArray)
				{
					childrens.Add(BuildItemMetadata(groupMetadata, pi));
				}
			}

			groupMetadata.Children = childrens.ToArray();

			return groupMetadata;
		}

		private SettingsMetadata BuildItemMetadata(SettingsGroupMetadata parent, PropertyInfo pi)
		{
			var itemMetadata = new SettingsItemMetadata { SettingsKey = parent.SettingsKey.ForProperty(pi) };

			// Заполнить базовые атрибуты
			FillFromProperty(itemMetadata, pi);

			// Атрибут для дефолтного значения для конкретного свойства
			var defAttribute = (DefaultValueAttribute)pi.GetCustomAttributes(typeof(DefaultValueAttribute), true).FirstOrDefault();
			itemMetadata.DefaultValue = defAttribute == null ? null : defAttribute.Value;

			return itemMetadata;
		}

		/// <summary>
		///	 Заполнить метаданные из атрибутов свойства.
		/// </summary>
		private void FillFromProperty(SettingsMetadata commonMetadata, PropertyInfo pi)
		{
			commonMetadata.Type = pi.PropertyType;
			commonMetadata.PropertyName = pi.Name;
		}

		/// <summary>
		///	 Список пропертей из класса.
		/// </summary>
		private IEnumerable<PropertyInfo> GetProperties(Type type)
		{
			return type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty);
		}

		public static bool IsNullableType(Type type)
		{
			return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
		}

		/// <summary>
		///	 Тип из набора простых типов.
		/// </summary>
		public static bool IsSimpleType(Type type)
		{
			if(type == null) return false;

			return type.IsEnum
				   || type == typeof(bool)
				   || type == typeof(byte) || type == typeof(sbyte)
				   || type == typeof(short) || type == typeof(ushort)
				   || type == typeof(int) || type == typeof(uint)
				   || type == typeof(long) || type == typeof(ulong)
				   || type == typeof(char)
				   || type == typeof(double)
				   || type == typeof(float)
				   || type == typeof(decimal)
				   || type == typeof(DateTime)
				   || type == typeof(TimeSpan)
				   || type == typeof(Type)
				   || type == typeof(Guid)
				   || type == typeof(string);
		}
	}
}
