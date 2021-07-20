using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FBXExporter.Entity;
using FBXExporter.Views;
using FBXExporter.Extensions;

namespace FBXExporter.UI
{
    public partial class HierarchyForm : Form, IHierarchyView
    {
        public event Action<List<string>> OnRenameButton;
        public event Action<List<string>> OnSelectionChanged;
        public event Action<List<ElementData>> OnEditElements;
        public event Action OnClose;
        public event Action OnChangePath;
        public event Action<string, string> OnMoveElement;
        public event Action<string> OnMoveElementToRoot;
        public event Action<string, string> OnEditElementName;

        public string DatabasePath { set => databaseNameTextBox.Text = value; }

        private ElementDataNode _selectedNode;

        public HierarchyForm()
        {
            InitializeComponent();
            treeView.CheckBoxes = true;
        }

        public void UpdateElements(List<ElementData> elements)
        {
            //dataGrid.Rows.Clear();
            //foreach (var element in elements)
            //{
            //    dataGrid.Rows.Add(element.RevitName, element.Id, element.Name, element.ParentName);
            //}
        }

        public void SelectElements(List<string> ids)
        {
            if (ids.Count == 0) return;

            // Prevent cyclic call of SelectionChanged events
            dataGrid.SelectionChanged -= dataGrid_SelectionChanged;
            treeView.AfterCheck -= treeView_AfterCheck;

            dataGrid.ClearSelection();
            
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                var rowID = (string)row.Cells[IdColumn.Name].Value;
                if (ids.Contains(rowID))
                {
                    row.Selected = true;
                }
            }

            
            foreach (var node in treeView.Nodes.GetRecursively<ElementDataNode>(x => x.Nodes))
            {
                if (ids.Contains(node.Id))
                    node.Checked = true;
                else
                    node.Checked = false;
            }

            treeView.AfterCheck += treeView_AfterCheck;
            dataGrid.SelectionChanged += dataGrid_SelectionChanged;
        }

        public void UpdateHierarcy(List<ElementData> elements)
        {
            treeView.Nodes.Clear();
            foreach (var elementData in elements)
            {
                treeView.Nodes.Add(CreateTreeNodeFromElementData(elementData));
            }

            //dataGrid.Rows.Clear();
            //foreach (var node in treeView.Nodes.GetRecursively<ElementDataNode>(x => x.Nodes))
            //{
            //    dataGrid.Rows.Add("RevitName", node.Id, "Name", "ParentName");
            //}
        }

        private ElementDataNode CreateTreeNodeFromElementData(ElementData elementData)
        {
            var node = new ElementDataNode();
            node.Text = $"{ elementData.RevitName} | ID:{elementData.Id} | Name:{elementData.Name}" ;
            node.Id = elementData.Id;
            node.ElementName = elementData.Name;
            foreach (var child in elementData.Elements)
            {
                node.Nodes.Add(CreateTreeNodeFromElementData(child));
            }
            return node;
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
            List<string> elements = new List<string>();

            //foreach (DataGridViewRow row in dataGrid.SelectedRows)
            //{
            //    var elementData = new ElementData(
            //        GetCellValue(row.Cells[IdColumn.Name]),
            //        GetCellValue(row.Cells[RevitNameColumn.Name]),
            //        GetCellValue(row.Cells[NameColumn.Name]),
            //        GetCellValue(row.Cells[ParentColumn.Name]));

            //    elements.Add(elementData);
            //}

            foreach (var node in treeView.Nodes.GetRecursively<ElementDataNode>(x=>x.Nodes))
            {
                if(node.Checked)
                {
                    elements.Add(node.Id);
                }
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

        private void treeView_DragDrop(object sender, DragEventArgs e)
        {
            ElementDataNode NewNode;

            if (e.Data.GetDataPresent("FBXExporter.Entity.ElementDataNode", false))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                ElementDataNode DestinationNode = (ElementDataNode)((TreeView)sender).GetNodeAt(pt);
                NewNode = (ElementDataNode)e.Data.GetData("FBXExporter.Entity.ElementDataNode");

                if (DestinationNode == NewNode)
                {
                    return;
                }
                if (DestinationNode == null)
                {
                    var sourceId = NewNode.Id;
                    treeView.Nodes.Add(NewNode.CloneNode());
                    NewNode.Remove();
                    OnMoveElementToRoot?.Invoke(sourceId);
                }
                else if (DestinationNode.TreeView == NewNode.TreeView)
                {
                    var sourceId = NewNode.Id;
                    var destinationId = DestinationNode.Id;
                    DestinationNode.Nodes.Add(NewNode.CloneNode());
                    DestinationNode.Expand();
                    NewNode.Remove();
                    OnMoveElement?.Invoke(sourceId, destinationId);
                }
            }
        }

        private void treeView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            List<string> elements = new List<string>();
            foreach (var node in treeView.Nodes.GetRecursively<ElementDataNode>(x => x.Nodes))
            {
                if (node.Checked)
                {
                    elements.Add(node.Id);
                }
            }
            if (elements.Count == 0) return;
            OnSelectionChanged?.Invoke(elements);
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _selectedNode = (ElementDataNode)e.Node;
            nameField.TextChanged -= nameField_TextChanged;
            nameField.Text = _selectedNode.ElementName;
            nameField.TextChanged += nameField_TextChanged;
        }

        private void nameField_TextChanged(object sender, EventArgs e)
        {
            if (_selectedNode == null) 
            {
                nameField.Text = "";
                return;
            }
            OnEditElementName?.Invoke(_selectedNode.Id, nameField.Text);
        }
    }
}
