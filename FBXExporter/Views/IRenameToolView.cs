using System;
using System.Windows.Forms;

namespace FBXExporter.Views
{
    public interface IRenameToolView
    {
        event Action OnRenameButton;
        event Action OnClose;

        bool UseBaseName { get; }
        bool UsePrefix { get; }
        bool UseSuffix { get; }
        bool UseNumber { get; }

        string BaseName { get; }
        string Prefix { get; }
        string Suffix { get; }
        uint StartNumber { get; }

        DialogResult ShowDialog();
    }
}
