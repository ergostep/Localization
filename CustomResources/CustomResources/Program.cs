// See https://aka.ms/new-console-template for more information

using System.Globalization;
using CustomResources.Data;

var ru = CultureInfo.GetCultureInfo("ru");
var fr = CultureInfo.GetCultureInfo("fr");
string guid = Guid.NewGuid().ToString();

var xmlResource = new XmlResource();
xmlResource.AddCulture(ru);
xmlResource.AddCulture(fr);
xmlResource.AddString(guid, "Утро", ru);
xmlResource.AddString(guid, "Matin", fr);
xmlResource.AddString(guid, "Morning");
var locMan = new CustomLocalizationManager();
locMan.RegisterResourceSource(xmlResource);
Console.WriteLine($"For {CultureInfo.CurrentUICulture.ToString()} : {locMan.GetString(guid)}");
Console.WriteLine($"For {ru} : {locMan.GetString(guid, ru)}");
Console.WriteLine($"For {fr} : {locMan.GetString(guid, fr)}");
