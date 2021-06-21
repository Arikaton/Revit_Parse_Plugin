using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FBXExporter.Entity;
using FBXExporter.Views;

namespace FBXExporter.UI
{
    public partial class HierarchyForm : Form, IHierarchyView
    {
        public event Action<List<ElementData>> OnRenameButton;
        public event Action<List<string>> OnSelectionChanged;
        public event Action<List<ElementData>> OnEditElements;
        public event Action OnClose;
        public event Action OnChangePath;

        public string DatabasePath { set => databaseNameTextBox.Text = value; }

        public HierarchyForm()
        {
            InitializeComponent();
        }

        public void UpdateElements(List<ElementData> elements)
        {
            dataGrid.Rows.Clear();
            foreach (var element in elements)
            {
                dataGrid.Rows.Add(element.RevitName, element.Id, element.Name, element.ParentName);
            }
        }

        public void SelectElements(List<string> ids)
        {
            if (ids.Count == 0) return;

            // Prevent cyclic call of SelectionChanged events
            dataGrid.SelectionChanged -= dataGrid_SelectionChanged;

            dataGrid.ClearSelection();
            
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                var rowID = (string)row.Cells[IdColumn.Name].Value;
                if (ids.Contains(rowID))
                {
                    row.Selected = true;
                }
            }

            dataGrid.SelectionChanged += dataGrid_SelectionChanged;
        }

        private void dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count == 0) return;
            var selectedIds = new List<string>();
            foreach (DataGridViewRow row in dataGrid.SelectedRows)
            {
                selectedIds.Add(row.Cells[IdColumn.Name].Value.ToString());
            }
            OnSelectionChanged?.Invoke(selectedIds);
        }

        private void dataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            if (rowIndex < 0) return; 

            var row = dataGrid.Rows[rowIndex];

            var revitName = row.Cells[RevitNameColumn.Name].Value.ToString();
            var elementID =  row.Cells[IdColumn.Name].Value.ToString();
            var name = GetCellValue(row.Cells[NameColumn.Name]);
            var parentName = GetCellValue(row.Cells[ParentColumn.Name]);

            var editedElement = new ElementData(elementID, revitName, name, parentName);

            var editedElements = new List<ElementData>() { editedElement };

            OnEditElements?.Invoke(editedElements);
        }

        private void HierarchyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnClose?.Invoke();
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            List<ElementData> elements = new List<ElementData>();

            foreach (DataGridViewRow row in dataGrid.SelectedRows)
            {
                var elementData = new ElementData(
                    GetCellValue(row.Cells[IdColumn.Name]),
                    GetCellValue(row.Cells[RevitNameColumn.Name]),
                    GetCellValue(row.Cells[NameColumn.Name]),
                    GetCellValue(row.Cells[ParentColumn.Name]));

                elements.Add(elementData);
            }

            OnRenameButton?.Invoke(elements);
        }

        private string GetCellValue(DataGridViewCell cell)
        {
            return cell.Value != null ? cell.Value.ToString() : "";
        }

        private void changePathButton_Click(object sender, EventArgs e)
        {
            OnChangePath?.Invoke();
        }
    }
}
