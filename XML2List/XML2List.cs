using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
namespace XML2List
{
    public class XML2List
    {
        private XDocument xDocument;
        public XML2List(XDocument xDoc)
        {
            xDocument = xDoc;
        }

        public void MakeList(TextWriter streamOut,string[] selectedPaths)
        {
            PathParser pathParser = new PathParser();
            CommandLists cl = pathParser.ParsePaths(selectedPaths);

            IEnumerable<XElement> a = xDocument.Elements();
            for (int index = 1; index < cl.GroupSelectCommands.Count; index++)
            {
                var elementsSelector = cl.GroupSelectCommands[index];
                a = elementsSelector.SelectItems(a);
            }

            foreach (var itemCommand in cl.ItemSelectCommands)
            {
                streamOut.Write(itemCommand.Value + ";");
            }
            streamOut.WriteLine();

            foreach (var xElement in a.Take(10))
            {

                foreach (var itemCommand in cl.ItemSelectCommands)
                {
                    XElement xe = itemCommand.SelectItem(xElement);
                    if (xe != null)
                    {
                        streamOut.Write(xe.Value + ";");
                    }
                    else
                    {
                        streamOut.Write(";");
                    }

                }
                streamOut.WriteLine();
            }
        }
    }
}