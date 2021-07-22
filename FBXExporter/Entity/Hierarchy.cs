using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            SaveDatabase();
            UnSubscribe();
        }

        public List<ElementData> GetAllElements()
        {
            var allElementsFromRevit = GetAllElementsFromRevit();
            var groupChilds = new List<Element>();

            foreach (var element in allElementsFromRevit)
            {
                var elementID = element.Id.IntegerValue.ToString();
                if (jsonDb.ContainsId(elementID)) continue;

                // Skip group childs
                if (element.GroupId.IntegerValue != -1 ) 
                {
                    groupChilds.Add(element);
                    continue; 
                }               

                var newElement = new ElementData(elementID, element.Name);
                jsonDb.AddNewElement(newElement);
            }

            foreach (var groupElement in groupChilds)
            {
                foreach (var element in jsonDb.ElementsList)
                {
                    if (groupElement.GroupId.IntegerValue.ToString() == element.Id)
                    {
                        var elementID = groupElement.Id.IntegerValue.ToString();
                        var newGroupElement = new ElementData(elementID, groupElement.Name);
                        newGroupElement.GroupName = groupElement.GroupId.IntegerValue.ToString();
                        newGroupElement.Name = $"Group:{newGroupElement.GroupName} ID:{newGroupElement.Id}";
                        element.Elements.Add(newGroupElement);                        
                        if(string.IsNullOrEmpty(element.GroupName))
                        {
                            element.GroupName = groupElement.GroupId.IntegerValue.ToString();
                            element.Name = "Group" + groupElement.GroupId.IntegerValue.ToString();
                        }
                        break;
                    }
                }
            }
            return jsonDb.ElementsList;
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

        internal void EditElementName(string id, string newName)
        {
            var elementData = GetElementData(id);
            elementData.Name = newName;
            SaveDatabase();
        }

        public void MoveElement(string sourceId, string targetId)
        {
            jsonDb.Move(sourceId, targetId);
            SaveDatabase();
        }

        public void MoveElementToRoot(string sourceId)
        {
            jsonDb.MoveToRoot(sourceId);
            SaveDatabase();
        }

        public ElementData GetElementData(string id)
        {
            return jsonDb.FindElement(id);
        }

        public void ChangeDatabasePath(string newPath)
        {
            dbPath = newPath;
            jsonDb = JsonDbSerializer.Deserialize(newPath);
        }

        public void Save()
        {
            SaveDatabase();
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
