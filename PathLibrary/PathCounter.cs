using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathLibrary
{
    public class PathCounter : Dictionary<string, int>
    {
        public void Add(string stringToAdd)
        {
            if (ContainsKey(stringToAdd))
            {
                base[stringToAdd]++;
            }
            else
            {
                Add(stringToAdd, 1);
            }
        }
    }
}
