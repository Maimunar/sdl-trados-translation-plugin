using System.Collections.Generic;
using System;

namespace GCSTranslationMemory
{
    /// <summary>
    /// A subclass of the main logging utility class that extends its functionality by providing a
    /// container to store log entries only for the duration of a single batch task execution
    /// </summary>
    public class BatchTaskLogger : Logger
    {
        private List<LogUnit> _logEntries;

        public List<LogUnit> LogEntries
        {
            get { return _logEntries; }
            set { _logEntries = value; }
        }

        public BatchTaskLogger(string dirPath) : base(dirPath) 
        {
            this.LogEntries = new List<LogUnit>();
        }

        public BatchTaskLogger(string dirPath, LoggingLevels logLevel) : base(dirPath, logLevel) 
        {
            this.LogEntries = new List<LogUnit>();
        }

        protected override void InternalLog(string msg, LoggingLevels logLevel)
        {
            base.InternalLog(msg, logLevel);
            // Note: Time is configured in specified format; The logging level is padded right by 10 spaces
            LogEntries.Add(new LogUnit($"[{DateTime.Now:yyyy-MM-dd - HH:mm:ss}] {logLevel, -10} | {msg}"));
        }
    }
}
