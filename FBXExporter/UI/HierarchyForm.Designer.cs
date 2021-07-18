
namespace FBXExporter.UI
{
    partial class HierarchyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Узел1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Узел2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Узел0", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Узел4");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Узел5");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Узел3", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.RevitNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.renameButton = new System.Windows.Forms.Button();
            this.databaseNameTextBox = new System.Windows.Forms.TextBox();
            this.changePathButton = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RevitNameColumn,
            this.IdColumn,
            this.NameColumn,
            this.ParentColumn});
            this.dataGrid.Location = new System.Drawing.Point(17, 25);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersWidth = 51;
            this.dataGrid.RowTemplate.Height = 24;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(749, 153);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellValueChanged);
            this.dataGrid.SelectionChanged += new System.EventHandler(this.dataGrid_SelectionChanged);
            // 
            // RevitNameColumn
            // 
            this.RevitNameColumn.FillWeight = 3F;
            this.RevitNameColumn.HeaderText = "Element";
            this.RevitNameColumn.MinimumWidth = 100;
            this.RevitNameColumn.Name = "RevitNameColumn";
            this.RevitNameColumn.ReadOnly = true;
            // 
            // IdColumn
            // 
            this.IdColumn.FillWeight = 1F;
            this.IdColumn.HeaderText = "ID";
            this.IdColumn.MinimumWidth = 60;
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.ReadOnly = true;
            // 
            // NameColumn
            // 
            this.NameColumn.FillWeight = 5F;
            this.NameColumn.HeaderText = "Имя";
            this.NameColumn.MinimumWidth = 120;
            this.NameColumn.Name = "NameColumn";
            // 
            // ParentColumn
            // 
            this.ParentColumn.FillWeight = 5F;
            this.ParentColumn.HeaderText = "Родитель";
            this.ParentColumn.MinimumWidth = 120;
            this.ParentColumn.Name = "ParentColumn";
            // 
            // renameButton
            // 
            this.renameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.renameButton.Location = new System.Drawing.Point(624, 650);
            this.renameButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(143, 36);
            this.renameButton.TabIndex = 1;
            this.renameButton.Text = "Переименовать";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // databaseNameTextBox
            // 
            this.databaseNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.databaseNameTextBox.Location = new System.Drawing.Point(16, 634);
            this.databaseNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.databaseNameTextBox.Multiline = true;
            this.databaseNameTextBox.Name = "databaseNameTextBox";
            this.databaseNameTextBox.ReadOnly = true;
            this.databaseNameTextBox.Size = new System.Drawing.Size(457, 50);
            this.databaseNameTextBox.TabIndex = 2;
            // 
            // changePathButton
            // 
            this.changePathButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.changePathButton.Location = new System.Drawing.Point(489, 650);
            this.changePathButton.Margin = new System.Windows.Forms.Padding(4);
            this.changePathButton.Name = "changePathButton";
            this.changePathButton.Size = new System.Drawing.Size(111, 36);
            this.changePathButton.TabIndex = 3;
            this.changePathButton.Text = "Изменить";
            this.changePathButton.UseVisualStyleBackColor = true;
            this.changePathButton.Click += new System.EventHandler(this.changePathButton_Click);
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(206, 253);
            this.treeView.Name = "treeView";
            treeNode1.Name = "Узел1";
            treeNode1.Text = "Узел1";
            treeNode2.Name = "Узел2";
            treeNode2.Text = "Узел2";
            treeNode3.Name = "Узел0";
            treeNode3.Text = "Узел0";
            treeNode4.Name = "Узел4";
            treeNode4.Text = "Узел4";
            treeNode5.Name = "Узел5";
            treeNode5.Text = "Узел5";
            treeNode6.Name = "Узел3";
            treeNode6.Text = "Узел3";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6});
            this.treeView.Size = new System.Drawing.Size(435, 299);
            this.treeView.TabIndex = 4;
            // 
            // HierarchyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 699);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.changePathButton);
            this.Controls.Add(this.databaseNameTextBox);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.dataGrid);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(794, 481);
            this.Name = "HierarchyForm";
            this.ShowIcon = false;
            this.Text = "Иерархия";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HierarchyForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn RevitNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentColumn;
        private System.Windows.Forms.TextBox databaseNameTextBox;
        private System.Windows.Forms.Button changePathButton;
        private System.Windows.Forms.TreeView treeView;
    }
}