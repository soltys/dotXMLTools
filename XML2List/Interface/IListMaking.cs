using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XML2List.Interface
{
    public interface IListMaking
    {
        void MakeList(TextWriter streamOut, string[] selectedPaths);
    }
}
