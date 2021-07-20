using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using FBXExporter.UI;
using System.Collections.Generic;
using System.IO;

namespace FBXExporter.Entity
{
    //public class PropertiesController
    //{
    //    private PropertyForm form;
    //    private JsonDb jsonDb;
    //    private string dbPath;
    //    private List<Element> selectedElements;
    //    private UIApplication _uiApp;

    //    public bool Initialized { get; private set; }

    //    public void RefreshData(UIApplication uiApp)
    //    {
    //        SetupForm();
    //        _uiApp = uiApp;
    //        Initialized = true;
    //    }

    //    private void SetupForm()
    //    {
    //        form = new PropertyForm(this);
    //        form.Show();
    //        form.UpdateDatabasePath(dbPath);
    //    }

    //    public void OnEnable()
    //    {
    //        dbPath = Directory.GetCurrentDirectory() + "\\DefaultDatabase.json";
    //        jsonDb = JsonDbSerializer.Deserialize(dbPath);
    //    }

    //    public void CloseForm()
    //    {
    //        SaveAllData();
    //        form.Close();
    //        CmdSelectionChanged.UnSubscribe();
    //        Initialized = false;
    //    }

    //    public void SaveAllData()
    //    {
    //        SaveSelectedElementData();
    //        JsonDbSerializer.Serialize(jsonDb, dbPath);
    //    }

    //    public void ChangeDatabasePath(string newPath)
    //    {
    //        dbPath = newPath;
    //        jsonDb = JsonDbSerializer.Deserialize(newPath);
    //        form.UpdateDatabasePath(newPath);
    //    }

    //    public void SaveSelectedElementData()
    //    { 
    //        var elementData = form.GetCurrentElementData();
    //        if (string.IsNullOrEmpty(elementData.Id))
    //            return;
    //        if (selectedElements is null || selectedElements.Count == 0)
    //            return;
    //        if (selectedElements.Count > 1)
    //        {
    //            var counter = 0;
    //            foreach (var element in selectedElements)
    //            {
    //                var id = element.Id.IntegerValue.ToString();
    //                var newElementData = new ElementData(
    //                    id,
    //                    element.Name,
    //                    $"{elementData.Name} ({counter++})",
    //                    elementData.ParentName,
    //                    elementData.RevitName);
    //                jsonDb.AddElement(id, newElementData);
    //            }
    //        }
    //        jsonDb.AddElement(elementData.Id, elementData);
    //    }

    //    public void SelectionChanged(Element element)
    //    {
    //        selectedElements = new List<Element> { element };
    //        var elementData = jsonDb.GetElementById(element.Id.IntegerValue.ToString());
    //        if (elementData is null)
    //            elementData = new ElementData(element.Id.IntegerValue.ToString(), element.Name);
    //        form.UpdateProperties(elementData, false);
    //    }

    //    public void SelectionChanged(List<Element> elements, Group group)
    //    {
    //        selectedElements = elements;
    //        var groupData = jsonDb.GetElementById(group.Id.IntegerValue.ToString());
    //        if (groupData is null)
    //            groupData = new ElementData(
    //                group.Id.IntegerValue.ToString(),
    //                group.Name);
    //        form.UpdateProperties(groupData, true);
    //    }
    //}
}
