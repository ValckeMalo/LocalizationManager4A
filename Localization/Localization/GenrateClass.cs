namespace Localization
{
    using System.Windows;
    using Localization.Plugin;

    public partial class MainWindow : Window
    {
        private void GenerateClass(EPlugin Eplugin, List<LocalizationItem> allLanguages, string path)
        {
            Plugin.Plugin? plugin = PluginManager.GetDefaultPlugin(Eplugin);

            if (plugin == null)
            {
                Console.Write($"Plugin choose is not recognize {(int)Eplugin}");
                return;
            }

            plugin.GenerateClass(allLanguages,path);
        }
    }
}