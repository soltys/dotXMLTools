﻿using System;
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

                if (groupCommand.IsNotNull())
                    commands.GroupSelectCommands.Add(groupCommand);

                if (itemCommand.IsNotNull())
                    commands.ItemSelectCommands.Add(itemCommand);
            }

            return commands;
        }

        private IItemSelect getItemCommand(string pathPart)
        {
            string attributePart = getAttributes(pathPart);
            return null;
        }

        private string getAttributes(string pathPart)
        {
            int whereAttributesStarts = pathPart.IndexOf('[');
            bool isPartHaveAttributes = whereAttributesStarts == -1;

            if (isPartHaveAttributes)
            {
                return pathPart.Substring(whereAttributesStarts, pathPart.Length);
            }
            else
            {
                return null;
            }
        }

        private IElementGroupSelect getGroupCommand(string pathPart)
        {
            string groupCommand = deleteAttributes(pathPart);
            return new ElementsGroupSelector(groupCommand);
        }

        private string deleteAttributes(string pathPart)
        {
            int whereAttributesStarts = pathPart.IndexOf('[');
            bool isPartHaveAttributes = whereAttributesStarts == -1;

            if (isPartHaveAttributes)
            {
                return pathPart.Substring(0,whereAttributesStarts);
            }
            else
            {
                return pathPart;
            }
        }
    }
}
