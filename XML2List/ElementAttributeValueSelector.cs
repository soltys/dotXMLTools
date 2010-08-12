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
        private string[] attribute;
        private string[] value;
        private string elementPath;
        public ElementAttributeValueSelector(string elemPath,string[] attr,string[] val)
        {
            attribute = attr;
            value = val;
            elementPath = PathTools.removeAttributes(elemPath);
        }
        public XElement SelectItem(XElement item)
        {
            IEnumerable<XElement> collection = PathElementsTools.GetCollectionUsingPath(item, elementPath);

            try
            {
                XElement returnElement = collection.First();
               return returnElement;
            }
            catch (Exception)
            {

                return null;
            }
        }
       
        public string Value
        {
            get { return string.Format("{0} {1} {2}", elementPath, attribute, value); }
        }
    }
}
