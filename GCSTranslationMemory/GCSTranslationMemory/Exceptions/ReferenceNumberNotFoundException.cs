using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCSTranslationMemory
{
    public class ReferenceNumberNotFoundException : Exception
    {
        public ReferenceNumberNotFoundException() { }

        public ReferenceNumberNotFoundException(string message) : base(message) { }

        public ReferenceNumberNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
