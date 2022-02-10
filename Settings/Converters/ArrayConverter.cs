﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Settings.Converters
{
	public class ArrayConverter : ISettingsConverter
	{
		private readonly ClassConverter _classConverter = new ClassConverter();

		private static bool IsSupportedType(Type type)
		{
			return type.IsArray;
		}

		public object ToObject(string value, object defaultValue, Type type)
		{
			if (!IsSupportedType(type))
				throw new NotSupportedException(string.Format("Only primitive arrays are supported by [{0}] converter", GetType()));

			var elementType = type.GetElementType();

			if (value != null)
				return ConvertStringToArray(value, elementType);

			if (defaultValue != null)
			{
				if (type.IsInstanceOfType(defaultValue))
					return defaultValue;

				if (defaultValue is string)
					return ConvertStringToArray(defaultValue as string, elementType);

				throw new NotSupportedException(string.Format("{0} is not supported as default value for [{1}] converter", defaultValue.GetType().FullName, GetType().FullName));
			}

			return Array.CreateInstance(elementType, 0);
		}

		private object ConvertStringToArray(string value, Type elementType)
		{
			var splittedString = SplitStorageString(value);
			var objectArray = splittedString.Select(x => _classConverter.ToObject(x, null, elementType)).ToArray();
			var typedArray = CastObjectArrayToCorrectCollectionType(elementType, objectArray);
			return typedArray;
		}

		private static object CastObjectArrayToCorrectCollectionType(Type elementType, object[] elements)
		{
			var array = Array.CreateInstance(elementType, elements.Length);
			for (var i = 0; i < elements.Length; i++)
				array.SetValue(elements[i], i);

			return array;
		}

		private static string[] SplitStorageString(string joinedArray)
		{
			if (joinedArray == null) return null;
			if (string.IsNullOrWhiteSpace(joinedArray)) return new string[0];
			var partiallyParsedStrings = new List<string>();

			var b1 = new StringBuilder();

			Action addString = () =>
			{
				partiallyParsedStrings.Add(b1.ToString());
				b1.Clear();
			};

			// preprocess
			var i = 0;
			// string ,,a,b,c -> ["", ""] + unparsed a,b,c
			for (; i < joinedArray.Length; i++)
			{
				if (joinedArray[i] == ',') partiallyParsedStrings.Add(string.Empty);
				else break;
			}

			// string a,b,c -> [..., a,b,c]
			for (; i < joinedArray.Length; i++)
			{
				var c = joinedArray[i];
				if (c == ',' && joinedArray[i - 1] != '\\')
				{
					addString();
					continue;
				}

				b1.Append(c);
			}

			if (b1.Length > 0) addString();

			// processing strings with unescaping

			return partiallyParsedStrings.Select(UnescapeString).ToArray();
		}

		private static string UnescapeString(string escapedString)
		{
			var builder = new StringBuilder();
			var i = 0;
			// skipping leading whitespace
			for (; i < escapedString.Length; i++)
				if (!char.IsWhiteSpace(escapedString[i])) break;

			// skippind trailing whitespace. it is harder 'data\\ ' should not be skipped
			var end = escapedString.Length - 1;
			while (end > 0)
			{
				if (char.IsWhiteSpace(escapedString[end]) && escapedString[end - 1] != '\\') end--;
				else break;
			}

			for (; i <= end; i++)
			{
				var c = escapedString[i];

				// e.g. string abc\ -> traing backslash is incorrect, but we can handle it as normal slash
				if (c == '\\' && i < escapedString.Length - 1)
				{
					i++;
					c = escapedString[i];
					if (c == 'n') c = '\n';
					if (c == 'r') c = '\r';
					if (c == 't') c = '\t';
				}

				builder.Append(c);
			}

			if (builder.Length == 0) return null;
			return builder.ToString();
		}
	}
}