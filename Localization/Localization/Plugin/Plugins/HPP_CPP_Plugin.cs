﻿namespace Localization.Plugin.Plugins
{
    using System.IO;
    using System.Collections.Generic;

    public class HPP_CPP_Plugin : Plugin
    {
        public override void GenerateClass(List<LocalizationItem> allLanguages, string directoryPath)
        {
            string modelCpp = File.ReadAllText(modelPath + "CPP/CPPModel.txt");
            string modelH = File.ReadAllText(modelPath + "CPP/HPPModel.txt");

            string map = string.Empty;

            map = GenerateLocalizerVariable(allLanguages);

            modelCpp = modelCpp.Replace(replaceString, map);

            TryDirectoryPath(directoryPath);

            File.WriteAllText(directoryPath + "/" + FileName + ".cpp", modelCpp);
            File.WriteAllText(directoryPath + "/" + FileName + ".hpp", modelH);
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

        protected override string GenerateLocalizerVariable(List<LocalizationItem> allLanguages)
        {
            string map = string.Empty;

            for (int i = 0; i < allLanguages.Count; i++)
            {
                map += GenerateLanguageVariable(allLanguages[i]);
            }

            return map;
        }
    }
}