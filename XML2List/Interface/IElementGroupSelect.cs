using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
namespace XML2List
{
    public interface IElementGroupSelect
    {
        IEnumerable<XElement> SelectItems(IEnumerable<XElement> listofXElements);
        string Value { get; }
    }
}
