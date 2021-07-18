using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FBXExporter.Entity
{
    class ElementDataNode : TreeNode
    {
        public ElementDataNode() : base() { }
        public ElementDataNode(string text) : base(text) { }
        public ElementDataNode(string text, string id) : base(text)
        {
            Id = id;
        }

        public string Id;
    }
}
