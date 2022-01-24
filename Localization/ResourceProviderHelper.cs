﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Fasterflect;

namespace Localization
{
    public class ResourceProviderHelper
    {
		private const char NamespaceSeparator = '.';

		public static LoadedResources Load(params Type[] types)
		{
			var builder = new LoadedResourcesBuilder();
			var sectionMap = new Dictionary<string, ResourceSectionMetadata>();

			CreateSections(types, builder.Metadata, sectionMap);

			foreach (var type in types)
			{
				var typeKey = type.FullName;

				Add(sectionMap[typeKey], type, builder);
			}

			return builder.ToLoadedResources();
		}

		public static object CreateLocalizedObject(IResourceProvider resourceProvider, Type typeOfResources)
		{
			var explicitPropValues = new Dictionary<string, string>();

			var properties = typeOfResources.GetProperties().ToArray();
			
			foreach (var property in properties)
			{
				var value = GetValue(resourceProvider, new LocalizationKeyPath(typeOfResources, property.Name));
				explicitPropValues[property.Name] = value;
			}

			var resources = Activator.CreateInstance(typeOfResources);

			foreach (var propValue in explicitPropValues)
			{
				resources.SetPropertyValue(propValue.Key, propValue.Value);
			}

			return resources;
		}

		public static void CreateSections(IEnumerable<Type> types,
			IList<ResourceMetadata> metadata, Dictionary<string, ResourceSectionMetadata> map)
		{
			foreach (var type in types)
			{
				ResourceSectionMetadata currentSection = null;

				var typeKey = type.FullName;
				var names = typeKey.Split(NamespaceSeparator);
				var builder = new StringBuilder();

				for (var index = 0; index < names.Length; index++)
				{
					var name = names[index];

					if (builder.Length > 0)
						builder.Append(ResourceMetadata.NameSeparator);
					builder.Append(name);

					var key = builder.ToString();

					ResourceSectionMetadata sectionMetadata;
					if (!map.TryGetValue(key, out sectionMetadata))
					{
						sectionMetadata = new ResourceSectionMetadata { Key = key, Name = name };
						
						if (index == names.Length - 1)
							sectionMetadata.Type = type;

						map.Add(key, sectionMetadata);

						if (currentSection == null)
							metadata.Add(sectionMetadata);
						else
							currentSection.Children.Add(sectionMetadata);
					}

					currentSection = sectionMetadata;
				}
			}
		}

		private static void Add(ResourceSectionMetadata sectionMetadata, Type type, LoadedResourcesBuilder builder)
		{
			var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).ToArray();

			foreach (var property in properties)
			{
				var itemMetadata = new ResourceMetadata
				{
					Name = ResourceMetadata.Normalize(property.Name),
					Key = string.Concat(sectionMetadata.Key, ResourceMetadata.NameSeparator, property.Name)
				};

				sectionMetadata.Children.Add(itemMetadata);

				var attributes = (TranslationAttribute[])property.GetCustomAttributes(typeof(TranslationAttribute), false);
				foreach (var translationAttribute in attributes)
				{
					builder.AppendValue(translationAttribute.Locale, itemMetadata.Key, translationAttribute.Value);
				}
			}

			var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).ToArray();

			foreach (var method in methods)
			{
				var metadata = new ResourceMetadata
				{
					Name = ResourceMetadata.Normalize(method.Name),
					Key = string.Concat(sectionMetadata.Key, ResourceMetadata.NameSeparator, method.Name)
				};

				sectionMetadata.Children.Add(metadata);
			}
		}
		
		private static string GetValue(IResourceProvider resourceProvider,
			LocalizationKeyPath path)
		{
			var locale = LocalizationSettingManager.GetCurrentLocale();

			do
			{
				foreach (var key in GetResourceKeys(path.ModelType, path.Postfix))
				{
					var value = resourceProvider.GetValue(locale, key);
					if (value != null) return value;
					
				}
			} while ((path = null) != null);

			return null;
		}

		private static IEnumerable<string> GetResourceKeys(Type typeOfResources, string memberName)
		{
			var key = typeOfResources.FullName + ResourceMetadata.NameSeparator + memberName;

			yield return key;
		}
	}
}