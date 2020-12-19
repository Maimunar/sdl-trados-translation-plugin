using Sdl.FileTypeSupport.Framework.BilingualApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using Sdl.LanguagePlatform.TranslationMemoryApi;
using Sdl.LanguagePlatform.TranslationMemory;
using Sdl.LanguagePlatform.Core;
using Sdl.ProjectAutomation.Core;
using System.Xml;

namespace GCSTranslationMemory
{
    /// <summary>
    /// This class takes responsibility of reading the reference numbers and creating the translation memory from
    /// all numbers that fit the criteria
    /// </summary>
    class FileReader : AbstractBilingualContentProcessor
    {
        // Note: This is not currently in use. Marked for potential deletion
        //private readonly TMBatchTaskSettings _taskSettings;
        //private readonly string _inputFilePath;

        private readonly TMDetails tmDetails;
        
        private List<String> referenceNumbers;
        FileBasedTranslationMemory tm;
        readonly string tmxDir;
        readonly BatchTaskLogger logger;

        /// <summary>
        /// This property is used for communicating the reference numbers outside of the class
        /// </summary>
        public List<String> ReferenceNumbers
        {
            get { return referenceNumbers; }
            set { referenceNumbers = value; }
        }

        /// <summary>
        /// The constructor creates the translation memory
        /// Adds the project's source and target languages to the TM
        /// Creates the core directory structure (if not present)
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="projectFile"></param>
        public FileReader(TMBatchTaskSettings settings, ProjectFile projectFile, ref BatchTaskLogger logger)
        {
            // Note: This is not currently in use. Marked for potential deletion
            //this._taskSettings = settings;
            //this._inputFilePath = projectFile.LocalFilePath;

            this.referenceNumbers = new List<string>();
            this.tmDetails = new TMDetails();

            this.logger = logger;

            // Setting up language abbreviations in the TM details class
            tmDetails.SourceLanguage = projectFile.SourceFile.Language.CultureInfo;
            tmDetails.TargetLanguage = projectFile.Language.CultureInfo;

            // Creating a new folder structure for the translation memory
            string dirPath = Path.GetDirectoryName(projectFile.LocalFilePath);
            string fileName = Path.GetFileNameWithoutExtension(projectFile.LocalFilePath);
            DirectoryInfo sdltmDir = Directory.CreateDirectory($"{dirPath}\\TranslationMemories\\{fileName}");
            DirectoryInfo tmxDirectory =  Directory.CreateDirectory($"{sdltmDir.FullName}\\Exports");
            tmxDir = $"{tmxDirectory.FullName}\\{fileName}.tmx";
            // Creating a translation memory
            TMCreator objCreate = new TMCreator();
            tm = objCreate.CreateFileBasedTM($"{sdltmDir.FullName}\\{Utility.RandomString(10)}.sdltm",
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
                {
                    if (HasAYear(match) && IsUnique(match))
                    {
                        foreach (Tuple<int, int> pair in GetNumbers(match))
                        {
                            try
                            {
                                XmlNodeList nodeList = SOAPRequestHandler.Execute(pair.Item1, pair.Item2);

                                if (nodeList.Count == 0) throw new ReferenceNumberNotFoundException();

                                foreach (XmlNode node in nodeList) ProcessEURLEXDocument(node.InnerText, ref tm);
                            }
                            catch (ReferenceNumberNotFoundException)
                            {
                                logger.Error($"The found reference number ({match.Value}) does not exist in the EUR-Lex database.");
                            }
                            catch (System.Net.WebException)
                            {
                                logger.Error("Failed to establish a connection with the EUR-Lex Database.");
                            }
                            catch (Exception ex)
                            {
                                logger.Error($"An unexpected failure occured when trying to request document data from the EUR-Lex database. Error: {ex.Message}");
                            }
                        }
                        referenceNumbers.Add(match.Value);
                    }
                } 
            }     
        }

        // This executes last from the class
        public override void Complete()
        {
            tm.Save();

            try
            {
                TMExporter objTmExport = new TMExporter();
                objTmExport.ExportTMXFile(tm.FilePath, tmxDir);
            }
            catch (Exception)
            {
                logger.Error("Failed to convert the aligned HTML documents to a TMX format.");
            }
            
            base.Complete();
        }

        /// <summary>
        /// This is the main function which deals with the creation of the translation memory's content
        /// </summary>
        /// <param name="celex_id"></param>
        /// <param name="tm"></param>
        private void ProcessEURLEXDocument(string celex_id, ref FileBasedTranslationMemory tm)
        {
            // Getting the full html code for the source and target language and extracting the paragraphs
            try
            {
                List<string> source = HtmlUtility.GetParagraphs(celex_id, tmDetails.SourceLanguage.TwoLetterISOLanguageName);
                List<string> target = HtmlUtility.GetParagraphs(celex_id, tmDetails.TargetLanguage.TwoLetterISOLanguageName);

                // Prevention of Out of Range Exception in case documents are not aligned
                int paragraphCount = Math.Min(source.Count, target.Count);
                // Creation of all translation units for a specific document

                for (int i = 0; i < paragraphCount; i++)
                {
                    if (IsAFaultyPair(source[i], target[i]))
                    {
                        logger.Warning("Detected inconsistency between the source and target language documents. Attempting to perform an automated realignment.");
                        int nextIndex = i + 1;
                        if (nextIndex < paragraphCount)
                        {
                            string newParagraph = $"{target[i]} {target[nextIndex]}";
                            target.RemoveAt(i);
                            target.RemoveAt(i);
                            target.Insert(i, newParagraph);
                        }
                    }

                    TranslationUnit tu = new TranslationUnit
                    {
                        SourceSegment = new Segment(tmDetails.SourceLanguage),
                        TargetSegment = new Segment(tmDetails.TargetLanguage)
                    };
                    tu.SourceSegment.Add(source.ElementAtOrDefault(i) != null ? source[i] : "KUREC");
                    tu.TargetSegment.Add(target.ElementAtOrDefault(i) != null ? target[i] : "KUREC");
                    tm.LanguageDirection.AddTranslationUnit(tu, Utility.GetImportSettings());
                }

                if (source.Count != target.Count) throw new ParagraphAlignmentException();

            }
            catch (ParagraphAlignmentException)
            {
                logger.Error($"The text aligning process failed for document with CELEX {celex_id} due to missing translation pairs. The length of the source and target documents do not match.");
            }
            catch (System.Net.WebException)
            {
                logger.Error("The source or target or both texts are not available on EUR-Lex for the corresponding reference number.");
            }
            catch (Exception ex)
            {
                logger.Error($"An unexpected failure occured when trying to load source/target data from the EUR-Lex database. There might not be enough storage in the translation memory. Error: {ex.Message}");
            }
        }

        /// <summary>
        /// This checks whether a reference number has a year inside
        /// A year can be in the range 1950-2030
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Check whether the reference number is unique
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        private bool IsUnique(Match match) => !ReferenceNumbers.Contains(match.Value);

        /// <summary>
        /// Takes a reference number and converts it to a list of tuples of pairs
        /// The pairs have a structure of <year,number>
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        private List<Tuple<int, int>> GetNumbers(Match match)
        {
            List<Tuple<int, int>> numbers = new List<Tuple<int, int>>();

            string[] values = match.Value.Split('/');
            // This is used to ignore the references without a country code
            if (values.Length > 2) return numbers;

            for (int i = 0; i< 2; i++)
            {
                int year = Convert.ToInt16(values[i]);
                if (year >= 1950 && year <= 2030)
                {
                    int number = Convert.ToInt16(values[(i + 1) % 2]);
                    numbers.Add(new Tuple<int, int>(year, number));
                }
            }
            return numbers;
        }

        public bool IsAFaultyPair(string source, string target) => Regex.IsMatch(source, @"^[0-9a-zA-Z]+[\)\.].+") && Regex.IsMatch(target, @"^\([0-9a-zA-Z]+\)$");
    }
}
