using Autodesk.Revit.UI;
using System.Reflection;
using System.Windows.Media.Imaging;

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
            var propertyTabName = "Show Property";
            application.CreateRibbonTab(exporterTabName);
            application.CreateRibbonTab(propertyTabName);
            var assemblyLocation = Assembly.GetExecutingAssembly().Location;

            var exportButtonData = new PushButtonData(
                "Export button",
                "Export",
                assemblyLocation,
                "FBXExporter.ExportCommand");
            var propertyButtonData = new PushButtonData(
                "Property button",
                "Show Properties",
                assemblyLocation,
                "FBXExporter.CmdSelectionChanged");

            var pannelAnnotation = application.CreateRibbonPanel(exporterTabName, "FBXExporter");
            var exportButton = pannelAnnotation.AddItem(exportButtonData) as PushButton;
            var propertyButton = pannelAnnotation.AddItem(propertyButtonData) as PushButton;
            exportButton.LargeImage = new BitmapImage(new System.Uri(@"C:\Users\user\RiderProjects\FBXExporter\FBXExporter\Resources\export-icon"));
            propertyButton.LargeImage = new BitmapImage(new System.Uri(@"C:\Users\user\RiderProjects\FBXExporter\FBXExporter\Resources\property-icon.png"));
            return Result.Succeeded;
        }
    }
}