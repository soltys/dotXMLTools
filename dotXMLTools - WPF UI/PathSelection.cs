using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dotXMLToolsWPF
{
    class PathSelection
    {
        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }

            set { _isSelected = value;
                   SelectionChanged(new PathSelection(Path, _isSelected));}
        }

        public string Path { get; set; }

        public delegate void SelectionHandler(PathSelection elementChanged);

        public event SelectionHandler SelectionChanged; 

        public PathSelection(string path, bool isSelected=false)
        {
            Path = path;
            _isSelected =  isSelected;
        }
    }
}
