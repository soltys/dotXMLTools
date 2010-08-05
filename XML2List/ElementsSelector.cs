using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XML2List.Interface;

namespace XML2List
{
    class ElementsSelector:IItemSelect
    {
        public bool SelectItem(XElement item)
        {
            throw new NotImplementedException();
        }

        public string Value
        {
            get { throw new NotImplementedException(); }
        }
    }
}
