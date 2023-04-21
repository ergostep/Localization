using System.Globalization;
namespace CustomResources.Data;

public class CustomLocalizationManager
{
    private List<IResourceSource> _resourceSources = new List<IResourceSource>();
    
    public string GetString(string guid, CultureInfo culture = null)
    {
        if (culture is null)
        {
            culture = CultureInfo.CurrentUICulture;
        }
        foreach (IResourceSource resourceSource in _resourceSources)
        {
            var result = resourceSource.GetString(guid, culture);
            if (result is not null) {return result;}
        }

        return String.Empty;
    }

    public void RegisterResourceSource(IResourceSource resource)
    {
        if (!_resourceSources.Contains(resource))
        {_resourceSources.Add(resource);}
    }
}