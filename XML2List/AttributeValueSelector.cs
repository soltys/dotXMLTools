﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XML2List
{
    class AttributeValueSelector: IListSelect
    {
        public IEnumerable<XElement> SelectItems(IEnumerable<IEnumerable<XElement>> listofXElements)
        {
            throw new NotImplementedException();
        }
    }
}
