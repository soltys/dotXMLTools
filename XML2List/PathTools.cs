using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
