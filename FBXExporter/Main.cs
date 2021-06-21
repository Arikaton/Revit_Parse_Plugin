using Autodesk.Revit.UI;
using FBXExporter.Utils;
using System.Reflection;

namespace FBXExporter
{
    public class Main : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            var exporterTabName = "FBXExporter";
            application.CreateRibbonTab(exporterTabName);
            var assemblyLocation = Assembly.GetExecutingAssembly().Location;

            /*var deletePushButton = new PushButtonData(
                "GetIds button",
                "Get ids",
                assemblyLocation,
                "FBXExporter.ExportCommand");*/

            var hierarchyButtonData = new PushButtonData(
                "Hierarchy",
                "Show Hierarchy",
                assemblyLocation,
                "FBXExporter.Commands.CmdOpenHierarchy");

            var pannelAnnotation = application.CreateRibbonPanel(exporterTabName, "FBXExporter");
            var hierarchyButton = pannelAnnotation.AddItem(hierarchyButtonData) as PushButton;
            hierarchyButton.LargeImage = Resources.property_icon.ToBitmapImage();
            return Result.Succeeded;
        }


    }
}