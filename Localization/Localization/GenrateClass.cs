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
            CPP,
        }

        private const string cSharpExtension = ".cs";
        private const string cPlusPlusExtension = ".cpp";

        private Dictionary<ClassExtension, string> classExtension = new Dictionary<ClassExtension, string>()
        {
            {ClassExtension.CS,".cs"},
            {ClassExtension.CPP,".cpp"},
        };

        private struct LanguageLocalizer
        {
            public string language;
            public StringKeyValue[] stringsCollections;

            public LanguageLocalizer()
            {
                language = string.Empty;
                stringsCollections = new StringKeyValue[0];
            }

            public LanguageLocalizer(string language, List<StringKeyValue> stringsCollections)
            {
                this.language = language;
                this.stringsCollections = stringsCollections.ToArray();
            }

            public LanguageLocalizer(string language, params StringKeyValue[] stringsCollections)
            {
                this.language = language;
                this.stringsCollections = stringsCollections;
            }

            public struct StringKeyValue
            {
                string key;
                string value;

                public StringKeyValue(string value, string key)
                {
                    this.value = value;
                    this.key = key;
                }
            }
        }

        private void GenerateClass(ClassExtension extension, string path)
        {
            if (path == null)
                return;

            string model = File.ReadAllText("CSModel.txt");
            File.WriteAllText(path + classExtension[extension], model);
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