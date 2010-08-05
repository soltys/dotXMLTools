using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XML2List
{
    class ElementsSelector:IListSelect
    {
        public IEnumerable<XElement> SelectItems(IEnumerable<XElement> listofXElements)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
        }
    }
}
