using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Localization
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public ObservableCollection<LocalizationItem> LocalizationItems { get; set; }

		private void FileButton_Click(object sender, RoutedEventArgs e)
		{
			fileContextMenu.IsOpen = true;
		}

		private void AddButton_Click(object sender, RoutedEventArgs e)
		{
			addContextMenu.IsOpen = true;
		}

		private void RemoveButton_Click(object sender, RoutedEventArgs e)
		{
			removeContextMenu.IsOpen = true;
		}

		private void New_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("New File");
		}

		private void Import_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Open File");
		}

		private void Export_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Save File");
		}

		private void AddColumn_Click(object sender, RoutedEventArgs e)
		{
			InputDialog inputDialog = new InputDialog();
			if (inputDialog.ShowDialog() == true)
			{
				string columnHeader = inputDialog.InputValue;

				if (columnHeader != null && columnHeader != string.Empty)
					DataGridLocalization.Columns.Add(new DataGridTextColumn() { Header = columnHeader, Binding = new Binding(columnHeader) });
			}
		}

		private void AddRow_Click(object sender, RoutedEventArgs e)
		{
			var newItem = new LocalizationItem
			{
				Key = "NewKey",
				Languages = new List<string>()
			};

			LocalizationItems.Add(newItem);
		}

		private void RemoveColumn_Click(object sender, RoutedEventArgs e)
		{
			int count = DataGridLocalization.Columns.Count;
			if (count > 1)
			{
				DataGridLocalization.Columns.RemoveAt(count - 1);
			}
		}

		private void RemoveRow_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}