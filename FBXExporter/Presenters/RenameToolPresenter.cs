using FBXExporter.Entity;
using FBXExporter.Views;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FBXExporter.Presenters
{
    public class RenameToolPresenter
    {
        private readonly IRenameToolView _view;
        private readonly RenameTool _renameTool;

        public RenameToolPresenter(IRenameToolView view, RenameTool renameTool)
        {
            _view = view;
            _renameTool = renameTool;
        }

        public List<ElementData> ShowDialog()
        {
            List<ElementData> renamedElements = new List<ElementData>();
            var dialogResult = _view.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                _renameTool.BaseName = _view.BaseName;
                _renameTool.Suffix = _view.Suffix;
                _renameTool.Prefix = _view.Prefix;
                _renameTool.StartNumber = _view.StartNumber;

                renamedElements = _renameTool.Rename(
                    _view.UseBaseName,
                    _view.UseSuffix,
                    _view.UsePrefix,
                    _view.UseNumber);
            }
            return renamedElements;
        }
    }
}
