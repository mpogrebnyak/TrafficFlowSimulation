using System;

namespace Localization
{
    public class ResourceProvider: IResourceProvider 
    {
        private readonly LoadedResources _resources;

        public ResourceProvider(params Type[] types)
        {
            _resources = ResourceProviderHelper.Load(types);
        }
        public string GetValue(string locale, string key)
        {
            return _resources.GetValue(locale, key);
        }
    }
}
