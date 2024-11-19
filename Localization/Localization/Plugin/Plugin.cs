using System.IO;

namespace Localization.Plugin
{
    public abstract class Plugin : IPlugin
    {
        protected string modelPath = "Model/";
        protected string replaceString = "/**/";

        protected const string FileName = "Localizer";
        protected const string DirectoryPath = "GenClass/";

        public abstract void GenerateClass(List<LocalizationItem> allLanguages,string path);
        protected abstract string GenerateLocalizerVariable(List<LocalizationItem> allLanguages);
        protected abstract string GenerateLanguageVariable(LocalizationItem localizationItem);

        protected void TryDirectoryPath()
        {
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
        }
        protected void TryDirectoryPath(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}