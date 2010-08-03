using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XML2List;
namespace TestingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument root = XDocument.Load(@"c:\pawel\xmlText\ulice.xml");
            PathFinder pc = new PathFinder(root.Root);

            foreach (var s in pc.PathCounter)
            {
                Console.WriteLine(s.Key + " " + s.Value);
            }
            var l = new  List<IListSelect>();
            l.Add(new ElementsSelector("teryt"));
            l.Add(new ElementsSelector("catalog"));
            l.Add(new ElementsSelector("row"));
            l.Add(new ElementsSelector("col"));
            l.Add(new AttributeValueSelector("name","NAZWA_1"));

            IEnumerable<XElement> a = root.Elements();

            for (int index = 1; index < l.Count; index++)
            {
                var elementsSelector = l[index];
                Console.WriteLine("using a " + elementsSelector.Name);
                a = elementsSelector.SelectItems(a);
            }


            foreach (var xElement in a)
            {
                Console.WriteLine(xElement.Value);
            }
        }
    }
}
