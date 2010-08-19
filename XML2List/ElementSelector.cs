﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using PathLibrary;
using PathLibrary.Interface;

namespace XML2List
{
    public class ElementSelector:IItemSelect
    {
        private string elementPath;

        public ElementSelector(string elementPath)
        {
            this.elementPath = elementPath;
        }

        public XElement SelectItem(XElement item)
        {
            //TODO change this in something more pretty
            IEnumerable<XElement> collection = PathElementsTools.GetCollectionUsingPath(item,elementPath);

            try
            {
                return collection.First();
            }
            catch (Exception)
            {

                return null;
            }
        }

        

        public string Name
        {
            get { return elementPath; }
        }
    }
}
