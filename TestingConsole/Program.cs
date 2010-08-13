using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XML2List;
using XML2List.Interface;

namespace TestingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument root = XDocument.Load(@"d:\pawel\xmlText\ulice.xml");
            PathFinder pc = new PathFinder(root.Root);

            foreach (var s in pc.PathCounter)
            {
                Console.WriteLine(s.Key + " " + s.Value);
            }

            string lineToParse = "/teryt/catalog/row/col[name=WOZ]";
            PathParser pp = new PathParser();
            CommandLists cl = pp.ParsePath(lineToParse);


            foreach (var command in cl.GroupSelectCommands)
            {
                Console.WriteLine(command.Value);
                Console.WriteLine(command.ToString());
                Console.WriteLine("----");
            }

            foreach (var command in cl.ItemSelectCommands)
            {
                Console.WriteLine(command.Value);
                Console.WriteLine(command.ToString());
                Console.WriteLine("----");
            }

            Console.WriteLine("Hurray!");
            Console.ReadKey();

            /*

            IEnumerable<XElement> a = root.Elements();

            for (int index = 1; index < l.Count; index++)
            {
                var elementsSelector = l[index];
                Console.WriteLine("using a " + elementsSelector.Value);
                a = elementsSelector.SelectItems(a);
            }


            foreach (var xElement in a)
            {
                foreach (var element in xElement.Elements("col")) 
                    //spianie w jedno naprzykład w postać XML'A
                {
                    Console.WriteLine(element.Name + " " + element.Value);    
                }
                
                Console.WriteLine("---");
            }
            */
        }
    }
}
