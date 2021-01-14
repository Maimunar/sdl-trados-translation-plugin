using GCSTranslationMemory.Forms;
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCSTranslationMemory
{
    //Creates an action with id HelloWorldAction (like the class), a display name "Hello World!", a description and an Icon, which it gets from PluginResources.resx
    //Puts it in the created Ribbon group with z-index 10 and Display Type - Large
    [Action("GCSFeedbackAction", Name = "GCS - Send feedback", Description = "Sends a feedback form to the GCS team", Icon = "feedback")]
    [ActionLayout(typeof(GCSRibbonGroup), 10, DisplayType.Large)]
    class GCSFeedbackAction : AbstractAction
    {
        //Executes on button click
        protected override void Execute()
        {
            FeedbackForm output = new FeedbackForm();
            output.ShowDialog();
        }
    }
}
