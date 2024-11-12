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
            GenerateClass(EPlugin.CS, null);
        }
    }
}