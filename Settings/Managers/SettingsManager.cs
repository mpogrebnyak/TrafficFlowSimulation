using System;
using Settings.Converters;
using Settings.Metadata;
using Settings.Metadata.Models;

namespace Settings.Managers
{
	public class SettingsManager : ISettingsManager
	{
		private readonly ISettingsMetadataManager _metadataManager;

		public SettingsManager(ISettingsMetadataManager metadataManager)
		{
			_metadataManager = metadataManager;
		}

		public object Get(Type settingType)
		{
			var entitySettings = _metadataManager.GetMetadata(settingType);
			
			var value = CreateAndFillInstance(entitySettings.SettingsMetadata);

			return value;
		}

		private object CreateAndFillInstance(SettingsGroupMetadata metadata)
		{
			var groupInstanceOfClass = Activator.CreateInstance(metadata.Type);

			foreach (var child in metadata.Children)
			{
				object propValue;
				if (child is SettingsGroupMetadata)
				{
					propValue = CreateAndFillInstance(((SettingsGroupMetadata)child));
				}
				else if (child is SettingsItemMetadata)
				{
					var itemMetadata = (SettingsItemMetadata)child;
					propValue = ConvertDefalutValueToPropertyType(itemMetadata);
				}
				else
				{
					throw new NotImplementedException(string.Format("Type [{0}] of settings metadata is not supported", child));
				}

				groupInstanceOfClass.GetType().GetProperty(child.PropertyName).SetValue(groupInstanceOfClass, propValue, null);
			}

			return groupInstanceOfClass;
		}

		private object ConvertDefalutValueToPropertyType(SettingsItemMetadata metadata)
		{
			if (metadata.DefaultValue == null)
			{
				if (metadata.Type.IsClass) return null;

				return Activator.CreateInstance(metadata.Type);
			}

			if (metadata.DefaultValue is string && metadata.Type != typeof(string))
			{
				var settingsConverterFactory = new SettingsConverterFactory();
				var converter = settingsConverterFactory.GetConverter(metadata);
				return converter.ToObject((string)metadata.DefaultValue, null, metadata.Type);
			}

			if (metadata.DefaultValue.GetType() != metadata.Type && (metadata.Type.IsGenericType && metadata.Type.GetGenericTypeDefinition() == typeof(Nullable<>)
				&& metadata.Type.GetGenericArguments().Length == 1 && metadata.Type.GetGenericArguments()[0] == metadata.Type))
			{
				throw new InvalidOperationException(string.Format("Could not convert defalut value [{0}] of property [{1}] to property type [{2}]",
					metadata.DefaultValue, metadata.PropertyName, metadata.Type));
			}

			return metadata.DefaultValue;
		}
	}
}
