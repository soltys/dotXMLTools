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
        private string attribute;
        private string value;
        private string elementPath;
        public ElementAttributeValueSelector(string elemPath,string attr,string val)
        {
            attribute = attr;
            value = val;
            elementPath = removeAttributes(elemPath);
        }
        public XElement SelectItem(XElement item)
        {
            //TODO change this in something more pretty
            string[] elementsPaths = elementPath.Split('/').Where(x => x.IsNotEmptyOrNull()).ToArray();
            IEnumerable<XElement> collection = item.Elements(elementsPaths[0]);


            for (int index = 1; index < elementsPaths.Length; index++)
            {
                collection = collection.Elements(elementsPaths[index]);
            }

            try
            {
                XElement returnElement = collection.First();
                if (returnElement.Attribute(attribute) != null && returnElement.Attribute(attribute).Value == value)
                {
                    return returnElement;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        private string removeAttributes(string pathPart)
        {
            int whereAttributesStarts = pathPart.IndexOf('[');
            bool isPartHaveAttributes = whereAttributesStarts != -1;

            if (isPartHaveAttributes)
            {
                return pathPart.Substring(0, whereAttributesStarts);
            }

            return pathPart;
        }
        public string Value
        {
            get { return string.Format("{0} {1} {2}", elementPath, attribute, value); }
        }
    }
}
