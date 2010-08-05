using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XML2List.Interface;
namespace XML2List
{
    class CommandLists
    {
        public List<IElementGroupSelect> GroupSelectCommands { get; set; }

        public List<IItemSelect> ItemSelectCommands { get; set; }
    }
}
