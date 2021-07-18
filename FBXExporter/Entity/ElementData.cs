using System.Collections.Generic;

namespace FBXExporter.Entity
{
    [Newtonsoft.Json.JsonObject]
    public class ElementData
    {
        public string Id;
        public string RevitName;
        public string Name;
        public string ParentName;
        public string GroupName;
        public List<ElementData> Elements = new List<ElementData>();

        [Newtonsoft.Json.JsonConstructor]
        public ElementData(string id, string revitName, string name, string parentName, string groupName = null)
        {
            Id = id;
            RevitName = revitName;
            Name = name;
            ParentName = parentName;
            GroupName = groupName;
        }

        public ElementData(string id, string revitName)
        {
            Id = id;
            RevitName = revitName;
        }

        public override string ToString()
        {
            return $"Id: {Id} | Name | {RevitName} | Element Name: {Name} | Parent Name | {ParentName}";
        }
    }
}
