using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XML2List.Interface
{
    interface IListMaking
    {
        void MakeList(TextWriter streamOut, string[] selectedPaths);
    }
}
