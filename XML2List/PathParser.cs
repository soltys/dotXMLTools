using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyExtensions;
using XML2List.Interface;
namespace XML2List
{
    class PathParser
    {
        public CommandLists ParsePath(string pathToParse)
        {
            string[] pathSplitElements = pathToParse.Split('/');
            CommandLists commands = new CommandLists();

            foreach(string pathPart in pathSplitElements.Where( x=> x.IsNotEmptyOrNull()))
            {
                IElementGroupSelect groupCommand = getGroupCommand(pathPart);
                IItemSelect itemCommand = getItemCommand(pathPart);

                commands.GroupSelectCommands.Add(groupCommand);
                commands.ItemSelectCommands.Add(itemCommand);
            }

            return commands;
        }

        private IItemSelect getItemCommand(string pathPart)
        {
            return null;
        }

        private IElementGroupSelect getGroupCommand(string pathPart)
        {
            
            return null;
        }
    }
}
