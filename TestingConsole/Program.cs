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
    internal class Program
    {
        private static void Main(string[] args)
        {
#if true
            XDocument root = XDocument.Load(@"d:\pawel\xmlText\baza.xml");
            PathCollection pc = new PathCollection(root.Root);
            Dictionary<string, int> selection = new Dictionary<string, int>();

            foreach (var s in pc.PathCounter)
            {
                selection.Add(s.Key, 0);
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

            string[] aa = getSelectedLines(selection);
            Console.Clear();
            XML2List.CSVListMaker csvListMaker = new XML2List.CSVListMaker(root);
            csvListMaker.MakeList(Console.Out, aa);
        }

        private static string[] getSelectedLines(Dictionary<string, int> selection)
        {
            List<string> listToReturn = new List<string>();
            foreach (var i in selection.Where(x => x.Value == 1))
            {
                listToReturn.Add(i.Key);
            }
            return listToReturn.ToArray();
        }

        private static void PrintOutView(PathCollection pc, Dictionary<string, int> selection)
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