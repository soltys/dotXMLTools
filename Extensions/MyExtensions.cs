using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyExtensions
{
    public static class MyExtensions
    {
        public static string DeleteLastCharacter(this string str)
        {
            return str.Substring(0, str.Length - 1);
        }

        public static bool IsNotEmptyOrNull(this string str)
        {
            if(str != null)
            {
                return true;
            }

            if(str != "")
            {
                return true;
            }

            return false;
        }
    }
}
