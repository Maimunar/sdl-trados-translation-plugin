using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCSTranslationMemory
{
    public class BatchTaskLogger : Logger
    {
        //TODO: Properly comment this class
        private List<string> _logEntries;

        public List<string> LogEntries
        {
            get { return _logEntries; }
            set { _logEntries = value; }
        }

        public BatchTaskLogger(string dirPath) : base(dirPath) 
        {
            this.LogEntries = new List<string>();
        }

        public BatchTaskLogger(string dirPath, LoggingLevels logLevel) : base(dirPath, logLevel) 
        {
            this.LogEntries = new List<string>();
        }

        protected override void InternalLog(string msg, LoggingLevels logLevel)
        {
            base.InternalLog(msg, logLevel);
            this.LogEntries.Add($"[{DateTime.Now.ToString("yyyy-MM-dd - HH:mm:ss")}] {logLevel.ToString().PadRight(10)} | {msg}");
        }
    }
}
