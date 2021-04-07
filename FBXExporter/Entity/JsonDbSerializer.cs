using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace FBXExporter.Entity
{
    public static class JsonDbSerializer
    {
        public static void Serialize(JsonDb jsonDb, string path)
        {
            if (jsonDb is null)
                return;
            if (string.IsNullOrEmpty(path))
                return;
            var json = JsonConvert.SerializeObject(jsonDb);
            File.WriteAllText(path, json);
        }

        public static JsonDb Deserialize(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
                return new JsonDb(new Dictionary<string, ElementData>(), new Dictionary<string, string>());
            }
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<JsonDb>(json);
        }
    }
}
