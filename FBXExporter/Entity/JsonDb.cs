using System.Collections.Generic;
using System.Linq;
using FBXExporter.Extensions;

namespace FBXExporter.Entity
{
    [System.Serializable]
    public class JsonDb
    {
        public Dictionary<string, string> Dictionary = new Dictionary<string, string>();
        public List<ElementData> ElementsList = new List<ElementData>();

        public void AddNewElement(ElementData elementData)
        {
            ElementsList.Add(elementData);
        }

        public bool ContainsId(string id)
        {
            foreach (var element in ElementsList.GetRecursively<ElementData>(x => x.Elements))
            {
                if (element.Id == id)
                    return true;
            }
            return false;
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

        public ElementData FindElement(string id)
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
