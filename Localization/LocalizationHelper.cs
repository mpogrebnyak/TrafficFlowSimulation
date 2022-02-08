using Localization.Localization;

namespace Localization
{
	public static class LocalizationHelper
	{
		private static ResourceManager _resourceManager = new();
		private static ResourceBuilder _resourceBuilder;

		public static void Register(object provider)
		{
			_resourceManager.Register(provider);
			_resourceBuilder = new ResourceBuilder(_resourceManager);
		}

		public static TResources Get<TResources>() where TResources : class
		{
			return _resourceBuilder.Get<TResources>();
		}
	}
}