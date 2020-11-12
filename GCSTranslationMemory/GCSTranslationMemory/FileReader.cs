using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.Core.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GCSTranslationMemory
{
    class FileReader : AbstractBilingualContentProcessor
    {
        private MyCustomBatchTaskSettings _taskSettings;
        private string _inputFilePath;

        //This property is used for cross-class communication
        private string referenceNumbers;

        public string ReferenceNumbers
        {
            get { return referenceNumbers; }
            set { referenceNumbers = value; }
        }

        public FileReader(MyCustomBatchTaskSettings settings, string filePath)
        {
            _taskSettings = settings;
            _inputFilePath = filePath;
            referenceNumbers = "";
        }
        //This executes once for all paragraphs in the text
        //It takes a segment pair and checks the source language for and Regex matches
        //The Regex format takes 4 numbers + / + 2-4 numbers + (optionally) / + 2-3 letters
        public override void ProcessParagraphUnit(IParagraphUnit paragraphUnit)
        {
            foreach (ISegmentPair item in paragraphUnit.SegmentPairs)
            {
                MatchCollection matches = Regex.Matches(item.Source.ToString(), @"([0-9]{1,4}[/][0-9]{4}([/][a-zA-Z]{2})?)|([0-9]{4}[/][0-9]{1,4}([/][a-zA-Z]{2})?)");
                foreach(Match match in matches)
                    if(HasAYear(match))
                        referenceNumbers += $"{match.Value}\n";
            }
        }
        //This is unused, might be needed in the future. This executes last from the class
        public override void Complete()
        {
            base.Complete();
        }

        bool HasAYear(Match match)
        {
            string[] values = match.Value.Split('/');
            for (int i = 0; i < 2; i++)
            {
                int valueInt = Convert.ToInt16(values[i]);
                if (valueInt > 1950 && valueInt < 2030)
                    return true;
            }
            return false;
        }
    }
}
