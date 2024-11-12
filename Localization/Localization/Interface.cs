using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;

namespace Localization
{
    public partial class MainWindow : Window
	{
		private string previousValueRegister = string.Empty;
		private ObservableCollection<Keys> keysItems;
		private Dictionary<string, ObservableCollection<StringValueKey>> dictStringValueKeys;

		public List<LocalizationItem> LocalizationItems
		{
			get
            {
                List<LocalizationItem> result = new List<LocalizationItem>();

                for (int i = 1; i < MainTabControl.Items.Count - 1; i++)
                {
                    TabItem tabItem = (TabItem)MainTabControl.Items[i];
                    string header = $"{tabItem.Header}";

                    result.Add(new LocalizationItem(header, dictStringValueKeys[header].ToList()));
                }

                return result;
            }
            set
            {
                MainTabControl.SelectedIndex = 0;
                keysItems.Clear();

                if (value == null)
                {
                    for (int i = MainTabControl.Items.Count - 2; i >= 1; i--)
                    {
                        MainTabControl.Items.RemoveAt(i);
                    }

                    dictStringValueKeys.Clear();
                    return;
                }

                for (int i = 1; i < MainTabControl.Items.Count - 1; i++)
                {
                    TabItem tabItem = (TabItem)MainTabControl.Items[i];
                    string header = $"{tabItem.Header}";

                    LocalizationItem localizationItem = value.FirstOrDefault(item => item.Language == header);

                    if (localizationItem != null)
                    {
                        if (dictStringValueKeys.ContainsKey(header))
                            dictStringValueKeys[header] = new ObservableCollection<StringValueKey>(localizationItem.StringsCollections);
                        else
                            dictStringValueKeys.Add(header, new ObservableCollection<StringValueKey>(localizationItem.StringsCollections));

                        tabItem.Header = localizationItem.Language;

                        keysItems.Add(new Keys { Key = header });
                    }
                }
            }
        }

		private void InitializeDataGrid()
		{
			keysItems = new ObservableCollection<Keys>();
            dictStringValueKeys = new Dictionary<string, ObservableCollection<StringValueKey>>();
            DataGrid_Master.ItemsSource = keysItems;
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
            tabControl.SelectedIndex = 0;

            // ASK TAB NAME
            InputDialog inputDialog = new InputDialog();
			if (inputDialog.ShowDialog() == true)
			{
				string header = inputDialog.InputValue;

				// CREATE TAB
				var tabItem = new TabItem { Header = header };
				var dataGrid = new DataGrid { Name = $"DataGrid_{header}" };

				ObservableCollection<StringValueKey> newKeyValue = new ObservableCollection<StringValueKey>();
				dictStringValueKeys.Add(header, newKeyValue);
				dataGrid.ItemsSource = dictStringValueKeys[header];
				dataGrid.CanUserAddRows = false;

				foreach (Keys keyItem in keysItems)
				{
					newKeyValue.Add(new StringValueKey() { Key = keyItem.Key, Value = string.Empty });
				}

				tabItem.Content = dataGrid;

				// INSERT TAB
				tabControl.Items.Insert(count - 1, tabItem);
            }
        }

        private void RemoveTabItem(TabControl tabControl)
        {
            int currentIndex = tabControl.SelectedIndex;
            tabControl.SelectedIndex = 0;

            if (currentIndex >= 0 && currentIndex < tabControl.Items.Count - 1)
            {
                tabControl.Items.RemoveAt(currentIndex);
            }
        }

        private void DataGrid_Master_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if (e.Row.Item is Keys keyContain)
            {
				previousValueRegister = keyContain.Key;
            }
        }

        private void DataGrid_Master_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            for (int i = 1; i < MainTabControl.Items.Count - 1; i++)
            {
                TabItem tabItem = (TabItem)MainTabControl.Items[i];
                string header = $"{tabItem.Header}";

                if (e.EditingElement is TextBox textBox)
                {
                    string newKey = textBox.Text;

					StringValueKey toModify = dictStringValueKeys[header].FirstOrDefault(x => x.Key == previousValueRegister);
                    if (toModify != null)
                    {
                        toModify.Key = newKey;
                    }
                    else
                    {
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
}
