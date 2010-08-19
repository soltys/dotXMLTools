﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PathLibrary.Interface;
using XML2List.Interface;

namespace PathLibrary
{
    public static class Extensions
    {
        public static bool IsNotNull(this IItemSelect iis)
        {
            return iis != null? true : false;
        }

        public static bool IsNotNull(this IElementGroupSelect iegs)
        {
            return iegs != null ? true : false;
        }
    }
}
