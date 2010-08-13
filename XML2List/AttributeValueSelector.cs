using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XML2List.Interface;

namespace XML2List
{
    public class AttributeValueSelector: IItemSelect
    {
        private string attribute;
        private string value;

        public AttributeValueSelector(string attr, string value)
        {
            attribute = attr;
            this.value = value;
        }

        public XElement SelectItem(XElement item)
        {
            if (item.Attribute(attribute) != null && item.Attribute(attribute).Value == value)
            {
                return item;
            }
            return null;
        }

        public string Name
        {
            get { return attribute + "=" + value; }
        }
    }
}
