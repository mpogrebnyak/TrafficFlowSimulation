namespace Localization
{
    public interface IResourceProvider
    {
        string GetValue(string locale, string key);
    }
}