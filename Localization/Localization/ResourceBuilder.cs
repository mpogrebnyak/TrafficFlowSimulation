using System;

namespace Localization.Localization
{
	public class ResourceBuilder
	{
		private readonly IResourceManager _resourceManager;

		public ResourceBuilder(IResourceManager resourceManager)
		{ 
			_resourceManager = resourceManager;
		}

		public TResources Get<TResources>() where TResources : class
		{
			return (TResources)Get(typeof(TResources));
		}

		private object Get(Type typeOfResources)
		{
			var resources = ResourceProviderHelper.CreateLocalizedObject(_resourceManager, typeOfResources);

			return resources;
		}
	}
}
