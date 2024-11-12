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

        private void DebugButton_Click(object sender, RoutedEventArgs e)
        {
            List<LocalizationItem> allLanguages = new List<LocalizationItem>()
            {
                new LocalizationItem
                (
                    "fr",
                    new List<StringValueKey>()
                        {
                            new StringValueKey() {Key = "Start",Value = "Debut" },
                            new StringValueKey() {Key = "End",Value = "Fin" },
                            new StringValueKey() {Key = "Hello",Value = "Bonjour" },
                        }
                ),

                new LocalizationItem
                (
                    "en",
                    new List<StringValueKey>()
                        {
                            new StringValueKey() {Key = "Start",Value = "Start" },
                            new StringValueKey() {Key = "End",Value = "End" },
                            new StringValueKey() {Key = "Hello",Value = "Hello" },
                        }
                ),
            };

            GenerateClass(EPlugin.CS, allLanguages);
            GenerateClass(EPlugin.H_CPP, allLanguages);
        }
    }
}