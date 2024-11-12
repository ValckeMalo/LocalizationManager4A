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
            var items = new List<LocalizationItem>();

            using (var parser = new TextFieldParser(filePath))
            {
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    string language = fields[0];
                    var stringsCollections = new List<StringValueKey>();

                    for (int i = 1; i < fields.Length; i += 2)
                    {
                        var stringValueKey = new StringValueKey
                        {
                            Key = fields[i],
                            Value = fields[i + 1]
                        };
                        stringsCollections.Add(stringValueKey);
                    }

                    items.Add(new LocalizationItem(language, stringsCollections));
                }
            }

            return items;
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