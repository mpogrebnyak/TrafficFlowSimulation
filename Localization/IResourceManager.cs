namespace Localization
{
    public interface IResourceManager : IResourceProvider
    {
        void Register(object provider);

        string GetValue(string locale, string key, out IResourceProvider source);
    }
}