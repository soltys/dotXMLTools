﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XML2List
{
    class PathAttributeValueGroup
    {
        public string Attribute { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Attribute + "=" + Value;
        }
    }
}
