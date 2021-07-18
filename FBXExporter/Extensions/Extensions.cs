using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBXExporter.Extensions
{
    public static class Extensions
    {
        public static IEnumerable<T> GetRecursively<T>(this IEnumerable collection,
            Func<T, IEnumerable> selector)
        {
            foreach (var item in collection.OfType<T>())
            {
                yield return item;

                IEnumerable<T> children = selector(item).GetRecursively(selector);
                foreach (var child in children)
                {
                    yield return child;
                }
            }
        }
    }
}
