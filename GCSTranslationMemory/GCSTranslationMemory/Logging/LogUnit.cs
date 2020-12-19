namespace GCSTranslationMemory
{
    /// <summary>
    /// A class structure to store logging entry data
    /// </summary>
    public class LogUnit
    {
        private readonly string _logEntry;

        public string Entry => _logEntry;

        public LogUnit(string entry)
        {
            this._logEntry = entry;
        }
    }
}
