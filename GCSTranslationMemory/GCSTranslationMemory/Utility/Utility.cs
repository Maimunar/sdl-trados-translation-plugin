using Sdl.LanguagePlatform.TranslationMemory;
using System;
using System.Linq;

namespace GCSTranslationMemory
{
    /// <summary>
    /// general type utility clas
    /// </summary>
    public class Utility
    {
        private static Random random = new Random();

        /// <summary>
        /// Generates a n-length random string
        /// Used for creation of translation memory names
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // A settings importer used for the translation unit creation
        public static ImportSettings GetImportSettings()
        {
            ImportSettings settings = new ImportSettings();
            settings.CheckMatchingSublanguages = true;
            settings.ExistingFieldsUpdateMode = ImportSettings.FieldUpdateMode.Merge;
            return settings;
        }
    }
}
