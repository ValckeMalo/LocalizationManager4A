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
        private void ExportCSV(DataGrid dataGrid, string filePath)
        {
            var sb = new StringBuilder();

            // Ajouter les en-têtes
            foreach (var column in dataGrid.Columns)
            {
                sb.Append(column.Header.ToString() + ",");
            }
            sb.AppendLine();

            // Ajouter les lignes
            foreach (var item in dataGrid.Items)
            {
                var row = (LocalizationItem)item;
                sb.Append(row.Key + ",");

                // Ajouter les langues
                sb.AppendLine(string.Join(",", row.Languages));
            }

            File.WriteAllText(filePath, sb.ToString());
        }

        public void ExportToJSON(DataGrid dataGrid, string filePath)
        {
            var items = dataGrid.Items.Cast<LocalizationItem>().ToList();
            var json = JsonSerializer.Serialize(items);
            File.WriteAllText(filePath, json);
        }

        public void ExportToXML(DataGrid dataGrid, string filePath)
        {
            var items = dataGrid.Items.Cast<LocalizationItem>().ToList();
            var serializer = new XmlSerializer(typeof(List<LocalizationItem>));
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, items);
            }
        }
    }

}