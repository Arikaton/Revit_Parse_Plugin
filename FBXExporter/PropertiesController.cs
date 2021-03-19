using Autodesk.Revit.DB;
using FBXExporter.UI;
using System.IO;

namespace FBXExporter
{
    public class PropertiesController
    {
        private PropertyForm form;
        private JsonDb jsonDb;
        private string dbPath;

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

        public void SaveElementData(ElementData elementData)
        {
            jsonDb.AddElement(elementData.Id, elementData);
        }

        public void SaveAllData()
        {
            SaveCurrentElementData();
            SaveData();
        }

        private void SaveData()
        {
            jsonDb.Save(dbPath);
        }

        public void ChangeDatabasePath(string newPath)
        {
            dbPath = newPath;
            jsonDb.Load(dbPath);
            form.UpdateDatabasePath(newPath);
        }

        public void SaveCurrentElementData()
        {
            var elementData = form.GetCurrentElementData();
            if (string.IsNullOrEmpty(elementData.Id))
                return;
            SaveElementData(elementData);
        }

        public void SelectionChanged(Element element)
        {
            var elementData = jsonDb.GetElementById(element.Id.IntegerValue.ToString());
            if (elementData is null)
                elementData = new ElementData(element.Id.IntegerValue.ToString(), element.Name);
            form.UpdateProperties(elementData);
        }
    }
}
