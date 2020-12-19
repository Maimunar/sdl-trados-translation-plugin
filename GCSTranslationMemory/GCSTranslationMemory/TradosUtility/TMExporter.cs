using Sdl.LanguagePlatform.TranslationMemoryApi;

namespace GCSTranslationMemory
{
    /// <summary>
    /// Exporter class that handles exporting to a .tmx
    /// Using a stripped down version of the one offered here:  
    /// http://producthelp.sdl.com/SDK/TranslationMemoryApi/2017/html/77dcb14d-5adc-4ef4-8ec1-75aaa8633cd8.htm
    /// </summary>
    public class TMExporter
    {
        public void ExportTMXFile(string tmPath, string exportFilePath)
        {
            FileBasedTranslationMemory tm = new FileBasedTranslationMemory(tmPath);
            TranslationMemoryExporter exporter = new TranslationMemoryExporter(tm.LanguageDirection);

            // Chunk size - It has a max of 200, changing this up would make the program run faster at the
            // Expense of memory (RAM) usage
            exporter.ChunkSize = 50;
          
            exporter.Export(exportFilePath, true);
        }
    }
}