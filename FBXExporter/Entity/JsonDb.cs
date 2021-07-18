using System;
using System.Collections;
using System.Collections.Generic;
using FBXExporter.Extensions;

namespace FBXExporter.Entity
{
    public class JsonDb
    {
        public readonly Dictionary<string, ElementData> Elements;
        public Dictionary<string, string> Dictionary;
        public List<ElementData> ElementsList = new List<ElementData>();

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

        public void Move(string sourceId, string targetId)
        {
            var sourceElement = FindElement(sourceId);
            var targetElement = FindElement(targetId);
            RemoveFromList(sourceElement);
            targetElement.Elements.Add(sourceElement);
            sourceElement.ParentName = targetElement.Id;
        }

        public void MoveToRoot(string id)
        {
            var sourceElement = FindElement(id);
            RemoveFromList(sourceElement);
            ElementsList.Add(sourceElement);
            sourceElement.ParentName = null;
        }

        private void RemoveFromList(ElementData element)
        {
            var parent = FindParent(element.Id);
            if (parent != null)
            {
                parent.Elements.Remove(element);
            }
            else
            {
                ElementsList.Remove(element);
            }
        }

        private ElementData FindElement(string id)
        {
            return ElementsList.GetRecursively<ElementData>(x => x.Elements).Where(x => x.Id == id).First();
        }

        private ElementData FindParent(string id)
        {
            foreach (var elementData in ElementsList.GetRecursively<ElementData>(x => x.Elements))
            {
                foreach (var element in elementData.Elements)
                {
                    if (element.Id == id)
                        return elementData;
                }
            }
            return null;
        }
    }
}
