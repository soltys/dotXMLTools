using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using XML2List.Interface;
namespace XML2List
{
    public class CSVListMaker : IListMaking
    {
        private XDocument xDocument;
        public CSVListMaker(XDocument xDoc)
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
                streamOut.Write(itemCommand.Name + ";");
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