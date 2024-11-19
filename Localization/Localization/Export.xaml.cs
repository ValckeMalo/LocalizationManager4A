using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
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
        public void TryDirectoryPath(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public void ExportToCSV(List<LocalizationItem> items, string filePath, string fileName)
        {
            var sb = new StringBuilder();

            foreach (var item in items)
            {
                foreach (var stringValue in item.StringsCollections)
                {
                    sb.Append($"{item.Language},{stringValue.Key},{stringValue.Value},\n");
                }
            }

            TryDirectoryPath(filePath);
            File.WriteAllText($"{filePath}/{fileName}.csv", sb.ToString());
        }

        public void ExportToJSON(List<LocalizationItem> items, string filePath, string fileName)
        {
            var json = JsonSerializer.Serialize(items);
            List<LocalizationItem> items2 = JsonSerializer.Deserialize<List<LocalizationItem>>(string.Empty);
            TryDirectoryPath(filePath);
            File.WriteAllText($"{filePath}/{fileName}.json", json);
        }

        public void ExportToXML(List<LocalizationItem> items, string filePath, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<LocalizationItem>));

            TryDirectoryPath(filePath);
            using (var writer = new StreamWriter($"{filePath}/{fileName}.xml"))
            {
                serializer.Serialize(writer, items);
            }
        }
    }

}