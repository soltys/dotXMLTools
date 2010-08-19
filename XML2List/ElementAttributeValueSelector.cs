using System;
using System.Collections.Generic;
using System.Xml.Linq;
using PathLibrary;
using PathLibrary.Interface;

namespace XML2List
{
    public class ElementAttributeValueSelector:IItemSelect
    {
        private PathAttributeValueGroup[] pavgArray;
        private string elementPath;
        public ElementAttributeValueSelector(string elemPath,PathAttributeValueGroup[] listPAVG)
        {
            elementPath = PathTools.RemoveAttributes(elemPath);
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
            get
            {
                string AttributePart = "[";
                foreach (var pavg in pavgArray)
                {
                    AttributePart = AttributePart + pavg.ToString();
                }
                AttributePart = AttributePart + "]";
                return string.Format("{0}{1}", elementPath, AttributePart);
            }
        }
    }
}
