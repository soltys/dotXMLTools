using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyExtensions;
using XML2List.Interface;

namespace XML2List
{
    /// <summary>
    /// Changes paths collected by PathFinder into commands for selecting items
    /// </summary>
    public class PathParser
    {
        public CommandLists ParsePaths(string[] pathsToParse)
        {
            if (pathsToParse.Length == 0)
                throw new ArgumentException("Array is empty");

            CommandLists commands = new CommandLists();
            if (pathsToParse.Length == 1)
            {
                commands = parseOnePath(pathsToParse);
            }
            else
            {
                commands = parseManyPaths(pathsToParse);
            }

            return commands;
        }

        private CommandLists parseOnePath(string[] pathsToParse)
        {
            CommandLists commands = new CommandLists();

            string commonParent = pathsToParse[0];
            commonParent = commonParent.Substring(0, commonParent.LastIndexOf('/')); //this deleting last groupCommand

            pathsToParse[0] = pathsToParse[0].Split('/').Last();

            commands = createCommands(pathsToParse, commonParent);

            return commands;
        }

        private CommandLists parseManyPaths(string[] pathsToParse)
        {
            CommandLists commands = new CommandLists();
            string commonParent = PathTools.getCommonParent(pathsToParse);
            pathsToParse = PathTools.filterNotCommonParent(commonParent, pathsToParse);

            commands = createCommands(pathsToParse, commonParent);
            return commands;
        }


        private CommandLists createCommands(string[] pathsToParse, string commonParent)
        {
            CommandLists commands = new CommandLists();
            string[] pathSplitElements = commonParent.Split('/');

            foreach (string pathPart in pathSplitElements.Where(x => x.IsNotEmptyOrNull()))
            {
                IElementGroupSelect groupCommand = getGroupCommand(pathPart);
                if (groupCommand.IsNotNull())
                    commands.GroupSelectCommands.Add(groupCommand);
            }

            foreach (var pathPart in pathsToParse)
            {
                IItemSelect itemCommand = getItemCommand(pathPart);
                if (itemCommand.IsNotNull())
                    commands.ItemSelectCommands.Add(itemCommand);
            }

            return commands;
        }

        //TODO Add Attribute commmands creation
        private IItemSelect getItemCommand(string pathPart)
        {
            return new ElementSelector(pathPart);
        }

        private IElementGroupSelect getGroupCommand(string pathPart)
        {
            string groupCommand = PathTools.removeAttributes(pathPart);
            return new ElementsGroupSelector(groupCommand);
        }
    }
}