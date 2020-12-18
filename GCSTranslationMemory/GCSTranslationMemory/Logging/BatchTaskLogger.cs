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
            this.LogEntries.Add(new LogUnit(DateTime.Now, logLevel, msg));
        }
    }
}
