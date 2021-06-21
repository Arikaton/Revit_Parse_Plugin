using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FBXExporter
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class TestCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var _uiapp = commandData.Application;
            var doc = _uiapp.ActiveUIDocument;
            var selectedElementId = doc.Selection.GetElementIds();
            var element = doc.Document.GetElement(selectedElementId.First());
            var transaction = new Transaction(_uiapp.ActiveUIDocument.Document, "Test delete");
            transaction.Start();
            var ids = _uiapp.ActiveUIDocument.Document.Delete(element.Id);
            var result = new StringBuilder();
            foreach (var id in ids)
            {
                result.Append(id.IntegerValue + "\n");
            }
            MessageBox.Show(result.ToString());
            transaction.RollBack();
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