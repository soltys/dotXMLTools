using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using MyExtensions;
namespace XML2List
{
    public class PathCollector
    {
        private XElement root = null;
        private PathCounter pathCounter;

        public PathCounter PathCounter
        {
            get { return pathCounter; }
        }

        public PathCollector(XElement root)
        {
            this.root = root;
            pathCounter = new PathCounter();
            CollectByRecursion(this.root,"/" + this.root.Name);
        }

        private void CollectByRecursion(XElement element, string xmlPath)
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

                CollectByRecursion(xElement, newXmlPath);
            }
        }
    }
}
