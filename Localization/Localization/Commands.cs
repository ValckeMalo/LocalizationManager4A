using System.Windows.Input;

namespace Localization
{
    public static class Commands
    {
        public static readonly RoutedUICommand NewFileCommand = new RoutedUICommand(
            "New File", "NewFileCommand", typeof(Commands));
    }
}
