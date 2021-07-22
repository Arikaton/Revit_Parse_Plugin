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
        }

        public void SelectElements(List<string> ids)
        {
            if (ids.Count == 0) return;

            // Prevent cyclic call of SelectionChanged events
            treeView.AfterCheck -= treeView_AfterCheck; 
            foreach (var node in treeView.Nodes.GetRecursively<ElementDataNode>(x => x.Nodes))
            {
                if (ids.Contains(node.Id))
                    node.Checked = true;
                else
                    node.Checked = false;
            }
            treeView.AfterCheck += treeView_AfterCheck;
        }

        public void UpdateHierarcy(List<ElementData> elements)
        {
            treeView.Nodes.Clear();
            foreach (var elementData in elements)
            {
                treeView.Nodes.Add(CreateTreeNodeFromElementData(elementData));
            }
        }

        private ElementDataNode CreateTreeNodeFromElementData(ElementData elementData)
        {
            var node = new ElementDataNode();
            node.Text = $"{ elementData.RevitName} | ID:{elementData.Id} | " +
                $"Name:{elementData.Name} | Group:{elementData.GroupName}";
            node.Id = elementData.Id;
            node.ElementName = elementData.Name;
            foreach (var child in elementData.Elements)
            {
                node.Nodes.Add(CreateTreeNodeFromElementData(child));
            }
            return node;
        }

        private void HierarchyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnClose?.Invoke();
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            List<string> elements = new List<string>();

            foreach (var node in treeView.Nodes.GetRecursively<ElementDataNode>(x=>x.Nodes))
            {
                if(node.Checked)
                {
                    elements.Add(node.Id);
                }
            }

            OnRenameButton?.Invoke(elements);
        }

        private bool IsParent(ElementDataNode source, ElementDataNode target)
        {
            foreach (ElementDataNode child in source.Nodes.GetRecursively<ElementDataNode>(x=>x.Nodes))
            {
                if (child.Id == target.Id) return true;
            }
            return false;
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
                if(IsParent(NewNode, DestinationNode))
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
            var elements = new List<string>();
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
            idLabel.Text = $"ID:{_selectedNode.Id}";
            nameField.TextChanged -= nameField_TextChanged;
            nameField.Text = _selectedNode.ElementName;
            nameField.TextChanged += nameField_TextChanged;

            var elements = new List<string>();
            elements.Add(_selectedNode.Id);
            OnSelectionChanged?.Invoke(elements);
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

        private void addEmptyButton_Click(object sender, EventArgs e)
        {

        }
    }
}
