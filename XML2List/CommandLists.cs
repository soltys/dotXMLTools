using System.Collections.Generic;
using XML2List;

namespace XML2List
{
    public class CommandLists
    {
        public CommandLists()
        {
            GroupSelectCommands  = new List<IElementGroupSelect>();
            ItemSelectCommands = new List<IItemSelect>();
        }
        public List<IElementGroupSelect> GroupSelectCommands { get; set; }

        public ICollection<IItemSelect> ItemSelectCommands { get; set; }
    }
}
