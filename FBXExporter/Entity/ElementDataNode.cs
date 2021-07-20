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
        public ElementDataNode(string text, string id, string name) : base(text)
        {
            Id = id;
            ElementName = name;
        }

        public string Id;
        public string ElementName;

        public ElementDataNode CloneNode()
        {
            var clone = (ElementDataNode)Clone();
            clone.Id = Id;
            clone.ElementName = ElementName;
            return clone;
        }
    }
}
