using FBXExporter.Contracts;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace FBXExporter
{
    class JsonDb : IElementDatabase
    {
        Dictionary<string, ElementData> elementDatas = new Dictionary<string, ElementData>();

        public void AddElement(string id, ElementData elementData)
        {
            if (elementDatas.ContainsKey(id))
                elementDatas[id] = elementData;
            else
                elementDatas.Add(id, elementData);
        }

        public ElementData GetElementById(string id)
        {
            if (elementDatas.ContainsKey(id))
                return elementDatas[id];
            return null;
        }

        public void Save(string path)
        {
            using (var sw = new StreamWriter(path))
            {
                var serializedData = JsonConvert.SerializeObject(elementDatas);
                sw.Write(serializedData);
            }
        }

        public void Load(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
                return;
            }
            var json = File.ReadAllText(path);
            elementDatas = JsonConvert.DeserializeObject<Dictionary<string, ElementData>>(json);
            if (elementDatas is null)
                elementDatas = new Dictionary<string, ElementData>();
        }
    }
}
