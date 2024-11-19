using Microsoft.VisualBasic.FileIO;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;


namespace Localization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public List<LocalizationItem> ImportFromCSV(string filePath)
        {
            var items = new Dictionary<string, LocalizationItem>();

            using (var parser = new TextFieldParser(filePath))
            {
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = false;

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    if (fields.Length < 3)
                    {
                        throw new Exception("Le fichier CSV contient des lignes invalides.");
                    }

                    string language = fields[0];
                    string key = fields[1];
                    string value = fields[2];

                    if (!items.TryGetValue(language, out var localizationItem))
                    {
                        localizationItem = new LocalizationItem(language, new List<StringValueKey>());
                        items.Add(language, localizationItem);
                    }

                    localizationItem.StringsCollections.Add(new StringValueKey
                    {
                        Key = key,
                        Value = value
                    });
                }
            }

            return new List<LocalizationItem>(items.Values);

        }

        public List<LocalizationItem> ImportFromJSON(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                var json = reader.ReadToEnd();
                var result = JsonSerializer.Deserialize<List<LocalizationItem>>(json);

                if (result == null)
                {
                    throw new Exception("Le résultat de la désérialisation est null.");
                }

                return result;
            }
        }

        public List<LocalizationItem> ImportFromXML(string filePath)
        {
            var serializer = new XmlSerializer(typeof(List<LocalizationItem>));
            using (var reader = new StreamReader(filePath))
            {
                var result = (List<LocalizationItem>)serializer.Deserialize(reader);

                if (result == null)
                {
                    throw new Exception("Le résultat de la désérialisation est null.");
                }

                return result;
            }
        }
    }

}