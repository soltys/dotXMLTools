using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dotXMLToolsWPF
{
    class PathSelection
    {
        public bool IsSelected { get; set; }
        public string Path { get; set; }

        public PathSelection(string path, bool isSelected=false)
        {
            Path = path;
            IsSelected =  isSelected;
        }
    }
}
