
namespace FBXExporter.UI
{
    partial class RenameForm
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
            this.RenameButton = new System.Windows.Forms.Button();
            this.useBaseNameCheckBox = new System.Windows.Forms.CheckBox();
            this.usePrefixCheckBox = new System.Windows.Forms.CheckBox();
            this.useSuffixCheckBox = new System.Windows.Forms.CheckBox();
            this.useNumberCheckBox = new System.Windows.Forms.CheckBox();
            this.baseNameTextBox = new System.Windows.Forms.TextBox();
            this.prefixTextBox = new System.Windows.Forms.TextBox();
            this.suffixTextBox = new System.Windows.Forms.TextBox();
            this.startNumberBox = new System.Windows.Forms.NumericUpDown();
            this.useParentNameCheckBox = new System.Windows.Forms.CheckBox();
            this.parentNameTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.startNumberBox)).BeginInit();
            this.SuspendLayout();
            // 
            // RenameButton
            // 
            this.RenameButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.RenameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RenameButton.Location = new System.Drawing.Point(76, 267);
            this.RenameButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RenameButton.Name = "RenameButton";
            this.RenameButton.Size = new System.Drawing.Size(136, 32);
            this.RenameButton.TabIndex = 0;
            this.RenameButton.Text = "Переименовать";
            this.RenameButton.UseVisualStyleBackColor = true;
            this.RenameButton.Click += new System.EventHandler(this.RenameButton_Click);
            // 
            // useBaseNameCheckBox
            // 
            this.useBaseNameCheckBox.AutoSize = true;
            this.useBaseNameCheckBox.Location = new System.Drawing.Point(17, 24);
            this.useBaseNameCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.useBaseNameCheckBox.Name = "useBaseNameCheckBox";
            this.useBaseNameCheckBox.Size = new System.Drawing.Size(92, 17);
            this.useBaseNameCheckBox.TabIndex = 1;
            this.useBaseNameCheckBox.Text = "Базовое имя";
            this.useBaseNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // usePrefixCheckBox
            // 
            this.usePrefixCheckBox.AutoSize = true;
            this.usePrefixCheckBox.Location = new System.Drawing.Point(17, 63);
            this.usePrefixCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.usePrefixCheckBox.Name = "usePrefixCheckBox";
            this.usePrefixCheckBox.Size = new System.Drawing.Size(72, 17);
            this.usePrefixCheckBox.TabIndex = 2;
            this.usePrefixCheckBox.Text = "Префикс";
            this.usePrefixCheckBox.UseVisualStyleBackColor = true;
            // 
            // useSuffixCheckBox
            // 
            this.useSuffixCheckBox.AutoSize = true;
            this.useSuffixCheckBox.Location = new System.Drawing.Point(17, 102);
            this.useSuffixCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.useSuffixCheckBox.Name = "useSuffixCheckBox";
            this.useSuffixCheckBox.Size = new System.Drawing.Size(72, 17);
            this.useSuffixCheckBox.TabIndex = 3;
            this.useSuffixCheckBox.Text = "Суффикс";
            this.useSuffixCheckBox.UseVisualStyleBackColor = true;
            // 
            // useNumberCheckBox
            // 
            this.useNumberCheckBox.AutoSize = true;
            this.useNumberCheckBox.Location = new System.Drawing.Point(17, 137);
            this.useNumberCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.useNumberCheckBox.Name = "useNumberCheckBox";
            this.useNumberCheckBox.Size = new System.Drawing.Size(92, 17);
            this.useNumberCheckBox.TabIndex = 4;
            this.useNumberCheckBox.Text = "Нумерация с";
            this.useNumberCheckBox.UseVisualStyleBackColor = true;
            // 
            // baseNameTextBox
            // 
            this.baseNameTextBox.Location = new System.Drawing.Point(128, 24);
            this.baseNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.baseNameTextBox.Name = "baseNameTextBox";
            this.baseNameTextBox.Size = new System.Drawing.Size(150, 20);
            this.baseNameTextBox.TabIndex = 5;
            // 
            // prefixTextBox
            // 
            this.prefixTextBox.Location = new System.Drawing.Point(128, 63);
            this.prefixTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.prefixTextBox.Name = "prefixTextBox";
            this.prefixTextBox.Size = new System.Drawing.Size(150, 20);
            this.prefixTextBox.TabIndex = 6;
            // 
            // suffixTextBox
            // 
            this.suffixTextBox.Location = new System.Drawing.Point(128, 102);
            this.suffixTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.suffixTextBox.Name = "suffixTextBox";
            this.suffixTextBox.Size = new System.Drawing.Size(150, 20);
            this.suffixTextBox.TabIndex = 7;
            // 
            // startNumberBox
            // 
            this.startNumberBox.Location = new System.Drawing.Point(128, 137);
            this.startNumberBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.startNumberBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.startNumberBox.Name = "startNumberBox";
            this.startNumberBox.Size = new System.Drawing.Size(34, 20);
            this.startNumberBox.TabIndex = 9;
            // 
            // useParentNameCheckBox
            // 
            this.useParentNameCheckBox.AutoSize = true;
            this.useParentNameCheckBox.Location = new System.Drawing.Point(17, 202);
            this.useParentNameCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.useParentNameCheckBox.Name = "useParentNameCheckBox";
            this.useParentNameCheckBox.Size = new System.Drawing.Size(98, 17);
            this.useParentNameCheckBox.TabIndex = 10;
            this.useParentNameCheckBox.Text = "Имя родителя";
            this.useParentNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // parentNameTextBox
            // 
            this.parentNameTextBox.Location = new System.Drawing.Point(128, 202);
            this.parentNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.parentNameTextBox.Name = "parentNameTextBox";
            this.parentNameTextBox.Size = new System.Drawing.Size(150, 20);
            this.parentNameTextBox.TabIndex = 11;
            // 
            // RenameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 311);
            this.Controls.Add(this.parentNameTextBox);
            this.Controls.Add(this.useParentNameCheckBox);
            this.Controls.Add(this.startNumberBox);
            this.Controls.Add(this.suffixTextBox);
            this.Controls.Add(this.prefixTextBox);
            this.Controls.Add(this.baseNameTextBox);
            this.Controls.Add(this.useNumberCheckBox);
            this.Controls.Add(this.useSuffixCheckBox);
            this.Controls.Add(this.usePrefixCheckBox);
            this.Controls.Add(this.useBaseNameCheckBox);
            this.Controls.Add(this.RenameButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 350);
            this.Name = "RenameForm";
            this.ShowIcon = false;
            this.Text = "RenameForm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RenameForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.startNumberBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RenameButton;
        private System.Windows.Forms.CheckBox useBaseNameCheckBox;
        private System.Windows.Forms.CheckBox usePrefixCheckBox;
        private System.Windows.Forms.CheckBox useSuffixCheckBox;
        private System.Windows.Forms.CheckBox useNumberCheckBox;
        private System.Windows.Forms.TextBox baseNameTextBox;
        private System.Windows.Forms.TextBox prefixTextBox;
        private System.Windows.Forms.TextBox suffixTextBox;
        private System.Windows.Forms.NumericUpDown startNumberBox;
        private System.Windows.Forms.CheckBox useParentNameCheckBox;
        private System.Windows.Forms.TextBox parentNameTextBox;
    }
}