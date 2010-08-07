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
            string commonParent = getCommonParent(pathsToParse);
            pathsToParse = filterNotCommonParent(commonParent,pathsToParse);

            CommandLists commands = new CommandLists();
            string[] pathSplitElements = commonParent.Split('/');
            
            foreach(string pathPart in pathSplitElements.Where( x=> x.IsNotEmptyOrNull()))
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

        private string[] filterNotCommonParent(string commonParent,string[] pathsToParse)
        {
            for (int i = 0; i < pathsToParse.Length; i++)
            {
                pathsToParse[i] = pathsToParse[i].Substring(0, commonParent.Length);
            }

            return pathsToParse;
        }

        private string getCommonParent(string[] restPathToParse)
        {
            string range = "";
            string basePath = restPathToParse.First();
            foreach (var nextElement in basePath.Split('/').Where(x => x.IsNotEmptyOrNull()))
            {
                if (!checkCommonParent(range + "/" + nextElement,restPathToParse))
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

        //TODO Change method to current situation
        private IItemSelect getItemCommand(string pathPart)
        {
            string attributePart = getAttributes(pathPart);

            if (pathPart.EndsWith(PathCounter.LastElementSymbol))
                return new ElementSelector(pathPart.DeleteLastCharacter());
            if (attributePart == null)
                return null;
            string[] attributes = removeBrackets(attributePart).Split(';');
            foreach (var attribute in attributes)
            {
                if(containsValue(attribute))
                {
                    string[] attributeValue = attribute.Split('=');
                    return new AttributeValueSelector(attributeValue[0], attributeValue[1]);
                }
                else
                {
                    return new AttributeSelector(attribute);
                }
                
            }
            return null;
        }

        private bool containsValue(string attribute)
        {
            return attribute.Contains("=");
        }

        private string removeBrackets(string attributePart)
        {
            attributePart = attributePart.Replace("[", "");
            attributePart = attributePart.Replace("]", "");
            return attributePart;
        }

        private string getAttributes(string pathPart)
        {
            int whereAttributesStarts = pathPart.IndexOf('[');
            bool isPartHaveAttributes = whereAttributesStarts != -1;

            if (isPartHaveAttributes)
            {
                return pathPart.Substring(whereAttributesStarts, pathPart.Length - whereAttributesStarts);
            }
            else
            {
                return null;
            }
        }

        private IElementGroupSelect getGroupCommand(string pathPart)
        {
            string groupCommand = deleteAttributes(pathPart);
            if (groupCommand.EndsWith(PathCounter.LastElementSymbol))
                groupCommand = groupCommand.DeleteLastCharacter();
            return new ElementsGroupSelector(groupCommand);
            
        }

        private string deleteAttributes(string pathPart)
        {
            int whereAttributesStarts = pathPart.IndexOf('[');
            bool isPartHaveAttributes = whereAttributesStarts != -1;

            if (isPartHaveAttributes)
            {
                return pathPart.Substring(0,whereAttributesStarts);
            }
            
            return pathPart;
        }
        
    }
}
