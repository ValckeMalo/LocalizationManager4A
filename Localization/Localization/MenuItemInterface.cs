using Localization.Plugin;
using Microsoft.Win32;
using System.Windows;

namespace Localization
{
    public partial class MainWindow : Window
    {
        private void NewFileButton_Click(object sender, RoutedEventArgs e)
        {
            ClearTables();
        }

        private void ImportCsvButton_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.FileName = "localizationFile";
			dialog.DefaultDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
			dialog.DefaultExt = ".csv";
			dialog.Filter = "CSV file (.csv)|*.csv";

			if (dialog.ShowDialog() == true)
				UpdateTables(ImportFromCSV(dialog.FileName));
        }

        private void ImportJsonButton_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.FileName = "localizationFile";
			dialog.DefaultDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
			dialog.DefaultExt = ".json";
			dialog.Filter = "JSON file (.json)|*.json";

			if (dialog.ShowDialog() == true)
				UpdateTables(ImportFromJSON(dialog.FileName));
		}

        private void ImportXmlButton_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.FileName = "localizationFile";
			dialog.DefaultDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
			dialog.DefaultExt = ".xml";
			dialog.Filter = "XML file (.xml)|*.xml";

			if (dialog.ShowDialog() == true)
				UpdateTables(ImportFromXML(dialog.FileName));
        }

        private void ExportCsvButton_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.FileName = "localizationFile";
			dialog.DefaultDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
			dialog.DefaultExt = ".csv";
			dialog.Filter = "CSV file (.csv)|*.csv";

			if (dialog.ShowDialog() == true)
			{
				string fullPath = dialog.FileName;

				string directoryPath = System.IO.Path.GetDirectoryName(fullPath);
				string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(fullPath);

				ExportToCSV(LocalizationItems, directoryPath, fileNameWithoutExtension);
			}
        }

        private void ExportJsonButton_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.FileName = "localizationFile";
			dialog.DefaultDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
			dialog.DefaultExt = ".json";
			dialog.Filter = "JSON file (.json)|*.json";

			if (dialog.ShowDialog() == true)
			{
				string fullPath = dialog.FileName;

				string directoryPath = System.IO.Path.GetDirectoryName(fullPath);
				string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(fullPath);

				ExportToJSON(LocalizationItems, directoryPath, fileNameWithoutExtension);
			}
		}

        private void ExportXmlButton_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.FileName = "localizationFile";
			dialog.DefaultDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
			dialog.DefaultExt = ".xml";
			dialog.Filter = "XML file (.xml)|*.xml";

			if (dialog.ShowDialog() == true)
			{
				string fullPath = dialog.FileName;

				string directoryPath = System.IO.Path.GetDirectoryName(fullPath);
				string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(fullPath);

				ExportToXML(LocalizationItems, directoryPath, fileNameWithoutExtension);
			}
        }

        private void ExportCsButton_Click(object sender, RoutedEventArgs e)
        {
			OpenFolderDialog dialog = new OpenFolderDialog();
			dialog.DefaultDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
			dialog.Multiselect = false;
			dialog.Title = "Select a folder";

			if (dialog.ShowDialog() == true)
			{
				GenerateClass(EPlugin.CS, LocalizationItems, dialog.FolderName);
				ExportToJSON(LocalizationItems, dialog.FolderName, "autoSave");
			}
		}

        private void ExportHCppButton_Click(object sender, RoutedEventArgs e)
		{
			OpenFolderDialog dialog = new OpenFolderDialog();
			dialog.DefaultDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
			dialog.Multiselect = false;
			dialog.Title = "Select a folder";

			if (dialog.ShowDialog() == true)
			{
				GenerateClass(EPlugin.H_CPP, LocalizationItems, dialog.FolderName);
				ExportToJSON(LocalizationItems, dialog.FolderName, "autoSave");
			}
		}

        private void ExportHInlineButton_Click(object sender, RoutedEventArgs e)
		{
			OpenFolderDialog dialog = new OpenFolderDialog();
			dialog.DefaultDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
			dialog.Multiselect = false;
			dialog.Title = "Select a folder";

			if (dialog.ShowDialog() == true)
			{
				GenerateClass(EPlugin.HInline, LocalizationItems, dialog.FolderName);
				ExportToJSON(LocalizationItems, dialog.FolderName, "autoSave");
			}
		}

        private void ExportHppCppButton_Click(object sender, RoutedEventArgs e)
		{
			OpenFolderDialog dialog = new OpenFolderDialog();
			dialog.DefaultDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
			dialog.Multiselect = false;
			dialog.Title = "Select a folder";

			if (dialog.ShowDialog() == true)
			{
				GenerateClass(EPlugin.HPP_CPP, LocalizationItems, dialog.FolderName);
				ExportToJSON(LocalizationItems, dialog.FolderName, "autoSave");
			}
		}

        private void ExportHppInlineButton_Click(object sender, RoutedEventArgs e)
		{
			OpenFolderDialog dialog = new OpenFolderDialog();
			dialog.DefaultDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
			dialog.Multiselect = false;
			dialog.Title = "Select a folder";

			if (dialog.ShowDialog() == true)
			{
				GenerateClass(EPlugin.HPPInline, LocalizationItems, dialog.FolderName);
				ExportToJSON(LocalizationItems, dialog.FolderName, "autoSave");
			}
        }
    }
}
