using System;
using System.Linq;
using MyExtensions;
using PathLibrary;
using XML2List;

namespace XML2List
{
    /// <summary>
    /// Changes paths collected by PathCollection into commands for selecting items
    /// </summary>
    public class PathListParser
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
            string commonParent = PathTools.GetCommonParent(pathsToParse);
            pathsToParse = PathTools.FilterNotCommonParent(commonParent, pathsToParse);

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

        
        private IItemSelect getItemCommand(string pathPart)
        {
            string attiributes = PathTools.GetAttributes(pathPart);
            if(attiributes == null)
                return new ElementSelector(pathPart);

            PathAttributeValueGroup[] pavg = PathTools.GetAttributeValue(attiributes);

            return new ElementAttributeValueSelector(
                PathTools.RemoveAttributes(pathPart),
                pavg);
        }

        private IElementGroupSelect getGroupCommand(string pathPart)
        {
            string groupCommand = PathTools.RemoveAttributes(pathPart);
            return new ElementsGroupSelector(groupCommand);
        }
    }
}