using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.DefaultLocations;
using Sdl.Desktop.IntegrationApi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldPlugin
{
    //Creates a group on the ribbon at addins with id HelloWorldRibbonGroup and display name "Display Hello World!"
    [RibbonGroup("GCSRibbonGroup", Name = "GCS")]
    [RibbonGroupLayout(LocationByType = typeof(StudioDefaultRibbonTabs.AddinsRibbonTabLocation))]
    class GCSRibbonGroup : AbstractRibbonGroup
    {

    }
}
