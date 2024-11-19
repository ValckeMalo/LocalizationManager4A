using Localization.Plugin;
using System.Windows;

namespace Localization
{
    public partial class MainWindow : Window
    {
        private void NewFileButton_Click(object sender, RoutedEventArgs e)
        {
            LocalizationItems = null;
        }

        private void ImportCsvButton_Click(object sender, RoutedEventArgs e)
        {
            ImportFromCSV("CSV");
        }

        private void ImportJsonButton_Click(object sender, RoutedEventArgs e)
		{
			ImportFromJSON("Json");
		}

        private void ImportXmlButton_Click(object sender, RoutedEventArgs e)
        {
            ImportFromXML("CSV");
        }

        private void ExportCsvButton_Click(object sender, RoutedEventArgs e)
        {
            ExportToCSV(LocalizationItems, "CSV", "masterCSV");
        }

        private void ExportJsonButton_Click(object sender, RoutedEventArgs e)
		{
			ExportToJSON(LocalizationItems, "Json", "masterJson");
		}

        private void ExportXmlButton_Click(object sender, RoutedEventArgs e)
        {
            ExportToXML(LocalizationItems, "XML", "masterXML");
        }

        private void ExportCsButton_Click(object sender, RoutedEventArgs e)
        {
            GenerateClass(EPlugin.CS, LocalizationItems);
        }

        private void ExportHCppButton_Click(object sender, RoutedEventArgs e)
        {
            GenerateClass(EPlugin.H_CPP, LocalizationItems);
        }

        private void ExportHInlineButton_Click(object sender, RoutedEventArgs e)
        {
            GenerateClass(EPlugin.HInline, LocalizationItems);
        }

        private void ExportHppCppButton_Click(object sender, RoutedEventArgs e)
        {
            GenerateClass(EPlugin.HPP_CPP, LocalizationItems);
        }

        private void ExportHppInlineButton_Click(object sender, RoutedEventArgs e)
        {
            GenerateClass(EPlugin.HPPInline, LocalizationItems);
        }

        private void RemoveCurrentLanguage_Click(object sender, RoutedEventArgs e)
        {
            if (MainTabControl.SelectedIndex > 0 && MainTabControl.SelectedIndex < MainTabControl.Items.Count - 1)
            {
                RemoveTabItem(MainTabControl);
            }
        }
    }
}
