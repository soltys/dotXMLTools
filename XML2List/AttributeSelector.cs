using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XML2List.Interface;

namespace XML2List
{
    class AttributeSelector : IElementGroupSelect
    {
        public IEnumerable<XElement> SelectItems(IEnumerable<XElement> listofXElements)
        {
            throw new NotImplementedException();
        }

        public string Value
        {
            get { throw new NotImplementedException(); }
        }
    }
}
