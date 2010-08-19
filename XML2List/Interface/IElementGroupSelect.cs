using System.Collections.Generic;
using System.Xml.Linq;

namespace XML2List.Interface
{
    public interface IElementGroupSelect
    {
        IEnumerable<XElement> SelectItems(IEnumerable<XElement> listofXElements);
        string Value { get; }
    }
}
