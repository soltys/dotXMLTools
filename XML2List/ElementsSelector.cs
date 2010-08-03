using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XML2List
{
    class ElementsSelector : IListSelect
    {
        private string childrenNames;

        public ElementsSelector(string childrenNames)
        {
            this.childrenNames = childrenNames;
        }
        public IEnumerable<XElement> SelectItems(IEnumerable<XElement> listofXElements)
        {
            return listofXElements.Elements(childrenNames);
        }
    }
}
