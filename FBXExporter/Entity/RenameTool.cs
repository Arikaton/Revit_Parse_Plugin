using System.Collections.Generic;

namespace FBXExporter.Entity
{
    public class RenameTool
    {
        private List<ElementData> _elements;

        public string BaseName { get; set; }
        public string Suffix { get; set; }
        public string Prefix { get; set; }
        public uint StartNumber { get; set; }

        public RenameTool(List<ElementData> elements)
        {
            _elements = elements;
        }

        public List<ElementData> Rename(bool useBaseName, bool useSuffix, bool usePrefix, bool useNumbers)
        {
            var counter = StartNumber;

            foreach (var element in _elements)
            {
                if(useBaseName && !string.IsNullOrWhiteSpace(BaseName))
                {
                    element.Name = BaseName;
                }
                if(usePrefix && !string.IsNullOrWhiteSpace(Prefix))
                {
                    element.Name = Prefix + "_" + element.Name;
                }
                if (useSuffix && !string.IsNullOrWhiteSpace(Suffix))
                {
                    element.Name = element.Name + "_" + Suffix;
                }
                if(useNumbers)
                {
                    element.Name += "_" + counter.ToString();
                }
                counter++;
            }
            return _elements;
        }
    }
}
