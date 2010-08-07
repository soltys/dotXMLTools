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

        public XElement SelectItem(XElement item)
        {
            return null;
        }

        public string Value
        {
            get { return attribute; }
        }
    }
}
