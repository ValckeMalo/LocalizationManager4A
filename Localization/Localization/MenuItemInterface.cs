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
            MessageBox.Show("Import CSV");
        }

        private void ImportJsonButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Import Json");
        }

        private void ImportXmlButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Import XML");
        }

        private void ExportCsvButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Export CSV");
        }

        private void ExportJsonButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Export Json");
        }

        private void ExportXmlButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Export XML");
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
