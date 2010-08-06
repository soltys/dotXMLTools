using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XML2List
{
    public class PathCounter : Dictionary<string, int>
    {
        public const string LastElementSymbol = "+";
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

        public void AddPlusMarker()
        {
            var keyValueToChange = from s in this
                                   where !s.Key.Contains("[")
                                   select s;
            List<KeyValuePair<string,int>> list = new List<KeyValuePair<string, int>>(keyValueToChange.AsEnumerable());
            foreach (var keyValuePair in list)
            {
                Remove(keyValuePair.Key);
                Add(keyValuePair.Key + LastElementSymbol,keyValuePair.Value);
            }
        }
    }
}
