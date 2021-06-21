using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using FBXExporter.Entity;
using FBXExporter.Presenters;
using FBXExporter.UI;

namespace FBXExporter.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class CmdOpenHierarchy : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;

            var hierarchyController = new HierarchyPresenter(new HierarchyForm(), new Hierarchy(uiapp));
            hierarchyController.Run();

            return Result.Succeeded;
        }
    }
}
