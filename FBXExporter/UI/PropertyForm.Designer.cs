
namespace FBXExporter.UI
{
    partial class PropertyForm
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
            this.Id = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ParentNameLabel = new System.Windows.Forms.Label();
            this.ElementIdValue = new System.Windows.Forms.Label();
            this.NameText = new System.Windows.Forms.TextBox();
            this.ParentNameText = new System.Windows.Forms.TextBox();
            this.RevitName = new System.Windows.Forms.Label();
            this.RevitNameValue = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.FilePath = new System.Windows.Forms.Label();
            this.ChangePathButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TestButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Id
            // 
            this.Id.AutoSize = true;
            this.Id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Id.Location = new System.Drawing.Point(3, 8);
            this.Id.Name = "Id";
            this.Id.Size = new System.Drawing.Size(89, 20);
            this.Id.TabIndex = 0;
            this.Id.Text = "Element ID";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLabel.Location = new System.Drawing.Point(3, 4);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(51, 20);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "Name";
            // 
            // ParentNameLabel
            // 
            this.ParentNameLabel.AutoSize = true;
            this.ParentNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParentNameLabel.Location = new System.Drawing.Point(3, 35);
            this.ParentNameLabel.Name = "ParentNameLabel";
            this.ParentNameLabel.Size = new System.Drawing.Size(102, 20);
            this.ParentNameLabel.TabIndex = 2;
            this.ParentNameLabel.Text = "Parent Name";
            // 
            // ElementIdValue
            // 
            this.ElementIdValue.AutoSize = true;
            this.ElementIdValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ElementIdValue.Location = new System.Drawing.Point(142, 5);
            this.ElementIdValue.Name = "ElementIdValue";
            this.ElementIdValue.Size = new System.Drawing.Size(0, 20);
            this.ElementIdValue.TabIndex = 3;
            // 
            // NameText
            // 
            this.NameText.Location = new System.Drawing.Point(149, 3);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(268, 20);
            this.NameText.TabIndex = 4;
            // 
            // ParentNameText
            // 
            this.ParentNameText.Location = new System.Drawing.Point(149, 35);
            this.ParentNameText.Name = "ParentNameText";
            this.ParentNameText.Size = new System.Drawing.Size(268, 20);
            this.ParentNameText.TabIndex = 5;
            // 
            // RevitName
            // 
            this.RevitName.AutoSize = true;
            this.RevitName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RevitName.Location = new System.Drawing.Point(3, 29);
            this.RevitName.Name = "RevitName";
            this.RevitName.Size = new System.Drawing.Size(114, 20);
            this.RevitName.TabIndex = 7;
            this.RevitName.Text = "Element Name";
            // 
            // RevitNameValue
            // 
            this.RevitNameValue.AutoSize = true;
            this.RevitNameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RevitNameValue.Location = new System.Drawing.Point(142, 29);
            this.RevitNameValue.Name = "RevitNameValue";
            this.RevitNameValue.Size = new System.Drawing.Size(0, 20);
            this.RevitNameValue.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TestButton);
            this.panel1.Controls.Add(this.Id);
            this.panel1.Controls.Add(this.RevitNameValue);
            this.panel1.Controls.Add(this.ElementIdValue);
            this.panel1.Controls.Add(this.RevitName);
            this.panel1.Location = new System.Drawing.Point(3, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 58);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.NameText);
            this.panel2.Controls.Add(this.NameLabel);
            this.panel2.Controls.Add(this.ParentNameLabel);
            this.panel2.Controls.Add(this.ParentNameText);
            this.panel2.Location = new System.Drawing.Point(3, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(427, 72);
            this.panel2.TabIndex = 10;
            // 
            // FilePath
            // 
            this.FilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FilePath.AutoEllipsis = true;
            this.FilePath.AutoSize = true;
            this.FilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FilePath.Location = new System.Drawing.Point(7, 194);
            this.FilePath.MaximumSize = new System.Drawing.Size(345, 20);
            this.FilePath.Name = "FilePath";
            this.FilePath.Size = new System.Drawing.Size(127, 16);
            this.FilePath.TabIndex = 11;
            this.FilePath.Text = "Choose FileChoose";
            // 
            // ChangePathButton
            // 
            this.ChangePathButton.Location = new System.Drawing.Point(355, 191);
            this.ChangePathButton.Name = "ChangePathButton";
            this.ChangePathButton.Size = new System.Drawing.Size(75, 23);
            this.ChangePathButton.TabIndex = 12;
            this.ChangePathButton.Text = "Change";
            this.ChangePathButton.UseVisualStyleBackColor = true;
            this.ChangePathButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChangePathButton_MouseClick);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Location = new System.Drawing.Point(413, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(20, 20);
            this.CloseButton.TabIndex = 13;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CloseButton_MouseClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Controls.Add(this.CloseButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(436, 25);
            this.panel3.TabIndex = 14;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseDown);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseMove);
            // 
            // TestButton
            // 
            this.TestButton.Location = new System.Drawing.Point(349, 17);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(75, 23);
            this.TestButton.TabIndex = 15;
            this.TestButton.Text = "Test";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // PropertyForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 222);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.ChangePathButton);
            this.Controls.Add(this.FilePath);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "PropertyForm";
            this.Text = "Element Data";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Id;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label ParentNameLabel;
        private System.Windows.Forms.Label ElementIdValue;
        private System.Windows.Forms.TextBox NameText;
        private System.Windows.Forms.TextBox ParentNameText;
        private System.Windows.Forms.Label RevitName;
        private System.Windows.Forms.Label RevitNameValue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label FilePath;
        private System.Windows.Forms.Button ChangePathButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button TestButton;
    }
}