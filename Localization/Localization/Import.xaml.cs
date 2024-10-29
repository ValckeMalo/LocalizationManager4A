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