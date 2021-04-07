using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Windows;
using FBXExporter.Entity;

namespace FBXExporter
{
    [Transaction(TransactionMode.Manual)]
    class CmdSelectionChanged : IExternalCommand
    {
        private static UIApplication _uiapp;
        private static bool _subscribed = false;
        private static PropertiesController propertiesController;
        private static void PanelEvent(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Debug.Assert(sender is RibbonTab,
              "expected sender to be a ribbon tab");

            var activeUI = _uiapp.ActiveUIDocument;
            var document = activeUI.Document;
            if (e.PropertyName == "Title")
            {
                var ids = activeUI.Selection.GetElementIds();
                if (ids.Count == 0) return;
                var firstSelectedElement = document.GetElement(ids.First());
                
                if (firstSelectedElement is Group group)
                {
                    var elements = GetElementsWithGeometry(group);
                    if (elements.Count != 0)
                    {
                        propertiesController?.SaveSelectedElementData();
                        propertiesController?.SelectionChanged(elements, group);
                        return;
                    }
                }

                propertiesController?.SaveSelectedElementData();
                propertiesController?.SelectionChanged(firstSelectedElement);
            }
        }

        private static List<Element> GetElementsWithGeometry(Group group)
        {
            var elements = new List<Element>();
            var memberIds = group.GetMemberIds();
            foreach (var member in memberIds)
            {
                var memberElement = _uiapp.ActiveUIDocument.Document.GetElement(member);
                var memberGeometry = memberElement.get_Geometry(new Options());
                if (memberGeometry is null) continue;
                elements.Add(memberElement);
            }
            return elements;
        }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            _uiapp = commandData.Application;
            InitializePropertyController();
            if (!_subscribed)
            {
                Subscribe();
                propertiesController.RefreshData(_uiapp);
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
                propertiesController.OnEnable();
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