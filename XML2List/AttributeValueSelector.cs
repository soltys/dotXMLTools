using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
namespace XML2List
{
    class AttributeValueSelector: IListSelect
    {
        IEnumerable<XElement> IListSelect.SelectItems(IEnumerable<XElement> listofXElements)
        {
            throw new NotImplementedException();
        }
    }
}
