using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System;

namespace Localization
{
	public partial class MainWindow : Window
	{
		public ObservableCollection<LocalizationItem> LocalizationItems { get; set; }

		private void FileButton_Click(object sender, RoutedEventArgs e) => fileContextMenu.IsOpen = true;

		private void New_Click(object sender, RoutedEventArgs e) => MessageBox.Show("New File");

		private void Import_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Open File");

		private void Export_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Save File");

		private void InitializeDataGrid()
		{
			LocalizationItems = new ObservableCollection<LocalizationItem>();
			DataGridLocalization.ItemsSource = LocalizationItems;
		}

		private void AddColumn_Click(object sender, RoutedEventArgs e)
		{
			//InputDialog inputDialog = new InputDialog();
			//if (inputDialog.ShowDialog() == true)
			//{
			//	string columnHeader = inputDialog.InputValue;
			//	if (!string.IsNullOrEmpty(columnHeader))
			//	{
			//		foreach (var item in LocalizationItems)
			//		{
			//			item.Languages.Add(string.Empty);
			//		}
			//	}
			//}
		}

		private void RemoveColumn_Click(object sender, RoutedEventArgs e)
		{
			//if (DataGridLocalization.Columns.Count > 1)
			//{
			//	string columnHeader = DataGridLocalization.Columns[^1].Header.ToString();
			//	foreach (var item in LocalizationItems)
			//	{
			//		int index = item.Languages.IndexOf(columnHeader);
			//		if (index >= 0)
			//		{
			//			item.Languages.RemoveAt(index);
			//		}
			//	}
			//	DataGridLocalization.Columns.RemoveAt(DataGridLocalization.Columns.Count - 1);
			//}
		}

		private void RemoveRow_Click(object sender, RoutedEventArgs e)
		{
			LocalizationItem selectedItem = (LocalizationItem)DataGridLocalization.SelectedItem;

			if (selectedItem != null)
			{
				int index = LocalizationItems.IndexOf(selectedItem);

				if (index >= 0)
					LocalizationItems.RemoveAt(index);
			}
		}
	}
}

//var currentCell = DataGridLocalization.CurrentCell;

//if (currentCell.Column != null)
//{
//	int columnIndex = currentCell.Column.DisplayIndex;

//	var rowItem = currentCell.Item;

//	Console.WriteLine($"Column Index: {columnIndex}");
//	Console.WriteLine($"Row Item: {rowItem}");
//}