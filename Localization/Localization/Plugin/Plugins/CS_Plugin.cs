namespace Localization.Plugin.Plugins
{
    using System.IO;
    using System.Collections.Generic;
    using System.Collections;

    public class CS_Plugin : Plugin
    {
        public override void GenerateClass(List<LocalizationItem> allLanguages)
        {
            string model = File.ReadAllText(modelPath + "CS/CSModel.txt");

            string dictionary = string.Empty;

            dictionary = GenerateLocalizerVariable(allLanguages);

            model = model.Replace(replaceString, dictionary);
            File.WriteAllText(DirectoryPath + FileName + ".cs", model);
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
            string value = string.Empty;

            value = "\t\t{\"" + localizationItem.Language + "\",\n\t\t\tnew Dictionary<string,string>()\n\t\t\t{";

            List<StringValueKey> stringKeyValue = localizationItem.StringsCollections;
            foreach (var item in stringKeyValue)
            {
                value += "\n\t\t\t\t{";
                value += $"\"{item.Key}\",\"{item.Value}\"";
                value += "},";
            }

            value += "\n\t\t\t}\n\t\t},\n\n";

            return value;
        }
    }
}