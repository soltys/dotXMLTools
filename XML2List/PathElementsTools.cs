using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using MyExtensions;

namespace XML2List
{
    /// <summary>
    /// Collections of static methods which combines Path and Elements in doument tree
    /// </summary>
    static class  PathElementsTools
    {
        public static IEnumerable<XElement> GetCollectionUsingPath(XElement item,string path)
        {
            string[] elementsPaths = path.Split('/').Where(x => x.IsNotEmptyOrNull()).ToArray();
            IEnumerable<XElement> collection = item.Elements(elementsPaths[0]);


            for (int index = 1; index < elementsPaths.Length; index++)
            {
                collection = collection.Elements(elementsPaths[index]);
            }
            return collection;
        }
    }
}
