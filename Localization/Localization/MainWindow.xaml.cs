namespace Localization
{
    using System.Windows;
    using System.Collections.Generic;
    using Localization.Plugin;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeDataGrid();
		}

		private void Debug_Click(object sender, RoutedEventArgs e)
		{
			UpdateTables(new List<LocalizationItem>()
			{
				new LocalizationItem("Fr", new List<StringValueKey>()
				{
					new StringValueKey()
					{
						Key = "Play",
						Value = "Jouer"
					},
					new StringValueKey()
					{
						Key = "Settings",
						Value = "Options"
					}
				}),
				new LocalizationItem("En", new List<StringValueKey>()
				{
					new StringValueKey()
					{
						Key = "Play",
						Value = "Play"
					},
					new StringValueKey()
					{
						Key = "Settings",
						Value = "Settings"
					}
				})
			});
		}
	}
}