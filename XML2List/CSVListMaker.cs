using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using PathLibrary;
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

        public void MakeList(TextWriter streamOut, string[] selectedPaths)
        {
            PathListParser pathListParser = new PathListParser();
            CommandLists cl = pathListParser.ParsePaths(selectedPaths);

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

            foreach (var xElement in a)
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