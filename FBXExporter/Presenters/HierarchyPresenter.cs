using System.Collections.Generic;
using Autodesk.Revit.DB;
using FBXExporter.Views;
using FBXExporter.Entity;
using FBXExporter.UI;
using System.Windows.Forms;

namespace FBXExporter.Presenters
{
    public class HierarchyPresenter
    {
        public IHierarchyView _view;
        public Hierarchy _hierarchy;

        public HierarchyPresenter(IHierarchyView hierarchyView, Hierarchy hierarchy)
        {
            _view = hierarchyView;
            _hierarchy = hierarchy;
            Subscribe();
        }

        public void Run()
        {
            _view.Show();
            LoadAllElements();
        }

        private void LoadAllElements()
        {
            var elements = _hierarchy.GetAllElements();
            _view.UpdateElements(elements);

            _view.UpdateHierarcy(elements);

            _view.DatabasePath = _hierarchy.DatabasePath;
        }

        private void Subscribe()
        {
            _view.OnSelectionChanged += FormSelectionChangedHandler;
            _view.OnEditElements += EditElementsHandler;
            _view.OnClose += CloseHandler;
            _view.OnRenameButton += RenameButtonHandler;
            _view.OnChangePath += ChangeDatabasePathHandler;
            _view.OnMoveElement += MoveElementHandler;
            _view.OnMoveElementToRoot += MoveElementToRootHandler;
            _view.OnEditElementName += OnEditElementNameHandler;

            _hierarchy.OnSelectionChange += RevitSelectionChangedHandler;
        }

        private void Unsubscribe()
        {
            _view.OnSelectionChanged -= FormSelectionChangedHandler;
            _view.OnEditElements -= EditElementsHandler;
            _view.OnClose -= CloseHandler;
            _view.OnRenameButton -= RenameButtonHandler;
            _view.OnChangePath -= ChangeDatabasePathHandler;
            _view.OnMoveElement -= MoveElementHandler;
            _view.OnMoveElementToRoot -= MoveElementToRootHandler;
            _view.OnEditElementName -= OnEditElementNameHandler;

            _hierarchy.OnSelectionChange -= RevitSelectionChangedHandler;
        }

        private void OnEditElementNameHandler(string id, string newName)
        {
            _hierarchy.EditElementName(id, newName);
            LoadAllElements();

        }

        private void MoveElementToRootHandler(string sourceId)
        {
            _hierarchy.MoveElementToRoot(sourceId);
        }

        private void MoveElementHandler(string sourceId, string targetId)
        {
            _hierarchy.MoveElement(sourceId, targetId);  
        }

        private void FormSelectionChangedHandler(List<string> ids)
        {
            _hierarchy.SelectElements(ids);
        }

        private void RevitSelectionChangedHandler(ICollection<ElementId> elementIds)
        {
            var ids = new List<string>();
            foreach (var elementId in elementIds)
            {
                ids.Add(elementId.IntegerValue.ToString());
            }
            _view.SelectElements(ids);
        }

        private void RenameButtonHandler(List<string> elements)
        {
            if (elements.Count == 0) return;
            var elementDataList = new List<ElementData>();
            foreach (var elementId in elements)
            {
                elementDataList.Add(_hierarchy.GetElementData(elementId));
            }
            var renameToolPresenter = new RenameToolPresenter(new RenameForm(), new RenameTool(elementDataList));
            var result = renameToolPresenter.ShowDialog();
            if (result.Count == 0) return;
            _hierarchy.Save();
            LoadAllElements();
        }

        private void CloseHandler()
        {
            Unsubscribe();
            _hierarchy.Close();
        }

        private void EditElementsHandler(List<ElementData> elements)
        {
            //_hierarchy.SaveElements(elements);
        }

        private void ChangeDatabasePathHandler()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json|*.json";
            saveFileDialog.Title = "Save a json database";
            var dialogResult = saveFileDialog.ShowDialog();

            if (dialogResult == DialogResult.Cancel)
                return;

            if (saveFileDialog.FileName != "")
            {
                _hierarchy.ChangeDatabasePath(saveFileDialog.FileName);
                LoadAllElements();
            }
        }
    }
}
