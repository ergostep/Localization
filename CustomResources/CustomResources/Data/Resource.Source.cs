using System.Globalization;
using System.Reflection.Metadata;
using CustomResources.Resources;

namespace CustomResources.Data;

public class ResourceSource:IResourceSource
{
    
    public string GetString(string guid, CultureInfo culture)
    {
        return Language.ResourceManager.GetString(guid, culture);
    }

    public void AddString(string guid, string value, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public void AddCulture(CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}