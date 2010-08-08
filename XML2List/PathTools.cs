using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyExtensions;

namespace XML2List
{
    static class PathTools
    {

        public static string removeBrackets(string attributePart)
        {
            attributePart = attributePart.Replace("[", "");
            attributePart = attributePart.Replace("]", "");
            return attributePart;
        }

        public static string getAttributes(string pathPart)
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

        public static bool containsValue(string attribute)
        {
            return attribute.Contains("=");
        }

        public static string removeAttributes(string pathPart)
        {
            int whereAttributesStarts = pathPart.IndexOf('[');
            bool isPartHaveAttributes = whereAttributesStarts != -1;

            if (isPartHaveAttributes)
            {
                return pathPart.Substring(0, whereAttributesStarts);
            }

            return pathPart;
        }

        public static string[] filterNotCommonParent(string commonParent, string[] pathsToParse)
        {
            for (int i = 0; i < pathsToParse.Length; i++)
            {
                pathsToParse[i] = pathsToParse[i].Substring(commonParent.Length + 1); //add 1 for deleting '/'
            }

            return pathsToParse;
        }

        public static string getCommonParent(string[] restPathToParse)
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

        public static bool checkCommonParent(string commonParrent, string[] restPathToParse)
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
    }
}
