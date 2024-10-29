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
        private void ImportCSV()
        {
            
        }

        public void ImportFromJSON()
        {
            
        }

        public List<LocalizationItem> ImportFromXML(string filePath)
        {
            var serializer = new XmlSerializer(typeof(List<LocalizationItem>));
            using (var reader = new StreamReader(filePath))
            {
                return (List<LocalizationItem>)serializer.Deserialize(reader);
            }
        }
    }

}