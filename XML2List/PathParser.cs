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

            pathsToParse[0] = pathsToParse[0].Split('/').Last();
            string commonParent = pathsToParse[0];

            commands = createCommands(pathsToParse, commonParent);

            return commands;
        }

        private CommandLists parseManyPaths(string[] pathsToParse)
        {
            CommandLists commands = new CommandLists();
            string commonParent = getCommonParent(pathsToParse);
            pathsToParse = filterNotCommonParent(commonParent, pathsToParse);

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

        private string[] filterNotCommonParent(string commonParent, string[] pathsToParse)
        {
            for (int i = 0; i < pathsToParse.Length; i++)
            {
                pathsToParse[i] = pathsToParse[i].Substring(commonParent.Length + 1); //add 1 for deleting '/'
            }

            return pathsToParse;
        }

        private string getCommonParent(string[] restPathToParse)
        {
            string range = "";
            string basePath = restPathToParse[0];
            foreach (var nextElement in basePath.Split('/').Where(x => x.IsNotEmptyOrNull()))
            {
                if (!checkCommonParent(range + "/" + nextElement, restPathToParse))
                    break;
                range = range + "/" + nextElement;
            }
            return range;
        }

        private bool checkCommonParent(string commonParrent, string[] restPathToParse)
        {
            bool isCommonParrent = true;
            foreach (var path in restPathToParse)
            {
                isCommonParrent = path.StartsWith(commonParrent);
                if (!isCommonParrent)
                    break;
            }
            return isCommonParrent;
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