
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
            this.ElementId = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ParentName = new System.Windows.Forms.Label();
            this.ElementIdValue = new System.Windows.Forms.Label();
            this.NameText = new System.Windows.Forms.TextBox();
            this.ParentNameText = new System.Windows.Forms.TextBox();
            this.ElementName = new System.Windows.Forms.Label();
            this.ElementNameValue = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.FilePath = new System.Windows.Forms.Label();
            this.ChangePathButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ElementId
            // 
            this.ElementId.AutoSize = true;
            this.ElementId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ElementId.Location = new System.Drawing.Point(3, 8);
            this.ElementId.Name = "ElementId";
            this.ElementId.Size = new System.Drawing.Size(89, 20);
            this.ElementId.TabIndex = 0;
            this.ElementId.Text = "Element ID";
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
            // ParentName
            // 
            this.ParentName.AutoSize = true;
            this.ParentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParentName.Location = new System.Drawing.Point(3, 35);
            this.ParentName.Name = "ParentName";
            this.ParentName.Size = new System.Drawing.Size(102, 20);
            this.ParentName.TabIndex = 2;
            this.ParentName.Text = "Parent Name";
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
            // ElementName
            // 
            this.ElementName.AutoSize = true;
            this.ElementName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ElementName.Location = new System.Drawing.Point(3, 29);
            this.ElementName.Name = "ElementName";
            this.ElementName.Size = new System.Drawing.Size(114, 20);
            this.ElementName.TabIndex = 7;
            this.ElementName.Text = "Element Name";
            // 
            // ElementNameValue
            // 
            this.ElementNameValue.AutoSize = true;
            this.ElementNameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ElementNameValue.Location = new System.Drawing.Point(142, 29);
            this.ElementNameValue.Name = "ElementNameValue";
            this.ElementNameValue.Size = new System.Drawing.Size(0, 20);
            this.ElementNameValue.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ElementId);
            this.panel1.Controls.Add(this.ElementNameValue);
            this.panel1.Controls.Add(this.ElementIdValue);
            this.panel1.Controls.Add(this.ElementName);
            this.panel1.Location = new System.Drawing.Point(3, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 58);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.NameText);
            this.panel2.Controls.Add(this.NameLabel);
            this.panel2.Controls.Add(this.ParentName);
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
            this.FilePath.Location = new System.Drawing.Point(7, 197);
            this.FilePath.MaximumSize = new System.Drawing.Size(345, 20);
            this.FilePath.Name = "FilePath";
            this.FilePath.Size = new System.Drawing.Size(343, 20);
            this.FilePath.TabIndex = 11;
            this.FilePath.Text = "Choose FileChoose FileChoose FileChoose FileChoose FileChoose FileChoose FileChoo" +
    "se FileChoose FileChoose FileChoose File";
            // 
            // ChangePathButton
            // 
            this.ChangePathButton.Location = new System.Drawing.Point(355, 194);
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
            // 
            // PropertyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 226);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.ChangePathButton);
            this.Controls.Add(this.FilePath);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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

        private System.Windows.Forms.Label ElementId;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label ParentName;
        private System.Windows.Forms.Label ElementIdValue;
        private System.Windows.Forms.TextBox NameText;
        private System.Windows.Forms.TextBox ParentNameText;
        private System.Windows.Forms.Label ElementName;
        private System.Windows.Forms.Label ElementNameValue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label FilePath;
        private System.Windows.Forms.Button ChangePathButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Panel panel3;
    }
}