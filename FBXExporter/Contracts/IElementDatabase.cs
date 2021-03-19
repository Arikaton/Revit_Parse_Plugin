using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBXExporter.Contracts
{
    interface IElementDatabase
    {
        ElementData GetElementById(string id);

        void AddElement(string id, ElementData elementData);

        void Save(string path);
    }
}
