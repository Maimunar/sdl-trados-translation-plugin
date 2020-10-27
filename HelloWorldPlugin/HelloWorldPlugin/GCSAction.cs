using System;
using System.Collections.Generic;
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.DefaultLocations;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using Sdl.TranslationStudioAutomation.IntegrationApi.Extensions;

namespace HelloWorldPlugin
{
    //Creates an action with id HelloWorldAction (like the class), a display name "Hello World!", a description and an Icon, which it gets from PluginResources.resx
    //Puts it in the created Ribbon group with z-index 10 and Display Type - Large
    [Action("GCSAction", Name = "GCS - Create Translation Memory", Description = "Create Translation Memory", Icon = "rocket")]
    [ActionLayout(typeof(GCSRibbonGroup), 10, DisplayType.Large)]
    class GCSAction : AbstractAction
    {
        //Executes on button click
        protected override void Execute()
        {
            System.Windows.Forms.MessageBox.Show("Hello World!");
        }
    }

}
