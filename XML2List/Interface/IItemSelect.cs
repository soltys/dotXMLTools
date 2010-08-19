using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PathLibrary.Interface
{
    public interface IItemSelect
    {
        XElement SelectItem(XElement item);

        string Name { get; }
    }
}
