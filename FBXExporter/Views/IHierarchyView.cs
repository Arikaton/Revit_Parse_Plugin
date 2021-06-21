using System;
using System.Collections.Generic;
using FBXExporter.Entity;

namespace FBXExporter.Views
{
    public interface IHierarchyView
    {
        event Action<List<ElementData>> OnRenameButton;
        event Action<List<string>> OnSelectionChanged;
        event Action<List<ElementData>> OnEditElements;
        event Action OnClose;
        event Action OnChangePath;
        string DatabasePath { set; }
        void Show();
        void Close();
        void UpdateElements(List<ElementData> elements);
        void SelectElements(List<string> id);        
    }
}
