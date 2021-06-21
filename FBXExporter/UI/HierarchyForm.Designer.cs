
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
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.RevitNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.renameButton = new System.Windows.Forms.Button();
            this.databaseNameTextBox = new System.Windows.Forms.TextBox();
            this.changePathButton = new System.Windows.Forms.Button();
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
            this.dataGrid.Location = new System.Drawing.Point(13, 20);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersWidth = 51;
            this.dataGrid.RowTemplate.Height = 24;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(562, 284);
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
            this.renameButton.Location = new System.Drawing.Point(468, 321);
            this.renameButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(107, 29);
            this.renameButton.TabIndex = 1;
            this.renameButton.Text = "Переименовать";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // databaseNameTextBox
            // 
            this.databaseNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.databaseNameTextBox.Location = new System.Drawing.Point(12, 308);
            this.databaseNameTextBox.Multiline = true;
            this.databaseNameTextBox.Name = "databaseNameTextBox";
            this.databaseNameTextBox.ReadOnly = true;
            this.databaseNameTextBox.Size = new System.Drawing.Size(344, 41);
            this.databaseNameTextBox.TabIndex = 2;
            // 
            // changePathButton
            // 
            this.changePathButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.changePathButton.Location = new System.Drawing.Point(367, 321);
            this.changePathButton.Name = "changePathButton";
            this.changePathButton.Size = new System.Drawing.Size(83, 29);
            this.changePathButton.TabIndex = 3;
            this.changePathButton.Text = "Изменить";
            this.changePathButton.UseVisualStyleBackColor = true;
            this.changePathButton.Click += new System.EventHandler(this.changePathButton_Click);
            // 
            // HierarchyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.changePathButton);
            this.Controls.Add(this.databaseNameTextBox);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.dataGrid);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 400);
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
    }
}