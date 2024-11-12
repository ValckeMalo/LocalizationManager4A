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
        public void ExportToCSV(List<LocalizationItem> items, string filePath)
        {
            var sb = new StringBuilder();

            foreach (var item in items)
            {
                sb.Append(item.Language);

                foreach (var stringValue in item.StringsCollections)
                {
                    sb.Append($",{stringValue.Key},{stringValue.Value}");
                }

                sb.AppendLine();
            }

            File.WriteAllText(filePath, sb.ToString());
        }

        public void ExportToJSON(List<LocalizationItem> items, string filePath)
        {
            var json = JsonSerializer.Serialize(items);
            File.WriteAllText(filePath, json);
        }

        public void ExportToXML(List<LocalizationItem> items, string filePath)
        {
            var serializer = new XmlSerializer(typeof(List<LocalizationItem>));
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, items);
            }
        }
    }

}