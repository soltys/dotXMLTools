using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XML2List.Interface;

namespace XML2List
{
    public class ElementSelector:IItemSelect
    {
        private string _elementName;

        public ElementSelector(string elementName)
        {
            this._elementName = elementName;
        }

        public XElement SelectItem(XElement item)
        {
            return null;
        }

        public string Value
        {
            get { return _elementName; }
        }
    }
}
