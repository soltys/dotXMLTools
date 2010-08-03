using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
namespace XML2List
{
    public interface IListSelect
    {
        IEnumerable<XElement> SelectItems(IEnumerable<XElement> listofXElements);
        string Name { get; }
    }
}
