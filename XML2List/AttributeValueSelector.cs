using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
namespace XML2List
{
    class AttributeValueSelector: IListSelect
    {
        List<List<XElement>> IListSelect.SelectItems(List<List<XElement>> listofXElements)
        {
            throw new NotImplementedException();
        }
    }
}
