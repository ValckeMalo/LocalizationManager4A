using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Localization
{
	public partial class MainWindow : Window
	{
		public ObservableCollection<Keys> KeysItems { get; set; }
		public Dictionary<string, ObservableCollection<StringValueKey>> dictStringValueKeys { get; set; } = new Dictionary<string, ObservableCollection<StringValueKey>>();

		private void FileButton_Click(object sender, RoutedEventArgs e) => fileContextMenu.IsOpen = true;

		private void New_Click(object sender, RoutedEventArgs e) => MessageBox.Show("New File");

		private void Import_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Open File");

		private void Export_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Save File");

		private void InitializeDataGrid()
		{
			KeysItems = new ObservableCollection<Keys>();
			DataGrid_Master.ItemsSource = KeysItems;
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
			//LocalizationItem selectedItem = (LocalizationItem)DataGridLocalization.SelectedItem;

			//if (selectedItem != null)
			//{
			//	int index = LocalizationItems.IndexOf(selectedItem);

			//	if (index >= 0)
			//		LocalizationItems.RemoveAt(index);
			//}
		}

		private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (MainTabControl.SelectedIndex == MainTabControl.Items.Count - 1)
			{
				AddTabItem(MainTabControl);
			}
		}

		private void AddTabItem(TabControl tabControl)
		{
			int count = tabControl.Items.Count;

			// ASK TAB NAME
			InputDialog inputDialog = new InputDialog();
			if (inputDialog.ShowDialog() == true)
			{
				string header = inputDialog.InputValue;

				// CREATE TAB
				var tabItem = new TabItem
				{
					Header = header
				};

				var dataGrid = new DataGrid
				{
					Name = $"DataGrid_{header}"
				};

				ObservableCollection<StringValueKey> newKeyValue = new ObservableCollection<StringValueKey>();
				dictStringValueKeys.Add(header, newKeyValue);
				dataGrid.ItemsSource = dictStringValueKeys[header];
				dataGrid.CanUserAddRows = false;

				foreach (Keys keyItem in KeysItems)
				{
					newKeyValue.Add(new StringValueKey() { Key = keyItem.Key, Value = string.Empty });
				}

				tabItem.Content = dataGrid;

				// INSERT TAB
				tabControl.Items.Insert(count - 1, tabItem);
			}

			// CHANGE SELECTED INEDX
			tabControl.SelectedIndex = count - 2;
		}

		private void DataGrid_Master_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
		{
			for (int i = 1; i < MainTabControl.Items.Count - 1; i++)
			{
				TabItem tabItem = (TabItem)MainTabControl.Items[i];
				string header = $"{tabItem.Header}";

				if (e.EditingElement is TextBox)
				{
					string newKey = (e.EditingElement as TextBox).Text;

					dictStringValueKeys[header].Add(new StringValueKey
					{
						Key = newKey,
						Value = string.Empty
					});
				}
			}
		}
	}
}

//foreach (var item in MainTabControl.Items)
//{
//	if (item is TabItem tabItem)
//	{
//		DataGrid dataGrid = (DataGrid)tabItem.Content;
//		if (dataGrid != null)
//		{

//		}
//	}
//}