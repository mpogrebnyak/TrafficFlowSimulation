using System;

namespace Localization
{
	public class LocalizationKeyPath
	{
		public Type ModelType { get; }

		public string Postfix { get; }

		public LocalizationKeyPath(Type modelType, string postfix)
		{
			ModelType = modelType;
			Postfix = postfix;
		}
	}
}