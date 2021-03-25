using Autodesk.Revit.DB;
using FBXExporter.UI;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FBXExporter.Entity
{
    public class PropertiesController
    {
        private PropertyForm form;
        private JsonDb jsonDb;
        private string dbPath;
        private List<Element> selectedElements;

        public bool Initialized { get; private set; }

        public void LoadDb()
        {
            dbPath = Directory.GetCurrentDirectory() + "\\DefaultDatabase.json";
            jsonDb = new JsonDb();
            jsonDb.Load(dbPath);
        }

        public void Initialize()
        {
            form = new PropertyForm(this);
            form.Show();
            form.UpdateDatabasePath(dbPath);
            Initialized = true;
        }

        public void CloseForm()
        {
            SaveAllData();
            form.Close();
            CmdSelectionChanged.UnSubscribe();
            Initialized = false;
        }

        public void SaveAllData()
        {
            SaveSelectedElementData();
            jsonDb.Save(dbPath);
        }

        public void ChangeDatabasePath(string newPath)
        {
            dbPath = newPath;
            jsonDb.Load(dbPath);
            form.UpdateDatabasePath(newPath);
        }

        public void SaveSelectedElementData()
        { 
            var elementData = form.GetCurrentElementData();
            if (string.IsNullOrEmpty(elementData.Id))
                return;
            if (selectedElements is null || selectedElements.Count == 0)
                return;
            if (selectedElements.Count > 1)
            {
                var counter = 0;
                foreach (var element in selectedElements)
                {
                    var newElementData = new ElementData(
                        element.Id.IntegerValue.ToString(),
                        element.Name,
                        $"{elementData.ElementName} ({counter++})",
                        elementData.ParentName);
                    jsonDb.AddElement(element.Id.IntegerValue.ToString(), newElementData);
                }
            }
            jsonDb.AddElement(elementData.Id, elementData);
        }

        public void SelectionChanged(Element element)
        {
            selectedElements = new List<Element> { element };
            var elementData = jsonDb.GetElementById(element.Id.IntegerValue.ToString());
            if (elementData is null)
                elementData = new ElementData(element.Id.IntegerValue.ToString(), element.Name);
            form.UpdateProperties(elementData, false);
        }

        public void SelectionChanged(List<Element> elements, Group group)
        {
            selectedElements = elements;
            var groupData = jsonDb.GetElementById(group.Id.IntegerValue.ToString());
            if (groupData is null)
                groupData = new ElementData(
                    group.Id.IntegerValue.ToString(),
                    group.Name);
            form.UpdateProperties(groupData, true);
        }
    }
}
