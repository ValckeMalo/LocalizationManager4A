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
                parser.SetDelimiters(","); // Délimiteur de colonne
                parser.HasFieldsEnclosedInQuotes = true; // Si tu as des champs entre guillemets

                // Lire les en-têtes (si nécessaire)
                string[] headers = parser.ReadFields();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    var item = new LocalizationItem
                    {
                        Key = fields[0], // Le premier champ devient la clé
                        Languages = new List<string>(fields[1..]) // Ajoute toutes les langues à partir du deuxième champ
                    };
                    items.Add(item);
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