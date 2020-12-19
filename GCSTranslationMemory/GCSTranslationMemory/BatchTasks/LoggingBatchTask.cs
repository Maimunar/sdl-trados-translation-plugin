using Sdl.ProjectAutomation.AutomaticTasks;
using System.Collections.Generic;
using System.Linq;
using Sdl.FileTypeSupport.Framework.IntegrationApi;
using Sdl.ProjectAutomation.Core;
using System.IO;

namespace GCSTranslationMemory
{
    ///<summary>
    /// Class handles the execution of the GCS logfiles batch task
    /// </summary>
    [AutomaticTask("Logging_Batch_Task_ID",
                   "Logging_Batch_Task_Name",
                   "Logging_Batch_Task_Description",
                   GeneratedFileType = AutomaticTaskFileType.BilingualTarget)]
    [AutomaticTaskSupportedFileType(AutomaticTaskFileType.BilingualTarget)]
    class LoggingBatchTask : AbstractFileContentProcessingAutomaticTask
    {
        private string dirPath;

        protected override void OnInitializeTask() { }

        protected override void ConfigureConverter(ProjectFile projectFile, IMultiFileConverter multiFileConverter) 
        {
            dirPath = Path.GetDirectoryName(projectFile.LocalFilePath);
        }

        // This executes last and shows a custom dialog form with a list of all available error logs
        public override void TaskComplete()
        {
            List<string> lines = File.ReadLines(Path.Combine(dirPath, "logs", "Logs.txt")).Reverse().ToList();

            List<LogUnit> logs = new List<LogUnit>();
            foreach (string line in lines) logs.Add(new LogUnit(line));

            LoggingResultForm output = new LoggingResultForm(logs);
            output.ShowDialog();
        }
    }
}

