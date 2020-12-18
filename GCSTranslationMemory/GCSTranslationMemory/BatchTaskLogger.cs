using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCSTranslationMemory
{
    public class BatchTaskLogger : Logger
    {
        private List<string> _logEntries;

        public List<string> LogEntries
        {
            get { return _logEntries; }
            set { _logEntries = value; }
        }

        public BatchTaskLogger() : base() 
        {
            this.LogEntries = new List<string>();
        }

        public BatchTaskLogger(LoggingLevels logLevel) : base(logLevel) 
        {
            this.LogEntries = new List<string>();
        }

        protected override void InternalLog(string msg, LoggingLevels logLevel)
        {
            base.InternalLog(msg, logLevel);
            this.LogEntries.Add($"[{DateTime.Now}] {logLevel.ToString().PadRight(10)} | {msg}");
        }
    }
}
