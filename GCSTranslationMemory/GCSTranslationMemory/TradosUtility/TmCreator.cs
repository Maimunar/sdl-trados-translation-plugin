using System.Globalization;
using Sdl.LanguagePlatform.Core.Tokenization;
using Sdl.LanguagePlatform.TranslationMemory;
using Sdl.LanguagePlatform.TranslationMemoryApi;


namespace GCSTranslationMemory
{
    /// <summary>
    /// This class handles the creation of a File-Based Translation Memory
    /// It follows the guide on here: 
    /// http://producthelp.sdl.com/SDK/TranslationMemoryApi/2017/html/864bc430-493f-41ce-9848-28052a314625.htm
    ///  /// </summary>
    public class TMCreator
    {
        #region "create TM"
        public FileBasedTranslationMemory CreateFileBasedTM(string tmPath, CultureInfo sourceLanguage, CultureInfo targetLanguage)
        {
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(
                tmPath,
                "This is a GCS Trados TM",
                sourceLanguage,
                targetLanguage,
                this.GetFuzzyIndexes(),
                this.GetRecognizers(),
                TokenizerFlags.AllFlags,
                WordCountFlags.AllFlags, 
                true
                );

            tm.LanguageResourceBundles.Clear();

            tm.Save();
            return tm;
        }
        #endregion

        #region "get fuzzy indexes"
        private FuzzyIndexes GetFuzzyIndexes()
        {
            return FuzzyIndexes.SourceCharacterBased |
                FuzzyIndexes.SourceWordBased |
                FuzzyIndexes.TargetCharacterBased |
                FuzzyIndexes.TargetWordBased;
        }
        #endregion

        #region "get recognizers"
        private BuiltinRecognizers GetRecognizers()
        {
            return BuiltinRecognizers.RecognizeAcronyms |
                BuiltinRecognizers.RecognizeDates |
                BuiltinRecognizers.RecognizeNumbers |
                BuiltinRecognizers.RecognizeTimes |
                BuiltinRecognizers.RecognizeVariables |
                BuiltinRecognizers.RecognizeMeasurements;
        }
        #endregion
    }
}