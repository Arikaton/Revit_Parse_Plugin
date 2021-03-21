namespace FBXExporter.Entity
{
    [Newtonsoft.Json.JsonObject]
    public class ElementData
    {
        public string Id;
        public string Name;
        public string ElementName;
        public string ParentName;

        [Newtonsoft.Json.JsonConstructor]
        public ElementData(string id, string name, string elementName, string parentName)
        {
            Id = id;
            Name = name;
            ElementName = elementName;
            ParentName = parentName;
        }

        public ElementData(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"Id: {Id} | Name | {Name} | Element Name: {ElementName} | Parent Name | {ParentName}";
        }
    }
}
