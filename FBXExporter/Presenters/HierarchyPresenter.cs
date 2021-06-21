using System.Collections.Generic;
using Autodesk.Revit.DB;
using FBXExporter.Views;
using FBXExporter.Entity;
using FBXExporter.UI;

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
        }

        private void Subscribe()
        {
            _view.OnSelectionChanged += FormSelectionChangedHandler;
            _view.OnEditElements += EditElementsHandler;
            _view.OnClose += CloseHandler;
            _view.OnRenameButton += RenameButtonHandler;

            _hierarchy.OnSelectionChange += RevitSelectionChangedHandler;
        }

        private void Unsubscribe()
        {
            _view.OnSelectionChanged -= FormSelectionChangedHandler;
            _view.OnEditElements -= EditElementsHandler;
            _view.OnClose -= CloseHandler;

            _hierarchy.OnSelectionChange -= RevitSelectionChangedHandler;
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

        private void RenameButtonHandler(List<ElementData> elements)
        {
            if (elements.Count == 0) return;
            var renameToolPresenter = new RenameToolPresenter(new RenameForm(), new RenameTool(elements));
            var result = renameToolPresenter.ShowDialog();
            if (result.Count == 0) return;
            _hierarchy.SaveElements(elements);
            LoadAllElements();
        }

        private void CloseHandler()
        {
            Unsubscribe();
            _hierarchy.Close();
        }

        private void EditElementsHandler(List<ElementData> elements)
        {
            _hierarchy.SaveElements(elements);
        }
    }
}
