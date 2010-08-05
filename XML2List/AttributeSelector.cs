using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XML2List.Interface;

namespace XML2List
{
    class AttributeSelector : IItemSelect{
        private string attribute;
        public AttributeSelector(string attribute)
        {
            this.attribute = attribute;
        }

        public bool SelectItem(XElement item)
        {
            return item.Attribute(attribute) != null;
        }

        public string Value
        {
            get { return attribute; }
        }
    }
}
