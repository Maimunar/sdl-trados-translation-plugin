using Sdl.ProjectAutomation.AutomaticTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.FileTypeSupport.Framework.IntegrationApi;
using Sdl.ProjectAutomation.Core;
using System.Windows.Forms;
using Sdl.LanguagePlatform.TranslationMemoryApi;
using Sdl.LanguagePlatform.TranslationMemory;
using Sdl.Core.Globalization;
using System.Globalization;
using Sdl.ProjectAutomation.FileBased;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.LanguagePlatform.Core;
using System.IO;

namespace GCSTranslationMemory
{
    ///<summary>
    /// Class handles the execution of the GCS batch task
    /// </summary>
    [AutomaticTask("Logging_Batch_Task_ID",
                   "Logging_Batch_Task_Name",
                   "Logging_Batch_Task_Description",
                   GeneratedFileType = AutomaticTaskFileType.BilingualTarget)]
    [AutomaticTaskSupportedFileType(AutomaticTaskFileType.BilingualTarget)]
    [RequiresSettings(typeof(MyCustomBatchTaskSettings), typeof(MyCustomBatchTaskSettingsPage))]
    class LoggingBatchTask : AbstractFileContentProcessingAutomaticTask
    {
        private MyCustomBatchTaskSettings _settings;
        BatchTaskLogger logger;

        string dirPath;

        protected override void OnInitializeTask()
        {
            // Note: there are no settings currently, only a template of them if needed
            _settings = GetSetting<MyCustomBatchTaskSettings>();
        }

        protected override void ConfigureConverter(ProjectFile projectFile, IMultiFileConverter multiFileConverter) 
        {
            dirPath = Path.GetDirectoryName(projectFile.LocalFilePath);
        }

        //This executes last and shows a DialogBox with the needed info from the reader's property
        public override void TaskComplete()
        {
            List<string> lines = File.ReadLines(Path.Combine(dirPath, "logs", "Logs.txt")).Reverse().ToList();

            LoggingResultForm output = new LoggingResultForm(lines);

            output.ShowDialog();

            //string output = "Logs:\n";

            //for (int i = (lines.Count() - 1); i >= 0; i--)
            //{
            //    output += $"{lines.ElementAt(i)}\n";
            //}

            //DialogResult res = MessageBox.Show(output, "Logs", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
    }
}

