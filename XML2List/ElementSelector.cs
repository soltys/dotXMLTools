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

        public bool SelectItem(XElement item)
        {
            return item.Name == _elementName;
        }

        public string Value
        {
            get { return _elementName; }
        }
    }
}
