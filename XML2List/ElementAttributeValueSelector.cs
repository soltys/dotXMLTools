using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using MyExtensions;
using XML2List.Interface;
namespace XML2List
{
    class ElementAttributeValueSelector:IItemSelect
    {
        private PathAttributeValueGroup[] pavgArray;
        private string elementPath;
        public ElementAttributeValueSelector(string elemPath,PathAttributeValueGroup[] listPAVG)
        {
            elementPath = PathTools.removeAttributes(elemPath);
            pavgArray = listPAVG;
        }
        public XElement SelectItem(XElement item)
        {
            IEnumerable<XElement> collection = PathElementsTools.GetCollectionUsingPath(item, elementPath);

            try
            {
                foreach (var element in collection)
                    foreach (var pavg in pavgArray)
                    {
                        if (element.Attribute(pavg.Attribute) != null && element.Attribute(pavg.Attribute).Value == pavg.Value)
                        {
                            return element;
                        }
                    }

                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }
       
        public string Name
        {
            get { return string.Format("{0} {1}", elementPath, pavgArray.ToString()); }
        }
    }
}
