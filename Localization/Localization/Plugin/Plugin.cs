namespace Localization.Plugin
{
    public abstract class Plugin : IPlugin
    {
        protected string modelPath = "Model/";
        protected string replaceString = "/**/";

        protected const string FileName = "Localizer";
        protected const string DirectoryPath = "GenClass/";

        public abstract void GenerateClass(List<LocalizationItem> allLanguages);
        protected abstract string GenerateLocalizerVariable(List<LocalizationItem> allLanguages);
        protected abstract string GenerateLanguageVariable(LocalizationItem localizationItem);
    }
}