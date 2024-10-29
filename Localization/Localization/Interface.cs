using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Localization
{
	public partial class MainWindow : Window
	{
		public ObservableCollection<LocalizationItem> LocalizationItems { get; set; }

		private void FileButton_Click(object sender, RoutedEventArgs e) => fileContextMenu.IsOpen = true;

		private void AddButton_Click(object sender, RoutedEventArgs e) => addContextMenu.IsOpen = true;

		private void RemoveButton_Click(object sender, RoutedEventArgs e) => removeContextMenu.IsOpen = true;

		private void New_Click(object sender, RoutedEventArgs e) => MessageBox.Show("New File");

		private void Import_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Open File");

		private void Export_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Save File");

		private void InitializeDataGrid()
		{
			LocalizationItems = new ObservableCollection<LocalizationItem>();
			CreateDynamicColumns(new List<string> { "En" });
			DataGridLocalization.ItemsSource = LocalizationItems;
		}

		private void CreateDynamicColumns(List<string> languages)
		{
			DataGridLocalization.Columns.Clear();
			DataGridLocalization.Columns.Add(new DataGridTextColumn { Header = "Key", Binding = new Binding("Key") });

			foreach (var language in languages)
			{
				DataGridLocalization.Columns.Add(new DataGridTextColumn
				{
					Header = language,
					Binding = new Binding($"Languages[{languages.IndexOf(language)}]")
				});
			}
		}

		private void AddColumn_Click(object sender, RoutedEventArgs e)
		{
			InputDialog inputDialog = new InputDialog();
			if (inputDialog.ShowDialog() == true)
			{
				string columnHeader = inputDialog.InputValue;
				if (!string.IsNullOrEmpty(columnHeader))
				{
					CreateDynamicColumns(new List<string>(GetCurrentLanguages()) { columnHeader });

					foreach (var item in LocalizationItems)
					{
						item.Languages.Add(string.Empty);
					}
				}
			}
		}

		private List<string> GetCurrentLanguages()
		{
			var languages = new List<string>();
			for (int i = 1; i < DataGridLocalization.Columns.Count; i++)
			{
				languages.Add(DataGridLocalization.Columns[i].Header.ToString());
			}
			return languages;
		}

		private void AddRow_Click(object sender, RoutedEventArgs e)
		{
			var newItem = new LocalizationItem
			{
				Key = "NewKey",
				Languages = new List<string>(new string[DataGridLocalization.Columns.Count - 1])
			};
			LocalizationItems.Add(newItem);
		}

		private void RemoveColumn_Click(object sender, RoutedEventArgs e)
		{
			if (DataGridLocalization.Columns.Count > 1)
			{
				string columnHeader = DataGridLocalization.Columns[^1].Header.ToString();
				foreach (var item in LocalizationItems)
				{
					int index = item.Languages.IndexOf(columnHeader);
					if (index >= 0)
					{
						item.Languages.RemoveAt(index);
					}
				}
				DataGridLocalization.Columns.RemoveAt(DataGridLocalization.Columns.Count - 1);
			}
		}

		private void RemoveRow_Click(object sender, RoutedEventArgs e)
		{
		}
	}
}
