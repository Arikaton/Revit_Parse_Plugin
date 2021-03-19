using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace FBXExporter
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class ExportCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiApp = commandData.Application;
            var doc = uiApp.ActiveUIDocument.Document;
            //Reference pickedref;
            var allElements = new FilteredElementCollector(doc, doc.ActiveView.Id);
            var elementsInView = (IList)allElements.ToElements();

            var result = new StringBuilder();
            foreach(Element elem in elementsInView)
            {
                result.Append($"Name: {elem.Name} | ID: {elem.Id}\n");
            }
            MessageBox.Show($"Element count{elementsInView.Count}\n{result.ToString()}");

            /*var selection = uiApp.ActiveUIDocument.Selection;
            pickedref = selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, "Please select a group");
            var element = doc.GetElement(pickedref);
            var box = element.get_Geometry(new Options());
            Group group = element as Group;
            MessageBox.Show($"Element ID:{element.Id}\nElement name: {element.Name}\nGeometry: {box.GetBoundingBox().Max}");*/

            return Result.Succeeded;
        }
        public XYZ GetElementCenter(Element elem)
        {
            BoundingBoxXYZ bounding = elem.get_BoundingBox(null);
            XYZ center = (bounding.Max + bounding.Min) * 0.5;
            return center;
        }
    }
}