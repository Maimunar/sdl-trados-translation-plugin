using Sdl.ProjectAutomation.AutomaticTasks;
using System.Linq;
using Sdl.FileTypeSupport.Framework.IntegrationApi;
using Sdl.ProjectAutomation.Core;
using System.IO;

namespace GCSTranslationMemory
{
    ///<summary>
    /// Class handles the execution of the GCS batch task
    /// </summary>
    [AutomaticTask("TM_Batch_Task_ID",
                   "TM_Batch_Task_Name",
                   "TM_Batch_Task_Description",
                   GeneratedFileType = AutomaticTaskFileType.BilingualTarget)]
    [AutomaticTaskSupportedFileType(AutomaticTaskFileType.BilingualTarget)]
    //[RequiresSettings(typeof(MyCustomBatchTaskSettings), typeof(MyCustomBatchTaskSettingsPage))]
    class TMBatchTask : AbstractFileContentProcessingAutomaticTask
    {
        private TMBatchTaskSettings _settings;
        FileReader task;

        BatchTaskLogger logger;

        protected override void OnInitializeTask()
        {
            // Note: there are no settings currently, only a template of them if needed
            _settings = GetSetting<TMBatchTaskSettings>();
        }

        protected override void ConfigureConverter(ProjectFile projectFile, IMultiFileConverter multiFileConverter)
        {
            // Creating a new FileReader and giving it access to the settings (unneeded currently) and the file; parsing text afterwards
            // The FileReader handles the task logic of searching the reference numbers, creating and populating the translation memory
            // And providing the reference numbers back

            logger = new BatchTaskLogger(Path.GetDirectoryName(projectFile.LocalFilePath), LoggingLevels.DEBUG);

            task = new FileReader(_settings, projectFile, ref logger);
            multiFileConverter.AddBilingualProcessor(task);
            multiFileConverter.Parse();
        }

        // Executes once the task is complete. Displays a custom dialog form with all found unique reference numbers
        public override void TaskComplete()
        {
            ReferenceNumbersForm output = new ReferenceNumbersForm(task.ReferenceNumbers.Distinct().ToList(), logger.LogEntries);
            output.ShowDialog();
        }
    }
}
