using System.Globalization;
namespace CustomResources.Data;

public interface IResourceSource
{
    public string GetString(string guid, CultureInfo culture);
    public void AddString(string guid, string value, CultureInfo culture);
    public void AddCulture(CultureInfo culture);

}