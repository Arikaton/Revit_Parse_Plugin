using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Windows;

namespace FBXExporter.Entity
{
    public class Hierarchy
    {
        public Action<ICollection<ElementId>> OnSelectionChange;

        private readonly UIApplication _uiapp;
        private JsonDb jsonDb;
        private string dbPath;
        private bool _subscribed;

        public string DatabasePath => dbPath;

        public Hierarchy(UIApplication uiapp)
        {
            _uiapp = uiapp;

            Subscribe();

            Initialize();
        }

        public void Close()
        {
            UnSubscribe();
        }

        public List<ElementData> GetAllElements()
        {
            var allElements = new List<ElementData>();
            var allElementsFromRevit = GetAllElementsFromRevit();

            foreach (var element in allElementsFromRevit)
            {
                // Skip group childs
                if (element.GroupId.IntegerValue != -1) continue;

                var elementID = element.Id.IntegerValue.ToString();              
                var elementData = new ElementData(elementID, element.Name);

                if (jsonDb.Elements.ContainsKey(elementID))
                {
                    var savedElement = jsonDb.GetElementById(elementID);
                    elementData.Name = savedElement.Name;
                    elementData.ParentName = savedElement.ParentName;
                    elementData.GroupName = savedElement.GroupName;
                }
                allElements.Add(elementData);
            }
            return allElements;
        }

        public void SelectElements(List<string> ids)
        {
            List<ElementId> idsToSelect = new List<ElementId>();

            foreach (var id in ids)
            {               
                idsToSelect.Add(new ElementId(int.Parse(id)));
            }

            SelectElements(idsToSelect);
        }

        public void SaveElement(ElementData element)
        {
            if (element == null || string.IsNullOrEmpty(element.Id)) return;

            jsonDb.AddElement(element.Id, element);

            SaveDatabase();
        }

        public void SaveElements(List<ElementData> elements)
        {
            foreach (var element in elements)
            {
                if (element == null || string.IsNullOrEmpty(element.Id)) continue;

                jsonDb.AddElement(element.Id, element);
            }

            SaveDatabase();
        }

        public void ChangeDatabasePath(string newPath)
        {
            dbPath = newPath;
            jsonDb = JsonDbSerializer.Deserialize(newPath);
        }

        private void SaveDatabase()
        {
            JsonDbSerializer.Serialize(jsonDb, dbPath);
        }

        private void SelectElements(List<ElementId> elementIds)
        {
            if (elementIds.Count == 0) return;
            _uiapp.ActiveUIDocument.Selection.SetElementIds(elementIds);
        }

        private void Initialize()
        {
            var myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dbPath = myDocumentsPath + "\\DefaultDatabase.json";         
            jsonDb = JsonDbSerializer.Deserialize(dbPath);
        }

        private IEnumerable<Element> GetAllElementsFromRevit()
        {
            var document = _uiapp.ActiveUIDocument.Document;
            var allElementsFilter = new FilteredElementCollector(document);
            var allElements = allElementsFilter
                .WhereElementIsNotElementType()
                .Where(e => e.get_Geometry(new Options()) != null);
            return allElements;
        }

        private void PanelEvent(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Debug.Assert(sender is RibbonTab,
              "expected sender to be a ribbon tab");

            var activeUI = _uiapp.ActiveUIDocument;

            if (e.PropertyName != "Title") return;

            var ids = activeUI.Selection.GetElementIds();
            if (ids.Count == 0) return;
            OnSelectionChange?.Invoke(ids);
        }

        private void Subscribe()
        {
            if (_subscribed) return;

            foreach (var tab in ComponentManager.Ribbon.Tabs.Where(tab => tab.Id == "Modify"))
            {
                tab.PropertyChanged += PanelEvent;
                _subscribed = true;
            }
        }

        private void UnSubscribe()
        {
            if (!_subscribed) return;

            foreach (var tab in ComponentManager.Ribbon.Tabs.Where(tab => tab.Id == "Modify"))
            {
                tab.PropertyChanged -= PanelEvent;
                _subscribed = false;
            }
        }
    }
}
