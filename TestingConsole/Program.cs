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
            XElement root = XElement.Load(@"c:\pawel\xmlText\ulice.xml");
            PathCollector pc = new PathCollector(root);

            foreach (var i in pc.PathCounter)
            {
                Console.WriteLine(i.Key + "  =  " + i.Value);
            }
        }
    }
}
