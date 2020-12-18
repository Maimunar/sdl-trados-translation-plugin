using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCSTranslationMemory
{
    public class LogUnit
    {
        //TODO: Properly comment this class
        private DateTime _time;
        private LoggingLevels _logType;
        private string _description;

        public string Time => _time.ToString("yyyy-MM-dd - HH:mm:ss");

        public string Type => _logType.ToString();

        public string Description => _description;

        public LogUnit(DateTime time, LoggingLevels type, string description)
        {
            _time = time;
            _logType = type;
            _description = description;
        }
    }
}
