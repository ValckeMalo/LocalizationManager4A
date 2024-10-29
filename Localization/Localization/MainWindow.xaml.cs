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
		public MainWindow()
        {
            InitializeComponent();
			InitializeDataGrid();
		}

		private void DebugButton_Click(object sender, RoutedEventArgs e)
        {
            LanguageLocalizer[] languageLocalizers = [new LanguageLocalizer("fr", new LanguageLocalizer.StringKeyValue("Play", "Jouer"), new LanguageLocalizer.StringKeyValue("Settings", "Options")), new LanguageLocalizer("en", new LanguageLocalizer.StringKeyValue("Play", "Play"), new LanguageLocalizer.StringKeyValue("Settings", "Settings"))];
            GenerateClass(ClassExtension.CS, "Debug", languageLocalizers);
        }
    }
}