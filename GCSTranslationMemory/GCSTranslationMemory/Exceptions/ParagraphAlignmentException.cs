using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCSTranslationMemory
{
    public class ParagraphAlignmentException : ArgumentException
    {
        public ParagraphAlignmentException() { }

        public ParagraphAlignmentException(string message) : base(message) { }

        public ParagraphAlignmentException(string message, Exception inner) : base(message, inner) { }
    }
}
