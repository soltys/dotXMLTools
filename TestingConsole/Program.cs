using System;
using System.Collections.Generic;
using System.Diagnostics;
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
#if true
            XDocument root = XDocument.Load(@"d:\pawel\xmlText\baza.xml");
            PathFinder pc = new PathFinder(root.Root);
            Dictionary<string,int> selection = new Dictionary<string, int>();

            foreach (var s in pc.PathCounter)
            {
                selection.Add(s.Key,0);
            }
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            int position = 0;
            
            do
            {
                
                Console.Clear();
                PrintOutView(pc, selection);
                Console.CursorLeft = 1;
                Console.CursorTop = position;
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        selection[pc.PathCounter.Take(position + 1).Last().Key] = 1;
                        break;
                    case ConsoleKey.UpArrow:
                        if (position > 0)
                        {
                            position--;
                        }
                        break;
                        
                    case ConsoleKey.DownArrow:
                        position++;
                        break;
                        

                }
            } while (cki.Key != ConsoleKey.S);

#endif
            PathParser pp = new PathParser();

            string[] aa = getSelectedLines(selection);
            CommandLists cl = pp.ParsePaths(aa);
            
            Console.Clear();
            
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

#if true       
            IEnumerable<XElement> a = root.Elements();

            for (int index = 1; index < cl.GroupSelectCommands.Count; index++)
            {
                var elementsSelector = cl.GroupSelectCommands[index];
                Console.WriteLine("using a " + elementsSelector.Value);
                a = elementsSelector.SelectItems(a);
            }

            Console.Clear();

            foreach (var itemCommand in cl.ItemSelectCommands)
            {
                    Console.Write(itemCommand.Value + ";");
            }
            Console.WriteLine();

            foreach (var xElement in a.Take(10))
            {
                
                foreach (var itemCommand in cl.ItemSelectCommands)
                {
                    XElement xe = itemCommand.SelectItem(xElement);
                    if(xe != null)
                    {
                        Console.Write(xe.Value +";" );
                    }
                    else
                    {
                        Console.Write(";");
                    }
                   
                }
            //    if(aa.Length == 1)
            //    Console.WriteLine(xElement.Name + " -> " + xElement.Value);
                Console.WriteLine();
            }
#endif

        }

        private static string[] getSelectedLines(Dictionary<string, int> selection)
        {
            List<string > listToReturn = new List<string>();
            foreach (var i in selection.Where(x=>x.Value == 1))
            {
                listToReturn.Add(i.Key);
            }
            return listToReturn.ToArray();
        }

        private static void PrintOutView(PathFinder pc, Dictionary<string, int> selection)
        {
            foreach (var car in pc.PathCounter)
            {
                Console.Write("[");
                switch (selection[car.Key])
                {
                    case 0:
                        Console.Write(" ");
                        break;
                    case 1:
                        Console.Write("&");
                        break;
                }
                Console.Write("] " + car.Key + " (" + car.Value + ")" + Environment.NewLine);
            }
        }

        
    }
}
