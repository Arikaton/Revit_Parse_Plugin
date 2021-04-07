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
            var propertyButtonData = new PushButtonData(
                "Property button",
                "Show Properties",
                assemblyLocation,
                "FBXExporter.CmdSelectionChanged");

            /*var deletePushButton = new PushButtonData(
                "GetIds button",
                "Get ids",
                assemblyLocation,
                "FBXExporter.ExportCommand");*/

            var pannelAnnotation = application.CreateRibbonPanel(exporterTabName, "FBXExporter");
            var propertyButton = pannelAnnotation.AddItem(propertyButtonData) as PushButton;
            propertyButton.LargeImage = Resources.property_icon.ToBitmapImage();
            return Result.Succeeded;
        }


    }
}