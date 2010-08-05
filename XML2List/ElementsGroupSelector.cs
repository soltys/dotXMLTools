using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XML2List
{
    public class ElementsGroupSelector : IElementGroupSelect
    {
        private readonly string _childrenValues;
        public string Value
        {
            get { return _childrenValues; }
        }
        public ElementsGroupSelector(string _childrenValues)
        {
            this._childrenValues = _childrenValues;
        }
        public IEnumerable<XElement> SelectItems(IEnumerable<XElement> listofXElements)
        {
            return listofXElements.Elements(_childrenValues);
        }
    }
}
