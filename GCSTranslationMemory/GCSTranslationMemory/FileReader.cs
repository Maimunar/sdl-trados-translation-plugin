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
using Sdl.LanguagePlatform.TranslationMemoryApi;
using Sdl.LanguagePlatform.TranslationMemory;
using Sdl.LanguagePlatform.Core;
using Sdl.ProjectAutomation.Core;

namespace GCSTranslationMemory
{
    // This class takes responsibility of reading the reference numbers and creating the translation memory for
    // all of the ones that fit the criteria 
    class FileReader : AbstractBilingualContentProcessor
    {
        private MyCustomBatchTaskSettings _taskSettings;
        private string _inputFilePath;
        private TMDetails tmDetails;
        
        private List<String> referenceNumbers;
        FileBasedTranslationMemory tm;

        // This property is used for communication outside of the class
        public List<String> ReferenceNumbers
        {
            get { return referenceNumbers; }
            set { referenceNumbers = value; }
        }

        // The constructor creates the translation memory
        // Adds the project's source and target languages to the TM
        // Creates the core directory structure (if not present)
        public FileReader(MyCustomBatchTaskSettings settings, ProjectFile projectFile)
        {
            _taskSettings = settings;
            _inputFilePath = projectFile.LocalFilePath;
            referenceNumbers = new List<string>();
            tmDetails = new TMDetails();

            // Setting up language abbreviations in the TM details class
            tmDetails.SourceLanguage = projectFile.SourceFile.Language.CultureInfo;
            tmDetails.TargetLanguage = projectFile.Language.CultureInfo;

            // Creating a new folder structure for the translation memory
            string dirPath = Path.GetDirectoryName(projectFile.LocalFilePath);
            string fileName = Path.GetFileNameWithoutExtension(projectFile.LocalFilePath);
            DirectoryInfo dir = Directory.CreateDirectory($"{dirPath}\\TranslationMemories\\{fileName}");
            
            // Directory.CreateDirectory($"{dir.FullName}\\Exports");

            // Creating a translation memory
            TMCreator objCreate = new TMCreator();
            tm = objCreate.CreateFileBasedTM($"{dir.FullName}\\{Utility.RandomString(10)}.sdltm",
                projectFile.SourceFile.Language.CultureInfo, projectFile.Language.CultureInfo);

        }

        // This executes once for each paragraph in the text
        // It takes a segment pair and checks the source language for and Regex matches
        // The Regex format takes (in different orders) 4 numbers as a year / 2-4 numbers / 2 letter ISO language code (Optional)
        public override void ProcessParagraphUnit(IParagraphUnit paragraphUnit)
        {
            foreach (ISegmentPair item in paragraphUnit.SegmentPairs)
            {
                MatchCollection matches = Regex.Matches(item.Source.ToString(), 
                    @"([0-9]{1,4} ?[/] ?[0-9]{4}( ?[/] ?[a-zA-Z]{2})?)|([0-9]{4} ?[/] ?[0-9]{1,4}( ?[/] ?[a-zA-Z]{2})?)");
                foreach (Match match in matches)
                    if (HasAYear(match) && IsUnique(match))
                    {
                        CreateEURLEXTranslationMemory("32006R2031", ref tm);
                        // TODO - Add celexid extraction here on found references
                        referenceNumbers.Add(match.Value);
                    }
                        
            }
            
        }
        // This executes last from the class
        public override void Complete()
        {
            tm.Save();
            //CreateEURLEXTranslationMemory("32006R2031", ref tm);
            base.Complete();
        }

        //This is the main function which deals with the creation of the translation memory's content
        private void CreateEURLEXTranslationMemory(string celex_id, ref FileBasedTranslationMemory tm)
        {
            // Getting the full html code for the source and target language and extracting the paragraphs
            string sourceHtml = HtmlUtility.GetHTMLEurLex(celex_id, tmDetails.SourceLanguage.TwoLetterISOLanguageName);
            string targetHtml = HtmlUtility.GetHTMLEurLex(celex_id, tmDetails.TargetLanguage.TwoLetterISOLanguageName);
            List<string> source = HtmlUtility.GetParagraphs(sourceHtml);
            List<string> target = HtmlUtility.GetParagraphs(targetHtml);

            // Prevention of Out of Range Exception in case documents are not aligned
            int paragraphCount = Math.Min(source.Count, target.Count);
            // Creation of all translation units for a specific document
            for (int i = 0; i < paragraphCount; i++)
            {
                TranslationUnit tu = new TranslationUnit();
                tu.SourceSegment = new Segment(tmDetails.SourceLanguage);
                tu.TargetSegment = new Segment(tmDetails.TargetLanguage);
                tu.SourceSegment.Add(source[i]);
                tu.TargetSegment.Add(target[i]);
                tm.LanguageDirection.AddTranslationUnit(tu, Utility.GetImportSettings());
            }
            //tm.Save();
        }

        // This checks whether a reference number has a year inside
        // A year can be in the range 1950-2030
        private bool HasAYear(Match match)
        {
            string[] values = match.Value.Split('/');
            for (int i = 0; i < 2; i++)
            {
                int valueInt = Convert.ToInt16(values[i]);
                if (valueInt >= 1950 && valueInt <= 2030)
                    return true;
            }
            return false;
        }

        //Check whether the reference number is unique
        private bool IsUnique(Match match) => !ReferenceNumbers.Contains(match.Value);
    }
}
