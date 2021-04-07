using FBXExporter.Contracts;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace FBXExporter.Entity
{
    public class JsonDb
    {
        public readonly Dictionary<string, ElementData> Elements;
        public Dictionary<string, string> Dictionary;

        public JsonDb(Dictionary<string, ElementData> elements, Dictionary<string, string> dictionary)
        {
            Elements = elements;
            Dictionary = dictionary;
        }

        public void AddElement(string id, ElementData elementData)
        {
            if (Elements.ContainsKey(id))
                Elements[id] = elementData;
            else
                Elements.Add(id, elementData);
        }

        public ElementData GetElementById(string id)
        {
            if (Elements.ContainsKey(id))
                return Elements[id];
            return null;
        }
    }
}
