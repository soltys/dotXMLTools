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
            
        }
    }
}
