namespace Localization.Plugin.Plugins
{
    using System.IO;
    using System.Collections.Generic;

    public class H_CPP_Plugin : Plugin
    {
        public override void GenerateClass(List<LocalizationItem> allLanguages)
        {
            string modelCpp = File.ReadAllText(modelPath + "CPP/CPPModel.txt");
            string modelH = File.ReadAllText(modelPath + "CPP/HModel.txt");

            string map = string.Empty;

            map = GenerateLocalizerVariable(allLanguages);

            modelCpp = modelCpp.Replace(replaceString, map);

            TryDirectoryPath();

            File.WriteAllText(DirectoryPath + FileName + ".cpp", modelCpp);
            File.WriteAllText(DirectoryPath + FileName + ".h", modelH);
        }

        protected override string GenerateLocalizerVariable(List<LocalizationItem> allLanguages)
        {
            string map = string.Empty;

            for (int i = 0; i < allLanguages.Count; i++)
            {
                map += GenerateLanguageVariable(allLanguages[i]);
            }

            return map;
        }

        protected override string GenerateLanguageVariable(LocalizationItem localizationItem)
        {
            string languageMap = string.Empty;

            languageMap = "{\"" + localizationItem.Language + "\",\n" +
                "\t\t\t{";

            List<StringValueKey> stringKeyValue = localizationItem.StringsCollections;
            foreach (var item in stringKeyValue)
            {
                languageMap += "\n\t\t\t\t{";
                languageMap += $"\"{item.Key}\",\"{item.Value}\"";
                languageMap += "},";
            }

            languageMap += "\n\t\t\t}\n\t\t},\n\n";

            return languageMap;
        }
    }
}