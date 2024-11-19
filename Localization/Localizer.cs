namespace Localizer
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;
    using System.Xml.Linq;

    public static class LocalizerManager
    {
        #region Class
        public class LocalizationItem
        {
            private string language = string.Empty;
            private List<StringValueKey> stringsCollections;

            public LocalizationItem(string language, List<StringValueKey> stringsCollections)
            {
                this.language = language;
                this.stringsCollections = stringsCollections;
            }

            public string Language
            {
                get => language;
                set => language = value;
            }

            public List<StringValueKey> StringsCollections
            {
                get => stringsCollections;
                set => stringsCollections = value;
            }
        }

        public class StringValueKey
        {
            private string key = string.Empty;
            private string value = string.Empty;

            public string Key
            {
                get => key;
                set => this.key = value;
            }

            public string Value
            {
                get => value;
                set => this.value = value;
            }
        }

        public class Keys
        {
            private string key = string.Empty;

            public string Key
            {
                get => key;
                set => key = value;
            }
        }
        #endregion

        private static Dictionary<string, Dictionary<string, string>> localizerCollections = new Dictionary<string, Dictionary<string, string>>();
        private static string culture = string.Empty;

        /// <summary>
        /// Load the string from a JsonFile
        /// retrun if the dictionary is load or not
        /// </summary>
        /// <returns></returns>
        public static bool LoadLocalizerFromJson(string jsonPath)
        {
            if (string.IsNullOrEmpty(jsonPath) || !File.Exists(jsonPath))
                return false;

            try
            {
                // Lire le contenu du fichier JSON
                var jsonContent = File.ReadAllText(jsonPath);

                // Désérialiser en liste de LocalizationItem
                var localizationItems = JsonSerializer.Deserialize<List<LocalizationItem>>(jsonContent);

                if (localizationItems == null)
                    return false;

                // Charger les données dans le dictionnaire
                foreach (var item in localizationItems)
                {
                    if (!localizerCollections.ContainsKey(item.Language))
                    {
                        localizerCollections[item.Language] = new Dictionary<string, string>();
                    }

                    foreach (var stringItem in item.StringsCollections)
                    {
                        localizerCollections[item.Language][stringItem.Key] = stringItem.Value;
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// Load the string from a JsonFile
        /// retrun if the dictionary is load or not
        /// </summary>
        /// <returns></returns>
        public static bool LoadLocalizerFromCSV(string csvPath)
        {
            if (string.IsNullOrEmpty(csvPath) || !File.Exists(csvPath))
                return false;

            try
            {
                // Lire toutes les lignes du fichier CSV
                var lines = File.ReadAllLines(csvPath);

                foreach (var line in lines)
                {
                    var parts = line.Split(',');

                    if (parts.Length < 3)
                        continue;

                    string language = parts[0].Trim();
                    string key = parts[1].Trim();
                    string value = parts[2].Trim();

                    if (!localizerCollections.ContainsKey(language))
                    {
                        localizerCollections[language] = new Dictionary<string, string>();
                    }

                    localizerCollections[language][key] = value;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// Load the string from a JsonFile
        /// retrun if the dictionary is load or not
        /// </summary>
        /// <returns></returns>
        public static bool LoadLocalizerFromXML(string xmlPath)
        {
            if (string.IsNullOrEmpty(xmlPath) || !File.Exists(xmlPath))
                return false;

            try
            {
                var xmlDocument = XDocument.Load(xmlPath);

                var languages = xmlDocument.Descendants("Language");

                foreach (var languageElement in languages)
                {
                    var language = languageElement.Attribute("Name")?.Value;

                    if (string.IsNullOrEmpty(language))
                        continue;

                    if (!localizerCollections.ContainsKey(language))
                    {
                        localizerCollections[language] = new Dictionary<string, string>();
                    }

                    var strings = languageElement.Descendants("String");

                    foreach (var stringElement in strings)
                    {
                        var key = stringElement.Attribute("Key")?.Value;
                        var value = stringElement.Attribute("Value")?.Value;

                        if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                        {
                            localizerCollections[language][key] = value;
                        }
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }


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
}