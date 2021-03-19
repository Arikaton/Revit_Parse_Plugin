using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Windows;

namespace FBXExporter
{
    [Transaction(TransactionMode.ReadOnly)]
    class CmdSelectionChanged : IExternalCommand
    {
        private static UIApplication _uiapp;
        private static bool _subscribed = false;
        private static PropertiesController propertiesController;

        private static void PanelEvent(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Debug.Assert(sender is RibbonTab,
              "expected sender to be a ribbon tab");

            if (e.PropertyName == "Title")
            {
                var ids = _uiapp.ActiveUIDocument.Selection.GetElementIds();
                if (ids.Count == 0) return;
                var firstSelectedElement = _uiapp.ActiveUIDocument.Document.GetElement(ids.First());
                propertiesController?.SaveCurrentElementData();
                propertiesController?.SelectionChanged(firstSelectedElement);
            }
        }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            _uiapp = commandData.Application;
            InitializePropertyController();
            if (!_subscribed)
            {
                Subscribe();
                propertiesController.Initialize();
            }
            else
            {
                propertiesController.CloseForm();
            }

            return Result.Succeeded;
        }

        private static void InitializePropertyController()
        {
            if (propertiesController is null)
            {
                propertiesController = new PropertiesController();
                propertiesController.LoadDb();
            }
        }

        public static void UnSubscribe()
        {
            foreach (var tab in ComponentManager.Ribbon.Tabs.Where(tab => tab.Id == "Modify"))
            {
                tab.PropertyChanged -= PanelEvent;
                _subscribed = false;
            }
        }

        public static void Subscribe()
        {
            foreach (var tab in ComponentManager.Ribbon.Tabs.Where(tab => tab.Id == "Modify"))
            {
                tab.PropertyChanged += PanelEvent;
                _subscribed = true;
            }
        }
    }
}