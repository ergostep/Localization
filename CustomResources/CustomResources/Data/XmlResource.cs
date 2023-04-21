using System.Globalization;
using System.Xml.Linq;

namespace CustomResources.Data;

public class XmlResource : IResourceSource
{
    public XmlResource()
    {
        AddCulture(CultureInfo.CurrentUICulture);
    }
    private List<CultureInfo> _cultures = new List<CultureInfo>();

    public string GetString(string guid, CultureInfo culture)
    {
        XDocument xdoc;
        try
        {
            xdoc = XDocument.Load(culture.Name +".xml");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine("This language doesn't exist");
            throw;
        }

        var word = xdoc.Element("language").Elements("word").
            FirstOrDefault(w => w.Attribute("id")?.Value == guid);
        var result = word?.Element("value")?.Value;
        return result;
    }

    public void AddString(string guid, string value, CultureInfo culture = null)
    {
        if (culture == null)
        {
            culture = CultureInfo.CurrentUICulture;
        }
        XDocument xdoc;
        try
        {
            xdoc = XDocument.Load(culture.Name +".xml");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine("This language doesn't exist");
            throw;
        }
        
        XElement? root = xdoc.Element("language");
        //TODO have to check for duplicate values
        if(root != null)
        {
            root.Add(new XElement("word",
                new XAttribute("id", guid),
                new XElement("value", value)));
            xdoc.Save(culture.Name +".xml");
        }
    }

    public void AddCulture(CultureInfo culture)
    {
        if (!_cultures.Contains(culture))
        {
            _cultures.Add(culture);
            if (!File.Exists(culture.Name + ".xml"))
            {
                XDocument xdoc = new XDocument();
                XElement languageBase = new XElement("language");
                XElement word = new XElement("word");
                XAttribute id = new XAttribute("id", 1);
                XElement value = new XElement("value","testValue");
                word.Add(id);
                word.Add(value);
                languageBase.Add(word);
                xdoc.Add(languageBase);
                xdoc.Save(culture.Name + ".xml");
            }
        }
    }
    
}

  