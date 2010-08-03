using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using MyExtensions;
namespace XML2List
{
    public class PathFinder
    {
        private XElement root = null;
        private PathCounter pathCounter;

        public PathCounter PathCounter
        {
            get { return pathCounter; }
        }

        public PathFinder(XElement root)
        {
            this.root = root;
            pathCounter = new PathCounter();
            FindByRecursion(this.root,"/" + this.root.Name);
        }

        private void FindByRecursion(XElement element, string xmlPath)
        {
            var q = element.Elements();
            if (q.Count() == 0)
                return;

            foreach (var xElement in q)
            {
                string newXmlPath = xmlPath + "/" + xElement.Name;
                string attribute = "[";
                string attributeValue = "[";
                foreach (var xAttribute in xElement.Attributes())
                {
                    attribute = attribute + xAttribute.Name + ";";
                    attributeValue = attributeValue + xAttribute.Name + "=" + xAttribute.Value + ";";
                }
                attribute = attribute.DeleteLastCharacter() + "]";          // Clean up for
                attributeValue = attributeValue.DeleteLastCharacter() + "]";// last semi-collon

                pathCounter.Add(xmlPath);

                if (attribute != "]")
                {
                    pathCounter.Add(newXmlPath + attribute);
                }
                if (attributeValue != "]")
                {
                    pathCounter.Add(newXmlPath + attributeValue);
                }

                FindByRecursion(xElement, newXmlPath);
            }
        }
    }
}
