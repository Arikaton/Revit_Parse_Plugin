using System;
using System.Windows.Forms;
using FBXExporter.Views;

namespace FBXExporter.UI
{
    public partial class RenameForm : Form, IRenameToolView
    {
        public event Action OnRenameButton;
        public event Action OnClose;

        public bool UseBaseName => useBaseNameCheckBox.Checked;

        public bool UsePrefix => usePrefixCheckBox.Checked;

        public bool UseSuffix => useSuffixCheckBox.Checked;

        public bool UseNumber => useNumberCheckBox.Checked;

        public bool UseParentName => useParentNameCheckBox.Checked;

        public string BaseName => baseNameTextBox.Text;

        public string Prefix => prefixTextBox.Text;

        public string Suffix => suffixTextBox.Text;

        public string ParentName => parentNameTextBox.Text;

        public uint StartNumber => (uint) startNumberBox.Value;

        public RenameForm()
        {
            InitializeComponent();
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            OnRenameButton?.Invoke();
        }

        private void RenameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnClose?.Invoke();
        }
    }
}
