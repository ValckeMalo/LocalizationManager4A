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
    }
}