using System.Globalization;

namespace GCSTranslationMemory
{

    /// <summary>
    /// This class stores the details needed for the translation memory
    /// </summary>
    public class TMDetails
    {
        private CultureInfo sourceLanguage;
        private CultureInfo targetLanguage;

        public CultureInfo SourceLanguage
        {
            get { return sourceLanguage; }
            set { sourceLanguage = value; }
        }

        public CultureInfo TargetLanguage
        {
            get { return targetLanguage; }
            set { targetLanguage = value; }
        }
    }
}
