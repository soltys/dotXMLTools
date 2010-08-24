using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyExtensions;
[assembly: CLSCompliant(true)]
namespace PathLibrary
{
    public static class PathTools
    {
        private static string RemoveBrackets(string attributePart)
        {
            attributePart = attributePart.Replace("[", "");
            attributePart = attributePart.Replace("]", "");
            return attributePart;
        }

        public static string GetAttributes(string pathPart)
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

        public static PathAttributeValueGroup[] GetAttributeValue(string attributePart)
        {
            attributePart = PathTools.RemoveBrackets(attributePart);
            List<PathAttributeValueGroup> list = new List<PathAttributeValueGroup>();
            foreach (var attrVal in attributePart.Split(';').Where(x => x.IsNotEmptyOrNull()))
            {
                string[] splitted = attrVal.Split('=');
                if (splitted.Length == 2)
                {
                    PathAttributeValueGroup pavg = new PathAttributeValueGroup();
                    pavg.Attribute = splitted[0];
                    pavg.Value = splitted[1];
                    list.Add(pavg);
                }
            }
            return list.ToArray();
        }

        public static string RemoveAttributes(string pathPart)
        {
            int whereAttributesStarts = pathPart.IndexOf('[');
            bool isPartHaveAttributes = whereAttributesStarts != -1;

            if (isPartHaveAttributes)
            {
                return pathPart.Substring(0, whereAttributesStarts);
            }

            return pathPart;
        }

        public static string[] FilterNotCommonParent(string commonParent, string[] pathsToParse)
        {
            for (int i = 0; i < pathsToParse.Length; i++)
            {
                pathsToParse[i] = pathsToParse[i].Substring(commonParent.Length + 1); //add 1 for deleting '/'
            }

            return pathsToParse;
        }

        public static string GetCommonParent(string[] restPathToParse)
        {
            string range = "";
            string basePath = restPathToParse[0];
            foreach (var nextElement in basePath.Split('/').Where(x => x.IsNotEmptyOrNull()))
            {
                if (!CheckCommonParent(range + "/" + nextElement, restPathToParse))
                    break;
                range = range + "/" + nextElement;
            }
            return range;
        }

        public static bool CheckCommonParent(string commonParrent, string[] restPathToParse)
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