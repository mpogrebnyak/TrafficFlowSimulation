using System;

namespace Localization
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
	public class TranslationAttribute : Attribute
	{
		public string Locale { get; }

		public string Value { get; }

		public TranslationAttribute(string locale, string value)
		{
			Locale = locale;
			Value = value;
		}
	}
}
