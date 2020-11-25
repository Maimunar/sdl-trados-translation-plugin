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
    [AutomaticTask("My_Custom_Batch_Task_ID",
                   "My_Custom_Batch_Task_Name",
                   "My_Custom_Batch_Task_Description",
                   GeneratedFileType = AutomaticTaskFileType.BilingualTarget)]
    [AutomaticTaskSupportedFileType(AutomaticTaskFileType.BilingualTarget)]
    [RequiresSettings(typeof(MyCustomBatchTaskSettings), typeof(MyCustomBatchTaskSettingsPage))]
    class MyCustomBatchTask : AbstractFileContentProcessingAutomaticTask
    {
        private MyCustomBatchTaskSettings _settings;
        FileReader task;

        protected override void OnInitializeTask()
        {
            // Note: there are no settings currently, only a template of them if needed
            _settings = GetSetting<MyCustomBatchTaskSettings>();
        }

        protected override void ConfigureConverter(ProjectFile projectFile, IMultiFileConverter multiFileConverter)
        {
            // Creating a new FileReader and giving it access to the settings (unneeded currently) and the file; parsing text afterwards
            // The FileReader handles the task logic of searching the reference numbers, creating and populating the translation memory
            // And providing the reference numbers back
            task = new FileReader(_settings, projectFile);
            multiFileConverter.AddBilingualProcessor(task);
            multiFileConverter.Parse();
        }

        //This executes last and shows a DialogBox with the needed info from the reader's property
        public override void TaskComplete()
        {
            string s = "Reference Numbers:\n";
            foreach (string refNumber in task.ReferenceNumbers.Distinct())
                s += $"{refNumber}\n";
             DialogResult res = MessageBox.Show(s, "References", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
    }
}
