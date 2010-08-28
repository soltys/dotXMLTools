using System.Collections.Generic;
using System.Xml.Linq;
using XML2List;

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
