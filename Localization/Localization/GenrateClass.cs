using System.Windows;
using System.IO;

namespace Localization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private enum ClassExtension
        {
            CS,
            HCPP,
        }

        private const string cSharpExtension = ".cs";
        private const string cPlusPlusExtension = ".cpp";

        private Dictionary<ClassExtension, string> classExtension = new Dictionary<ClassExtension, string>()
        {
            {ClassExtension.CS,".cs"},
            {ClassExtension.HCPP,".cpp"},
        };

        private void GenerateClass(ClassExtension extension, LocalizationItem[] allLanguages)
        {
            if (extension == ClassExtension.CS)
            {
                string model = File.ReadAllText("Model/CS/CSModel.txt");

                string dictionary = string.Empty;

                for (int i = 0; i < allLanguages.Length; i++)
                {
                    dictionary += DictionaryVariablesCS(allLanguages[i]);
                }

                model = model.Replace("/**/", dictionary);
                File.WriteAllText("GenClass/Localizer.cs", model);
            }
            else if (extension == ClassExtension.HCPP)
            {

                string modelCpp = File.ReadAllText("Model/CPP/CPPModel.txt");
                string modelH = File.ReadAllText("Model/CPP/HModel.txt");

                string map = string.Empty;

                for (int i = 0; i < allLanguages.Length; i++)
                {
                    map += MapVariablesCPP(allLanguages[i]);
                }

                modelCpp = modelCpp.Replace("/**/", map);

                File.WriteAllText("GenClass/Localizer.cpp", modelCpp);
                File.WriteAllText("GenClass/Localizer.h", modelH);
            }
        }

        private string MapVariablesCPP(LocalizationItem localizer)
        {
            string value = string.Empty;

            value = "{\"" + localizer.Language + "\",\n" +
                "\t\t\t{";

            Dictionary<string, string> stringKeyValue = localizer.StringsCollections;
            foreach (var item in stringKeyValue)
            {
                value += "\n\t\t\t\t{";
                value += $"\"{item.Key}\",\"{item.Value}\"";
                value += "},";
            }

            value += "\n\t\t\t}\n\t\t},\n\n";

            return value;
        }
        private string DictionaryVariablesCS(LocalizationItem localizer)
        {
            string value = string.Empty;

            value = "\t\t{\"" + localizer.Language + "\",\n\t\t\tnew Dictionary<string,string>()\n\t\t\t{";

            Dictionary<string, string> stringKeyValue = localizer.StringsCollections;
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

public static class LocalizerManager
{
    private static Dictionary<string, Dictionary<string, string>> localizerCollections = new Dictionary<string, Dictionary<string, string>>()
    {
        /**/
    };
    private static string culture = string.Empty;

    /// <summary>
    /// return the count of language stored
    /// </summary>
    public static int LanguageCount { get => localizerCollections.Count; }

    /// <summary>
    /// Return the total of elements of the key
    /// Return -1 if the key doesn't exist
    /// </summary>
    /// <param name="language"></param>
    /// <returns></returns>
    public static int KeyCount(string language)
    {
        if (language == null || !localizerCollections.ContainsKey(language))
            return -1;

        return localizerCollections[language].Count;
    }

    /// <summary>
    /// return the string based on the language and key
    /// </summary>
    /// <param name="language"></param>
    /// <param name="stringKey"></param>
    /// <returns></returns>
    public static string LocalizedStringOnLanguage(string language, string stringKey)
    {
        if (language == null || !localizerCollections.ContainsKey(language) || stringKey == null)
            return string.Empty;

        return localizerCollections[language][stringKey];
    }

    /// <summary>
    /// return the string based on the culture set and the params key
    /// </summary>
    /// <param name="language"></param>
    /// <param name="stringKey"></param>
    /// <returns></returns>
    public static string LocalizedString(string stringKey)
    {
        if (culture == null || !localizerCollections.ContainsKey(culture) || stringKey == null)
            return string.Empty;

        return localizerCollections[culture][stringKey];
    }

    /// <summary>
    /// Set the culture
    /// </summary>
    /// <param name="language"></param>
    /// <returns></returns>
    public static bool SetCulture(string language)
    {
        if (!localizerCollections.ContainsKey(language))
            return false;

        culture = language;
        return true;
    }
}