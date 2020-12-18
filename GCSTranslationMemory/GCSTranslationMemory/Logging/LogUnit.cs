using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCSTranslationMemory
{
    public class LogUnit
    {
        //TODO: Comments. Used for data grids
        private string _logEntry;

        public string Entry => _logEntry;

        public LogUnit(string entry)
        {
            this._logEntry = entry;
        }
    }
}
