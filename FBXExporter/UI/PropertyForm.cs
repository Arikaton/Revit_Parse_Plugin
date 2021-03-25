﻿using FBXExporter.Entity;
using System.Drawing;
using System.Windows.Forms;

namespace FBXExporter.UI
{
    public partial class PropertyForm : Form
    {
        private PropertiesController controller;
        private Point formPointBeforeMove;

        public PropertyForm(PropertiesController controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        public void UpdateProperties(ElementData elementData, bool isGroup)
        {
            if (!isGroup)
            {
                ElementId.Text = "Element Id:";
                ElementName.Text = "Element Name:";
            } else
            {
                ElementId.Text = "Group Id:";
                ElementName.Text = "Group Name:";
            }
            
            ElementIdValue.Text = elementData.Id;
            ElementNameValue.Text = elementData.Name;
            NameText.Text = !string.IsNullOrEmpty(elementData.ElementName) ? elementData.ElementName : ""; 
            ParentNameText.Text = !string.IsNullOrEmpty(elementData.ParentName) ? elementData.ParentName : ""; 
        }

        public ElementData GetCurrentElementData() 
            => new ElementData(ElementIdValue.Text, ElementNameValue.Text, NameText.Text, ParentNameText.Text);

        private void ChangePathButton_MouseClick(object sender, MouseEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json|*.json";
            saveFileDialog.Title = "Save a json database";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                controller.ChangeDatabasePath(saveFileDialog.FileName);
            }
        }

        public void UpdateDatabasePath(string path)
        {
            FilePath.Text = path;
        }

        private void CloseButton_MouseClick(object sender, MouseEventArgs e)
        {
            controller.CloseForm();
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - formPointBeforeMove.X;
                Top += e.Y - formPointBeforeMove.Y;
            }
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            formPointBeforeMove = e.Location;
        }
    }
}
